using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD8pdf
    {
        #region Global Variable
        private Hashtable CD8_ht = new Hashtable();
        #endregion
        #region Constant PDF field Variable
        private const string FS_CNNumber = "Text5";
        private const string L_Borough = "Text6";
        private const string L_Block = "Text7";
        private const string L_Lot = "Text8";
        private const string L_Bin = "Text9";
        private const string L_HouseNo = "Text10";
        private const string L_StreetName = "Text11";
        private const string L_Apt_condo_no = "Text12";
        private const string L_SpecialPlaceName = "Text13";
        private const string L_Floor = "Text14";
        private const string App_LastName = "Text15";
        private const string App_FirstName = "Text16";
        private const string App_MI = "Text17";
        private const string App_BusinessName = "Text18";
        private const string App_Address = "Text19";
        private const string App_City = "Text20";
        private const string App_State = "Text21";
        private const string App_Zip = "Text22";
        private const string App_Telephone = "Text23";
        private const string App_Fax = "Text24";
        private const string App_LicNo = "Text30";
        private const string CI_CDNo1 = "Text31";
        private const string CI_Manufacturer1 = "Text32";
        private const string CI_Model1 = "Text33";
        private const string CI_BoomLength1 = "Text34";
        private const string CI_JibLenght1 = "Text35";
        private const string CI_Total1 = "Text36";
        private const string CI_CDNo2 = "Text37";
        private const string CI_Manufacturer2 = "Text38";
        private const string CI_Model2 = "Text39";
        private const string CI_BoomLength2 = "Text40";
        private const string CI_JibLenght2 = "Text41";
        private const string CI_Total2 = "Text42";
        private const string CI_CDNo3 = "Text43";
        private const string CI_Manufacturer3 = "Text44";
        private const string CI_Model3 = "Text45";
        private const string CI_BoomLength3 = "Text46";
        private const string CI_JibLenght3 = "Text47";
        private const string CI_Total3 = "Text48";
        private const string CI_CDNo4 = "Text49";
        private const string CI_Manufacturer4 = "Text50";
        private const string CI_Model4 = "Text51";
        private const string CI_BoomLength4 = "Text52";
        private const string CI_JibLenght4 = "Text53";
        private const string CI_Total4 = "Text54";
        private const string CI_CDNo5 = "Text59";
        private const string CI_Manufacturer5 = "Text60";
        private const string CI_Model5 = "Text61";
        private const string CI_BoomLength5 = "Text62";
        private const string CI_JibLenght5 = "Text63";
        private const string CI_Total5 = "Text64";
        private const string CI_CDNo6 = "Text65";
        private const string CI_Manufacturer6 = "Text66";
        private const string CI_Model6 = "Text67";
        private const string CI_BoomLength6 = "Text68";
        private const string CI_JibLenght6 = "Text69";
        private const string CI_Total6 = "Text70";
        #endregion
  
        #region Properties
        public string FillingStatus_CNNumber
        {
            get
            {
                return CD8_ht[FS_CNNumber].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(FS_CNNumber))
                {
                    CD8_ht[FS_CNNumber] = value;
                }
                else
                {
                    CD8_ht.Add(FS_CNNumber, value);
                }
            }
        }
        public string Location_Borough
        {
            get
            {
                return CD8_ht[L_Borough].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_Borough))
                {
                    CD8_ht[L_Borough] = value;
                }
                else
                {
                    CD8_ht.Add(L_Borough, value);
                }
            }
        }
        public string Location_Block
        {
            get
            {
                return CD8_ht[L_Block].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_Block))
                {
                    CD8_ht[L_Block] = value;
                }
                else
                {
                    CD8_ht.Add(L_Block, value);
                }
            }
        }
        public string Location_Lot
        {
            get
            {
                return CD8_ht[L_Lot].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_Lot))
                {
                    CD8_ht[L_Lot] = value;
                }
                else
                {
                    CD8_ht.Add(L_Lot, value);
                }
            }
        }
        public string Location_Bin
        {
            get
            {
                return CD8_ht[L_Bin].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_Bin))
                {
                    CD8_ht[L_Bin] = value;
                }
                else
                {
                    CD8_ht.Add(L_Bin, value);
                }
            }
        }
        public string Location_HouseNo
        {
            get
            {
                return CD8_ht[L_HouseNo].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_HouseNo))
                {
                    CD8_ht[L_HouseNo] = value;
                }
                else
                {
                    CD8_ht.Add(L_HouseNo, value);
                }
            }
        }
        public string Location_StreetName
        {
            get
            {
                return CD8_ht[L_StreetName].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_StreetName))
                {
                    CD8_ht[L_StreetName] = value;
                }
                else
                {
                    CD8_ht.Add(L_StreetName, value);
                }
            }
        }
        public string Location_AptCondoNo
        {
            get
            {
                return CD8_ht[L_Apt_condo_no].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_Apt_condo_no))
                {
                    CD8_ht[L_Apt_condo_no] = value;
                }
                else
                {
                    CD8_ht.Add(L_Apt_condo_no, value);
                }
            }
        }
        public string Location_SpecialPlaceName
        {
            get
            {
                return CD8_ht[L_SpecialPlaceName].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_SpecialPlaceName))
                {
                    CD8_ht[L_SpecialPlaceName] = value;
                }
                else
                {
                    CD8_ht.Add(L_SpecialPlaceName, value);
                }
            }
        }
        public string Location_Floor
        {
            get
            {
                return CD8_ht[L_Floor].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(L_Floor))
                {
                    CD8_ht[L_Floor] = value;
                }
                else
                {
                    CD8_ht.Add(L_Floor, value);
                }
            }
        }
        public string Applicant_LastName
        {
            get
            {
                return CD8_ht[App_LastName].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_LastName))
                {
                    CD8_ht[App_LastName] = value;
                }
                else
                {
                    CD8_ht.Add(App_LastName, value);
                }
            }
        }
        public string Applicant_FirstName
        {
            get
            {
                return CD8_ht[App_FirstName].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_FirstName))
                {
                    CD8_ht[App_FirstName] = value;
                }
                else
                {
                    CD8_ht.Add(App_FirstName, value);
                }
            }
        }
        public string Applicant_MI
        {
            get
            {
                return CD8_ht[App_MI].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_MI))
                {
                    CD8_ht[App_MI] = value;
                }
                else
                {
                    CD8_ht.Add(App_MI, value);
                }
            }
        }
        public string Applicant_BusinessName
        {
            get
            {
                return CD8_ht[App_BusinessName].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_BusinessName))
                {
                    CD8_ht[App_BusinessName] = value;
                }
                else
                {
                    CD8_ht.Add(App_BusinessName, value);
                }
            }
        }
        public string Applicant_Address
        {
            get
            {
                return CD8_ht[App_Address].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_Address))
                {
                    CD8_ht[App_Address] = value;
                }
                else
                {
                    CD8_ht.Add(App_Address, value);
                }
            }
        }
        public string Applicant_City
        {
            get
            {
                return CD8_ht[App_City].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_City))
                {
                    CD8_ht[App_City] = value;
                }
                else
                {
                    CD8_ht.Add(App_City, value);
                }
            }
        }
        public string Applicant_State
        {
            get
            {
                return CD8_ht[App_State].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_State))
                {
                    CD8_ht[App_State] = value;
                }
                else
                {
                    CD8_ht.Add(App_State, value);
                }
            }
        }
        public string Applicant_TelephoneNo
        {
            get
            {
                return CD8_ht[App_Telephone].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_Telephone))
                {
                    CD8_ht[App_Telephone] = value;
                }
                else
                {
                    CD8_ht.Add(App_Telephone, value);
                }
            }
        }
        public string Applicant_Zip
        {
            get
            {
                return CD8_ht[App_Zip].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_Zip))
                {
                    CD8_ht[App_Zip] = value;
                }
                else
                {
                    CD8_ht.Add(App_Zip, value);
                }
            }
        }
        public string Applicant_Fax
        {
            get
            {
                return CD8_ht[App_Fax].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_Fax))
                {
                    CD8_ht[App_Fax] = value;
                }
                else
                {
                    CD8_ht.Add(App_Fax, value);
                }
            }
        }
        public string Applicant_LICNo
        {
            get
            {
                return CD8_ht[App_LicNo].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(App_LicNo))
                {
                    CD8_ht[App_LicNo] = value;
                }
                else
                {
                    CD8_ht.Add(App_LicNo, value);
                }
            }
        }
        public string CraneInformation_CDNo1
        {
            get
            {
                return CD8_ht[CI_CDNo1].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_CDNo1))
                {
                    CD8_ht[CI_CDNo1] = value;
                }
                else
                {
                    CD8_ht.Add(CI_CDNo1, value);
                }
            }
        }
        public string CraneInformation_Manufacturer1
        {
            get
            {
                return CD8_ht[CI_Manufacturer1].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Manufacturer1))
                {
                    CD8_ht[CI_Manufacturer1] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Manufacturer1, value);
                }
            }
        }
        public string CraneInformation_Model1
        {
            get
            {
                return CD8_ht[CI_Model1].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Model1))
                {
                    CD8_ht[CI_Model1] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Model1, value);
                }
            }
        }
        public string CraneInformation_BoomLength1
        {
            get
            {
                return CD8_ht[CI_BoomLength1].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_BoomLength1))
                {
                    CD8_ht[CI_BoomLength1] = value;
                }
                else
                {
                    CD8_ht.Add(CI_BoomLength1, value);
                }
            }
        }
        public string CraneInformation_JibLenght1
        {
            get
            {
                return CD8_ht[CI_JibLenght1].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_JibLenght1))
                {
                    CD8_ht[CI_JibLenght1] = value;
                }
                else
                {
                    CD8_ht.Add(CI_JibLenght1, value);
                }
            }
        }
        public string CraneInformation_Total1
        {
            get
            {
                return CD8_ht[CI_Total1].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Total1))
                {
                    CD8_ht[CI_Total1] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Total1, value);
                }
            }
        }

        //CI_2

        public string CraneInformation_CDNo2
        {
            get
            {
                return CD8_ht[CI_CDNo2].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_CDNo2))
                {
                    CD8_ht[CI_CDNo2] = value;
                }
                else
                {
                    CD8_ht.Add(CI_CDNo2, value);
                }
            }
        }
        public string CraneInformation_Manufacturer2
        {
            get
            {
                return CD8_ht[CI_Manufacturer2].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Manufacturer2))
                {
                    CD8_ht[CI_Manufacturer2] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Manufacturer2, value);
                }
            }
        }
        public string CraneInformation_Model2
        {
            get
            {
                return CD8_ht[CI_Model2].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Model2))
                {
                    CD8_ht[CI_Model2] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Model2, value);
                }
            }
        }
        public string CraneInformation_BoomLength2
        {
            get
            {
                return CD8_ht[CI_BoomLength2].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_BoomLength2))
                {
                    CD8_ht[CI_BoomLength2] = value;
                }
                else
                {
                    CD8_ht.Add(CI_BoomLength2, value);
                }
            }
        }
        public string CraneInformation_JibLenght2
        {
            get
            {
                return CD8_ht[CI_JibLenght2].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_JibLenght2))
                {
                    CD8_ht[CI_JibLenght2] = value;
                }
                else
                {
                    CD8_ht.Add(CI_JibLenght2, value);
                }
            }
        }
        public string CraneInformation_Total2
        {
            get
            {
                return CD8_ht[CI_Total2].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Total2))
                {
                    CD8_ht[CI_Total2] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Total2, value);
                }
            }
        }

        //CI_3

        public string CraneInformation_CDNo3
        {
            get
            {
                return CD8_ht[CI_CDNo3].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_CDNo3))
                {
                    CD8_ht[CI_CDNo3] = value;
                }
                else
                {
                    CD8_ht.Add(CI_CDNo3, value);
                }
            }
        }
        public string CraneInformation_Manufacturer3
        {
            get
            {
                return CD8_ht[CI_Manufacturer3].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Manufacturer3))
                {
                    CD8_ht[CI_Manufacturer3] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Manufacturer3, value);
                }
            }
        }
        public string CraneInformation_Model3
        {
            get
            {
                return CD8_ht[CI_Model3].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Model3))
                {
                    CD8_ht[CI_Model3] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Model3, value);
                }
            }
        }
        public string CraneInformation_BoomLength3
        {
            get
            {
                return CD8_ht[CI_BoomLength3].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_BoomLength3))
                {
                    CD8_ht[CI_BoomLength3] = value;
                }
                else
                {
                    CD8_ht.Add(CI_BoomLength3, value);
                }
            }
        }
        public string CraneInformation_JibLenght3
        {
            get
            {
                return CD8_ht[CI_JibLenght3].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_JibLenght3))
                {
                    CD8_ht[CI_JibLenght3] = value;
                }
                else
                {
                    CD8_ht.Add(CI_JibLenght3, value);
                }
            }
        }
        public string CraneInformation_Total3
        {
            get
            {
                return CD8_ht[CI_Total3].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Total3))
                {
                    CD8_ht[CI_Total3] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Total3, value);
                }
            }
        }

        //CI_4

        public string CraneInformation_CDNo4
        {
            get
            {
                return CD8_ht[CI_CDNo4].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_CDNo4))
                {
                    CD8_ht[CI_CDNo4] = value;
                }
                else
                {
                    CD8_ht.Add(CI_CDNo4, value);
                }
            }
        }
        public string CraneInformation_Manufacturer4
        {
            get
            {
                return CD8_ht[CI_Manufacturer4].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Manufacturer4))
                {
                    CD8_ht[CI_Manufacturer4] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Manufacturer4, value);
                }
            }
        }
        public string CraneInformation_Model4
        {
            get
            {
                return CD8_ht[CI_Model4].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Model4))
                {
                    CD8_ht[CI_Model4] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Model4, value);
                }
            }
        }
        public string CraneInformation_BoomLength4
        {
            get
            {
                return CD8_ht[CI_BoomLength4].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_BoomLength4))
                {
                    CD8_ht[CI_BoomLength4] = value;
                }
                else
                {
                    CD8_ht.Add(CI_BoomLength4, value);
                }
            }
        }
        public string CraneInformation_JibLenght4
        {
            get
            {
                return CD8_ht[CI_JibLenght4].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_JibLenght4))
                {
                    CD8_ht[CI_JibLenght4] = value;
                }
                else
                {
                    CD8_ht.Add(CI_JibLenght4, value);
                }
            }
        }
        public string CraneInformation_Total4
        {
            get
            {
                return CD8_ht[CI_Total4].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Total4))
                {
                    CD8_ht[CI_Total4] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Total4, value);
                }
            }
        }

        //CI_5

        public string CraneInformation_CDNo5
        {
            get
            {
                return CD8_ht[CI_CDNo5].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_CDNo5))
                {
                    CD8_ht[CI_CDNo5] = value;
                }
                else
                {
                    CD8_ht.Add(CI_CDNo5, value);
                }
            }
        }
        public string CraneInformation_Manufacturer5
        {
            get
            {
                return CD8_ht[CI_Manufacturer5].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Manufacturer5))
                {
                    CD8_ht[CI_Manufacturer5] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Manufacturer5, value);
                }
            }
        }
        public string CraneInformation_Model5
        {
            get
            {
                return CD8_ht[CI_Model5].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Model5))
                {
                    CD8_ht[CI_Model5] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Model5, value);
                }
            }
        }
        public string CraneInformation_BoomLength5
        {
            get
            {
                return CD8_ht[CI_BoomLength5].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_BoomLength5))
                {
                    CD8_ht[CI_BoomLength5] = value;
                }
                else
                {
                    CD8_ht.Add(CI_BoomLength5, value);
                }
            }
        }
        public string CraneInformation_JibLenght5
        {
            get
            {
                return CD8_ht[CI_JibLenght5].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_JibLenght5))
                {
                    CD8_ht[CI_JibLenght5] = value;
                }
                else
                {
                    CD8_ht.Add(CI_JibLenght5, value);
                }
            }
        }
        public string CraneInformation_Total5
        {
            get
            {
                return CD8_ht[CI_Total5].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Total5))
                {
                    CD8_ht[CI_Total5] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Total5, value);
                }
            }
        }

        //CI_6

        public string CraneInformation_CDNo6
        {
            get
            {
                return CD8_ht[CI_CDNo6].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_CDNo6))
                {
                    CD8_ht[CI_CDNo6] = value;
                }
                else
                {
                    CD8_ht.Add(CI_CDNo6, value);
                }
            }
        }
        public string CraneInformation_Manufacturer6
        {
            get
            {
                return CD8_ht[CI_Manufacturer6].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Manufacturer6))
                {
                    CD8_ht[CI_Manufacturer6] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Manufacturer6, value);
                }
            }
        }
        public string CraneInformation_Model6
        {
            get
            {
                return CD8_ht[CI_Model6].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Model6))
                {
                    CD8_ht[CI_Model6] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Model6, value);
                }
            }
        }
        public string CraneInformation_BoomLength6
        {
            get
            {
                return CD8_ht[CI_BoomLength6].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_BoomLength6))
                {
                    CD8_ht[CI_BoomLength6] = value;
                }
                else
                {
                    CD8_ht.Add(CI_BoomLength6, value);
                }
            }
        }
        public string CraneInformation_JibLenght6
        {
            get
            {
                return CD8_ht[CI_JibLenght6].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_JibLenght6))
                {
                    CD8_ht[CI_JibLenght6] = value;
                }
                else
                {
                    CD8_ht.Add(CI_JibLenght6, value);
                }
            }
        }
        public string CraneInformation_Total6
        {
            get
            {
                return CD8_ht[CI_Total6].ToString();
            }
            set
            {
                if (CD8_ht.ContainsKey(CI_Total6))
                {
                    CD8_ht[CI_Total6] = value;
                }
                else
                {
                    CD8_ht.Add(CI_Total6, value);
                }
            }
        }

        #endregion

        public void FillCD8pdfForm(string Path)
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
                    //Declare form field name colletion from pdf file
                    AcroFields AF = pdfStm.AcroFields;
                    foreach (DictionaryEntry Element in CD8_ht)
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
