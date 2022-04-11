using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFEditor
{
    public class AEU20
    {
		#region Global variable
		private Hashtable AEU20_ht = new Hashtable();
		#endregion
		#region Constant variable
		private const string ECB_Violation_No1 = "topmostSubform[0].Page1[0].ECB_violation_number[0]";
		private const string ECB_Violation_No2 = "topmostSubform[0].Page1[0].undefined[0]";
		private const string ECB_Violation_No3 = "topmostSubform[0].Page1[0].undefined_2[0]";
		private const string ECB_Violation_No4 = "topmostSubform[0].Page1[0].undefined_3[0]";
		private const string Place_Of_Occurrence = "topmostSubform[0].Page1[0].Place_of_Occurrence[0]";
		private const string I_Delcaration = "topmostSubform[0].Page1[0].I[0]";
		private const string Respondent = "topmostSubform[0].Page1[0].Respondent[0]";
		private const string Owner_Not_Respondent = "topmostSubform[0].Page1[0].Owner_not_respondent[0]";
		private const string Contractor = "topmostSubform[0].Page1[0].Contractor[0]";
		private const string Respondent_Employee = "topmostSubform[0].Page1[0].Respondent_s_Employee[0]";
		private const string Licensed_Professional = "topmostSubform[0].Page1[0].Licensed_Professional[0]";
		private const string Other_Specify = "topmostSubform[0].Page1[0].Other_specify[0]";
		private const string Other_Specify_Declaration = "topmostSubform[0].Page1[0].undefined_4[0]";
		private const string I_Personally_DeclarationDate = "topmostSubform[0].Page1[0].I_PERSONALLY_performed_the_following_work_to_correct_the_above-cited_ECB_violation_on[0]";
		private const string Describe_Work = "topmostSubform[0].Page1[0].Describe_the_work_performed_if_additional_space_is_needed__use_attached_supplement_form_AEU20S_1[0]";
		private const string Aeu20_Date = "topmostSubform[0].Page1[0].Date[0]";
		private const string Day = "topmostSubform[0].Page1[0].Day[0]";
		private const string Month = "topmostSubform[0].Page1[0].month[0]";
		private const string Year = "topmostSubform[0].Page1[0].year[0]";
		#endregion

		#region Properties
		public string ECB_Violation_No1_Pro
		{
			get
			{
				return AEU20_ht[ECB_Violation_No1].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(ECB_Violation_No1))
				{
					AEU20_ht[ECB_Violation_No1] = value;
				}
				else
				{
					AEU20_ht.Add(ECB_Violation_No1, value);
				}
			}
		}
		public string ECB_Violation_No2_Pro
		{
			get
			{
				return AEU20_ht[ECB_Violation_No2].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(ECB_Violation_No2))
				{
					AEU20_ht[ECB_Violation_No2] = value;
				}
				else
				{
					AEU20_ht.Add(ECB_Violation_No2, value);
				}
			}
		}
		public string ECB_Violation_No3_Pro
		{
			get
			{
				return AEU20_ht[ECB_Violation_No3].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(ECB_Violation_No3))
				{
					AEU20_ht[ECB_Violation_No3] = value;
				}
				else
				{
					AEU20_ht.Add(ECB_Violation_No3, value);
				}
			}
		}
		public string ECB_Violation_No4_Pro
		{
			get
			{
				return AEU20_ht[ECB_Violation_No4].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(ECB_Violation_No4))
				{
					AEU20_ht[ECB_Violation_No4] = value;
				}
				else
				{
					AEU20_ht.Add(ECB_Violation_No4, value);
				}
			}
		}
		public string Place_Of_Occurrence_Pro
		{
			get
			{
				return AEU20_ht[Place_Of_Occurrence].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Place_Of_Occurrence))
				{
					AEU20_ht[Place_Of_Occurrence] = value;
				}
				else
				{
					AEU20_ht.Add(Place_Of_Occurrence, value);
				}
			}
		}
		public string I_Delcaration_Pro
		{
			get
			{
				return AEU20_ht[I_Delcaration].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(I_Delcaration))
				{
					AEU20_ht[I_Delcaration] = value;
				}
				else
				{
					AEU20_ht.Add(I_Delcaration, value);
				}
			}
		}
		public string Respondent_Pro
		{
			get
			{
				return AEU20_ht[Respondent].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Respondent))
				{
					AEU20_ht[Respondent] = value;
				}
				else
				{
					AEU20_ht.Add(Respondent, value);
				}
			}
		}
		public string Owner_Not_Respondent_Pro
		{
			get
			{
				return AEU20_ht[Owner_Not_Respondent].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Owner_Not_Respondent))
				{
					AEU20_ht[Owner_Not_Respondent] = value;
				}
				else
				{
					AEU20_ht.Add(Owner_Not_Respondent, value);
				}
			}
		}
		public string Contractor_Pro
		{
			get
			{
				return AEU20_ht[Contractor].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Contractor))
				{
					AEU20_ht[Contractor] = value;
				}
				else
				{
					AEU20_ht.Add(Contractor, value);
				}
			}
		}
		public string Respondent_Employee_Pro
		{
			get
			{
				return AEU20_ht[Respondent_Employee].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Respondent_Employee))
				{
					AEU20_ht[Respondent_Employee] = value;
				}
				else
				{
					AEU20_ht.Add(Respondent_Employee, value);
				}
			}
		}
		public string Licensed_Professional_Pro
		{
			get
			{
				return AEU20_ht[Licensed_Professional].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Licensed_Professional))
				{
					AEU20_ht[Licensed_Professional] = value;
				}
				else
				{
					AEU20_ht.Add(Licensed_Professional, value);
				}
			}
		}
		public string Other_Specify_Pro
		{
			get
			{
				return AEU20_ht[Other_Specify].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Other_Specify))
				{
					AEU20_ht[Other_Specify] = value;
				}
				else
				{
					AEU20_ht.Add(Other_Specify, value);
				}
			}
		}
		public string Other_Specify_Declaration_Pro
		{
			get
			{
				return AEU20_ht[Other_Specify_Declaration].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Other_Specify_Declaration))
				{
					AEU20_ht[Other_Specify_Declaration] = value;
				}
				else
				{
					AEU20_ht.Add(Other_Specify_Declaration, value);
				}
			}
		}
		public string I_Personally_DeclarationDate_Pro
		{
			get
			{
				return AEU20_ht[I_Personally_DeclarationDate].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(I_Personally_DeclarationDate))
				{
					AEU20_ht[I_Personally_DeclarationDate] = value;
				}
				else
				{
					AEU20_ht.Add(I_Personally_DeclarationDate, value);
				}
			}
		}
		public string Describe_Work_Pro
		{
			get
			{
				return AEU20_ht[Describe_Work].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Describe_Work))
				{
					AEU20_ht[Describe_Work] = value;
				}
				else
				{
					AEU20_ht.Add(Describe_Work, value);
				}
			}
		}
		public string Date_Pro
		{
			get
			{
				return AEU20_ht[Aeu20_Date].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Aeu20_Date))
				{
					AEU20_ht[Aeu20_Date] = value;
				}
				else
				{
					AEU20_ht.Add(Aeu20_Date, value);
				}
			}
		}
		public string Day_Pro
		{
			get
			{
				return AEU20_ht[Day].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Day))
				{
					AEU20_ht[Day] = value;
				}
				else
				{
					AEU20_ht.Add(Day, value);
				}
			}
		}
		public string Month_Pro
		{
			get
			{
				return AEU20_ht[Month].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Month))
				{
					AEU20_ht[Month] = value;
				}
				else
				{
					AEU20_ht.Add(Month, value);
				}
			}
		}
		public string Year_Pro
		{
			get
			{
				return AEU20_ht[Year].ToString();
			}
			set
			{
				if (AEU20_ht.ContainsKey(Year))
				{
					AEU20_ht[Year] = value;
				}
				else
				{
					AEU20_ht.Add(Year, value);
				}
			}
		}

		#endregion
		public void FillAEU2pdfForm(string Path)
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
					foreach (DictionaryEntry Element in AEU20_ht)
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
