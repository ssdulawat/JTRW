using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD16pdf
    {
		#region Global Variable
		private Hashtable CD16_ht = new Hashtable();
		#endregion
		#region Constant variable
		private const string Application_Type = "Text1";
		private const string Apllicaton_No = "Text2";
		private const string Date_Filled = "Text3";
		private const string Borough_Info = "Text4";
		private const string Community_Board_Info = "Text5";
		private const string Address_Info1 = "Text6";
		private const string Address_Info2 = "Text7";
		private const string HereBy_DeclareName = "Text8";
		private const string HereBy_Date = "Text9";
		private const string HereBy_TelephoneNo = "Text10";
		private const string Block_Info = "Text11";
		private const string Lot_Info = "Text12";
		private const string Location_Info = "Text13";
		private const string NumberOfStories_Info = "Text14";
		private const string Occupancy_Info = "Text15";
		private const string No_Of_Apts_Info = "Text16";
		private const string Current_Info = "Text17";
		private const string Proposed_Info = "Text18";
		private const string NO_Of_SRO_Info = "Text19";
		private const string SRO_Current_Info = "Text20";
		private const string SRO_Proposed_Info = "Text21";
		private const string Work_Proposed_Info1 = "Text22";
		private const string Work_Proposed_Info2 = "Text23";
		private const string Work_Proposed_Info3 = "Text24";
		private const string Applicant_Name = "Text26";
		private const string Applicant_Address = "Text27";
		private const string Owner_Name = "Text28";
		private const string Owner_Address = "Text29";
		private const string Architect_Name = "Text30";
		private const string Architect_Address = "Text31";
		private const string Engineer_Name = "Text32";
		private const string Engineer_Address = "Text33";
		#endregion
		#region Properties
		public string ApplicationType
		{
			get
			{
				return CD16_ht[Application_Type].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Application_Type))
				{
					CD16_ht[Application_Type] = value;
				}
				else
				{
					CD16_ht.Add(Application_Type, value);
				}
			}
		}
		public string ApplicationNO
		{
			get
			{
				return CD16_ht[Apllicaton_No].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Apllicaton_No))
				{
					CD16_ht[Apllicaton_No] = value;
				}
				else
				{
					CD16_ht.Add(Apllicaton_No, value);
				}
			}
		}
		public string DateFilled
		{
			get
			{
				return CD16_ht[Date_Filled].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Date_Filled))
				{
					CD16_ht[Date_Filled] = value;
				}
				else
				{
					CD16_ht.Add(Date_Filled, value);
				}
			}
		}
		public string Borough
		{
			get
			{
				return CD16_ht[Borough_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Borough_Info))
				{
					CD16_ht[Borough_Info] = value;
				}
				else
				{
					CD16_ht.Add(Borough_Info, value);
				}
			}
		}
		public string CommunityBoard
		{
			get
			{
				return CD16_ht[Community_Board_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Community_Board_Info))
				{
					CD16_ht[Community_Board_Info] = value;
				}
				else
				{
					CD16_ht.Add(Community_Board_Info, value);
				}
			}
		}
		public string Address1
		{
			get
			{
				return CD16_ht[Address_Info1].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Address_Info1))
				{
					CD16_ht[Address_Info1] = value;
				}
				else
				{
					CD16_ht.Add(Address_Info1, value);
				}
			}
		}
		public string Address2
		{
			get
			{
				return CD16_ht[Address_Info2].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Address_Info2))
				{
					CD16_ht[Address_Info2] = value;
				}
				else
				{
					CD16_ht.Add(Address_Info2, value);
				}
			}
		}
		public string HereByDeclareName
		{
			get
			{
				return CD16_ht[HereBy_DeclareName].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(HereBy_DeclareName))
				{
					CD16_ht[HereBy_DeclareName] = value;
				}
				else
				{
					CD16_ht.Add(HereBy_DeclareName, value);
				}
			}
		}
		public string HereByDate
		{
			get
			{
				return CD16_ht[HereBy_Date].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(HereBy_Date))
				{
					CD16_ht[HereBy_Date] = value;
				}
				else
				{
					CD16_ht.Add(HereBy_Date, value);
				}
			}
		}
		public string HereByTelephoneNo
		{
			get
			{
				return CD16_ht[HereBy_TelephoneNo].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(HereBy_TelephoneNo))
				{
					CD16_ht[HereBy_TelephoneNo] = value;
				}
				else
				{
					CD16_ht.Add(HereBy_TelephoneNo, value);
				}
			}
		}
		public string Block
		{
			get
			{
				return CD16_ht[Block_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Block_Info))
				{
					CD16_ht[Block_Info] = value;
				}
				else
				{
					CD16_ht.Add(Block_Info, value);
				}
			}
		}
		public string Lot
		{
			get
			{
				return CD16_ht[Lot_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Lot_Info))
				{
					CD16_ht[Lot_Info] = value;
				}
				else
				{
					CD16_ht.Add(Lot_Info, value);
				}
			}
		}
		public string Location
		{
			get
			{
				return CD16_ht[Location_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Location_Info))
				{
					CD16_ht[Location_Info] = value;
				}
				else
				{
					CD16_ht.Add(Location_Info, value);
				}
			}
		}
		public string NumberOfStories
		{
			get
			{
				return CD16_ht[NumberOfStories_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(NumberOfStories_Info))
				{
					CD16_ht[NumberOfStories_Info] = value;
				}
				else
				{
					CD16_ht.Add(NumberOfStories_Info, value);
				}
			}
		}
		public string Occupancy
		{
			get
			{
				return CD16_ht[Occupancy_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Occupancy_Info))
				{
					CD16_ht[Occupancy_Info] = value;
				}
				else
				{
					CD16_ht.Add(Occupancy_Info, value);
				}
			}
		}
		public string NoOfApts
		{
			get
			{
				return CD16_ht[No_Of_Apts_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(No_Of_Apts_Info))
				{
					CD16_ht[No_Of_Apts_Info] = value;
				}
				else
				{
					CD16_ht.Add(No_Of_Apts_Info, value);
				}
			}
		}
		public string AptsCurrent
		{
			get
			{
				return CD16_ht[Current_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Current_Info))
				{
					CD16_ht[Current_Info] = value;
				}
				else
				{
					CD16_ht.Add(Current_Info, value);
				}
			}
		}
		public string AptsProposed
		{
			get
			{
				return CD16_ht[Proposed_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Proposed_Info))
				{
					CD16_ht[Proposed_Info] = value;
				}
				else
				{
					CD16_ht.Add(Proposed_Info, value);
				}
			}
		}
		public string NoOfSRO
		{
			get
			{
				return CD16_ht[NO_Of_SRO_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(NO_Of_SRO_Info))
				{
					CD16_ht[NO_Of_SRO_Info] = value;
				}
				else
				{
					CD16_ht.Add(NO_Of_SRO_Info, value);
				}
			}
		}
		public string SROCurrent
		{
			get
			{
				return CD16_ht[SRO_Current_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(SRO_Current_Info))
				{
					CD16_ht[SRO_Current_Info] = value;
				}
				else
				{
					CD16_ht.Add(SRO_Current_Info, value);
				}
			}
		}
		public string SROProposed
		{
			get
			{
				return CD16_ht[SRO_Proposed_Info].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(SRO_Proposed_Info))
				{
					CD16_ht[SRO_Proposed_Info] = value;
				}
				else
				{
					CD16_ht.Add(SRO_Proposed_Info, value);
				}
			}
		}
		public string WorkProposed1
		{
			get
			{
				return CD16_ht[Work_Proposed_Info1].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Work_Proposed_Info1))
				{
					CD16_ht[Work_Proposed_Info1] = value;
				}
				else
				{
					CD16_ht.Add(Work_Proposed_Info1, value);
				}
			}
		}
		public string WorkProposed2
		{
			get
			{
				return CD16_ht[Work_Proposed_Info2].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Work_Proposed_Info2))
				{
					CD16_ht[Work_Proposed_Info2] = value;
				}
				else
				{
					CD16_ht.Add(Work_Proposed_Info2, value);
				}
			}
		}
		public string WorkProposed3
		{
			get
			{
				return CD16_ht[Work_Proposed_Info3].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Work_Proposed_Info3))
				{
					CD16_ht[Work_Proposed_Info3] = value;
				}
				else
				{
					CD16_ht.Add(Work_Proposed_Info3, value);
				}
			}
		}
		public string ApplicantName
		{
			get
			{
				return CD16_ht[Applicant_Name].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Applicant_Name))
				{
					CD16_ht[Applicant_Name] = value;
				}
				else
				{
					CD16_ht.Add(Applicant_Name, value);
				}
			}
		}
		public string ApplicantAddress
		{
			get
			{
				return CD16_ht[Applicant_Address].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Applicant_Address))
				{
					CD16_ht[Applicant_Address] = value;
				}
				else
				{
					CD16_ht.Add(Applicant_Address, value);
				}
			}
		}
		public string OwnerName
		{
			get
			{
				return CD16_ht[Owner_Name].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Owner_Name))
				{
					CD16_ht[Owner_Name] = value;
				}
				else
				{
					CD16_ht.Add(Owner_Name, value);
				}
			}
		}
		public string OwnerAddress
		{
			get
			{
				return CD16_ht[Owner_Address].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Owner_Address))
				{
					CD16_ht[Owner_Address] = value;
				}
				else
				{
					CD16_ht.Add(Owner_Address, value);
				}
			}
		}
		public string ArchitectName
		{
			get
			{
				return CD16_ht[Architect_Name].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Architect_Name))
				{
					CD16_ht[Architect_Name] = value;
				}
				else
				{
					CD16_ht.Add(Architect_Name, value);
				}
			}
		}
		public string ArchitectAddress
		{
			get
			{
				return CD16_ht[Architect_Address].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Architect_Address))
				{
					CD16_ht[Architect_Address] = value;
				}
				else
				{
					CD16_ht.Add(Architect_Address, value);
				}
			}
		}
		public string EngineerName
		{
			get
			{
				return CD16_ht[Engineer_Name].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Engineer_Name))
				{
					CD16_ht[Engineer_Name] = value;
				}
				else
				{
					CD16_ht.Add(Engineer_Name, value);
				}
			}
		}
		public string EngineerAddress
		{
			get
			{
				return CD16_ht[Engineer_Address].ToString();
			}
			set
			{
				if (CD16_ht.ContainsKey(Engineer_Address))
				{
					CD16_ht[Engineer_Address] = value;
				}
				else
				{
					CD16_ht.Add(Engineer_Address, value);
				}
			}
		}

		#endregion
		public void FillCD16pdfForm(string Path)
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
					foreach (DictionaryEntry Element in CD16_ht)
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
