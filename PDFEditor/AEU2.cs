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
    public class AEU2
    {
		#region Global Variable
		private Hashtable AEU2_ht = new Hashtable();
		#endregion

		#region Constant Variable
		private const string ECB_Violation_No = "topmostSubform[0].Page1[0].ECB_VIOLATION_NUMBER[0]";
		private const string Place_Of_Occurrence = "topmostSubform[0].Page1[0].PLACE_OF_OCCURRENCE[0]";
		private const string State = "topmostSubform[0].Page1[0].STATE_OF[0]";
		private const string County = "topmostSubform[0].Page1[0].COUNTY_OF[0]";
		private const string I_Declaration = "topmostSubform[0].Page1[0].I[0]";
		private const string Respondent_Name_Violation = "topmostSubform[0].Page1[0].Respondent_named_on_the_violation[0]";
		private const string Office_Director_ManagingAgent_Name = "topmostSubform[0].Page1[0].Officer__Director_or_Managing_Agent_of_the_named_respondent_corporation_circle_one[0]";
		private const string Owner_Of_Properties = "topmostSubform[0].Page1[0].Owner_of_Property_but_not_named_respondent_if_you_are_a_new_owner__attach_copy_of_deed[0]";
		private const string ManagingAgent_Of_Occurence = "topmostSubform[0].Page1[0].Managing_agent_of_place_of_occurrence_attach_letter_of_designation_by_owner[0]";
		private const string Partner_of_Name_Respond = "topmostSubform[0].Page1[0].Partner_of_named_respondent_partnership[0]";
		private const string Contractor_Or_OtherAgent_Responde = "topmostSubform[0].Page1[0].Contractor_or_other_agent_of_named_respondent_attach_written_authorization_from_respondent[0]";
		private const string My_MailingAddress = "topmostSubform[0].Page1[0].My_mailing_address_is[0]";
		private const string StatementWasCompleted = "topmostSubform[0].Page1[0].statement_was_completed_on[0]";
		private const string PerformedWorkerName = "topmostSubform[0].Page1[0].Name_of_person_who_performed_work[0]";
		private const string MySelf = "topmostSubform[0].Page1[0].Myself[0]";
		private const string My_Employee = "topmostSubform[0].Page1[0].My_employee[0]";
		private const string Company = "topmostSubform[0].Page1[0].Company[0]";
		private const string Contractor = "topmostSubform[0].Page1[0].Contractor[0]";
		private const string Address = "topmostSubform[0].Page1[0].Address[0]";
		private const string ArchitectEngineer = "topmostSubform[0].Page1[0].ArchitectEngineer[0]";
		private const string LicenseNo = "topmostSubform[0].Page1[0].License_Registration_No_of_professionallicenseecontractor[0]";
		private const string Borough_ZipCode = "topmostSubform[0].Page1[0].Borough_Zipcode[0]";
		private const string Cure_Submission = "topmostSubform[0].Page1[0].Cure_Submission[0]";
		#endregion

		#region Properties
		public string ECB_Violation_No_Pro
		{
			get
			{
				return AEU2_ht[ECB_Violation_No].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(ECB_Violation_No))
				{
					AEU2_ht[ECB_Violation_No] = value;
				}
				else
				{
					AEU2_ht.Add(ECB_Violation_No, value);
				}
			}
		}
		public string Place_Of_Occurrence_Pro
		{
			get
			{
				return AEU2_ht[Place_Of_Occurrence].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Place_Of_Occurrence))
				{
					AEU2_ht[Place_Of_Occurrence] = value;
				}
				else
				{
					AEU2_ht.Add(Place_Of_Occurrence, value);
				}
			}
		}
		public string State_Pro
		{
			get
			{
				return AEU2_ht[State].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(State))
				{
					AEU2_ht[State] = value;
				}
				else
				{
					AEU2_ht.Add(State, value);
				}
			}
		}
		public string County_Pro
		{
			get
			{
				return AEU2_ht[County].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(County))
				{
					AEU2_ht[County] = value;
				}
				else
				{
					AEU2_ht.Add(County, value);
				}
			}
		}
		public string I_Declaration_Pro
		{
			get
			{
				return AEU2_ht[I_Declaration].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(I_Declaration))
				{
					AEU2_ht[I_Declaration] = value;
				}
				else
				{
					AEU2_ht.Add(I_Declaration, value);
				}
			}
		}
		public string Respondent_Name_Violation_Pro
		{
			get
			{
				return AEU2_ht[Respondent_Name_Violation].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Respondent_Name_Violation))
				{
					AEU2_ht[Respondent_Name_Violation] = value;
				}
				else
				{
					AEU2_ht.Add(Respondent_Name_Violation, value);
				}
			}
		}
		public string Office_Director_ManagingAgent_Name_Pro
		{
			get
			{
				return AEU2_ht[Office_Director_ManagingAgent_Name].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Office_Director_ManagingAgent_Name))
				{
					AEU2_ht[Office_Director_ManagingAgent_Name] = value;
				}
				else
				{
					AEU2_ht.Add(Office_Director_ManagingAgent_Name, value);
				}
			}
		}
		public string Owner_Of_Properties_Pro
		{
			get
			{
				return AEU2_ht[Owner_Of_Properties].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Owner_Of_Properties))
				{
					AEU2_ht[Owner_Of_Properties] = value;
				}
				else
				{
					AEU2_ht.Add(Owner_Of_Properties, value);
				}
			}
		}
		public string ManagingAgent_Of_Occurence_Pro
		{
			get
			{
				return AEU2_ht[ManagingAgent_Of_Occurence].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(ManagingAgent_Of_Occurence))
				{
					AEU2_ht[ManagingAgent_Of_Occurence] = value;
				}
				else
				{
					AEU2_ht.Add(ManagingAgent_Of_Occurence, value);
				}
			}
		}
		public string Partner_of_Name_Respond_Pro
		{
			get
			{
				return AEU2_ht[Partner_of_Name_Respond].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Partner_of_Name_Respond))
				{
					AEU2_ht[Partner_of_Name_Respond] = value;
				}
				else
				{
					AEU2_ht.Add(Partner_of_Name_Respond, value);
				}
			}
		}
		public string Contractor_Or_OtherAgent_Responde_Pro
		{
			get
			{
				return AEU2_ht[Contractor_Or_OtherAgent_Responde].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Contractor_Or_OtherAgent_Responde))
				{
					AEU2_ht[Contractor_Or_OtherAgent_Responde] = value;
				}
				else
				{
					AEU2_ht.Add(Contractor_Or_OtherAgent_Responde, value);
				}
			}
		}
		public string My_MailingAddress_Pro
		{
			get
			{
				return AEU2_ht[My_MailingAddress].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(My_MailingAddress))
				{
					AEU2_ht[My_MailingAddress] = value;
				}
				else
				{
					AEU2_ht.Add(My_MailingAddress, value);
				}
			}
		}
		public string StatementWasCompleted_Pro
		{
			get
			{
				return AEU2_ht[StatementWasCompleted].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(StatementWasCompleted))
				{
					AEU2_ht[StatementWasCompleted] = value;
				}
				else
				{
					AEU2_ht.Add(StatementWasCompleted, value);
				}
			}
		}
		public string PerformedWorkerName_Pro
		{
			get
			{
				return AEU2_ht[PerformedWorkerName].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(PerformedWorkerName))
				{
					AEU2_ht[PerformedWorkerName] = value;
				}
				else
				{
					AEU2_ht.Add(PerformedWorkerName, value);
				}
			}
		}
		public string Borough_ZipCode_Pro
		{
			get
			{
				return AEU2_ht[Borough_ZipCode].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Borough_ZipCode))
				{
					AEU2_ht[Borough_ZipCode] = value;
				}
				else
				{
					AEU2_ht.Add(Borough_ZipCode, value);
				}
			}
		}
		public string Cure_Submission_Pro
		{
			get
			{
				return AEU2_ht[Cure_Submission].ToString();
			}
			set
			{
				if (AEU2_ht.ContainsKey(Cure_Submission))
				{
					AEU2_ht[Cure_Submission] = value;
				}
				else
				{
					AEU2_ht.Add(Cure_Submission, value);
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
					foreach (DictionaryEntry Element in AEU2_ht)
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
