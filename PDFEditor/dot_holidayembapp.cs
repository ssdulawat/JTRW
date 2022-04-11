using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_holidayembapp
    {
        #region Global Variable
        private Hashtable dot_holidayembapp_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string AID = "Permittee ID";
        private const string Permit_Name = "Permittee Name";
        private const string Address = "Address";
        private const string T1 = "Area Code";
        private const string T2 = "Tel 2";
        private const string T3 = "Tel 3";
        private const string Email = "Email";
        private const string MN = "MN";
        private const string BK = "BK";
        private const string QN = "QN";
        private const string BX = "BX";
        private const string SI = "SI";
        private const string O1 = "Engineering Control";
        private const string O2 = "2 Digit Year";
        private const string O3 = "File Number";
        private const string B_HouseNo = "House No";
        private const string B_OnStreet = "On Street";
        private const string B_StreetWorkOn = "Street Work On, If Different From Above";
        private const string B_CrossStreet1 = "Cross Street #1";
        private const string B_CrossStreet2 = "Cross Street #2";
        private const string B_Purpose = "Purpose";
        private const string WSM = "Work Start Month";
        private const string WSD = "Work Start Day";
        private const string WSY = "Work Start Year";
        private const string WEM = "Work End Month";
        private const string WED = "Work End Day";
        private const string WEY = "Work End Year";
        private const string Reason_For = "Reason For Request";
        private const string Contract_Name = "Contact Person Name";
        private const string Area_Code2 = "Area Code 2";
        private const string Tel22 = "Tel 22";
        private const string Tel32 = "Tel 32";
        private const string Contract_Person_Email = "Contact Person Email Address";
        private const string Submitted_By = "Submitted by";
        private const string Month = "Month";
        private const string Day = "Day";
        private const string Year = "Year";
        #endregion
        #region Properties
        public string AID_Pro
        {
            get
            {
                return dot_holidayembapp_ht[AID].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(AID))
                    dot_holidayembapp_ht[AID] = value;
                else
                    dot_holidayembapp_ht.Add(AID, value);
            }
        }
        public string Permit_Name_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Permit_Name].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Permit_Name))
                    dot_holidayembapp_ht[Permit_Name] = value;
                else
                    dot_holidayembapp_ht.Add(Permit_Name, value);
            }
        }
        public string Address_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Address].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Address))
                    dot_holidayembapp_ht[Address] = value;
                else
                    dot_holidayembapp_ht.Add(Address, value);
            }
        }
        public string T1_Pro
        {
            get
            {
                return dot_holidayembapp_ht[T1].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(T1))
                    dot_holidayembapp_ht[T1] = value;
                else
                    dot_holidayembapp_ht.Add(T1, value);
            }
        }
        public string T2_Pro
        {
            get
            {
                return dot_holidayembapp_ht[T2].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(T2))
                    dot_holidayembapp_ht[T2] = value;
                else
                    dot_holidayembapp_ht.Add(T2, value);
            }
        }
        public string T3_Pro
        {
            get
            {
                return dot_holidayembapp_ht[T3].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(T3))
                    dot_holidayembapp_ht[T3] = value;
                else
                    dot_holidayembapp_ht.Add(T3, value);
            }
        }
        public string Email_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Email].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Email))
                    dot_holidayembapp_ht[Email] = value;
                else
                    dot_holidayembapp_ht.Add(Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_holidayembapp_ht[MN].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(MN))
                    dot_holidayembapp_ht[MN] = value;
                else
                    dot_holidayembapp_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_holidayembapp_ht[BK].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(BK))
                    dot_holidayembapp_ht[BK] = value;
                else
                    dot_holidayembapp_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_holidayembapp_ht[QN].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(QN))
                    dot_holidayembapp_ht[QN] = value;
                else
                    dot_holidayembapp_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_holidayembapp_ht[BX].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(BX))
                    dot_holidayembapp_ht[BX] = value;
                else
                    dot_holidayembapp_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_holidayembapp_ht[SI].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(SI))
                    dot_holidayembapp_ht[SI] = value;
                else
                    dot_holidayembapp_ht.Add(SI, value);
            }
        }
        public string O1_Pro
        {
            get
            {
                return dot_holidayembapp_ht[O1].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(O1))
                    dot_holidayembapp_ht[O1] = value;
                else
                    dot_holidayembapp_ht.Add(O1, value);
            }
        }
        public string O2_Pro
        {
            get
            {
                return dot_holidayembapp_ht[O2].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(O2))
                    dot_holidayembapp_ht[O2] = value;
                else
                    dot_holidayembapp_ht.Add(O2, value);
            }
        }
        public string O3_Pro
        {
            get
            {
                return dot_holidayembapp_ht[O3].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(O3))
                    dot_holidayembapp_ht[O3] = value;
                else
                    dot_holidayembapp_ht.Add(O3, value);
            }
        }
        public string B_HouseNo_Pro
        {
            get
            {
                return dot_holidayembapp_ht[B_HouseNo].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(B_HouseNo))
                    dot_holidayembapp_ht[B_HouseNo] = value;
                else
                    dot_holidayembapp_ht.Add(B_HouseNo, value);
            }
        }
        public string B_OnStreet_Pro
        {
            get
            {
                return dot_holidayembapp_ht[B_OnStreet].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(B_OnStreet))
                    dot_holidayembapp_ht[B_OnStreet] = value;
                else
                    dot_holidayembapp_ht.Add(B_OnStreet, value);
            }
        }
        public string B_StreetWorkOn_Pro
        {
            get
            {
                return dot_holidayembapp_ht[B_StreetWorkOn].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(B_StreetWorkOn))
                    dot_holidayembapp_ht[B_StreetWorkOn] = value;
                else
                    dot_holidayembapp_ht.Add(B_StreetWorkOn, value);
            }
        }
        public string B_CrossStreet1_Pro
        {
            get
            {
                return dot_holidayembapp_ht[B_CrossStreet1].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(B_CrossStreet1))
                    dot_holidayembapp_ht[B_CrossStreet1] = value;
                else
                    dot_holidayembapp_ht.Add(B_CrossStreet1, value);
            }
        }
        public string B_CrossStreet2_Pro
        {
            get
            {
                return dot_holidayembapp_ht[B_CrossStreet2].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(B_CrossStreet2))
                    dot_holidayembapp_ht[B_CrossStreet2] = value;
                else
                    dot_holidayembapp_ht.Add(B_CrossStreet2, value);
            }
        }
        public string B_Purpose_Pro
        {
            get
            {
                return dot_holidayembapp_ht[B_Purpose].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(B_Purpose))
                    dot_holidayembapp_ht[B_Purpose] = value;
                else
                    dot_holidayembapp_ht.Add(B_Purpose, value);
            }
        }
        public string WSM_Pro
        {
            get
            {
                return dot_holidayembapp_ht[WSM].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(WSM))
                    dot_holidayembapp_ht[WSM] = value;
                else
                    dot_holidayembapp_ht.Add(WSM, value);
            }
        }
        public string WSD_Pro
        {
            get
            {
                return dot_holidayembapp_ht[WSD].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(WSD))
                    dot_holidayembapp_ht[WSD] = value;
                else
                    dot_holidayembapp_ht.Add(WSD, value);
            }
        }
        public string WSY_Pro
        {
            get
            {
                return dot_holidayembapp_ht[WSY].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(WSY))
                    dot_holidayembapp_ht[WSY] = value;
                else
                    dot_holidayembapp_ht.Add(WSY, value);
            }
        }
        public string WEM_Pro
        {
            get
            {
                return dot_holidayembapp_ht[WEM].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(WEM))
                    dot_holidayembapp_ht[WEM] = value;
                else
                    dot_holidayembapp_ht.Add(WEM, value);
            }
        }
        public string WED_Pro
        {
            get
            {
                return dot_holidayembapp_ht[WED].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(WED))
                    dot_holidayembapp_ht[WED] = value;
                else
                    dot_holidayembapp_ht.Add(WED, value);
            }
        }
        public string WEY_Pro
        {
            get
            {
                return dot_holidayembapp_ht[WEY].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(WEY))
                    dot_holidayembapp_ht[WEY] = value;
                else
                    dot_holidayembapp_ht.Add(WEY, value);
            }
        }
        public string Reason_For_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Reason_For].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Reason_For))
                    dot_holidayembapp_ht[Reason_For] = value;
                else
                    dot_holidayembapp_ht.Add(Reason_For, value);
            }
        }
        public string Contract_Name_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Contract_Name].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Contract_Name))
                    dot_holidayembapp_ht[Contract_Name] = value;
                else
                    dot_holidayembapp_ht.Add(Contract_Name, value);
            }
        }
        public string Area_Code2_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Area_Code2].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Area_Code2))
                    dot_holidayembapp_ht[Area_Code2] = value;
                else
                    dot_holidayembapp_ht.Add(Area_Code2, value);
            }
        }
        public string Tel22_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Tel22].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Tel22))
                    dot_holidayembapp_ht[Tel22] = value;
                else
                    dot_holidayembapp_ht.Add(Tel22, value);
            }
        }
        public string Tel32_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Tel32].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Tel32))
                    dot_holidayembapp_ht[Tel32] = value;
                else
                    dot_holidayembapp_ht.Add(Tel32, value);
            }
        }
        public string Contract_Person_Email_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Contract_Person_Email].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Contract_Person_Email))
                    dot_holidayembapp_ht[Contract_Person_Email] = value;
                else
                    dot_holidayembapp_ht.Add(Contract_Person_Email, value);
            }
        }
        public string Submitted_By_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Submitted_By].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Submitted_By))
                    dot_holidayembapp_ht[Submitted_By] = value;
                else
                    dot_holidayembapp_ht.Add(Submitted_By, value);
            }
        }
        public string Month_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Month].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Month))
                    dot_holidayembapp_ht[Month] = value;
                else
                    dot_holidayembapp_ht.Add(Month, value);
            }
        }
        public string Day_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Day].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Day))
                    dot_holidayembapp_ht[Day] = value;
                else
                    dot_holidayembapp_ht.Add(Day, value);
            }
        }
        public string Year_Pro
        {
            get
            {
                return dot_holidayembapp_ht[Year].ToString();
            }
            set
            {
                if (dot_holidayembapp_ht.ContainsKey(Year))
                    dot_holidayembapp_ht[Year] = value;
                else
                    dot_holidayembapp_ht.Add(Year, value);
            }
        }
        #endregion
        public void FillD_HolidaypdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_holidayembapp_ht)
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