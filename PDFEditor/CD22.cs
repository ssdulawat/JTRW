using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD22
    {
        #region Global Variable
        private Hashtable CD22_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string App_Name = "Text1";
        private const string App_Company = "Text2";
        private const string JI_Address = "Text3";
        private const string JI_Borough = "Text4";
        private const string OSCI_Name = "Text5";
        private const string OSCI_CellNo = "Text6";
        private const string CI_CN = "Text7";
        private const string CI_CD = "Text8";
        private const string CI_CraneModel = "Text9";
        private const string CI_Tower = "Text10";
        private const string Unassembled_Yes = "Check Box11";
        private const string Unassembled_No = "Check Box12";
        private const string Assembled_Yes = "Check Box13";
        private const string Assembled_No = "Check Box14";
        private const string LoadTest_Yes = "Check Box15";
        private const string LoadTest_No = "Check Box16";
        private const string CNApproved_Yes = "Check Box17";
        private const string CNApproved_No = "Check Box18";
        private const string All_Yes = "Check Box19";
        private const string All_No = "Check Box20";
        private const string Inspection_Date = "Text21";

        #endregion
        #region Properties
        public string App_Name_Pro
        {
            get
            {
                return CD22_ht[App_Name].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(App_Name))
                {
                    CD22_ht[App_Name] = value;
                }
                else
                {
                    CD22_ht.Add(App_Name, value);
                }
            }
        }
        public string App_Company_Pro
        {
            get
            {
                return CD22_ht[App_Company].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(App_Company))
                {
                    CD22_ht[App_Company] = value;
                }
                else
                {
                    CD22_ht.Add(App_Company, value);
                }
            }
        }
        public string JI_Address_Pro
        {
            get
            {
                return CD22_ht[JI_Address].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(JI_Address))
                {
                    CD22_ht[JI_Address] = value;
                }
                else
                {
                    CD22_ht.Add(JI_Address, value);
                }
            }
        }
        public string JI_Borough_Pro
        {
            get
            {
                return CD22_ht[JI_Borough].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(JI_Borough))
                {
                    CD22_ht[JI_Borough] = value;
                }
                else
                {
                    CD22_ht.Add(JI_Borough, value);
                }
            }
        }
        public string OSCI_Name_Pro
        {
            get
            {
                return CD22_ht[OSCI_Name].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(OSCI_Name))
                {
                    CD22_ht[OSCI_Name] = value;
                }
                else
                {
                    CD22_ht.Add(OSCI_Name, value);
                }
            }
        }
        public string OSCI_CellNo_Pro
        {
            get
            {
                return CD22_ht[OSCI_CellNo].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(OSCI_CellNo))
                {
                    CD22_ht[OSCI_CellNo] = value;
                }
                else
                {
                    CD22_ht.Add(OSCI_CellNo, value);
                }
            }
        }
        public string CI_CN_Pro
        {
            get
            {
                return CD22_ht[CI_CN].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(CI_CN))
                {
                    CD22_ht[CI_CN] = value;
                }
                else
                {
                    CD22_ht.Add(CI_CN, value);
                }
            }
        }
        public string CI_CD_Pro
        {
            get
            {
                return CD22_ht[CI_CD].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(CI_CD))
                {
                    CD22_ht[CI_CD] = value;
                }
                else
                {
                    CD22_ht.Add(CI_CD, value);
                }
            }
        }
        public string CI_CraneModel_Pro
        {
            get
            {
                return CD22_ht[CI_CraneModel].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(CI_CraneModel))
                {
                    CD22_ht[CI_CraneModel] = value;
                }
                else
                {
                    CD22_ht.Add(CI_CraneModel, value);
                }
            }
        }
        public string CI_Tower_Pro
        {
            get
            {
                return CD22_ht[CI_Tower].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(CI_Tower))
                {
                    CD22_ht[CI_Tower] = value;
                }
                else
                {
                    CD22_ht.Add(CI_Tower, value);
                }
            }
        }
        public string Unassembled_Yes_Pro
        {
            get
            {
                return CD22_ht[Unassembled_Yes].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(Unassembled_Yes))
                {
                    CD22_ht[Unassembled_Yes] = value;
                }
                else
                {
                    CD22_ht.Add(Unassembled_Yes, value);
                }
            }
        }
        public string Unassembled_No_Pro
        {
            get
            {
                return CD22_ht[Unassembled_No].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(Unassembled_No))
                {
                    CD22_ht[Unassembled_No] = value;
                }
                else
                {
                    CD22_ht.Add(Unassembled_No, value);
                }
            }
        }
        public string Assembled_Yes_Pro
        {
            get
            {
                return CD22_ht[Assembled_Yes].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(Assembled_Yes))
                {
                    CD22_ht[Assembled_Yes] = value;
                }
                else
                {
                    CD22_ht.Add(Assembled_Yes, value);
                }
            }
        }
        public string Assembled_No_Pro
        {
            get
            {
                return CD22_ht[Assembled_No].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(Assembled_No))
                {
                    CD22_ht[Assembled_No] = value;
                }
                else
                {
                    CD22_ht.Add(Assembled_No, value);
                }
            }
        }
        public string LoadTest_Yes_Pro
        {
            get
            {
                return CD22_ht[LoadTest_Yes].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(LoadTest_Yes))
                {
                    CD22_ht[LoadTest_Yes] = value;
                }
                else
                {
                    CD22_ht.Add(LoadTest_Yes, value);
                }
            }
        }
        public string LoadTest_No_Pro
        {
            get
            {
                return CD22_ht[LoadTest_No].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(LoadTest_No))
                {
                    CD22_ht[LoadTest_No] = value;
                }
                else
                {
                    CD22_ht.Add(LoadTest_No, value);
                }
            }
        }
        public string CNApproved_Yes_Pro
        {
            get
            {
                return CD22_ht[CNApproved_Yes].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(CNApproved_Yes))
                {
                    CD22_ht[CNApproved_Yes] = value;
                }
                else
                {
                    CD22_ht.Add(CNApproved_Yes, value);
                }
            }
        }
        public string CNApproved_No_Pro
        {
            get
            {
                return CD22_ht[CNApproved_No].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(CNApproved_No))
                {
                    CD22_ht[CNApproved_No] = value;
                }
                else
                {
                    CD22_ht.Add(CNApproved_No, value);
                }
            }
        }
        public string All_Yes_Pro
        {
            get
            {
                return CD22_ht[All_Yes].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(All_Yes))
                {
                    CD22_ht[All_Yes] = value;
                }
                else
                {
                    CD22_ht.Add(All_Yes, value);
                }
            }
        }
        public string All_No_Pro
        {
            get
            {
                return CD22_ht[All_No].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(All_No))
                {
                    CD22_ht[All_No] = value;
                }
                else
                {
                    CD22_ht.Add(All_No, value);
                }
            }
        }
        public string Inspection_Date_Pro
        {
            get
            {
                return CD22_ht[Inspection_Date].ToString();
            }
            set
            {
                if (CD22_ht.ContainsKey(Inspection_Date))
                {
                    CD22_ht[Inspection_Date] = value;
                }
                else
                {
                    CD22_ht.Add(Inspection_Date, value);
                }
            }
        }

        #endregion
        public void FillCD22pdfForm(string Path)
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
                    foreach (DictionaryEntry Element in CD22_ht)
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
