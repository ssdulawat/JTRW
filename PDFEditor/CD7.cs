using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD7
    {
        #region Global Variable
        private Hashtable CD7_ht = new Hashtable();
        #endregion
        #region Const
        private const string LOJ_Borough = "topmostSubform[0].Page1[0].Borough[0]";
        private const string LOJ_StreetName = "topmostSubform[0].Page1[0].Street_Name[0]";
        private const string External_Climbing_Cranes = "topmostSubform[0].Page1[0].External_Climbing_Cranes[0]";
        private const string Internal_Climbing_Cranes = "topmostSubform[0].Page1[0].Internal_Climbing_Crane[0]";
        private const string RS_LicenseNo = "topmostSubform[0].Page1[0].License_Number[0]";
        private const string RS_Address = "topmostSubform[0].Page1[0].Address_rigger[0]";
        private const string RS_Declaration = "topmostSubform[0].Page1[0].I[0]";
        private const string RS_Sign_Date = "topmostSubform[0].Page1[0].Signature__Date[0]";
        private const string EUS_BusinessName = "topmostSubform[0].Page1[0].Business_Name[0]";
        private const string EUS_Address = "topmostSubform[0].Page1[0].Address_2[0]";
        private const string EUS_Declaration = "topmostSubform[0].Page1[0].I_2[0]";
        private const string EUS_Sign_Date = "topmostSubform[0].Page1[0].Signature__Date_2[0]";
        private const string LOJ_HouseNO = "topmostSubform[0].Page1[0].HouseNo[0]";
        private const string CI_CDNo = "topmostSubform[0].Page1[0].CDNo[0]";
        private const string CI_CNNo = "topmostSubform[0].Page1[0].CNNo[0]";
        private const string CI_Phase = "topmostSubform[0].Page1[0].TextField4[0]";
        private const string CI_Date = "topmostSubform[0].Page1[0].Proposed_date_raising[0]";
        private const string CI_Time = "topmostSubform[0].Page1[0].Proposed_time_raising[0]";
        private const string RS_LastName = "topmostSubform[0].Page1[0].Lastname[0]";
        private const string RS_FirstName = "topmostSubform[0].Page1[0].Firstname[0]";
        private const string RS_MI = "topmostSubform[0].Page1[0].mi[0]";
        private const string RS_City = "topmostSubform[0].Page1[0].city_rigger[0]";
        private const string RS_State = "topmostSubform[0].Page1[0].TextField11[0]";
        private const string RS_Zip = "topmostSubform[0].Page1[0].TextField12[0]";
        private const string RS_Phone = "topmostSubform[0].Page1[0].TextField13[0]";
        private const string RS_Fax = "topmostSubform[0].Page1[0].TextField14[0]";
        private const string EUS_LastName = "topmostSubform[0].Page1[0].TextField15[0]";
        private const string EUS_FirstName = "topmostSubform[0].Page1[0].TextField16[0]";
        private const string EUS_MI = "topmostSubform[0].Page1[0].TextField17[0]";
        private const string EUS_City = "topmostSubform[0].Page1[0].TextField18[0]";
        private const string EUS_State = "topmostSubform[0].Page1[0].TextField19[0]";
        private const string EUS_Zip = "topmostSubform[0].Page1[0].TextField20[0]";

        #endregion

        #region Properties
        public string LOJ_Borough_Pro
        {
            get
            {
                return CD7_ht[LOJ_Borough].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(LOJ_Borough))
                {
                    CD7_ht[LOJ_Borough] = value;
                }
                else
                {
                    CD7_ht.Add(LOJ_Borough, value);
                }
            }
        }
        public string LOJ_StreetName_Pro
        {
            get
            {
                return CD7_ht[LOJ_StreetName].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(LOJ_StreetName))
                {
                    CD7_ht[LOJ_StreetName] = value;
                }
                else
                {
                    CD7_ht.Add(LOJ_StreetName, value);
                }
            }
        }
        public string External_Climbing_Cranes_Pro
        {
            get
            {
                return CD7_ht[External_Climbing_Cranes].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(External_Climbing_Cranes))
                {
                    CD7_ht[External_Climbing_Cranes] = value;
                }
                else
                {
                    CD7_ht.Add(External_Climbing_Cranes, value);
                }
            }
        }
        public string Internal_Climbing_Cranes_Pro
        {
            get
            {
                return CD7_ht[Internal_Climbing_Cranes].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(Internal_Climbing_Cranes))
                {
                    CD7_ht[Internal_Climbing_Cranes] = value;
                }
                else
                {
                    CD7_ht.Add(Internal_Climbing_Cranes, value);
                }
            }
        }
        public string RS_LicenseNo_Pro
        {
            get
            {
                return CD7_ht[RS_LicenseNo].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_LicenseNo))
                {
                    CD7_ht[RS_LicenseNo] = value;
                }
                else
                {
                    CD7_ht.Add(RS_LicenseNo, value);
                }
            }
        }
        public string RS_Address_Pro
        {
            get
            {
                return CD7_ht[RS_Address].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_Address))
                {
                    CD7_ht[RS_Address] = value;
                }
                else
                {
                    CD7_ht.Add(RS_Address, value);
                }
            }
        }
        public string RS_Declaration_Pro
        {
            get
            {
                return CD7_ht[RS_Declaration].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_Declaration))
                {
                    CD7_ht[RS_Declaration] = value;
                }
                else
                {
                    CD7_ht.Add(RS_Declaration, value);
                }
            }
        }
        public string RS_Sign_Date_Pro
        {
            get
            {
                return CD7_ht[RS_Sign_Date].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_Sign_Date))
                {
                    CD7_ht[RS_Sign_Date] = value;
                }
                else
                {
                    CD7_ht.Add(RS_Sign_Date, value);
                }
            }
        }
        public string EUS_BusinessName_Pro
        {
            get
            {
                return CD7_ht[EUS_BusinessName].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_BusinessName))
                {
                    CD7_ht[EUS_BusinessName] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_BusinessName, value);
                }
            }
        }
        public string EUS_Address_Pro
        {
            get
            {
                return CD7_ht[EUS_Address].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_Address))
                {
                    CD7_ht[EUS_Address] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_Address, value);
                }
            }
        }
        public string EUS_Declaration_Pro
        {
            get
            {
                return CD7_ht[EUS_Declaration].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_Declaration))
                {
                    CD7_ht[EUS_Declaration] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_Declaration, value);
                }
            }
        }
        public string EUS_Sign_Date_Pro
        {
            get
            {
                return CD7_ht[EUS_Sign_Date].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_Sign_Date))
                {
                    CD7_ht[EUS_Sign_Date] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_Sign_Date, value);
                }
            }
        }
        public string LOJ_HouseNO_Pro
        {
            get
            {
                return CD7_ht[LOJ_HouseNO].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(LOJ_HouseNO))
                {
                    CD7_ht[LOJ_HouseNO] = value;
                }
                else
                {
                    CD7_ht.Add(LOJ_HouseNO, value);
                }
            }
        }
        public string CI_CDNo_Pro
        {
            get
            {
                return CD7_ht[CI_CDNo].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(CI_CDNo))
                {
                    CD7_ht[CI_CDNo] = value;
                }
                else
                {
                    CD7_ht.Add(CI_CDNo, value);
                }
            }
        }
        public string CI_CNNo_Pro
        {
            get
            {
                return CD7_ht[CI_CNNo].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(CI_CNNo))
                {
                    CD7_ht[CI_CNNo] = value;
                }
                else
                {
                    CD7_ht.Add(CI_CNNo, value);
                }
            }
        }
        public string CI_Phase_Pro
        {
            get
            {
                return CD7_ht[CI_Phase].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(CI_Phase))
                {
                    CD7_ht[CI_Phase] = value;
                }
                else
                {
                    CD7_ht.Add(CI_Phase, value);
                }
            }
        }
        public string CI_Date_Pro
        {
            get
            {
                return CD7_ht[CI_Date].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(CI_Date))
                {
                    CD7_ht[CI_Date] = value;
                }
                else
                {
                    CD7_ht.Add(CI_Date, value);
                }
            }
        }
        public string CI_Time_Pro
        {
            get
            {
                return CD7_ht[CI_Time].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(CI_Time))
                {
                    CD7_ht[CI_Time] = value;
                }
                else
                {
                    CD7_ht.Add(CI_Time, value);
                }
            }
        }
        public string RS_LastName_Pro
        {
            get
            {
                return CD7_ht[RS_LastName].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_LastName))
                {
                    CD7_ht[RS_LastName] = value;
                }
                else
                {
                    CD7_ht.Add(RS_LastName, value);
                }
            }
        }
        public string RS_FirstName_Pro
        {
            get
            {
                return CD7_ht[RS_FirstName].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_FirstName))
                {
                    CD7_ht[RS_FirstName] = value;
                }
                else
                {
                    CD7_ht.Add(RS_FirstName, value);
                }
            }
        }
        public string RS_MI_Pro
        {
            get
            {
                return CD7_ht[RS_MI].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_MI))
                {
                    CD7_ht[RS_MI] = value;
                }
                else
                {
                    CD7_ht.Add(RS_MI, value);
                }
            }
        }
        public string RS_City_Pro
        {
            get
            {
                return CD7_ht[RS_City].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_City))
                {
                    CD7_ht[RS_City] = value;
                }
                else
                {
                    CD7_ht.Add(RS_City, value);
                }
            }
        }
        public string RS_State_Pro
        {
            get
            {
                return CD7_ht[RS_State].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_State))
                {
                    CD7_ht[RS_State] = value;
                }
                else
                {
                    CD7_ht.Add(RS_State, value);
                }
            }
        }
        public string RS_Zip_Pro
        {
            get
            {
                return CD7_ht[RS_Zip].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_Zip))
                {
                    CD7_ht[RS_Zip] = value;
                }
                else
                {
                    CD7_ht.Add(RS_Zip, value);
                }
            }
        }
        public string RS_Phone_Pro
        {
            get
            {
                return CD7_ht[RS_Phone].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_Phone))
                {
                    CD7_ht[RS_Phone] = value;
                }
                else
                {
                    CD7_ht.Add(RS_Phone, value);
                }
            }
        }
        public string RS_Fax_Pro
        {
            get
            {
                return CD7_ht[RS_Fax].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(RS_Fax))
                {
                    CD7_ht[RS_Fax] = value;
                }
                else
                {
                    CD7_ht.Add(RS_Fax, value);
                }
            }
        }
        public string EUS_LastName_Pro
        {
            get
            {
                return CD7_ht[EUS_LastName].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_LastName))
                {
                    CD7_ht[EUS_LastName] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_LastName, value);
                }
            }
        }
        public string EUS_FirstName_Pro
        {
            get
            {
                return CD7_ht[EUS_FirstName].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_FirstName))
                {
                    CD7_ht[EUS_FirstName] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_FirstName, value);
                }
            }
        }
        public string EUS_MI_Pro
        {
            get
            {
                return CD7_ht[EUS_MI].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_MI))
                {
                    CD7_ht[EUS_MI] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_MI, value);
                }
            }
        }
        public string EUS_City_Pro
        {
            get
            {
                return CD7_ht[EUS_City].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_City))
                {
                    CD7_ht[EUS_City] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_City, value);
                }
            }
        }
        public string EUS_State_Pro
        {
            get
            {
                return CD7_ht[EUS_State].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_State))
                {
                    CD7_ht[EUS_State] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_State, value);
                }
            }
        }
        public string EUS_Zip_Pro
        {
            get
            {
                return CD7_ht[EUS_Zip].ToString();
            }
            set
            {
                if (CD7_ht.ContainsKey(EUS_Zip))
                {
                    CD7_ht[EUS_Zip] = value;
                }
                else
                {
                    CD7_ht.Add(EUS_Zip, value);
                }
            }
        }

        #endregion
        public void FillCD7pdfForm(string Path)
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
                    foreach (DictionaryEntry Element in CD7_ht)
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
