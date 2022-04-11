using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_roadway_closure_app
    {
        #region Global Variable
        private Hashtable dot_roadway_closure_app_ht = new Hashtable();
        #endregion
        #region Constant
        private const string AID = "Permittee ID";
        private const string A_PermittedName = "Permittee Name";
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
        private const string B_Sildewalk = "Sidewalk";
        private const string DOB = "DOB#";
        private const string B_HouseNo = "House No";
        private const string B_OnStreet = "On Street";
        private const string B_StreetWorkOn = "Street Work On, If Different From Above";
        private const string B_CrossStreet1 = "Cross Street #1";
        private const string B_CrossStreet2 = "Cross Street #2";
        private const string B_Purpose = "Purpose";
        private const string D1 = "Work Start Month";
        private const string D2 = "Work Start Day";
        private const string D3 = "Work Start Year";
        private const string D4 = "Work End Month";
        private const string D5 = "Work End Day";
        private const string D6 = "Work End Year";
        private const string OS = "OS";
        private const string CS1 = "CS 1";
        private const string CS2 = "CS 2";
        private const string DIM_1 = "Dim 1";
        private const string DIM_2 = "Dim 2";
        private const string DIM_3 = "Dim 3";
        private const string DIM_4 = "Dim 4";
        private const string DIM_5 = "Dim 5";
        private const string North1 = "North 1";
        private const string North2 = "North 2";
        private const string North3 = "North 3";
        private const string North4 = "North 4";
        private const string SubmittedBy = "Submitted by";
        private const string Area_Code = "Area Code 2";
        private const string Tel22 = "Tel 22";
        private const string Tel23 = "Tel 23";
        private const string D7 = "Month";
        private const string D8 = "Day";
        private const string D9 = "Year";

        #endregion
        #region Properties
        public string AID_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[AID].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(AID))
                    dot_roadway_closure_app_ht[AID] = value;
                else
                    dot_roadway_closure_app_ht.Add(AID, value);
            }
        }
        public string A_PermittedName_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[A_PermittedName].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(A_PermittedName))
                    dot_roadway_closure_app_ht[A_PermittedName] = value;
                else
                    dot_roadway_closure_app_ht.Add(A_PermittedName, value);
            }
        }
        public string A_Address_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[A_Address].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(A_Address))
                    dot_roadway_closure_app_ht[A_Address] = value;
                else
                    dot_roadway_closure_app_ht.Add(A_Address, value);
            }
        }
        public string T1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[T1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(T1))
                    dot_roadway_closure_app_ht[T1] = value;
                else
                    dot_roadway_closure_app_ht.Add(T1, value);
            }
        }
        public string T2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[T2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(T2))
                    dot_roadway_closure_app_ht[T2] = value;
                else
                    dot_roadway_closure_app_ht.Add(T2, value);
            }
        }
        public string T3_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[T3].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(T3))
                    dot_roadway_closure_app_ht[T3] = value;
                else
                    dot_roadway_closure_app_ht.Add(T3, value);
            }
        }
        public string A_Email_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[A_Email].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(A_Email))
                    dot_roadway_closure_app_ht[A_Email] = value;
                else
                    dot_roadway_closure_app_ht.Add(A_Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[MN].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(MN))
                    dot_roadway_closure_app_ht[MN] = value;
                else
                    dot_roadway_closure_app_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[BK].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(BK))
                    dot_roadway_closure_app_ht[BK] = value;
                else
                    dot_roadway_closure_app_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[QN].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(QN))
                    dot_roadway_closure_app_ht[QN] = value;
                else
                    dot_roadway_closure_app_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[BX].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(BX))
                    dot_roadway_closure_app_ht[BX] = value;
                else
                    dot_roadway_closure_app_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[SI].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(SI))
                    dot_roadway_closure_app_ht[SI] = value;
                else
                    dot_roadway_closure_app_ht.Add(SI, value);
            }
        }
        public string O1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[O1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(O1))
                    dot_roadway_closure_app_ht[O1] = value;
                else
                    dot_roadway_closure_app_ht.Add(O1, value);
            }
        }
        public string O2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[O2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(O2))
                    dot_roadway_closure_app_ht[O2] = value;
                else
                    dot_roadway_closure_app_ht.Add(O2, value);
            }
        }
        public string O3_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[O3].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(O3))
                    dot_roadway_closure_app_ht[O3] = value;
                else
                    dot_roadway_closure_app_ht.Add(O3, value);
            }
        }
        public string B_Roadway_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_Roadway].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_Roadway))
                    dot_roadway_closure_app_ht[B_Roadway] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_Roadway, value);
            }
        }
        public string B_Sildewalk_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_Sildewalk].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_Sildewalk))
                    dot_roadway_closure_app_ht[B_Sildewalk] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_Sildewalk, value);
            }
        }
        public string DOB_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[DOB].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(DOB))
                    dot_roadway_closure_app_ht[DOB] = value;
                else
                    dot_roadway_closure_app_ht.Add(DOB, value);
            }
        }
        public string B_HouseNo_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_HouseNo].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_HouseNo))
                    dot_roadway_closure_app_ht[B_HouseNo] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_HouseNo, value);
            }
        }
        public string B_OnStreet_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_OnStreet].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_OnStreet))
                    dot_roadway_closure_app_ht[B_OnStreet] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_OnStreet, value);
            }
        }
        public string B_StreetWorkOn_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_StreetWorkOn].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_StreetWorkOn))
                    dot_roadway_closure_app_ht[B_StreetWorkOn] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_StreetWorkOn, value);
            }
        }
        public string B_CrossStreet1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_CrossStreet1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_CrossStreet1))
                    dot_roadway_closure_app_ht[B_CrossStreet1] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_CrossStreet1, value);
            }
        }
        public string B_CrossStreet2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_CrossStreet2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_CrossStreet2))
                    dot_roadway_closure_app_ht[B_CrossStreet2] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_CrossStreet2, value);
            }
        }
        public string B_Purpose_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[B_Purpose].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(B_Purpose))
                    dot_roadway_closure_app_ht[B_Purpose] = value;
                else
                    dot_roadway_closure_app_ht.Add(B_Purpose, value);
            }
        }
        public string D1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D1))
                    dot_roadway_closure_app_ht[D1] = value;
                else
                    dot_roadway_closure_app_ht.Add(D1, value);
            }
        }
        public string D2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D2))
                    dot_roadway_closure_app_ht[D2] = value;
                else
                    dot_roadway_closure_app_ht.Add(D2, value);
            }
        }
        public string D3_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D3].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D3))
                    dot_roadway_closure_app_ht[D3] = value;
                else
                    dot_roadway_closure_app_ht.Add(D3, value);
            }
        }
        public string D4_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D4].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D4))
                    dot_roadway_closure_app_ht[D4] = value;
                else
                    dot_roadway_closure_app_ht.Add(D4, value);
            }
        }
        public string D5_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D5].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D5))
                    dot_roadway_closure_app_ht[D5] = value;
                else
                    dot_roadway_closure_app_ht.Add(D5, value);
            }
        }
        public string D6_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D6].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D6))
                    dot_roadway_closure_app_ht[D6] = value;
                else
                    dot_roadway_closure_app_ht.Add(D6, value);
            }
        }
        public string OS_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[OS].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(OS))
                    dot_roadway_closure_app_ht[OS] = value;
                else
                    dot_roadway_closure_app_ht.Add(OS, value);
            }
        }
        public string CS1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[CS1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(CS1))
                    dot_roadway_closure_app_ht[CS1] = value;
                else
                    dot_roadway_closure_app_ht.Add(CS1, value);
            }
        }
        public string CS2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[CS2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(CS2))
                    dot_roadway_closure_app_ht[CS2] = value;
                else
                    dot_roadway_closure_app_ht.Add(CS2, value);
            }
        }
        public string DIM_1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[DIM_1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(DIM_1))
                    dot_roadway_closure_app_ht[DIM_1] = value;
                else
                    dot_roadway_closure_app_ht.Add(DIM_1, value);
            }
        }
        public string DIM_2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[DIM_2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(DIM_2))
                    dot_roadway_closure_app_ht[DIM_2] = value;
                else
                    dot_roadway_closure_app_ht.Add(DIM_2, value);
            }
        }
        public string DIM_3_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[DIM_3].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(DIM_3))
                    dot_roadway_closure_app_ht[DIM_3] = value;
                else
                    dot_roadway_closure_app_ht.Add(DIM_3, value);
            }
        }
        public string DIM_4_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[DIM_4].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(DIM_4))
                    dot_roadway_closure_app_ht[DIM_4] = value;
                else
                    dot_roadway_closure_app_ht.Add(DIM_4, value);
            }
        }
        public string DIM_5_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[DIM_5].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(DIM_5))
                    dot_roadway_closure_app_ht[DIM_5] = value;
                else
                    dot_roadway_closure_app_ht.Add(DIM_5, value);
            }
        }
        public string North1_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[North1].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(North1))
                    dot_roadway_closure_app_ht[North1] = value;
                else
                    dot_roadway_closure_app_ht.Add(North1, value);
            }
        }
        public string North2_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[North2].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(North2))
                    dot_roadway_closure_app_ht[North2] = value;
                else
                    dot_roadway_closure_app_ht.Add(North2, value);
            }
        }
        public string North3_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[North3].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(North3))
                    dot_roadway_closure_app_ht[North3] = value;
                else
                    dot_roadway_closure_app_ht.Add(North3, value);
            }
        }
        public string North4_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[North4].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(North4))
                    dot_roadway_closure_app_ht[North4] = value;
                else
                    dot_roadway_closure_app_ht.Add(North4, value);
            }
        }
        public string SubmittedBy_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[SubmittedBy].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(SubmittedBy))
                    dot_roadway_closure_app_ht[SubmittedBy] = value;
                else
                    dot_roadway_closure_app_ht.Add(SubmittedBy, value);
            }
        }
        public string Area_Code_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[Area_Code].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(Area_Code))
                    dot_roadway_closure_app_ht[Area_Code] = value;
                else
                    dot_roadway_closure_app_ht.Add(Area_Code, value);
            }
        }
        public string Tel22_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[Tel22].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(Tel22))
                    dot_roadway_closure_app_ht[Tel22] = value;
                else
                    dot_roadway_closure_app_ht.Add(Tel22, value);
            }
        }
        public string Tel23_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[Tel23].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(Tel23))
                    dot_roadway_closure_app_ht[Tel23] = value;
                else
                    dot_roadway_closure_app_ht.Add(Tel23, value);
            }
        }
        public string D7_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D7].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D7))
                    dot_roadway_closure_app_ht[D7] = value;
                else
                    dot_roadway_closure_app_ht.Add(D7, value);
            }
        }
        public string D8_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D8].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D8))
                    dot_roadway_closure_app_ht[D8] = value;
                else
                    dot_roadway_closure_app_ht.Add(D8, value);
            }
        }
        public string D9_Pro
        {
            get
            {
                return dot_roadway_closure_app_ht[D9].ToString();
            }
            set
            {
                if (dot_roadway_closure_app_ht.ContainsKey(D9))
                    dot_roadway_closure_app_ht[D9] = value;
                else
                    dot_roadway_closure_app_ht.Add(D9, value);
            }
        }
        #endregion
        public void FillD_RoadwaypdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_roadway_closure_app_ht)
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