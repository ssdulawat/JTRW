using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
    public class CD12
    {
		#region Global Variable
		private Hashtable CD12_ht = new Hashtable();
		#endregion
		#region Constant
		private const string CN = "Text1";
		private const string CD = "Text2";
		private const string Address_Borough = "Text3";
		private const string Block = "Text4";
		private const string LOT = "Text5";
		private const string Ms = "Text6";
		private const string Owner_Name = "Text7";
		private const string Owner_PhoneNo = "Text8";
		private const string Owner_Address = "Text9";
		private const string Owner_Sign_Date = "Text10";
		private const string SC_Name = "Text11";
		private const string SC_NAMEOnly = "Text12";
		private const string SC_PhoneNo = "Text13";
		private const string SC_Address = "Text14";
		private const string SC_Sign_Date = "Text15";

		#endregion
		#region Properties
		public string CN_Pro
		{
			get
			{
				return CD12_ht[CN].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(CN))
				{
					CD12_ht[CN] = value;
				}
				else
				{
					CD12_ht.Add(CN, value);
				}
			}
		}
		public string CD_Pro
		{
			get
			{
				return CD12_ht[CD].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(CD))
				{
					CD12_ht[CD] = value;
				}
				else
				{
					CD12_ht.Add(CD, value);
				}
			}
		}
		public string Address_Borough_Pro
		{
			get
			{
				return CD12_ht[Address_Borough].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Address_Borough))
				{
					CD12_ht[Address_Borough] = value;
				}
				else
				{
					CD12_ht.Add(Address_Borough, value);
				}
			}
		}
		public string Block_Pro
		{
			get
			{
				return CD12_ht[Block].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Block))
				{
					CD12_ht[Block] = value;
				}
				else
				{
					CD12_ht.Add(Block, value);
				}
			}
		}
		public string LOT_Pro
		{
			get
			{
				return CD12_ht[LOT].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(LOT))
				{
					CD12_ht[LOT] = value;
				}
				else
				{
					CD12_ht.Add(LOT, value);
				}
			}
		}
		public string Ms_Pro
		{
			get
			{
				return CD12_ht[Ms].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Ms))
				{
					CD12_ht[Ms] = value;
				}
				else
				{
					CD12_ht.Add(Ms, value);
				}
			}
		}
		public string Owner_Name_Pro
		{
			get
			{
				return CD12_ht[Owner_Name].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Owner_Name))
				{
					CD12_ht[Owner_Name] = value;
				}
				else
				{
					CD12_ht.Add(Owner_Name, value);
				}
			}
		}
		public string Owner_PhoneNo_Pro
		{
			get
			{
				return CD12_ht[Owner_PhoneNo].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Owner_PhoneNo))
				{
					CD12_ht[Owner_PhoneNo] = value;
				}
				else
				{
					CD12_ht.Add(Owner_PhoneNo, value);
				}
			}
		}
		public string Owner_Address_Pro
		{
			get
			{
				return CD12_ht[Owner_Address].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Owner_Address))
				{
					CD12_ht[Owner_Address] = value;
				}
				else
				{
					CD12_ht.Add(Owner_Address, value);
				}
			}
		}
		public string Owner_Sign_Date_Pro
		{
			get
			{
				return CD12_ht[Owner_Sign_Date].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(Owner_Sign_Date))
				{
					CD12_ht[Owner_Sign_Date] = value;
				}
				else
				{
					CD12_ht.Add(Owner_Sign_Date, value);
				}
			}
		}
		public string SC_Name_Pro
		{
			get
			{
				return CD12_ht[SC_Name].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(SC_Name))
				{
					CD12_ht[SC_Name] = value;
				}
				else
				{
					CD12_ht.Add(SC_Name, value);
				}
			}
		}
		public string SC_NAMEOnly_Pro
		{
			get
			{
				return CD12_ht[SC_NAMEOnly].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(SC_NAMEOnly))
				{
					CD12_ht[SC_NAMEOnly] = value;
				}
				else
				{
					CD12_ht.Add(SC_NAMEOnly, value);
				}
			}
		}
		public string SC_PhoneNo_Pro
		{
			get
			{
				return CD12_ht[SC_PhoneNo].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(SC_PhoneNo))
				{
					CD12_ht[SC_PhoneNo] = value;
				}
				else
				{
					CD12_ht.Add(SC_PhoneNo, value);
				}
			}
		}
		public string SC_Address_Pro
		{
			get
			{
				return CD12_ht[SC_Address].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(SC_Address))
				{
					CD12_ht[SC_Address] = value;
				}
				else
				{
					CD12_ht.Add(SC_Address, value);
				}
			}
		}
		public string SC_Sign_Date_Pro
		{
			get
			{
				return CD12_ht[SC_Sign_Date].ToString();
			}
			set
			{
				if (CD12_ht.ContainsKey(SC_Sign_Date))
				{
					CD12_ht[SC_Sign_Date] = value;
				}
				else
				{
					CD12_ht.Add(SC_Sign_Date, value);
				}
			}
		}

		#endregion
		public void FillCD12pdfForm(string Path)
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
					foreach (DictionaryEntry Element in CD12_ht)
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
