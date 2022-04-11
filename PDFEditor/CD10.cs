using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
   public class CD10
    {
		#region Global Variable
		private Hashtable CD10_ht = new Hashtable();
		#endregion
		#region Constant
		private const string AppDate = "Text1";
		private const string AppYear = "Text2";
		private const string AppCNNo = "Text3";
		private const string AppCN_Year = "Text4";
		private const string Block = "Text5";
		private const string LOT = "Text6";
		private const string Location_StreetAddress = "Text7";
		private const string Location_Borough = "Text8";
		private const string Applicant = "Text9";
		private const string Address = "Text10";
		private const string PhoneNo = "Text11";
		private const string Description = "Text12";
		private const string PageNo = "Text13";
		private const string TotalPage = "Text14";

		#endregion
		#region Properties
		public string AppDate_Pro
		{
			get
			{
				return CD10_ht[AppDate].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(AppDate))
				{
					CD10_ht[AppDate] = value;
				}
				else
				{
					CD10_ht.Add(AppDate, value);
				}
			}
		}
		public string AppYear_Pro
		{
			get
			{
				return CD10_ht[AppYear].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(AppYear))
				{
					CD10_ht[AppYear] = value;
				}
				else
				{
					CD10_ht.Add(AppYear, value);
				}
			}
		}
		public string AppCNNo_Pro
		{
			get
			{
				return CD10_ht[AppCNNo].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(AppCNNo))
				{
					CD10_ht[AppCNNo] = value;
				}
				else
				{
					CD10_ht.Add(AppCNNo, value);
				}
			}
		}
		public string AppCN_Year_Pro
		{
			get
			{
				return CD10_ht[AppCN_Year].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(AppCN_Year))
				{
					CD10_ht[AppCN_Year] = value;
				}
				else
				{
					CD10_ht.Add(AppCN_Year, value);
				}
			}
		}
		public string Block_Pro
		{
			get
			{
				return CD10_ht[Block].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(Block))
				{
					CD10_ht[Block] = value;
				}
				else
				{
					CD10_ht.Add(Block, value);
				}
			}
		}
		public string LOT_Pro
		{
			get
			{
				return CD10_ht[LOT].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(LOT))
				{
					CD10_ht[LOT] = value;
				}
				else
				{
					CD10_ht.Add(LOT, value);
				}
			}
		}
		public string Location_StreetAddress_Pro
		{
			get
			{
				return CD10_ht[Location_StreetAddress].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(Location_StreetAddress))
				{
					CD10_ht[Location_StreetAddress] = value;
				}
				else
				{
					CD10_ht.Add(Location_StreetAddress, value);
				}
			}
		}
		public string Location_Borough_Pro
		{
			get
			{
				return CD10_ht[Location_Borough].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(Location_Borough))
				{
					CD10_ht[Location_Borough] = value;
				}
				else
				{
					CD10_ht.Add(Location_Borough, value);
				}
			}
		}
		public string Applicant_Pro
		{
			get
			{
				return CD10_ht[Applicant].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(Applicant))
				{
					CD10_ht[Applicant] = value;
				}
				else
				{
					CD10_ht.Add(Applicant, value);
				}
			}
		}
		public string Address_Pro
		{
			get
			{
				return CD10_ht[Address].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(Address))
				{
					CD10_ht[Address] = value;
				}
				else
				{
					CD10_ht.Add(Address, value);
				}
			}
		}
		public string PhoneNo_Pro
		{
			get
			{
				return CD10_ht[PhoneNo].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(PhoneNo))
				{
					CD10_ht[PhoneNo] = value;
				}
				else
				{
					CD10_ht.Add(PhoneNo, value);
				}
			}
		}
		public string Description_Pro
		{
			get
			{
				return CD10_ht[Description].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(Description))
				{
					CD10_ht[Description] = value;
				}
				else
				{
					CD10_ht.Add(Description, value);
				}
			}
		}
		public string PageNo_Pro
		{
			get
			{
				return CD10_ht[PageNo].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(PageNo))
				{
					CD10_ht[PageNo] = value;
				}
				else
				{
					CD10_ht.Add(PageNo, value);
				}
			}
		}
		public string TotalPage_Pro
		{
			get
			{
				return CD10_ht[TotalPage].ToString();
			}
			set
			{
				if (CD10_ht.ContainsKey(TotalPage))
				{
					CD10_ht[TotalPage] = value;
				}
				else
				{
					CD10_ht.Add(TotalPage, value);
				}
			}
		}

		#endregion
		public void FillCD10pdfForm(string Path)
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
					foreach (DictionaryEntry Element in CD10_ht)
					{
						AF.SetField(Element.Key.ToString().ToString(), Element.Value.ToString().ToString());
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
