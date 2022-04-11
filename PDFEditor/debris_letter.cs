using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class debris_letter
    {
        #region Global Variable
        private Hashtable debris_letter_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string Name_Owner = "txt_OwenerName";
        private const string Address_Owner = "txt_OwnerAddress";
        private const string PhoneNo_Owner = "txt_telephoneNo";
        private const string HR_Emergency_No = "txt_EmergencyNo";
        private const string License_No = "txt_LicenseNo";
        private const string SDPNo = "txt_SDP_NO";

        #endregion
        #region Properties
        public string Name_Owner_Pro
        {
            get
            {
                return debris_letter_ht[Name_Owner].ToString();
            }
            set
            {
                if (debris_letter_ht.ContainsKey(Name_Owner))
                {
                    debris_letter_ht[Name_Owner] = value;
                }
                else
                {
                    debris_letter_ht.Add(Name_Owner, value);
                }
            }
        }
        public string Address_Owner_Pro
        {
            get
            {
                return debris_letter_ht[Address_Owner].ToString();
            }
            set
            {
                if (debris_letter_ht.ContainsKey(Address_Owner))
                {
                    debris_letter_ht[Address_Owner] = value;
                }
                else
                {
                    debris_letter_ht.Add(Address_Owner, value);
                }
            }
        }
        public string PhoneNo_Owner_Pro
        {
            get
            {
                return debris_letter_ht[PhoneNo_Owner].ToString();
            }
            set
            {
                if (debris_letter_ht.ContainsKey(PhoneNo_Owner))
                {
                    debris_letter_ht[PhoneNo_Owner] = value;
                }
                else
                {
                    debris_letter_ht.Add(PhoneNo_Owner, value);
                }
            }
        }
        public string HR_Emergency_No_Pro
        {
            get
            {
                return debris_letter_ht[HR_Emergency_No].ToString();
            }
            set
            {
                if (debris_letter_ht.ContainsKey(HR_Emergency_No))
                {
                    debris_letter_ht[HR_Emergency_No] = value;
                }
                else
                {
                    debris_letter_ht.Add(HR_Emergency_No, value);
                }
            }
        }
        public string License_No_Pro
        {
            get
            {
                return debris_letter_ht[License_No].ToString();
            }
            set
            {
                if (debris_letter_ht.ContainsKey(License_No))
                {
                    debris_letter_ht[License_No] = value;
                }
                else
                {
                    debris_letter_ht.Add(License_No, value);
                }
            }
        }
        public string SDPNo_Pro
        {
            get
            {
                return debris_letter_ht[SDPNo].ToString();
            }
            set
            {
                if (debris_letter_ht.ContainsKey(SDPNo))
                {
                    debris_letter_ht[SDPNo] = value;
                }
                else
                {
                    debris_letter_ht.Add(SDPNo, value);
                }
            }
        }


        #endregion
        public void Filldebris_letterpdfForm(string Path)
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
                    foreach (DictionaryEntry Element in debris_letter_ht)
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
