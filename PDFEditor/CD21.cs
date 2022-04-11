using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
   public class CD21
    {
		#region Global Variable
		private Hashtable CD21_ht = new Hashtable();
		#endregion
		#region Constant Variable
		private const string Contractor_Name = "Text1";
		private const string Full_Address = "Text2";
		private const string Location = "Text3";
		private const string Equipment = "Text4";
		private const string Serial = "Text5";
		private const string Boom_ft = "Text6";
		private const string Jib_ft = "Text7";
		private const string Mast_ft = "Text8";
		private const string Fee = "Text9";
		private const string Total = "Text10";
		private const string Inspection_Date = "Text11";
		private const string Curr_Date = "Text12";

		#endregion

		#region Properties
		public string Contractor_Name_Pro
		{
			get
			{
				return CD21_ht[Contractor_Name].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Contractor_Name))
				{
					CD21_ht[Contractor_Name] = value;
				}
				else
				{
					CD21_ht.Add(Contractor_Name, value);
				}
			}
		}
		public string Full_Address_Pro
		{
			get
			{
				return CD21_ht[Full_Address].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Full_Address))
				{
					CD21_ht[Full_Address] = value;
				}
				else
				{
					CD21_ht.Add(Full_Address, value);
				}
			}
		}
		public string Location_Pro
		{
			get
			{
				return CD21_ht[Location].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Location))
				{
					CD21_ht[Location] = value;
				}
				else
				{
					CD21_ht.Add(Location, value);
				}
			}
		}
		public string Equipment_Pro
		{
			get
			{
				return CD21_ht[Equipment].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Equipment))
				{
					CD21_ht[Equipment] = value;
				}
				else
				{
					CD21_ht.Add(Equipment, value);
				}
			}
		}
		public string Serial_Pro
		{
			get
			{
				return CD21_ht[Serial].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Serial))
				{
					CD21_ht[Serial] = value;
				}
				else
				{
					CD21_ht.Add(Serial, value);
				}
			}
		}
		public string Boom_ft_Pro
		{
			get
			{
				return CD21_ht[Boom_ft].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Boom_ft))
				{
					CD21_ht[Boom_ft] = value;
				}
				else
				{
					CD21_ht.Add(Boom_ft, value);
				}
			}
		}
		public string Jib_ft_Pro
		{
			get
			{
				return CD21_ht[Jib_ft].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Jib_ft))
				{
					CD21_ht[Jib_ft] = value;
				}
				else
				{
					CD21_ht.Add(Jib_ft, value);
				}
			}
		}
		public string Mast_ft_Pro
		{
			get
			{
				return CD21_ht[Mast_ft].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Mast_ft))
				{
					CD21_ht[Mast_ft] = value;
				}
				else
				{
					CD21_ht.Add(Mast_ft, value);
				}
			}
		}
		public string Fee_Pro
		{
			get
			{
				return CD21_ht[Fee].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Fee))
				{
					CD21_ht[Fee] = value;
				}
				else
				{
					CD21_ht.Add(Fee, value);
				}
			}
		}
		public string Total_Pro
		{
			get
			{
				return CD21_ht[Total].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Total))
				{
					CD21_ht[Total] = value;
				}
				else
				{
					CD21_ht.Add(Total, value);
				}
			}
		}
		public string Inspection_Date_Pro
		{
			get
			{
				return CD21_ht[Inspection_Date].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Inspection_Date))
				{
					CD21_ht[Inspection_Date] = value;
				}
				else
				{
					CD21_ht.Add(Inspection_Date, value);
				}
			}
		}
		public string Curr_Date_Pro
		{
			get
			{
				return CD21_ht[Curr_Date].ToString();
			}
			set
			{
				if (CD21_ht.ContainsKey(Curr_Date))
				{
					CD21_ht[Curr_Date] = value;
				}
				else
				{
					CD21_ht.Add(Curr_Date, value);
				}
			}
		}

		#endregion
		public void FillCD21pdfForm(string Path)
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
					foreach (DictionaryEntry Element in CD21_ht)
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