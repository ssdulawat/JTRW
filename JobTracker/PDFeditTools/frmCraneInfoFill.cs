using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using iTextSharp.text.pdf;
using JobTracker.JobTrackingForm;
using JobTracker.PDFeditTools.PDFeditClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.PDFeditTools
{
    public partial class frmCraneInfoFill : Form
    {
        bool bComboNeedToRefill = true;
        #region Constant CD4 data field variable
        //IDictionary<string, string> CD4Constant = new Dictionary<string, string>();
        
        Dictionary<string, string> CD4Constant = new Dictionary<string, string>();
        #endregion

        #region Form Info Table Column name
        private const string JobID = "JobID";
        private const string JobListID = "JobListID";
        private const string JobNumber = "JobNumber";
        private const string ApplicantID = "Applicant";
        private const string JobSiteBlock = "JobSiteBlock";
        private const string JobSiteLot = "JobSiteLot";
        private const string JobSiteCNNum = "JobSiteCNNum";
        private const string JobSiteHouseNum = "JobSiteHouseNum";
        private const string JobSiteStreet = "JobSiteStreet";
        private const string JobSiteBorough = "JobSiteBorough";
        private const string JobSiteState = "JobSiteState";
        private const string Crane1CD = "Crane1CD";
        private const string Crane2CD = "Crane2CD";
        private const string Crane3CD = "Crane3CD";
        private const string Crane4CD = "Crane4CD";
        private const string Crane5CD = "Crane5CD";
        private const string Crane6CD = "Crane6CD";
        private const string CraneUser = "CraneUser";
        private const string CraneUserInfo = "CraneUserInfo";
        private const string CraneUserTitle = "CraneUserTitle";
        private const string WorkPlatformManufacturer = "WorkPlatformManufacturer";
        private const string WorkPlatformModel = "WorkPlatformModel";
        private const string WorkPlatformSuperName = "WorkPlatformSuperName";
        private const string WorkPlatformSuperPhone = "WorkPlatformSuperPhone";
        private const string WorkPlatformSuperFax = "WorkPlatformSuperFax";
        private const string WorkPlatformSuperAddr = "WorkPlatformSuperAddr";
        private const string WorkPlatformSuperCity = "WorkPlatformSuperCity";
        private const string WorkPlatformSuperState = "WorkPlatformSuperState";
        private const string WorkPlatformSuperZip = "WorkPlatformSuperZip";
        private const string FirstVariance = "FirstVariance";
        private const string BIN = "BIN";
        private const string CBNum = "CBNum";
        private const string AptorCondoNum = "AptorCondoNum";
        private const string SpecialPlaceName = "SpecialPlaceName";
        private const string SubName = "SubName";
        private const string SubInfo = "SubInfo";
        private const string ResidenceWithin200ft = "ResidenceWithin200ft";
        private const string DatesofVariance = "DatesofVariance";
        private const string DaysofVariance = "DaysofVariance";
        private const string TimeofVarianceFrom = "TimeofVarianceFrom";
        private const string TimeofVarianceTo = "TimeofVarianceTo";
        private const string VarianceWorkDescription = "VarianceWorkDescription";
        private const string ReasonforVariance = "ReasonforVariance";
        private const string SiteArchitect = "SiteArchitect";
        private const string CommunityBoardID = "CommunityBoardID";
        private const string SiteNumofStories = "SiteNumofStories";
        private const string SiteOccupancy = "SiteOccupancy";
        private const string OccupancyType = "OccupancyType";
        private const string SiteNumofApts = "SiteNumofApts";
        private const string SiteNumofAptsCurrent = "SiteNumofAptsCurrent";
        private const string SiteNumofAptsProposed = "SiteNumofAptsProposed";
        private const string SiteOwner = "SiteOwner";
        private const string SiteOwnerAddress = "SiteOwnerAddress";
        private const string SiteOwnerStreet = "SiteOwnerStreet";
        private const string SiteOwnerCity = "SiteOwnerCity";
        private const string SiteOwnerState = "SiteOwnerState";
        private const string SiteOwnerZip = "SiteOwnerZip";
        private const string WorkProposed = "WorkProposed";
        private const string Architect2 = "Architect2";
        private const string Architect2fullAddress = "Architect2fullAddress";
        private const string IsChange = "IsChange";
        private const string IsNewRecord = "IsNewRecord";
        private const string IsDelete = "IsDelete";
        private const string ChangeDate = "ChangeDate";
        #endregion

        #region VBCDDatabase Constant Variable
        private const string Con_CDID = "CDID";
        private const string Con_CDNumber = "CDNumber";
        private const string Con_SerialNumber = "SerialNumber";
        private const string Con_Make = "Make";
        private const string Con_Model = "Model";
        private const string Con_ModelYear = "ModelYear";
        private const string Con_Capacity = "Capacity";
        private const string Con_Owner = "Owner";
        private const string Con_Expiration = "Expiration";
        private const string Con_ModelSpaceName = "ModelSpaceName";
        private const string Con_Notes = "Notes";
        private const string Con_CraneName = "CraneName";
        private const string Con_CraneID = "CraneID";
        private const string Con_OwnerPhone = "OwnerPhone";
        private const string Con_OwnerFax = "OwnerFax";
        private const string Con_TypMast = "TypMast";
        private const string Con_TypBoom = "TypBoom";
        private const string Con_TypJIB = "TypJIB";
        private const string Con_TypTotal = "TypTotal";
        #endregion

        #region Constant Crane User Info Declaration
        private const string ContactsID = "ContactsID";
        private const string Contact_FirstName = "FirstName";
        private const string Contact_MiddleName = "MiddleName";
        private const string Contact_LastName = "LastName";
        private const string ContactTitle = "ContactTitle";
        private const string Contact_MobilePhone = "MobilePhone";
        private const string Contact_EmailAddress = "EmailAddress";
        private const string Contact_Address = "Address";
        private const string Contact_City = "City";
        private const string Contact_State = "State";
        private const string Contact_ZIP = "PostalCode";
        private const string Contact_Country = "Country";
        private const string Contacts_CompanyName = "CompanyName";
        private const string Contacts_Fax = "FaxNumber";
        #endregion

        #region Properties
        public string AssignApplicantID
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ApplicantID].Value = value;
                    }
                }
            }
        }
        public string AssignCommunityBoardNumber
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneID1
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneID2
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneID3
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneID4
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneID5
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneID6
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value = value;
                    }
                }
            }
        }
        public string AssignSubName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneUser
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value = value;
                    }
                }
            }
        }
        public string AssignCraneUserInfo
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[CraneUserInfo].Value = value;
                    }
                }
            }
        }
        public string AssignCraneUserTitle
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[CraneUserTitle].Value = value;
                    }
                }
            }
        }
        public string AssignSubInfo
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!string.IsNullOrEmpty(value.Trim()))
                    {
                        grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SubInfo].Value = value;
                    }
                }
            }
        }
        #endregion

        public frmCraneInfoFill()
        {
            InitializeComponent();
            CD4Constant.Clear();

            //grdFormInfo.Columns[JobNumber].Visible = false;
           

            CD4Constant.Add("CN_Number", "topmostSubform[0].Page1[0].CN_Number[0]");
            CD4Constant.Add("ApplicationType_New", "topmostSubform[0].Page1[0].ApplicationType_New[0]");
            CD4Constant.Add("ApplicationType_Renewal", "topmostSubform[0].Page1[0].ApplicationType_Renewal[0]");
            CD4Constant.Add("ApplicationType_Amendment", "topmostSubform[0].Page1[0].ApplicationType_Amendment[0]");
            CD4Constant.Add("EquipType_MobileCrane", "topmostSubform[0].Page1[0].EquipType_MobileCrane[0]");
            CD4Constant.Add("EquipType_MobileTowerCrane", "topmostSubform[0].Page1[0].EquipType_MobileTowerCrane[0]");
            CD4Constant.Add("EquipType_Fix_ClimberTower", "topmostSubform[0].Page1[0].EquipType_Fix_ClimberTower[0]");
            CD4Constant.Add("EquipType_Derrick", "topmostSubform[0].Page1[0].EquipType_Derrick[0]");
            CD4Constant.Add("EquipType_MastClimber", "topmostSubform[0].Page1[0].EquipType_MastClimber[0]");
            CD4Constant.Add("EquipType_PileDriver", "topmostSubform[0].Page1[0].EquipType_PileDriver[0]");
            CD4Constant.Add("Borough", "topmostSubform[0].Page1[0].Borough[0]");
            CD4Constant.Add("Block", "topmostSubform[0].Page1[0].Block[0]");
            CD4Constant.Add("Lot", "topmostSubform[0].Page1[0].Lot[0]");
            CD4Constant.Add("Address", "topmostSubform[0].Page1[0].Address[0]");


            //CD4Constant.Add("Job_Number", "topmostSubform[0].Page1[0].Job_Number[0]");
            CD4Constant.Add("Job_No", "topmostSubform[0].Page1[0].Job_No[0]");


            CD4Constant.Add("CD_Number_1", "topmostSubform[0].Page1[0].CD_Number__1[0]");
            CD4Constant.Add("CD_Number_2", "topmostSubform[0].Page1[0].CD_Number__2[0]");
            CD4Constant.Add("CD_Number_3", "topmostSubform[0].Page1[0].CD_Number__3[0]");
            CD4Constant.Add("CD_Number_4", "topmostSubform[0].Page1[0].CD_Number__4[0]");
            CD4Constant.Add("CD_Number_5", "topmostSubform[0].Page1[0].CD_Number__5[0]");
            CD4Constant.Add("CD_Number_6", "topmostSubform[0].Page1[0].CD_Number__6[0]");
            CD4Constant.Add("Serial_Number_1", "topmostSubform[0].Page1[0].Serial_Number__1[0]");
            CD4Constant.Add("Serial_Number_2", "topmostSubform[0].Page1[0].Serial_Number__2[0]");
            CD4Constant.Add("Serial_Number_3", "topmostSubform[0].Page1[0].Serial_Number__3[0]");
            CD4Constant.Add("Serial_Number_4", "topmostSubform[0].Page1[0].Serial_Number__4[0]");
            CD4Constant.Add("Serial_Number_5", "topmostSubform[0].Page1[0].Serial_Number__5[0]");
            CD4Constant.Add("Serial_Number_6", "topmostSubform[0].Page1[0].Serial_Number__6[0]");
            CD4Constant.Add("Expiration_Date_1", "topmostSubform[0].Page1[0].Expiration_Date__1[0]");
            CD4Constant.Add("Expiration_Date_2", "topmostSubform[0].Page1[0].Expiration_Date__2[0]");
            CD4Constant.Add("Expiration_Date_3", "topmostSubform[0].Page1[0].Expiration_Date__3[0]");
            CD4Constant.Add("Expiration_Date_4", "topmostSubform[0].Page1[0].Expiration_Date__4[0]");
            CD4Constant.Add("Expiration_Date_5", "topmostSubform[0].Page1[0].Expiration_Date__5[0]");
            CD4Constant.Add("Expiration_Date_6", "topmostSubform[0].Page1[0].Expiration_Date__6[0]");
            CD4Constant.Add("Mast_ft_1", "topmostSubform[0].Page1[0].Mast_ft__1[0]");
            CD4Constant.Add("Mast_ft_2", "topmostSubform[0].Page1[0].Mast_ft__2[0]");
            CD4Constant.Add("Mast_ft_3", "topmostSubform[0].Page1[0].Mast_ft__3[0]");
            CD4Constant.Add("Mast_ft_4", "topmostSubform[0].Page1[0].Mast_ft__4[0]");
            CD4Constant.Add("Mast_ft_5", "topmostSubform[0].Page1[0].Mast_ft__5[0]");
            CD4Constant.Add("Mast_ft_6", "topmostSubform[0].Page1[0].Mast_ft__6[0]");
            CD4Constant.Add("Boom_ft_1", "topmostSubform[0].Page1[0].Boom_ft__1[0]");
            CD4Constant.Add("Boom_ft_2", "topmostSubform[0].Page1[0].Boom_ft__2[0]");
            CD4Constant.Add("Boom_ft_3", "topmostSubform[0].Page1[0].Boom_ft__3[0]");
            CD4Constant.Add("Boom_ft_4", "topmostSubform[0].Page1[0].Boom_ft__4[0]");
            CD4Constant.Add("Boom_ft_5", "topmostSubform[0].Page1[0].Boom_ft__5[0]");
            CD4Constant.Add("Boom_ft_6", "topmostSubform[0].Page1[0].Boom_ft__6[0]");
            CD4Constant.Add("Jib_ft_1", "topmostSubform[0].Page1[0].Jib_ft__1[0]");
            CD4Constant.Add("Jib_ft_2", "topmostSubform[0].Page1[0].Jib_ft__2[0]");
            CD4Constant.Add("Jib_ft_3", "topmostSubform[0].Page1[0].Jib_ft__3[0]");
            CD4Constant.Add("Jib_ft_4", "topmostSubform[0].Page1[0].Jib_ft__4[0]");
            CD4Constant.Add("Jib_ft_5", "topmostSubform[0].Page1[0].Jib_ft__5[0]");
            CD4Constant.Add("Jib_ft_6", "topmostSubform[0].Page1[0].Jib_ft__6[0]");
            CD4Constant.Add("Total_ft_1", "topmostSubform[0].Page1[0].Total_ft__1[0]");
            CD4Constant.Add("Total_ft_2", "topmostSubform[0].Page1[0].Total_ft__2[0]");
            CD4Constant.Add("Total_ft_3", "topmostSubform[0].Page1[0].Total_ft__3[0]");
            CD4Constant.Add("Total_ft_4", "topmostSubform[0].Page1[0].Total_ft__4[0]");
            CD4Constant.Add("Total_ft_5", "topmostSubform[0].Page1[0].Total_ft__5[0]");
            CD4Constant.Add("Total_ft_6", "topmostSubform[0].Page1[0].Total_ft__6[0]");
            CD4Constant.Add("Appl_Name", "topmostSubform[0].Page1[0].Appl_Name[0]");
            CD4Constant.Add("Appl_Email", "topmostSubform[0].Page1[0].Appl_Email[0]");
            CD4Constant.Add("Appl_Title", "topmostSubform[0].Page1[0].Appl_Title[0]");
            CD4Constant.Add("Appl_Lic_No", "topmostSubform[0].Page1[0].Appl_Lic_No[0]");
            CD4Constant.Add("Appl_Bus_Name", "topmostSubform[0].Page1[0].Appl_Bus_Name[0]");
            CD4Constant.Add("Appl_Address", "topmostSubform[0].Page1[0].Appl_Address[0]");
            CD4Constant.Add("Appl_City", "topmostSubform[0].Page1[0].Appl_City[0]");
            CD4Constant.Add("Appl_State", "topmostSubform[0].Page1[0].Appl_State[0]");
            CD4Constant.Add("Appl_Zip", "topmostSubform[0].Page1[0].Appl_Zip[0]");
            CD4Constant.Add("Appl_Phone", "topmostSubform[0].Page1[0].Appl_Phone[0]");
            CD4Constant.Add("Appl_Fax", "topmostSubform[0].Page1[0].Appl_Fax[0]");
            CD4Constant.Add("MCS_Name", "topmostSubform[0].Page1[0].MCS_Name[0]");
            CD4Constant.Add("MCS_Lic_No", "topmostSubform[0].Page1[0].MCS_Lic_No[0]");
            CD4Constant.Add("MCS_Address", "topmostSubform[0].Page1[0].MCS_Address[0]");
            CD4Constant.Add("MCS_City", "topmostSubform[0].Page1[0].MCS_City[0]");
            CD4Constant.Add("MCS_State", "topmostSubform[0].Page1[0].MCS_State[0]");
            CD4Constant.Add("MCS_Zip", "topmostSubform[0].Page1[0].MCS_Zip[0]");
            CD4Constant.Add("MCS_Phone", "topmostSubform[0].Page1[0].MCS_Phone[0]");
            CD4Constant.Add("MCS_Fax", "topmostSubform[0].Page1[0].MCS_Fax[0]");
            CD4Constant.Add("DateTimeField1", "topmostSubform[0].Page1[0].DateTimeField1[0]");
            CD4Constant.Add("Equip_Name", "topmostSubform[0].Page1[0].Equip_Name[0]");
            CD4Constant.Add("Equip_email", "topmostSubform[0].Page1[0].Equip_email[0]");
            CD4Constant.Add("Equip_Title", "topmostSubform[0].Page1[0].Equip_Title[0]");
            CD4Constant.Add("Equip_Company", "topmostSubform[0].Page1[0].Equip_Company[0]");
            CD4Constant.Add("Equip_Address", "topmostSubform[0].Page1[0].Equip_Address[0]");
            CD4Constant.Add("Equip_City", "topmostSubform[0].Page1[0].Equip_City[0]");
            CD4Constant.Add("Equip_State", "topmostSubform[0].Page1[0].Equip_State[0]");
            CD4Constant.Add("Equip_Zip", "topmostSubform[0].Page1[0].Equip_Zip[0]");
            CD4Constant.Add("Equip_Phone", "topmostSubform[0].Page1[0].Equip_Phone[0]");
            CD4Constant.Add("Equip_Fax", "topmostSubform[0].Page1[0].Equip_Fax[0]");
            CD4Constant.Add("CSC_Name", "topmostSubform[0].Page1[0].CSC_Name[0]");
            CD4Constant.Add("CSC_Lic_No", "topmostSubform[0].Page1[0].CSC_Lic_No[0]");
            CD4Constant.Add("CSC_Address", "topmostSubform[0].Page1[0].CSC_Address[0]");
            CD4Constant.Add("CSC_City", "topmostSubform[0].Page1[0].CSC_City[0]");
            CD4Constant.Add("CSC_State", "topmostSubform[0].Page1[0].CSC_State[0]");
            CD4Constant.Add("CSC_Zip", "topmostSubform[0].Page1[0].CSC_Zip[0]");
            CD4Constant.Add("CSC_Phone", "topmostSubform[0].Page1[0].CSC_Phone[0]");
            CD4Constant.Add("CSC_Fax", "topmostSubform[0].Page1[0].CSC_Fax[0]");
        }

        #region Events
        private void frmCraneInfoFill_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                //tblLayoutpnlParent.RowStyles(0).SizeType = SizeType.Absolute
                tblLayoutpnlParent.SetRowSpan(pnlFormInfo, 4);
                pnlApplicantGrid.Visible = false;
                pnlCommunityBoard.Visible = false;
                pnlCraneInfo.Visible = false;
                tblLayoutpnlParent.RowStyles[1].SizeType = SizeType.Absolute;
                tblLayoutpnlParent.RowStyles[2].SizeType = SizeType.Absolute;
                tblLayoutpnlParent.RowStyles[3].SizeType = SizeType.Absolute;
                fillGridCombo();
                FillInfo();
                
                ///Commented due to it seems not usable. - 16/11/20
                ////////txtJobNumber.Text = "0";
                ////////bComboNeedToRefill = false;
                ////////txtJobNumber.Text = "02";
                ////////txtJobNumber.Text = "0";
                ////////txtJobNumber.Text = "02";
                ////////txtJobNumber.Text = "0";
                ////////txtJobNumber.Text = "02";
                ////////txtJobNumber.Text = "0";
                ////////txtJobNumber.Text = "02";
                ////////txtJobNumber.Text = "0";
                ////////txtJobNumber.Text = "0";
                ////////txtJobNumber.Text = "";
                ////////bComboNeedToRefill = true;
            }
            catch (Exception ex)
            {
            }
        }
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Save")
                {
                    InsertFormInfodata();
                }
                else
                {
                    btnAdd.Text = "Save";
                    AddRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetID(string oldID)
        {
            frmCraneInfo CraneInfo = new frmCraneInfo();
            string id = "";
            try
            {
                CraneInfo.CraneOldID = oldID;
                CraneInfo.ShowDialog();
                if (CraneInfo.SelectCDID != null)
                {
                    if (!string.IsNullOrEmpty(CraneInfo.SelectCDID.ToString()))
                    {
                        id = CraneInfo.SelectCDID;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CraneInfo.Dispose();
            }
            return id;
        }
        private void grdFormInfo_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //Update Here Applicant Info and enter new applicant info from here
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                frmApplicant ApplicantInfo = new frmApplicant();
                ApplicantInfo.ApplicantOldID = grdFormInfo.Rows[e.RowIndex].Cells[ApplicantID].Value.ToString();
                ApplicantInfo.ShowDialog();
                if (ApplicantInfo.SelectApplicationID != null)
                {
                    if (!string.IsNullOrEmpty(ApplicantInfo.SelectApplicationID.ToString()))
                    {
                        AssignApplicantID = ApplicantInfo.SelectApplicationID;
                    }
                }
            }
            //Update here community board num  and enter new community board info from here
            if (e.ColumnIndex == 33 && e.RowIndex > -1)
            {
                frmCommunityBoard CommunityBoradFrm = new frmCommunityBoard();
                CommunityBoradFrm.CommunityBoardOldNum = grdFormInfo.Rows[e.RowIndex].Cells[btnGrdCBNum.Name].Value.ToString();
                CommunityBoradFrm.ShowDialog();
                if (CommunityBoradFrm.SelectCommunityBoardNum != null)
                {
                    if (!string.IsNullOrEmpty(CommunityBoradFrm.SelectCommunityBoardNum.ToString()))
                    {
                        AssignCommunityBoardNumber = CommunityBoradFrm.SelectCommunityBoardNum;
                    }
                }
            }
            // Uopdate here Crane1,Crane2,crane3,crane4,crane5,crane6 cd id and insert new crane Cd from here and assign new id to forminfo record
            if (e.ColumnIndex == 13 && e.RowIndex > -1)
            {
                AssignCraneID1 = GetID(grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCrane1.Name].Value.ToString());
            }
            if (e.ColumnIndex == 14 && e.RowIndex > -1)
            {
                AssignCraneID2 = GetID(grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCrane2.Name].Value.ToString());
            }
            if (e.ColumnIndex == 15 && e.RowIndex > -1)
            {
                AssignCraneID3 = GetID(grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCrane3.Name].Value.ToString());
            }
            if (e.ColumnIndex == 16 && e.RowIndex > -1)
            {
                AssignCraneID4 = GetID(grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCrane4.Name].Value.ToString());
            }
            if (e.ColumnIndex == 17 && e.RowIndex > -1)
            {
                AssignCraneID5 = GetID(grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCrane5.Name].Value.ToString());
            }
            if (e.ColumnIndex == 18 && e.RowIndex > -1)
            {
                AssignCraneID6 = GetID(grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCrane6.Name].Value.ToString());
            }
            //Crane User
            if (e.ColumnIndex == 19 && e.RowIndex > -1)
            {
                frmCraneUser_subInfo CraneUserInfo = new frmCraneUser_subInfo();
                CraneUserInfo.CraneUser_SubOldID = grdFormInfo.Rows[e.RowIndex].Cells[grdBtnCraneUser.Name].Value.ToString();
                CraneUserInfo.ShowDialog();
                if (CraneUserInfo.SelectCraneUser_SubID != null)
                {
                    if (!string.IsNullOrEmpty(CraneUserInfo.SelectCraneUser_SubID.ToString()))
                    {
                        AssignCraneUser = CraneUserInfo.SelectCraneUser_SubID;
                        AssignCraneUserInfo = CraneUserInfo.CraneUser_SubInfo;
                        AssignCraneUserTitle = CraneUserInfo.CraneUserTitle;
                    }
                }
                CraneUserInfo.Dispose();
            }
            //Sub user
            if (e.ColumnIndex == 36 && e.RowIndex > -1)
            {
                frmCraneUser_subInfo SubNameInfo = new frmCraneUser_subInfo();
                SubNameInfo.CraneUser_SubOldID = grdFormInfo.Rows[e.RowIndex].Cells[grdBtnSubName.Name].Value.ToString();
                SubNameInfo.ShowDialog();
                if (SubNameInfo.SelectCraneUser_SubID != null)
                {
                    if (!string.IsNullOrEmpty(SubNameInfo.SelectCraneUser_SubID.ToString()))
                    {
                        AssignSubName = SubNameInfo.SelectCraneUser_SubID;
                        AssignSubInfo = SubNameInfo.CraneUser_SubInfo;
                    }
                }
                SubNameInfo.Dispose();
            }

            //ColumnFirstVariance
            if (e.ColumnIndex == 31 && e.RowIndex > -1)
            {               
                grdFormInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;                
                //DataGridViewCheckBoxColumn DGCB = new DataGridViewCheckBoxColumn();
                //MessageBox.Show(grdFormInfo.Columns [31].HeaderText .ToString ());
            }

            //First
            if (e.ColumnIndex == 38 && e.RowIndex > -1)
            {
                grdFormInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }


            RefreshdependedGrid();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //fillGridCombo();
                //FillInfo();
                //btnAdd.Text = "Insert";

              
                FillInfo();
                btnAdd.Text = "Insert";


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void grdFormInfo_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                if (btnAdd.Text == "Save")
                {
                    InsertFormInfodata();
                }
                else
                {
                    UpdateFormInfo();
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                try
                {
                    //PdfEditTableBindingSourceCDinfo.Filter = "CDID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString() + " OR CDID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString() + " OR CDID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString() + " OR CDID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString() + " OR CDID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString() + " OR CDID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString()
                    //If (grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString() <> String.Empty) Then
                    //    PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString()
                    //Else
                    //    PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=0"
                    //End If
                    //PdfEditTableBindingSourceApplicationInfo.Filter = "ApplicantID=" & grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString()
                    RefreshdependedGrid();
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message);
                }
            }
        }
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                DeleteForminfoRecord();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            
        }
        private void grdFormInfo_RowHeaderMouseDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            try
            {
                PdfEditTableBindingSourceCDinfo.Filter = "CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString() + " OR CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString() + " OR CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString() + " OR CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString() + " OR CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString() + " OR CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString();
                if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString()))
                {
                    PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString();
                }
                else
                {
                    PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=0";
                }
                PdfEditTableBindingSourceApplicationInfo.Filter = "ApplicantID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
        private void btnCD4_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //Source File stream declare here where the pickup the source file to read
                // Dim ownerpassword() As Byte = System.Text.Encoding.ASCII.GetBytes("VE1")
                PdfReader pdfRDR = new PdfReader(Application.StartupPath + "\\PdfFile\\CD4.pdf");
                //Save open file dialouge declare here to save generated pdf to destination derive
                
                SaveFileDialog pdfSave = new SaveFileDialog();

                if (Directory.Exists("N:"))
                {
                    pdfSave.InitialDirectory = "N:";
                }
                else
                {
                    pdfSave.InitialDirectory = "C:";
                }


           

                pdfSave.Filter = "PDF file|*.pdf";
                //Data Access class object
                DataTable CDtable = new DataTable();
                if (pdfSave.ShowDialog() == DialogResult.OK)
                {
                    PdfStamper pdfStm = new PdfStamper(pdfRDR, new FileStream(pdfSave.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite), '\0', true);
                    //Declare form field nmae colletion from pdf file
                    AcroFields AF = pdfStm.AcroFields;
                    
                    AF.SetField(CD4Constant["CD_Number_1"], "1256");

                    //AF.SetField(CD_Number_1, "1256")

                    //If grdFormInfo.Rows.Count > 0 Then
                    //    AF.SetField(Job_No, grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobNumber).Value.ToString())
                    //    AF.SetField(Address, grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobSiteHouseNum).Value.ToString() + " " + grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobSiteStreet).Value.ToString() + " " + grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobSiteState).Value.ToString())
                    //End If

                    //MessageBox.Show("1");


                    //string Query = "SELECT     VBFormInfo.JobID, VBFormInfo.JobListID, VBFormInfo.Applicant,JobList.JobNumber, VBFormInfo.JobSiteBlock, VBFormInfo.JobSiteLot, VBFormInfo.JobSiteCNNum,   VBFormInfo.JobSiteHouseNum, VBFormInfo.JobSiteStreet, VBFormInfo.JobSiteBorough, VBFormInfo.JobSiteState, VBFormInfo.Crane1CD, VBFormInfo.Crane2CD,     VBFormInfo.Crane3CD, VBFormInfo.Crane4CD, VBFormInfo.Crane5CD, VBFormInfo.Crane6CD, VBFormInfo.CraneUser, VBFormInfo.CraneUserInfo,   VBFormInfo.CraneUserTitle, VBFormInfo.WorkPlatformManufacturer, VBFormInfo.WorkPlatformModel, VBFormInfo.WorkPlatformSuperName,      VBFormInfo.WorkPlatformSuperPhone, VBFormInfo.WorkPlatformSuperFax, VBFormInfo.WorkPlatformSuperAddr, VBFormInfo.WorkPlatformSuperCity,        VBFormInfo.WorkPlatformSuperState, VBFormInfo.WorkPlatformSuperZip, VBFormInfo.FirstVariance, VBFormInfo.BIN, VBFormInfo.CBNum,   VBFormInfo.AptorCondoNum, VBFormInfo.SpecialPlaceName, VBFormInfo.SubName, VBFormInfo.SubInfo, VBFormInfo.ResidenceWithin200ft,  VBFormInfo.DatesofVariance, VBFormInfo.DaysofVariance, VBFormInfo.TimeofVarianceFrom, VBFormInfo.TimeofVarianceTo, VBFormInfo.VarianceWorkDescription,   VBFormInfo.ReasonforVariance, VBFormInfo.SiteArchitect,  VBFormInfo.SiteNumofStories, VBFormInfo.SiteOccupancy,  VBFormInfo.OccupancyType, VBFormInfo.SiteNumofApts, VBFormInfo.SiteNumofAptsCurrent, VBFormInfo.SiteNumofAptsProposed, VBFormInfo.SiteOwner,    VBFormInfo.SiteOwnerAddress, VBFormInfo.SiteOwnerStreet, VBFormInfo.SiteOwnerCity, VBFormInfo.SiteOwnerState, VBFormInfo.SiteOwnerZip,  VBFormInfo.WorkProposed, VBFormInfo.Architect2, VBFormInfo.Architect2fullAddress, VBFormInfo.PDFType FROM         VBFormInfo INNER JOIN                      JobList ON VBFormInfo.JobListID = JobList.JobListID WHERE     (VBFormInfo.IsDelete = 0 OR   VBFormInfo.IsDelete IS NULL)";


                  

                    if (grdFormInfo.Rows.Count > 0)
                    {



                        //grdFormInfo.Columns[JobNumber].Visible = false;
                        //CD4Constant.Add("JobNumber", "topmostSubform[0].Page1[0].JobNumber[0]");



                        //AF.SetField(CD4Constant["Job_Number"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobNumber].Value.ToString());

                        AF.SetField(CD4Constant["Job_No"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobNumber].Value.ToString());

                        //MessageBox.Show(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobNumber].Value.ToString());

                        //If grdFormInfo.Rows.Count > 0 Then
                        //    AF.SetField(Job_No, grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobNumber).Value.ToString())
                        //    AF.SetField(Address, grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobSiteHouseNum).Value.ToString() + " " + grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobSiteStreet).Value.ToString() + " " + grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(JobSiteState).Value.ToString())
                        //End If

                        //AF.SetField(CD4Constant["Job_No"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobNumber].Value.ToString());
                        //AF.SetField(CD4Constant["Address"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString());

                        AF.SetField(CD4Constant["Address"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString());


                        //MessageBox.Show(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString());
                        //MessageBox.Show(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString());
                        //MessageBox.Show(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString());

                    }

                   

                    if (grdFormInfo.Rows.Count > 0)
                    {

                        //MessageBox.Show("2");

                        AF.SetField(CD4Constant["CN_Number"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteCNNum].Value.ToString());
                        AF.SetField(CD4Constant["Borough"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString());
                        AF.SetField(CD4Constant["Block"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString());
                        AF.SetField(CD4Constant["Lot"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Address"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperAddr].Value.ToString());
                        AF.SetField(CD4Constant["MCS_City"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperCity].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Fax"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperFax].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Name"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperPhone].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Phone"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperPhone].Value.ToString());
                        AF.SetField(CD4Constant["MCS_State"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperState].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Zip"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperZip].Value.ToString());
                    }

                    //MessageBox.Show("3");

                    //MessageBox.Show("Application Info rows => " , grdApplicantInfo.Rows.Count.ToString());

                    if (grdApplicantInfo.Rows.Count > 0)
                    {



                        //string ApplicantName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();



                        //MessageBox.Show(grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString());

                        //MessageBox.Show(grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString());

                        //MessageBox.Show(grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString());

                        string ApplicantName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();


                        //Dim ApplicantName As String = grdApplicantInfo.Rows(grdApplicantInfo.CurrentRow.Index).Cells(ApplicantFirstNameDataGridViewTextBoxColumn.Name).Value.ToString() + " " + grdApplicantInfo.Rows(grdApplicantInfo.CurrentRow.Index).Cells(ApplicantMidNameDataGridViewTextBoxColumn.Name).Value.ToString() + " " + grdApplicantInfo.Rows(grdApplicantInfo.CurrentRow.Index).Cells(ApplicantLastNameDataGridViewTextBoxColumn.Name).Value.ToString()

                        //AF.SetField(Appl_Name, ApplicantName)

                        //MessageBox.Show(ApplicantName.ToString());

                        AF.SetField(CD4Constant["Appl_Name"], ApplicantName);

                        AF.SetField(CD4Constant["Appl_Address"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString());

                        //AF.SetField(CD4Constant["Appl_Address"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString());

                        AF.SetField(CD4Constant["Appl_Bus_Name"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn5.Name].Value.ToString());

                        //AF.SetField(CD4Constant["Appl_Bus_Name"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessNameDataGridViewTextBoxColumn.Name].Value.ToString());

                        AF.SetField(CD4Constant["Appl_City"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString());

                        //AF.SetField(CD4Constant["Appl_City"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString());



                        AF.SetField(CD4Constant["Appl_State"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString());

                        //AF.SetField(CD4Constant["Appl_State"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString());

                        AF.SetField(CD4Constant["Appl_Lic_No"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn11.Name].Value.ToString());


                        //AF.SetField(CD4Constant["Appl_Lic_No"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLicenseDataGridViewTextBoxColumn.Name].Value.ToString());


                        AF.SetField(CD4Constant["Appl_Fax"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn7.Name].Value.ToString());


                        //AF.SetField(CD4Constant["Appl_Fax"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString());



                        AF.SetField(CD4Constant["Appl_Phone"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn12.Name].Value.ToString());


                        //AF.SetField(CD4Constant["Appl_Phone"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantPhoneDataGridViewTextBoxColumn.Name].Value.ToString());


                        AF.SetField(CD4Constant["Appl_Zip"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn9.Name].Value.ToString());

                        //AF.SetField(CD4Constant["Appl_Zip"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantBusinessZipDataGridViewTextBoxColumn.Name].Value.ToString());


                        AF.SetField(CD4Constant["Appl_Title"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn10.Name].Value.ToString());

                        //AF.SetField(CD4Constant["Appl_Title"], grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantTitleDataGridViewTextBoxColumn.Name].Value.ToString());


                    }


                    //MessageBox.Show("4");

                    if (grdFormInfo.Rows.Count > 0)
                    {
                        if (grdFormInfo.CurrentRow.Cells["grdBtnSubName"].Value.ToString() != "0")
                        {
                            DataTable EquipmentUserTable1 = new DataTable();

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                            //    EquipmentUserTable1 = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                            //}


                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                                    EquipmentUserTable1 = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                                }

                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                                    EquipmentUserTable1 = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                                }

                            }

                            if (EquipmentUserTable1.Rows.Count > 0)
                            {
                                DataRow Dr = EquipmentUserTable1.Rows[0];
                                AF.SetField(CD4Constant["CSC_Name"], Dr[Contact_FirstName].ToString() + " " + Dr[Contact_MiddleName].ToString() + " " + Dr[Contact_LastName].ToString());
                                AF.SetField(CD4Constant["CSC_Address"], Dr[Contact_Address].ToString());
                                AF.SetField(CD4Constant["CSC_City"], Dr[Contact_City].ToString());
                                AF.SetField(CD4Constant["CSC_State"], Dr[Contact_State].ToString());
                                AF.SetField(CD4Constant["CSC_Zip"], Dr[Contact_ZIP].ToString());
                                AF.SetField(CD4Constant["CSC_Phone"], Dr[Contact_MobilePhone].ToString());
                                AF.SetField(CD4Constant["CSC_Fax"], Convert.ToString(Dr[Contacts_Fax]));
                            }
                        }
                    }

                    //MessageBox.Show("5");

                    //Crane 1 data
                    if (grdCraneInfo.Rows.Count > 0)
                    {

                        //If grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(grdBtnCrane1.Name).Value.ToString() <> String.Empty Then
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" & grdFormInfo.Rows(grdFormInfo.CurrentRow.Index).Cells(grdBtnCrane1.Name).Value.ToString())
                        //Else
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0")
                        //End If

                        GetCraneData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString(), ref AF, "1");



                        //if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString()))
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString());
                        //}
                        //else
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0");
                        //}
                        //if (CDtable.Rows.Count > 0)
                        //{
                        //    AF.SetField(CD4Constant["CD_Number_1"], CDtable.Rows[0][Con_CDNumber].ToString());
                        //    AF.SetField(CD4Constant["Serial_Number_1"], CDtable.Rows[0][Con_SerialNumber].ToString());
                        //    AF.SetField(CD4Constant["Expiration_Date_1"], CDtable.Rows[0][Con_Expiration].ToString());
                        //    AF.SetField(CD4Constant["Mast_ft_1"], CDtable.Rows[0][Con_TypMast].ToString());
                        //    AF.SetField(CD4Constant["Boom_ft_1"], CDtable.Rows[0][Con_TypBoom].ToString());
                        //    AF.SetField(CD4Constant["Jib_ft_1"], CDtable.Rows[0][Con_TypJIB].ToString());
                        //    AF.SetField(CD4Constant["Total_ft_1"], CDtable.Rows[0][Con_TypTotal].ToString());
                        //}
                    }
                    //Crane2 data

                    //MessageBox.Show("6");

                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        GetCraneData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString(), ref AF, "2");
                        //if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString()))
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString());
                        //}
                        //else
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0");
                        //}
                        //if (CDtable.Rows.Count > 0)
                        //{
                        //    AF.SetField(CD4Constant["CD_Number_2"], CDtable.Rows[0][Con_CDNumber].ToString());
                        //    AF.SetField(CD4Constant["Serial_Number_2"], CDtable.Rows[0][Con_SerialNumber].ToString());
                        //    AF.SetField(CD4Constant["Expiration_Date_2"], CDtable.Rows[0][Con_Expiration].ToString());
                        //    AF.SetField(CD4Constant["Mast_ft_2"], CDtable.Rows[0][Con_TypMast].ToString());
                        //    AF.SetField(CD4Constant["Boom_ft_2"], CDtable.Rows[0][Con_TypBoom].ToString());
                        //    AF.SetField(CD4Constant["Jib_ft_2"], CDtable.Rows[0][Con_TypJIB].ToString());
                        //    AF.SetField(CD4Constant["Total_ft_2"], CDtable.Rows[0][Con_TypTotal].ToString());
                        //}
                    }
                    //Crane3 data

                    //MessageBox.Show("7");

                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        GetCraneData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString(), ref AF, "3");
                        //if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString()))
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString());
                        //}
                        //else
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0");
                        //}
                        //if (CDtable.Rows.Count > 0)
                        //{
                        //    AF.SetField(CD4Constant["CD_Number_3, CDtable.Rows[0][Con_CDNumber].ToString());
                        //    AF.SetField(CD4Constant["CD_Number_3, CDtable.Rows[0][Con_SerialNumber].ToString());
                        //    AF.SetField(CD4Constant["Expiration_Date_3, CDtable.Rows[0][Con_Expiration].ToString());
                        //    AF.SetField(CD4Constant["Mast_ft_3, CDtable.Rows[0][Con_TypMast].ToString());
                        //    AF.SetField(Boom_ft_3, CDtable.Rows[0][Con_TypBoom].ToString());
                        //    AF.SetField(Jib_ft_3, CDtable.Rows[0][Con_TypJIB].ToString());
                        //    AF.SetField(Total_ft_3, CDtable.Rows[0][Con_TypTotal].ToString());
                        //}
                    }
                    //Crane4 data

                    //MessageBox.Show("8");

                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        GetCraneData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString(), ref AF, "4");
                        //if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString()))
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString());
                        //}
                        //else
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0");
                        //}
                        //if (CDtable.Rows.Count > 0)
                        //{
                        //    AF.SetField(CD4Constant["CD_Number_4, CDtable.Rows[0][Con_CDNumber].ToString());
                        //    AF.SetField(CD4Constant["CD_Number_4, CDtable.Rows[0][Con_SerialNumber].ToString());
                        //    AF.SetField(CD4Constant["Expiration_Date_4, CDtable.Rows[0][Con_Expiration].ToString());
                        //    AF.SetField(CD4Constant["Mast_ft_4, CDtable.Rows[0][Con_TypMast].ToString());
                        //    AF.SetField(Boom_ft_4, CDtable.Rows[0][Con_TypBoom].ToString());
                        //    AF.SetField(Jib_ft_4, CDtable.Rows[0][Con_TypJIB].ToString());
                        //    AF.SetField(Total_ft_4, CDtable.Rows[0][Con_TypTotal].ToString());
                        //}
                    }
                    //crane5 data

                    //MessageBox.Show("9");

                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        GetCraneData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString(), ref AF, "5");
                        //if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString()))
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString());
                        //}
                        //else
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0");
                        //}
                        //if (CDtable.Rows.Count > 0)
                        //{
                        //    AF.SetField(CD4Constant["CD_Number_5"], CDtable.Rows[0][Con_CDNumber].ToString());
                        //    AF.SetField(CD4Constant["Serial_Number_5"], CDtable.Rows[0][Con_SerialNumber].ToString());
                        //    AF.SetField(CD4Constant["Expiration_Date_5"], CDtable.Rows[0][Con_Expiration].ToString());
                        //    AF.SetField(CD4Constant["Mast_ft_5"], CDtable.Rows[0][Con_TypMast].ToString());
                        //    AF.SetField(CD4Constant["Boom_ft_5"], CDtable.Rows[0][Con_TypBoom].ToString());
                        //    AF.SetField(CD4Constant["Jib_ft_5"], CDtable.Rows[0][Con_TypJIB].ToString());
                        //    AF.SetField(CD4Constant["Total_ft_5"], CDtable.Rows[0][Con_TypTotal].ToString());
                        //}
                    }
                    //Crane6 data

                    //MessageBox.Show("10");

                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        GetCraneData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString(), ref AF, "6");
                        //if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString()))
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString());
                        //}
                        //else
                        //{
                        //    CDtable = DAL.Filldatatable("SELECT * FROM VBCDDatabase WHERE CDID=0");
                        //}
                        //if (CDtable.Rows.Count > 0)
                        //{
                        //    AF.SetField(CD4Constant["CD_Number_6"], CDtable.Rows[0][Con_CDNumber].ToString());
                        //    AF.SetField(CD4Constant["Serial_Number_6"], CDtable.Rows[0][Con_SerialNumber].ToString());
                        //    AF.SetField(CD4Constant["Expiration_Date_6"], CDtable.Rows[0][Con_Expiration].ToString());
                        //    AF.SetField(CD4Constant["Mast_ft_6"], CDtable.Rows[0][Con_TypMast].ToString());
                        //    AF.SetField(CD4Constant["Boom_ft_6"], CDtable.Rows[0][Con_TypBoom].ToString());
                        //    AF.SetField(CD4Constant["Jib_ft_6"], CDtable.Rows[0][Con_TypJIB].ToString());
                        //    AF.SetField(CD4Constant["Total_ft_6"], CDtable.Rows[0][Con_TypTotal].ToString());
                        //}
                    }
                    GetEquipmenData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value.ToString(), ref AF, "Equip");
                    //DataTable EquipmentUserTable = new DataTable();
                    //EquipmentUserTable = DAL.Filldatatable(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value.ToString());
                    //if (EquipmentUserTable.Rows.Count > 0)
                    //{
                    //    DataRow Dr = EquipmentUserTable.Rows[0];
                    //    AF.SetField(CD4Constant["Equip_Name"], Dr[Contact_FirstName].ToString() + " " + Dr[Contact_MiddleName].ToString() + " " + Dr[Contact_LastName].ToString());
                    //    AF.SetField(CD4Constant["Equip_Title"], Dr[ContactTitle].ToString());
                    //    AF.SetField(CD4Constant["Equip_Company"], Dr[Contacts_CompanyName].ToString());
                    //    AF.SetField(CD4Constant["Equip_Address"], Dr[Contact_Address].ToString());
                    //    AF.SetField(CD4Constant["Equip_City"], Dr[Contact_City].ToString());
                    //    AF.SetField(CD4Constant["Equip_State"], Dr[Contact_State].ToString());
                    //    AF.SetField(CD4Constant["Equip_Zip"], Dr[Contact_ZIP].ToString());
                    //    AF.SetField(CD4Constant["Equip_Phone"], Dr[Contact_MobilePhone].ToString());
                    //    AF.SetField(CD4Constant["Equip_Fax"], Convert.ToString(Dr[Contacts_Fax]));
                    //}

                    GetEquipmenData(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString(), ref AF, "CSC");
                    //EquipmentUserTable = DAL.Filldatatable(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString());
                    //if (EquipmentUserTable.Rows.Count > 0)
                    //{
                    //    DataRow Dr = EquipmentUserTable.Rows[0];
                    //    AF.SetField(CD4Constant["CSC_Name"], Dr[Contact_FirstName].ToString() + " " + Dr[Contact_MiddleName].ToString() + " " + Dr[Contact_LastName].ToString());
                    //    //AF.SetField(CSC_Title, Dr(ContactTitle).ToString())
                    //    //AF.SetField(CD4Constant["Equip_Company"], Dr(Contacts_CompanyName).ToString())
                    //    AF.SetField(CD4Constant["CSC_Address"], Dr[Contact_Address].ToString());
                    //    AF.SetField(CD4Constant["CSC_City"], Dr[Contact_City].ToString());
                    //    AF.SetField(CD4Constant["CSC_State"], Dr[Contact_State].ToString());
                    //    AF.SetField(CD4Constant["CSC_Zip"], Dr[Contact_ZIP].ToString());
                    //    AF.SetField(CD4Constant["CSC_Phone"], Dr[Contact_MobilePhone].ToString());
                    //    AF.SetField(CD4Constant["CSC_Fax"], Convert.ToString(Dr[Contacts_Fax]));
                    //}
                    if (grdFormInfo.Rows.Count > 0)
                    {
                        AF.SetField(CD4Constant["MCS_Name"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperName].Value.ToString());
                        //AF.SetField(MCS_Lic_No, grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString())
                        AF.SetField(CD4Constant["MCS_Address"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperAddr].Value.ToString());
                        AF.SetField(CD4Constant["MCS_City"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperCity].Value.ToString());
                        AF.SetField(CD4Constant["MCS_State"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperState].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Zip"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperZip].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Phone"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperPhone].Value.ToString());
                        AF.SetField(CD4Constant["MCS_Fax"], grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperFax].Value.ToString());
                    }
                    pdfStm.FormFlattening = false;
                    pdfRDR.Close();
                    pdfStm.Close();
                    Process.Start(pdfSave.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CD Pdf", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void GetEquipmenData(string sWhereClause, ref AcroFields AF, string dataType)
        {
            DataTable EquipmentUserTable = new DataTable();
            try
            {
                string query = frmCraneUser_subInfo.Query + " AND ContactsID=" + sWhereClause;

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<CraneUser>(query).ToList();
                //    EquipmentUserTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<CraneUser>(query).ToList();
                        EquipmentUserTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<CraneUser>(query).ToList();
                        EquipmentUserTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                    }

                }

                if (EquipmentUserTable.Rows.Count > 0)
                {
                    DataRow Dr = EquipmentUserTable.Rows[0];
                    AF.SetField(CD4Constant[dataType + "_Name"], Dr[Contact_FirstName].ToString() + " " + Dr[Contact_MiddleName].ToString() + " " + Dr[Contact_LastName].ToString());
                    if (dataType.Contains("Equip"))
                    {
                        AF.SetField(CD4Constant[dataType + "_Title"], Dr[ContactTitle].ToString());
                        AF.SetField(CD4Constant[dataType + "_Company"], Dr[Contacts_CompanyName].ToString());
                    }
                    AF.SetField(CD4Constant[dataType + "_Address"], Dr[Contact_Address].ToString());
                    AF.SetField(CD4Constant[dataType + "_City"], Dr[Contact_City].ToString());
                    AF.SetField(CD4Constant[dataType + "_State"], Dr[Contact_State].ToString());
                    AF.SetField(CD4Constant[dataType + "_Zip"], Dr[Contact_ZIP].ToString());
                    AF.SetField(CD4Constant[dataType + "_Phone"], Dr[Contact_MobilePhone].ToString());
                    AF.SetField(CD4Constant[dataType + "_Fax"], Convert.ToString(Dr[Contacts_Fax]));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (EquipmentUserTable != null)
                {
                    EquipmentUserTable.Clear();
                    EquipmentUserTable.Dispose();
                    EquipmentUserTable = null;
                }
            }
        }

        private void GetCraneData(string CDIDValue, ref AcroFields AF, string cNumber)
        {
            DataTable CDtable = new DataTable();
            try
            {
                string query = "SELECT * FROM VBCDDatabase WHERE CDID=";
                query += (!string.IsNullOrEmpty(CDIDValue)) ? CDIDValue : "0";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    //var data = db.Database.SqlQuery<CraneUser>(query).ToList();
                //    //CDtable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);

                //    var data = db.Database.SqlQuery<CDInfoData2>(query).ToList();
                //    CDtable = Program.ToDataTable<CDInfoData2>((List<CDInfoData2>)data);



                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        //var data = db.Database.SqlQuery<CraneUser>(query).ToList();
                        //CDtable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);

                        var data = db.Database.SqlQuery<CDInfoData2>(query).ToList();
                        CDtable = Program.ToDataTable<CDInfoData2>((List<CDInfoData2>)data);



                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        //var data = db.Database.SqlQuery<CraneUser>(query).ToList();
                        //CDtable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);

                        var data = db.Database.SqlQuery<CDInfoData2>(query).ToList();
                        CDtable = Program.ToDataTable<CDInfoData2>((List<CDInfoData2>)data);



                    }
                }

                if (CDtable.Rows.Count > 0)
                {
                    AF.SetField(CD4Constant["CD_Number_" + cNumber], CDtable.Rows[0][Con_CDNumber].ToString());
                    AF.SetField(CD4Constant["Serial_Number_" + cNumber], CDtable.Rows[0][Con_SerialNumber].ToString());
                    AF.SetField(CD4Constant["Expiration_Date_" + cNumber], CDtable.Rows[0][Con_Expiration].ToString());
                    AF.SetField(CD4Constant["Mast_ft_" + cNumber], CDtable.Rows[0][Con_TypMast].ToString());
                    AF.SetField(CD4Constant["Boom_ft_" + cNumber], CDtable.Rows[0][Con_TypBoom].ToString());
                    AF.SetField(CD4Constant["Jib_ft_" + cNumber], CDtable.Rows[0][Con_TypJIB].ToString());
                    AF.SetField(CD4Constant["Total_ft_" + cNumber], CDtable.Rows[0][Con_TypTotal].ToString());
                }

                    //If CDtable.Rows.Count > 0 Then
                    //     With CDtable
                    //            AF.SetField(CD_Number_1, .Rows(0).Item(Con_CDNumber).ToString())
                    //            AF.SetField(Serial_Number_1, .Rows(0).Item(Con_SerialNumber).ToString())
                    //            AF.SetField(Expiration_Date_1, .Rows(0).Item(Con_Expiration).ToString())
                    //            AF.SetField(Mast_ft_1, .Rows(0).Item(Con_TypMast).ToString())
                    //            AF.SetField(Boom_ft_1, .Rows(0).Item(Con_TypBoom).ToString())
                    //            AF.SetField(Jib_ft_1, .Rows(0).Item(Con_TypJIB).ToString())
                    //            AF.SetField(Total_ft_1, .Rows(0).Item(Con_TypTotal).ToString())
                    //        End With

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (CDtable != null)
                {
                    CDtable.Clear();
                    CDtable.Dispose();
                    CDtable = null;
                }
            }
        }

        private void btnPW5_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\PW5.pdf";
            //Dim Path As String = "D:\Extracted Page of PDF file\cd8.pdf"
            PW5class.LocationInfo_StreetName = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            PW5class.LocationInfo_Block = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString();
            PW5class.LocationInfo_Borough = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            PW5class.LocationInfo_Lot = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString();
            PW5class.LocationInfo_Bin = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[BIN].Value.ToString();
            PW5class.LocationInfo_Apt_Condono = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[AptorCondoNum].Value.ToString();
            PW5class.LocationInfo_CBNO = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString();
            PW5class.LocationInfo_HouseNo = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                PW5class.Contractor_FirstName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn2.Name].Value.ToString();

                //PW5class.Contractor_FirstName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString();


                PW5class.Contractor_MiddelName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn4.Name].Value.ToString();


                //PW5class.Contractor_MiddelName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString();



                PW5class.Contractor_LastName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn3.Name].Value.ToString();

                //PW5class.Contractor_LastName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                //PW5class.Contractor_BusinessName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessNameDataGridViewTextBoxColumn.Name].Value.ToString();

                PW5class.Contractor_BusinessName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn5.Name].Value.ToString();


                PW5class.Contractor_BusinessAddress = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn6.Name].Value.ToString();

                //PW5class.Contractor_BusinessAddress = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();


                PW5class.Contractor_BusinessFax = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn13.Name].Value.ToString();

                //PW5class.Contractor_BusinessFax = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantfaxDataGridViewTextBoxColumn.Name].Value.ToString();

                PW5class.Contractor_City = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn7.Name].Value.ToString();


                //PW5class.Contractor_City = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString();



                PW5class.Contractor_State = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn8.Name].Value.ToString();


                //PW5class.Contractor_State = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                PW5class.Contractor_BusinessTelephone = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn12.Name].Value.ToString();


                //PW5class.Contractor_BusinessTelephone = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantPhoneDataGridViewTextBoxColumn.Name].Value.ToString();



                //PW5class.Contractor_LicenseNo = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantLicenseDataGridViewTextBoxColumn.Name].Value.ToString();

                PW5class.Contractor_LicenseNo = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn11.Name].Value.ToString();
            }
            if (grdFormInfo.Rows.Count > 0)
            {
                if (grdFormInfo.CurrentRow.Cells["grdBtnSubName"].Value.ToString() != "0")
                {
                    DataTable EquipmentUserTable1 = new DataTable();


                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                    //    EquipmentUserTable1 = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                            EquipmentUserTable1 = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                        }

                    }
                    else
                    {

                        using (EFDbContext db = new EFDbContext())
                        {
                            var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                            EquipmentUserTable1 = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                        }
                    }

                    if (EquipmentUserTable1.Rows.Count > 0)
                    {
                        DataRow Dr = EquipmentUserTable1.Rows[0];
                        PW5class.SubContrator_FirstName = Dr[Contact_FirstName].ToString();
                        PW5class.SubContrator_LastName = Dr[Contact_LastName].ToString();
                        PW5class.SubContrator_MiddleName = Dr[Contact_MiddleName].ToString();
                        PW5class.SubContrator_BusinessName = Dr[Contacts_CompanyName].ToString();
                        PW5class.SubContrator_BusinessAddress = Dr[Contact_Address].ToString();
                        PW5class.SubContrator_BusinessFAx_Email = Dr[Contacts_Fax].ToString();
                        PW5class.SubContrator_BusinessCity = Dr[Contact_City].ToString();
                        PW5class.SubContrator_State = Dr[Contact_State].ToString();
                        PW5class.SubContrator_Zip = Dr[Contact_ZIP].ToString();
                        PW5class.SubContrator_MobileNo = Dr[Contact_MobilePhone].ToString();

                    }
                }
            }
            DataTable SubcontractorTable = new DataTable();


            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
            //    SubcontractorTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                    SubcontractorTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                }

            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                    SubcontractorTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                }

            }

            if (SubcontractorTable.Rows.Count > 0)
            {
                DataRow DR = SubcontractorTable.Rows[0];
                PW5class.SubContrator_FirstName = DR[Contact_FirstName].ToString();
                PW5class.SubContrator_MiddleName = DR[Contact_MiddleName].ToString();
                PW5class.SubContrator_LastName = DR[Contact_LastName].ToString();
                PW5class.SubContrator_BusinessName = DR[ContactTitle].ToString();
                //AF.SetField(CD4Constant["Equip_Company"], Dr(Contacts_CompanyName).ToString())
                PW5class.SubContrator_BusinessAddress = DR[Contact_Address].ToString();
                PW5class.SubContrator_BusinessCity = DR[Contact_City].ToString();
                PW5class.SubContrator_State = DR[Contact_State].ToString();
                PW5class.SubContrator_Zip = DR[Contact_ZIP].ToString();
                PW5class.SubContrator_MobileNo = DR[Contact_MobilePhone].ToString();
                PW5class.SubContrator_BusinessFAx_Email = Convert.ToString(DR[Contacts_Fax]) + "/" + DR[Contact_EmailAddress].ToString();
            }
            PW5class.VarianceInformaton_Reason = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ReasonforVariance].Value.ToString();
            PW5class.VarianceInformaton_Description = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[VarianceWorkDescription].Value.ToString();
            PW5class.FillPWD5pdfForm(Path);
        }

        private void txtJobNumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            //if(bComboNeedToRefill)
            FillInfo();
        }

        private void grdFormInfo_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                DataTable DT = new DataTable();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<JobOwner>("SELECT OwnerName, OwnerAddress  FROM JobList WHERE JobNumber='" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[cmbGrdJobNumber.Name].FormattedValue.ToString() + "'").ToList();
                //    DT = Program.ToDataTable<JobOwner>((List<JobOwner>)data);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<JobOwner>("SELECT OwnerName, OwnerAddress  FROM JobList WHERE JobNumber='" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[cmbGrdJobNumber.Name].FormattedValue.ToString() + "'").ToList();
                        DT = Program.ToDataTable<JobOwner>((List<JobOwner>)data);
                    }
                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<JobOwner>("SELECT OwnerName, OwnerAddress  FROM JobList WHERE JobNumber='" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[cmbGrdJobNumber.Name].FormattedValue.ToString() + "'").ToList();
                        DT = Program.ToDataTable<JobOwner>((List<JobOwner>)data);
                    }
                }

                if (DT.Rows.Count > 0)
                {
                    DataRow Dr = DT.Rows[0];
                    grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value = Dr["OwnerName"].ToString();
                    grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value = Dr["OwnerAddress"].ToString();
                }
            }

        }

        private void btnCD8_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                CD8pdf CD8 = new CD8pdf();
                //***Filling Status Set here
                CD8.FillingStatus_CNNumber = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteCNNum].Value.ToString();
                //***Location Information Fill here
                CD8.Location_Borough = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
                CD8.Location_AptCondoNo = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[AptorCondoNum].Value.ToString();
                CD8.Location_Bin = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[BIN].Value.ToString();
                CD8.Location_Block = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString();
                //.Location_Floor=grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[job].Value.ToString()
                CD8.Location_HouseNo = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
                CD8.Location_Lot = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString();
                CD8.Location_StreetName = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
                CD8.Location_SpecialPlaceName = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SpecialPlaceName].Value.ToString();
                //***Applicant Information
                if (grdApplicantInfo.Rows.Count > 0)
                {
                    CD8.Applicant_Address = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString();

                    //CD8.Applicant_Address = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();

                    //CD8.Applicant_BusinessName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessNameDataGridViewTextBoxColumn.Name].Value.ToString();

                    CD8.Applicant_BusinessName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn5.Name].Value.ToString();

                    CD8.Applicant_City = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString();

                    //CD8.Applicant_City = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString();


                    CD8.Applicant_Fax = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn13.Name].Value.ToString();

                    //CD8.Applicant_Fax = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantfaxDataGridViewTextBoxColumn.Name].Value.ToString();

                    CD8.Applicant_FirstName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString();


                    //CD8.Applicant_FirstName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString();


                    CD8.Applicant_LastName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                    //CD8.Applicant_LastName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                    CD8.Applicant_LICNo = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn11.Name].Value.ToString();

                    //CD8.Applicant_LICNo = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLicenseDataGridViewTextBoxColumn.Name].Value.ToString();


                    //.Applicant_MI
                    CD8.Applicant_State = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();

                    //CD8.Applicant_State = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                    CD8.Applicant_Zip = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn9.Name].Value.ToString();


                    //CD8.Applicant_Zip = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantBusinessZipDataGridViewTextBoxColumn.Name].Value.ToString();


                    CD8.Applicant_TelephoneNo = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.dataGridViewTextBoxColumn12.Name].Value.ToString();


                    //CD8.Applicant_TelephoneNo = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[this.ApplicantPhoneDataGridViewTextBoxColumn.Name].Value.ToString();


                    //Crane 1 data
                    DataTable CDTable = null;
                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        CDTable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString());
                        if (CDTable.Rows.Count > 0)
                        {
                            CD8.CraneInformation_CDNo1 = CDTable.Rows[0][Con_CDNumber].ToString();
                            CD8.CraneInformation_Manufacturer1 = CDTable.Rows[0][Con_Make].ToString();
                            CD8.CraneInformation_Model1 = CDTable.Rows[0][Con_Model].ToString();
                            CD8.CraneInformation_BoomLength1 = CDTable.Rows[0][Con_TypBoom].ToString();
                            CD8.CraneInformation_JibLenght1 = CDTable.Rows[0][Con_TypJIB].ToString();
                            CD8.CraneInformation_Total1 = CDTable.Rows[0][Con_TypTotal].ToString();
                        }
                    }
                    //Crane2 data
                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        CDTable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString());
                        if (CDTable.Rows.Count > 0)
                        {
                            CD8.CraneInformation_CDNo2 = CDTable.Rows[0][Con_CDNumber].ToString();
                            CD8.CraneInformation_Manufacturer2 = CDTable.Rows[0][Con_Make].ToString();
                            CD8.CraneInformation_Model2 = CDTable.Rows[0][Con_Model].ToString();
                            CD8.CraneInformation_BoomLength2 = CDTable.Rows[0][Con_TypBoom].ToString();
                            CD8.CraneInformation_JibLenght2 = CDTable.Rows[0][Con_TypJIB].ToString();
                            CD8.CraneInformation_Total2 = CDTable.Rows[0][Con_TypTotal].ToString();
                        }
                    }
                    //Crane3 data
                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        CDTable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString());
                        if (CDTable.Rows.Count > 0)
                        {
                            CD8.CraneInformation_CDNo3 = CDTable.Rows[0][Con_CDNumber].ToString();
                            CD8.CraneInformation_Manufacturer3 = CDTable.Rows[0][Con_Make].ToString();
                            CD8.CraneInformation_Model3 = CDTable.Rows[0][Con_Model].ToString();
                            CD8.CraneInformation_BoomLength3 = CDTable.Rows[0][Con_TypBoom].ToString();
                            CD8.CraneInformation_JibLenght3 = CDTable.Rows[0][Con_TypJIB].ToString();
                            CD8.CraneInformation_Total3 = CDTable.Rows[0][Con_TypTotal].ToString();
                        }
                    }
                    //Crane4 data
                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        CDTable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString());
                        if (CDTable.Rows.Count > 0)
                        {
                            CD8.CraneInformation_CDNo4 = CDTable.Rows[0][Con_CDNumber].ToString();
                            CD8.CraneInformation_Manufacturer4 = CDTable.Rows[0][Con_Make].ToString();
                            CD8.CraneInformation_Model4 = CDTable.Rows[0][Con_Model].ToString();
                            CD8.CraneInformation_BoomLength4 = CDTable.Rows[0][Con_TypBoom].ToString();
                            CD8.CraneInformation_JibLenght4 = CDTable.Rows[0][Con_TypJIB].ToString();
                            CD8.CraneInformation_Total4 = CDTable.Rows[0][Con_TypTotal].ToString();
                        }
                    }
                    //crane5 data
                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        CDTable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString());
                        if (CDTable.Rows.Count > 0)
                        {
                            CD8.CraneInformation_CDNo5 = CDTable.Rows[0][Con_CDNumber].ToString();
                            CD8.CraneInformation_Manufacturer5 = CDTable.Rows[0][Con_Make].ToString();
                            CD8.CraneInformation_Model5 = CDTable.Rows[0][Con_Model].ToString();
                            CD8.CraneInformation_BoomLength5 = CDTable.Rows[0][Con_TypBoom].ToString();
                            CD8.CraneInformation_JibLenght5 = CDTable.Rows[0][Con_TypJIB].ToString();
                            CD8.CraneInformation_Total5 = CDTable.Rows[0][Con_TypTotal].ToString();
                        }
                    }
                    //Crane6 data
                    if (grdCraneInfo.Rows.Count > 0)
                    {
                        CDTable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString());
                        if (CDTable.Rows.Count > 0)
                        {
                            CD8.CraneInformation_CDNo6 = CDTable.Rows[0][Con_CDNumber].ToString();
                            CD8.CraneInformation_Manufacturer6 = CDTable.Rows[0][Con_Make].ToString();
                            CD8.CraneInformation_Model6 = CDTable.Rows[0][Con_Model].ToString();
                            CD8.CraneInformation_BoomLength6 = CDTable.Rows[0][Con_TypBoom].ToString();
                            CD8.CraneInformation_JibLenght6 = CDTable.Rows[0][Con_TypJIB].ToString();
                            CD8.CraneInformation_Total6 = CDTable.Rows[0][Con_TypTotal].ToString();
                        }
                    }
                }
                CD8.FillCD8pdfForm(Application.StartupPath + "\\PdfFile\\CD8.pdf");
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void btnCD16_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                CD16pdf CD16 = new CD16pdf();
                CD16.Borough = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
                CD16.CommunityBoard = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString();
                CD16.Address1 = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
                CD16.Address2 = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString();
                CD16.Block = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString();
                CD16.Lot = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString();
                CD16.NumberOfStories = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofStories].Value.ToString();
                CD16.Occupancy = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[OccupancyType].Value.ToString();
                CD16.NoOfApts = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofApts].Value.ToString();
                CD16.AptsCurrent = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofAptsCurrent].Value.ToString();
                CD16.AptsProposed = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofAptsProposed].Value.ToString();
                CD16.WorkProposed1 = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkProposed].Value.ToString();
                if (grdApplicantInfo.Rows.Count > 0)
                {
                    CD16.HereByDeclareName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();


                    //CD16.HereByDeclareName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                    CD16.ApplicantAddress = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString();

                    //CD16.ApplicantAddress = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();

                    CD16.ApplicantName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                    //CD16.ApplicantName = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();
                }
                CD16.OwnerName = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
                CD16.OwnerAddress = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString();
                CD16.ArchitectName = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Architect2].Value.ToString();
                CD16.ArchitectAddress = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Architect2fullAddress].Value.ToString();
                CD16.FillCD16pdfForm(Application.StartupPath + "\\PdfFile\\CD16.pdf");
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAEU2_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\aeu2.pdf";
            //Dim Path As String = "D:\Extracted Page of PDF file\cd8.pdf"
            PDFEditor.AEU2 AEU2 = new PDFEditor.AEU2();
            AEU2.Borough_ZipCode_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            AEU2.State_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString();
            //AEU2.County_Pro =grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[cou
            AEU2.My_MailingAddress_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                AEU2.PerformedWorkerName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //AEU2.PerformedWorkerName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                //AEU2.Company_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessNameDataGridViewTextBoxColumn.Name].Value.ToString();

                AEU2.Company_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn5.Name].Value.ToString();

                AEU2.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString();

                //AEU2.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();

                AEU2.LicenseNo_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn11.Name].Value.ToString();

                //AEU2.LicenseNo_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLicenseDataGridViewTextBoxColumn.Name].Value.ToString();
            }
            AEU2.FillAEU2pdfForm(Path);
        }

        private void btnAEU20_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\aeu2.pdf";
            PDFEditor.AEU20 AEU20 = new PDFEditor.AEU20();
        }

        private void btnCD7_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\cd7.pdf";
            PDFEditor.CD7 CD7 = new PDFEditor.CD7();
            CD7.LOJ_Borough_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            CD7.LOJ_HouseNO_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            CD7.LOJ_StreetName_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            CD7.RS_FirstName_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
            CD7.RS_Address_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString();
            CD7.RS_City_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerCity].Value.ToString();
            CD7.RS_State_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerState].Value.ToString();
            CD7.RS_Zip_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerZip].Value.ToString();

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var list = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value.ToString()).ToList();
            //    if (list.Count > 0)
            //    {
            //        CraneUser cUser = list.Select(r => r).FirstOrDefault();
            //        CD7.EUS_FirstName_Pro = cUser.FirstName;
            //        CD7.EUS_LastName_Pro = cUser.LastName;
            //        CD7.EUS_BusinessName_Pro = cUser.CompanyName;
            //        //CD7.EUS_Address_Pro = Dr("FirstName").ToString()
            //        CD7.EUS_City_Pro = cUser.City;
            //        CD7.EUS_State_Pro = cUser.State;
            //        //CD7.EUS_Zip_Pro = Dr("FirstName").ToString()
            //    }
            //}



            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var list = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value.ToString()).ToList();
                    if (list.Count > 0)
                    {
                        CraneUser cUser = list.Select(r => r).FirstOrDefault();
                        CD7.EUS_FirstName_Pro = cUser.FirstName;
                        CD7.EUS_LastName_Pro = cUser.LastName;
                        CD7.EUS_BusinessName_Pro = cUser.CompanyName;
                        //CD7.EUS_Address_Pro = Dr("FirstName").ToString()
                        CD7.EUS_City_Pro = cUser.City;
                        CD7.EUS_State_Pro = cUser.State;
                        //CD7.EUS_Zip_Pro = Dr("FirstName").ToString()
                    }
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var list = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value.ToString()).ToList();
                    if (list.Count > 0)
                    {
                        CraneUser cUser = list.Select(r => r).FirstOrDefault();
                        CD7.EUS_FirstName_Pro = cUser.FirstName;
                        CD7.EUS_LastName_Pro = cUser.LastName;
                        CD7.EUS_BusinessName_Pro = cUser.CompanyName;
                        //CD7.EUS_Address_Pro = Dr("FirstName").ToString()
                        CD7.EUS_City_Pro = cUser.City;
                        CD7.EUS_State_Pro = cUser.State;
                        //CD7.EUS_Zip_Pro = Dr("FirstName").ToString()
                    }
                }
            }

            CD7.FillCD7pdfForm(Path);
        }

        private void btnCD10_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\cd10.pdf";
            PDFEditor.CD10 CD10 = new PDFEditor.CD10();
            CD10.Block_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString();
            CD10.LOT_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString();
            CD10.Location_StreetAddress_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString();
            CD10.Location_Borough_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                CD10.Applicant_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();


                //CD10.Applicant_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                CD10.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString();

                //CD10.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();


                CD10.PhoneNo_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn12.Name].Value.ToString();

                //CD10.PhoneNo_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantPhoneDataGridViewTextBoxColumn.Name].Value.ToString();



            }
            CD10.FillCD10pdfForm(Path);
        }

        private void btnCD12_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\cd12.pdf";
            PDFEditor.CD12 CD12 = new PDFEditor.CD12();
            CD12.CN_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteCNNum].Value.ToString();
            if (grdCraneInfo.Rows.Count > 0)
            {
                //CD12.CD_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[CDNumberDataGridViewTextBoxColumn.Name].Value.ToString();
                CD12.CD_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn26.Name].Value.ToString();

            }
            CD12.Address_Borough_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            CD12.Block_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString();
            CD12.LOT_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString();
            CD12.Ms_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
            CD12.Owner_Name_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
            //CD12.Owner_PhoneNo_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString()
            CD12.Owner_Address_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString();
            DataTable EquipmentUserTable = new DataTable();


            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
            //    EquipmentUserTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                    EquipmentUserTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                }


            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<CraneUser>(frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()).ToList();
                    EquipmentUserTable = Program.ToDataTable<CraneUser>((List<CraneUser>)data);
                }


            }

            if (EquipmentUserTable.Rows.Count > 0)
            {
                DataRow Dr = EquipmentUserTable.Rows[0];
                CD12.SC_Name_Pro = Dr["FirstName"].ToString();
                CD12.SC_NAMEOnly_Pro = Dr[Contact_FirstName].ToString() + " " + Dr[Contact_MiddleName].ToString() + " " + Dr[Contact_LastName].ToString();
                CD12.SC_PhoneNo_Pro = Dr[Contact_MobilePhone].ToString();
                CD12.SC_Address_Pro = Dr[Contact_Address].ToString() + " " + Dr[Contact_City].ToString() + " " + Dr[Contact_State].ToString() + " " + Dr[Contact_ZIP].ToString();
            }
            CD12.FillCD12pdfForm(Path);
        }

        private void btnCD21_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\cd21.pdf";
            PDFEditor.CD21 CD21 = new PDFEditor.CD21();
            CD21.Contractor_Name_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
            CD21.Full_Address_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerCity].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerState].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerZip].Value.ToString();
            if (grdCraneInfo.Rows.Count > 0)
            {
                CD21.Equipment_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn44.Name].Value.ToString();

                //CD21.Equipment_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[EquipmentTypeDataGridViewTextBoxColumn.Name].Value.ToString();


                //CD21.Serial_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[SerialNumberDataGridViewTextBoxColumn.Name].Value.ToString();
                CD21.Serial_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn27.Name].Value.ToString();

                CD21.Boom_ft_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn41.Name].Value.ToString();

                //CD21.Boom_ft_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[TypBoomDataGridViewTextBoxColumn.Name].Value.ToString();

                CD21.Jib_ft_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn42.Name].Value.ToString();


                //CD21.Jib_ft_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[TypJIBDataGridViewTextBoxColumn.Name].Value.ToString();


                CD21.Mast_ft_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn40.Name].Value.ToString();

                //CD21.Mast_ft_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[TypMastDataGridViewTextBoxColumn.Name].Value.ToString();


                CD21.Total_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn43.Name].Value.ToString();

                //CD21.Total_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[TypTotalDataGridViewTextBoxColumn.Name].Value.ToString();

            }
            CD21.FillCD21pdfForm(Path);
        }
        private void btnCD22_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\cd22.pdf";
            PDFEditor.CD22 CD22 = new PDFEditor.CD22();
            CD22.App_Name_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
            CD22.JI_Address_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerCity].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerState].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerZip].Value.ToString();
            CD22.JI_Borough_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            CD22.CI_CN_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteCNNum].Value.ToString();
            if (grdCraneInfo.Rows.Count > 0)
            {

                //CD22.CI_CD_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[CDNumberDataGridViewTextBoxColumn.Name].Value.ToString();
                CD22.CI_CD_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn26.Name].Value.ToString();

                CD22.CI_CraneModel_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn29.Name].Value.ToString();

                //CD22.CI_CraneModel_Pro = grdCraneInfo.Rows[grdCraneInfo.CurrentRow.Index].Cells[ModelDataGridViewTextBoxColumn.Name].Value.ToString();
            }
            CD22.FillCD22pdfForm(Path);
        }
        private void btnCD24_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\cd24.pdf";
            PDFEditor.CD24 CD24 = new PDFEditor.CD24();
            CD24.LI_HouseNo_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            CD24.LI_StreetName_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            CD24.LI_Borough_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString();
            CD24.LI_Block_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString();
            CD24.LI_Lot_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString();
            CD24.LI_CN_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteCNNum].Value.ToString();
            //CD24.LI_CD1_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Crane1CD].Value.ToString()
            //CD24.LI_CD2_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Crane2CD].Value.ToString()
            //CD24.LI_CD3_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Crane3CD].Value.ToString()
            //CD24.LI_CD4_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Crane4CD].Value.ToString()
            DataTable CDtable = new DataTable();
            if (grdCraneInfo.Rows.Count > 0)
            {
                CDtable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString());


                if (CDtable.Rows.Count > 0)
                {
                    CD24.LI_CD1_Pro = CDtable.Rows[0][Con_CDNumber].ToString();
                    CD24.LI_DeviceType1_Pro = CDtable.Rows[0][Con_Model].ToString();
                    CD24.LI_SerialNo1_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Boom_Phase1_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Jib_Phase1_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Mast_Phase1_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Total_Phase1_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                }
            }
            if (grdCraneInfo.Rows.Count > 0)
            {
                CDtable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString());
                if (CDtable.Rows.Count > 0)
                {
                    CD24.LI_CD2_Pro = CDtable.Rows[0][Con_CDNumber].ToString();
                    CD24.LI_DeviceType2_Pro = CDtable.Rows[0][Con_Model].ToString();
                    CD24.LI_SerialNo2_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Boom_Phase2_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Jib_Phase2_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Mast_Phase2_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Total_Phase2_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                }
            }
            //Crane3 data
            if (grdCraneInfo.Rows.Count > 0)
            {
                CDtable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString());
                if (CDtable.Rows.Count > 0)
                {
                    CD24.LI_CD3_Pro = CDtable.Rows[0][Con_CDNumber].ToString();
                    CD24.LI_DeviceType3_Pro = CDtable.Rows[0][Con_Model].ToString();
                    CD24.LI_SerialNo3_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Boom_Phase3_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Jib_Phase3_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Mast_Phase3_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Total_Phase3_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                }
            }
            //Crane4 data
            if (grdCraneInfo.Rows.Count > 0)
            {
                CDtable = GetCDInfo(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString());
                if (CDtable.Rows.Count > 0)
                {
                    CD24.LI_CD4_Pro = CDtable.Rows[0][Con_CDNumber].ToString();
                    CD24.LI_DeviceType4_Pro = CDtable.Rows[0][Con_Model].ToString();
                    CD24.LI_SerialNo4_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Boom_Phase4_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Jib_Phase1_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Mast_Phase4_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                    CD24.PI_Total_Phase4_Pro = CDtable.Rows[0][Con_SerialNumber].ToString();
                }
            }
            if (grdApplicantInfo.Rows.Count > 0)
            {
                //CD24.AI_LastName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                CD24.AI_LastName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                CD24.AI_FirstName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString();

                //CD24.AI_FirstName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_MiddleName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString();

                //CD24.AI_MiddleName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_BusinessName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn5.Name].Value.ToString();

                //CD24.AI_BusinessName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessNameDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_BusinessPhone_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn12.Name].Value.ToString();


                //CD24.AI_BusinessPhone_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantPhoneDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_BusinessAddress_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString();
                
                //CD24.AI_BusinessAddress_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_BusinessFax_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn13.Name].Value.ToString();

                //CD24.AI_BusinessFax_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantfaxDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_City_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString();

                //CD24.AI_City_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_State_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //CD24.AI_State_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_Zip_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn9.Name].Value.ToString();


                //CD24.AI_Zip_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessZipDataGridViewTextBoxColumn.Name].Value.ToString();


                CD24.AI_LicenseNo_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn11.Name].Value.ToString();

                //CD24.AI_LicenseNo_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLicenseDataGridViewTextBoxColumn.Name].Value.ToString();



            }
            CD24.FillCD24pdfForm(Path);
        }
        private void btnDebrisLetter_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\debris_letter.pdf";
            PDFEditor.debris_letter debris_letter = new PDFEditor.debris_letter();
            debris_letter.Name_Owner_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString();
            debris_letter.Address_Owner_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerStreet].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerCity].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerState].Value.ToString() + " " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerZip].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                debris_letter.License_No_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn11.Name].Value.ToString();

                //debris_letter.License_No_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLicenseDataGridViewTextBoxColumn.Name].Value.ToString();

            }
            debris_letter.Filldebris_letterpdfForm(Path);
        }
        private void btnDGWPA_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_govt_work_permit_app.pdf";
            PDFEditor.dot_govt_work_permit_app dot_govt_work_permit_app = new PDFEditor.dot_govt_work_permit_app();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                dot_govt_work_permit_app.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //dot_govt_work_permit_app.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();

                dot_govt_work_permit_app.A_Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();


                //dot_govt_work_permit_app.A_Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                dot_govt_work_permit_app.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //dot_govt_work_permit_app.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();

                dot_govt_work_permit_app.Submitted_By_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //dot_govt_work_permit_app.Submitted_By_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();
            }
            dot_govt_work_permit_app.Filldot_govt_work_permit_apppdfForm(Path);
        }
        private void btnDGWPRA_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_govt_work_permit_reissue_app.pdf";
            PDFEditor.dot_govt_work_permit_reissue_app DGWPRA = new PDFEditor.dot_govt_work_permit_reissue_app();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                DGWPRA.Permit_ID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //DGWPRA.Permit_ID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();


                DGWPRA.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();


                //DGWPRA.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                DGWPRA.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();

                //DGWPRA.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                DGWPRA.Submitted_By_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //DGWPRA.Submitted_By_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();
            }
            DGWPRA.FillDGWPRApdfForm(Path);
        }
        private void btnDGWPRenewApp_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_govt_work_permit_renew_app.pdf";
            PDFEditor.dot_govt_work_permit_renew_app DGWPRenewA = new PDFEditor.dot_govt_work_permit_renew_app();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                DGWPRenewA.Permit_ID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();


                //DGWPRenewA.Permit_ID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();


                DGWPRenewA.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //DGWPRenewA.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                DGWPRenewA.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //DGWPRenewA.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                //DGWPRenewA.Submitted_by_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                DGWPRenewA.Submitted_by_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();
            }
            DGWPRenewA.FillDGWPRenewApdfForm(Path);
        }
        private void btnHoliday_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_holidayembapp.pdf";
            PDFEditor.dot_holidayembapp D_Holiday = new PDFEditor.dot_holidayembapp();
            D_Holiday.B_HouseNo_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            D_Holiday.B_OnStreet_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                D_Holiday.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //D_Holiday.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();


                D_Holiday.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //D_Holiday.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();



                D_Holiday.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //D_Holiday.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();



                //D_Holiday.Submitted_By_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_Holiday.Submitted_By_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();
            }
            D_Holiday.FillD_HolidaypdfForm(Path);
        }
        private void btnPermapp_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_permapp.pdf";
            PDFEditor.dot_permapp D_Permapp = new PDFEditor.dot_permapp();
            D_Permapp.B_HouseNo_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            D_Permapp.B_OnStreet_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                D_Permapp.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //D_Permapp.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();

                

                D_Permapp.A_Pemit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();


                //D_Permapp.A_Pemit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                D_Permapp.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //D_Permapp.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                //D_Permapp.SubmittedBy_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_Permapp.SubmittedBy_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();
            }
            D_Permapp.FillD_PermapppdfForm(Path);
        }
        private void btndot_permappreissue_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_permappreissue.pdf";
            PDFEditor.dot_permappreissue D_PermappIssue = new PDFEditor.dot_permappreissue();
            D_PermappIssue.House_No_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            D_PermappIssue.OnStreet_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                D_PermappIssue.Permit_ID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //D_PermappIssue.Permit_ID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();

                D_PermappIssue.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //D_PermappIssue.Permit_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                D_PermappIssue.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //D_PermappIssue.Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                //D_PermappIssue.Submittedby_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_PermappIssue.Submittedby_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();
            }
            D_PermappIssue.FillD_PermappIssuepdfForm(Path);
        }
        private void btnP_Renew_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_permapprenew.pdf";
            PDFEditor.dot_permapprenew D_PermappRenew = new PDFEditor.dot_permapprenew();
            D_PermappRenew.House_No_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            D_PermappRenew.OnStreet_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                D_PermappRenew.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //D_PermappRenew.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();


                D_PermappRenew.PermitName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //D_PermappRenew.PermitName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_PermappRenew.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //D_PermappRenew.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();



                //D_PermappRenew.SubmittedBy_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_PermappRenew.SubmittedBy_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();
            }
            D_PermappRenew.FillD_PermappRenewpdfForm(Path);
        }
        private void btnD_regapp_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_regapp.pdf";
            PDFEditor.dot_regapp D_Regapp = new PDFEditor.dot_regapp();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                D_Regapp.A_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //D_Regapp.A_Name_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();


                D_Regapp.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString();

                //D_Regapp.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString();


                D_Regapp.A_CIty_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString();


                //D_Regapp.A_CIty_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString();



                D_Regapp.A_STate_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //D_Regapp.A_STate_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();

                //D_Regapp.A_Zip_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessZipDataGridViewTextBoxColumn.Name].Value.ToString();

                D_Regapp.A_Zip_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn9.Name].Value.ToString();
            }
            D_Regapp.FillD_RegapppdfForm(Path);
        }
        private void btnRoadway_Click(System.Object sender, System.EventArgs e)
        {
            string Path = Application.StartupPath + "\\PdfFile\\dot_roadway_closure_app.pdf";
            PDFEditor.dot_roadway_closure_app D_Roadway = new PDFEditor.dot_roadway_closure_app();
            D_Roadway.B_HouseNo_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString();
            D_Roadway.B_OnStreet_Pro = grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString();
            if (grdApplicantInfo.Rows.Count > 0)
            {
                D_Roadway.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn1.Name].Value.ToString();

                //D_Roadway.AID_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantIDDataGridViewTextBoxColumn.Name].Value.ToString();


                D_Roadway.A_PermittedName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();

                //D_Roadway.A_PermittedName_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_Roadway.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn6.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn7.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn8.Name].Value.ToString();


                //D_Roadway.A_Address_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddressDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCityDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessStateDataGridViewTextBoxColumn.Name].Value.ToString();


                //D_Roadway.SubmittedBy_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidNameDataGridViewTextBoxColumn.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastNameDataGridViewTextBoxColumn.Name].Value.ToString();

                D_Roadway.SubmittedBy_Pro = grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn2.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn4.Name].Value.ToString() + " " + grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[dataGridViewTextBoxColumn3.Name].Value.ToString();
            }
            D_Roadway.FillD_RoadwaypdfForm(Path);
        }

        // common event for all checkbox
        private void chkCraneFill_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            FillInfo();
        }
        #endregion

        #region Functions
        private void SetFormInfoGridColumnName()
        {
            grdFormInfo.Columns[JobSiteBlock].HeaderText = "Job Site Block";
            grdFormInfo.Columns[JobSiteLot].HeaderText = "Job Site Lot";
            grdFormInfo.Columns[JobSiteHouseNum].HeaderText = "Job Site House No";
            grdFormInfo.Columns[JobSiteStreet].HeaderText = "Job Site Street";
            grdFormInfo.Columns[JobSiteBorough].HeaderText = "Job Site Borough";
            grdFormInfo.Columns[JobSiteState].HeaderText = "Job Site State";
            grdFormInfo.Columns[CraneUserInfo].HeaderText = "Crane User Info";
            grdFormInfo.Columns[CraneUserTitle].HeaderText = "Crane User Title";
            grdFormInfo.Columns[WorkPlatformManufacturer].HeaderText = "WorkPlatform Manufacturer";
            grdFormInfo.Columns[WorkPlatformModel].HeaderText = "WorkPlatform Model";
            grdFormInfo.Columns[WorkPlatformSuperName].HeaderText = "WorkPlatform SuperName";
            grdFormInfo.Columns[WorkPlatformSuperPhone].HeaderText = "WorkPlatfor mSuperPhone";
            grdFormInfo.Columns[WorkPlatformSuperFax].HeaderText = "WorkPlatform SuperFax";
            grdFormInfo.Columns[WorkPlatformSuperAddr].HeaderText = "WorkPlatform SuperAddr";
            grdFormInfo.Columns[WorkPlatformSuperCity].HeaderText = "WorkPlatform SuperCity";
            grdFormInfo.Columns[WorkPlatformSuperState].HeaderText = "WorkPlatform SuperState";
            grdFormInfo.Columns[WorkPlatformSuperZip].HeaderText = "WorkPlatform SuperZip";
            //grdFormInfo.Columns[FirstVariance].HeaderText = "First Variance";
            grdFormInfo.Columns[BIN].HeaderText = "BIN";
            grdFormInfo.Columns[AptorCondoNum].HeaderText = "Aptor CondoNum";
            grdFormInfo.Columns[SpecialPlaceName].HeaderText = "Special PlaceName";
            grdFormInfo.Columns[SubInfo].HeaderText = "Sub Info";
            //grdFormInfo.Columns[ResidenceWithin200ft].HeaderText = "Residence Within200ft";
            grdFormInfo.Columns[DatesofVariance].HeaderText = "Dates of Variance";
            grdFormInfo.Columns[DaysofVariance].HeaderText = "Days of Variance";
            grdFormInfo.Columns[TimeofVarianceFrom].HeaderText = "Time of VarianceFrom";
            grdFormInfo.Columns[TimeofVarianceTo].HeaderText = "Time of Variance To";
            grdFormInfo.Columns[VarianceWorkDescription].HeaderText = "Variance Work Description";
            grdFormInfo.Columns[ReasonforVariance].HeaderText = "Reason for Variance";
            grdFormInfo.Columns[SiteArchitect].HeaderText = "Site Architect";
            grdFormInfo.Columns[SiteNumofStories].HeaderText = "SiteNum of Stories";
            //grdFormInfo.Columns[SiteOccupancy].HeaderText = "Site Occupancy";

            grdFormInfo.Columns[OccupancyType].HeaderText = "Occupancy Type";
            grdFormInfo.Columns[SiteNumofApts].HeaderText = "SiteNum of Apts";
            grdFormInfo.Columns[SiteNumofAptsCurrent].HeaderText = "SiteNum of AptsCurrent";
            grdFormInfo.Columns[SiteNumofAptsProposed].HeaderText = "SiteNum of AptsProposed";
            grdFormInfo.Columns[SiteOwner].HeaderText = "Site Owner";
            grdFormInfo.Columns[SiteOwnerAddress].HeaderText = "Site Owner Address";
            grdFormInfo.Columns[SiteOwnerStreet].HeaderText = "Site Owner Street";
            grdFormInfo.Columns[SiteOwnerCity].HeaderText = "Site Owner City";
            grdFormInfo.Columns[SiteOwnerState].HeaderText = "Site Owner State";
            grdFormInfo.Columns[SiteOwnerZip].HeaderText = "Site Owner Zip";
            grdFormInfo.Columns[WorkProposed].HeaderText = "Work Proposed";
            grdFormInfo.Columns[Architect2].HeaderText = "Architect2";
            grdFormInfo.Columns[Architect2fullAddress].HeaderText = "Architect2 full Address";
        }
        private void FillInfo()
        {
            //try
            {
                //string Query = "SELECT     VBFormInfo.JobID, VBFormInfo.JobListID, VBFormInfo.Applicant,JobList.JobNumber, VBFormInfo.JobSiteBlock, VBFormInfo.JobSiteLot, VBFormInfo.JobSiteCNNum,   VBFormInfo.JobSiteHouseNum, VBFormInfo.JobSiteStreet, VBFormInfo.JobSiteBorough, VBFormInfo.JobSiteState, VBFormInfo.Crane1CD, VBFormInfo.Crane2CD,     VBFormInfo.Crane3CD, VBFormInfo.Crane4CD, VBFormInfo.Crane5CD, VBFormInfo.Crane6CD, VBFormInfo.CraneUser, VBFormInfo.CraneUserInfo,   VBFormInfo.CraneUserTitle, VBFormInfo.WorkPlatformManufacturer, VBFormInfo.WorkPlatformModel, VBFormInfo.WorkPlatformSuperName,      VBFormInfo.WorkPlatformSuperPhone, VBFormInfo.WorkPlatformSuperFax, VBFormInfo.WorkPlatformSuperAddr, VBFormInfo.WorkPlatformSuperCity,        VBFormInfo.WorkPlatformSuperState, VBFormInfo.WorkPlatformSuperZip, VBFormInfo.FirstVariance, VBFormInfo.BIN, VBFormInfo.CBNum,   VBFormInfo.AptorCondoNum, VBFormInfo.SpecialPlaceName, VBFormInfo.SubName, VBFormInfo.SubInfo, VBFormInfo.ResidenceWithin200ft,  VBFormInfo.DatesofVariance, VBFormInfo.DaysofVariance, VBFormInfo.TimeofVarianceFrom, VBFormInfo.TimeofVarianceTo, VBFormInfo.VarianceWorkDescription,   VBFormInfo.ReasonforVariance, VBFormInfo.SiteArchitect,  VBFormInfo.SiteNumofStories, VBFormInfo.SiteOccupancy,  VBFormInfo.OccupancyType, VBFormInfo.SiteNumofApts, VBFormInfo.SiteNumofAptsCurrent, VBFormInfo.SiteNumofAptsProposed, VBFormInfo.SiteOwner,    VBFormInfo.SiteOwnerAddress, VBFormInfo.SiteOwnerStreet, VBFormInfo.SiteOwnerCity, VBFormInfo.SiteOwnerState, VBFormInfo.SiteOwnerZip,  VBFormInfo.WorkProposed, VBFormInfo.Architect2, VBFormInfo.Architect2fullAddress, VBFormInfo.PDFType FROM         VBFormInfo INNER JOIN                      JobList ON VBFormInfo.JobListID = JobList.JobListID WHERE     (VBFormInfo.IsDelete = 0 OR   VBFormInfo.IsDelete IS NULL)";

                string Query = "SELECT     VBFormInfo.JobID, VBFormInfo.JobListID, VBFormInfo.Applicant,JobList.JobNumber, VBFormInfo.JobSiteBlock, VBFormInfo.JobSiteLot, VBFormInfo.JobSiteCNNum,   VBFormInfo.JobSiteHouseNum, VBFormInfo.JobSiteStreet, VBFormInfo.JobSiteBorough, VBFormInfo.JobSiteState, VBFormInfo.Crane1CD, VBFormInfo.Crane2CD,     VBFormInfo.Crane3CD, VBFormInfo.Crane4CD, VBFormInfo.Crane5CD, VBFormInfo.Crane6CD, VBFormInfo.CraneUser, VBFormInfo.CraneUserInfo,   VBFormInfo.CraneUserTitle, VBFormInfo.WorkPlatformManufacturer, VBFormInfo.WorkPlatformModel, VBFormInfo.WorkPlatformSuperName,      VBFormInfo.WorkPlatformSuperPhone, VBFormInfo.WorkPlatformSuperFax, VBFormInfo.WorkPlatformSuperAddr, VBFormInfo.WorkPlatformSuperCity,        VBFormInfo.WorkPlatformSuperState, VBFormInfo.WorkPlatformSuperZip, VBFormInfo.FirstVariance, VBFormInfo.BIN, VBFormInfo.CBNum,   VBFormInfo.AptorCondoNum, VBFormInfo.SpecialPlaceName, VBFormInfo.SubName, VBFormInfo.SubInfo, VBFormInfo.ResidenceWithin200ft,  VBFormInfo.DatesofVariance, VBFormInfo.DaysofVariance, VBFormInfo.TimeofVarianceFrom, VBFormInfo.TimeofVarianceTo, VBFormInfo.VarianceWorkDescription,   VBFormInfo.ReasonforVariance, VBFormInfo.SiteArchitect,  VBFormInfo.SiteNumofStories, VBFormInfo.SiteOccupancy,  VBFormInfo.OccupancyType, VBFormInfo.SiteNumofApts, VBFormInfo.SiteNumofAptsCurrent, VBFormInfo.SiteNumofAptsProposed, VBFormInfo.SiteOwner,    VBFormInfo.SiteOwnerAddress, VBFormInfo.SiteOwnerStreet, VBFormInfo.SiteOwnerCity, VBFormInfo.SiteOwnerState, VBFormInfo.SiteOwnerZip,  VBFormInfo.WorkProposed, VBFormInfo.Architect2, VBFormInfo.Architect2fullAddress, VBFormInfo.PDFType FROM         VBFormInfo INNER JOIN                      JobList ON VBFormInfo.JobListID = JobList.JobListID WHERE     (VBFormInfo.IsDelete = 0 OR   VBFormInfo.IsDelete IS NULL)";

                if (!string.IsNullOrEmpty(txtJobNumber.Text.Trim()))
                {
                    Query = Query + " AND VBFormInfo.JobListID in (SELECT JobListID FROM JobList WHERE JobNumber LIKE'" + txtJobNumber.Text + "%')";
                }

                string QueryString = SelectCheckString();

                if (!string.IsNullOrEmpty(QueryString))
                {
                    Query = Query + " AND VBFormInfo.Pdftype in (" + QueryString + ")";
                }
                //string sSql = frmCraneUser_subInfo.Query + " AND ContactsID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString();
                ////using (EFDbContext db = new EFDbContext())
                ////{
                ////    var data = db.Database.SqlQuery<JobForm>(sSql).ToList();
                ////    grdFormInfo.DataSource = data;
                ////}
                ///


                //var data = StMethod.GetListDT<JobForm>(Query);
                
                var data = StMethod.GetListDT<JobForm>(Query);
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data = StMethod.GetListDTNew<JobForm>(Query);
                }
                else
                {
                    data = StMethod.GetListDT<JobForm>(Query);
                }

                //DataTable data = StMethod.GetListDT<JobForm>(Query);

                grdFormInfo.DataSource = data;

                grdFormInfo.Columns[JobID].Visible = false;
                grdFormInfo.Columns[ApplicantID].Visible = false;
                grdFormInfo.Columns[JobNumber].Visible = false;


                //grdFormInfo.Columns[grdBtnCrane1.Name].DisplayIndex = 4;
                //grdFormInfo.Columns[grdBtnCrane2.Name].DisplayIndex = 5;
                //grdFormInfo.Columns[grdBtnCrane3.Name].DisplayIndex = 6;
                //grdFormInfo.Columns[grdBtnCrane4.Name].DisplayIndex = 7;
                //grdFormInfo.Columns[grdBtnCrane5.Name].DisplayIndex = 8;
                //grdFormInfo.Columns[grdBtnCrane6.Name].DisplayIndex = 9;
                //grdFormInfo.Columns[grdBtnCraneUser.Name].DisplayIndex = 10;

                //grdFormInfo.Columns[grdBtnSubName.Name].DisplayIndex = 36;
                //grdFormInfo.Columns[ColumnFirstVariance.Name].DisplayIndex = 31;
                //grdFormInfo.Columns[ResidenceWithin.Name].DisplayIndex = 39;
                //grdFormInfo.Columns[SiteOccu.Name].DisplayIndex = 47;

                //MessageBox.Show(grdFormInfo.Columns[0].HeaderText.ToString());

                grdFormInfo.Columns[GrdPreRequireUpdate.Name].DisplayIndex = 0;
                grdFormInfo.Columns[btnGrdApplicantID.Name].DisplayIndex = 1;
                grdFormInfo.Columns[cmbGrdJobNumber.Name].DisplayIndex = 2;
                grdFormInfo.Columns[btnGrdCBNum.Name].DisplayIndex = 3;
                grdFormInfo.Columns[JobSiteBlock].DisplayIndex = 4;
                grdFormInfo.Columns[JobSiteLot].DisplayIndex = 5;
                
                grdFormInfo.Columns[JobSiteCNNum].DisplayIndex = 6;                 
                grdFormInfo.Columns[JobSiteHouseNum].DisplayIndex = 7;
                grdFormInfo.Columns[JobSiteStreet].DisplayIndex = 8;
                grdFormInfo.Columns[JobSiteBorough].DisplayIndex = 9;
                grdFormInfo.Columns[JobSiteState].DisplayIndex = 10;

                grdFormInfo.Columns[grdBtnCrane1.Name].DisplayIndex = 11;
                grdFormInfo.Columns[grdBtnCrane2.Name].DisplayIndex = 12;
                grdFormInfo.Columns[grdBtnCrane3.Name].DisplayIndex = 13;
                grdFormInfo.Columns[grdBtnCrane4.Name].DisplayIndex = 14;
                grdFormInfo.Columns[grdBtnCrane5.Name].DisplayIndex = 15;
                grdFormInfo.Columns[grdBtnCrane6.Name].DisplayIndex = 16;
                grdFormInfo.Columns[grdBtnCraneUser.Name].DisplayIndex = 17;

                grdFormInfo.Columns[CraneUserInfo].DisplayIndex = 18;

                grdFormInfo.Columns[CraneUserTitle].DisplayIndex = 19;
                grdFormInfo.Columns[WorkPlatformManufacturer].DisplayIndex = 20;
                grdFormInfo.Columns[WorkPlatformModel].DisplayIndex = 21;
                grdFormInfo.Columns[WorkPlatformSuperName].DisplayIndex = 22;
                grdFormInfo.Columns[WorkPlatformSuperPhone].DisplayIndex = 23;
                grdFormInfo.Columns[WorkPlatformSuperFax].DisplayIndex = 24;
                grdFormInfo.Columns[WorkPlatformSuperAddr].DisplayIndex = 25;
                grdFormInfo.Columns[WorkPlatformSuperCity].DisplayIndex = 26;
                grdFormInfo.Columns[WorkPlatformSuperState].DisplayIndex = 27;
                grdFormInfo.Columns[WorkPlatformSuperZip].DisplayIndex = 28;

                grdFormInfo.Columns[ColumnFirstVariance.Name].DisplayIndex = 29;
                grdFormInfo.Columns[BIN].DisplayIndex = 30;
                grdFormInfo.Columns[AptorCondoNum].DisplayIndex = 31;
                grdFormInfo.Columns[SpecialPlaceName].DisplayIndex = 32;
                
                grdFormInfo.Columns[grdBtnSubName.Name ].DisplayIndex = 33;
                grdFormInfo.Columns[SubInfo].DisplayIndex = 34;
                grdFormInfo.Columns[ResidenceWithin.Name].DisplayIndex = 35;


                grdFormInfo.Columns[DatesofVariance].DisplayIndex = 36;
                grdFormInfo.Columns[DaysofVariance].DisplayIndex = 37;
                grdFormInfo.Columns[TimeofVarianceFrom].DisplayIndex = 38;
                grdFormInfo.Columns[TimeofVarianceTo].DisplayIndex = 39;
                grdFormInfo.Columns[VarianceWorkDescription].DisplayIndex = 40;

                grdFormInfo.Columns[ReasonforVariance].DisplayIndex = 41;
                grdFormInfo.Columns[SiteArchitect].DisplayIndex = 42;
                grdFormInfo.Columns[SiteNumofStories].DisplayIndex = 43;

                grdFormInfo.Columns[SiteOccu.Name].DisplayIndex = 44;

                grdFormInfo.Columns[OccupancyType].DisplayIndex = 45;
                grdFormInfo.Columns[SiteNumofApts].DisplayIndex = 46;
                grdFormInfo.Columns[SiteNumofAptsCurrent].DisplayIndex = 47;
                grdFormInfo.Columns[SiteNumofAptsProposed].DisplayIndex = 48;

                grdFormInfo.Columns[SiteOwner].DisplayIndex = 49;
                grdFormInfo.Columns[SiteOwnerAddress].DisplayIndex = 50;

                grdFormInfo.Columns[SiteOwnerStreet].DisplayIndex = 51;
                grdFormInfo.Columns[SiteOwnerCity].DisplayIndex = 52;
                grdFormInfo.Columns[SiteOwnerState].DisplayIndex = 53;
                grdFormInfo.Columns[SiteOwnerZip].DisplayIndex = 54;

                grdFormInfo.Columns[WorkProposed].DisplayIndex = 55;
                grdFormInfo.Columns[Architect2].DisplayIndex = 56;
                grdFormInfo.Columns[Architect2fullAddress].DisplayIndex = 57;


                //.Columns[grdBtnCraneUser.Name).DisplayIndex = 19
                //.Columns[btnGrdApplicantID.Name).DisplayIndex = 1
                //.Columns[btnGrdCBNum.Name).DisplayIndex = 33
                //.Columns[grdBtnCrane1.Name).DisplayIndex = 13
                //.Columns[grdBtnCrane2.Name).DisplayIndex = 14
                //.Columns[grdBtnCrane3.Name).DisplayIndex = 15
                //.Columns[grdBtnCrane4.Name).DisplayIndex = 16
                //.Columns[grdBtnCrane5.Name).DisplayIndex = 17
                //.Columns[grdBtnCrane6.Name).DisplayIndex = 18

                SetFormInfoGridColumnName();

                if (grdFormInfo.Rows.Count > 0)
                {
                    grdFormInfo.Rows[0].Selected = true;
                    grdFormInfo.CurrentCell = grdFormInfo.Rows[0].Cells[btnGrdApplicantID.Name];
                    RefreshdependedGrid();
                }
                else
                {
                    RefreshdependedGrid();
                }


            }
            ////catch (Exception ex)
            ////{
            ////    KryptonMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////}
        }
        private void fillGridCombo()
        {
            try
            {
                string Query = "SELECT JobListID,JobNumber FROM JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)";
                ////using (EFDbContext db = new EFDbContext())
                ////{
                ////    var data = db.Database.SqlQuery<JobNumList>(Query).ToList();
                ////    cmbGrdJobNumber.DataSource = data;
                ////}

                //var data = StMethod.GetListDT<JobNumList>(Query);

                var data = StMethod.GetListDT<JobNumList>(Query);
                data = null;


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data = StMethod.GetListDTNew<JobNumList>(Query);
                }
                else
                {
                    data = StMethod.GetListDT<JobNumList>(Query);
                }

                cmbGrdJobNumber.DataSource = data;
                cmbGrdJobNumber.ValueMember = "JobListID";
                cmbGrdJobNumber.DisplayMember = "JobNumber";
                cmbGrdJobNumber.Name = "cmbGrdJobNumber";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FillGridColumnFirstVariance()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
            }
        }

        private void AddRow()
        {
            try
            {
                btnAdd.Text = "Save";
                DataTable Dt = new DataTable();
                //Dt = Program.ToDataTable<JobForm>((List<JobForm>)grdFormInfo.DataSource);
                Dt = (DataTable)grdFormInfo.DataSource;
                DataRow Dr = Dt.NewRow();
                Dt.Rows.Add(Dr);
                grdFormInfo.DataSource = Dt;
                grdFormInfo.CurrentCell = grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteBlock];
                grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Selected = true;
            }
            catch (Exception ex)
            {
                btnAdd.Text = "Insert";
                MessageBox.Show(ex.Message.ToString());

            }
        }
        private void InsertFormInfodata()
        {
            try
            {
                string Query = "INSERT INTO VBFormInfo (JobListID, JobNumber, Applicant, JobSiteBlock, JobSiteLot, JobSiteCNNum, JobSiteHouseNum, JobSiteStreet, JobSiteBorough, JobSiteState, Crane1CD, Crane2CD, Crane3CD, Crane4CD, Crane5CD, Crane6CD, CraneUser, CraneUserInfo, CraneUserTitle, WorkPlatformManufacturer, WorkPlatformModel, WorkPlatformSuperName, WorkPlatformSuperPhone, WorkPlatformSuperFax, WorkPlatformSuperAddr, WorkPlatformSuperCity, WorkPlatformSuperState, WorkPlatformSuperZip, FirstVariance, BIN, CBNum, AptorCondoNum, SpecialPlaceName, SubName, SubInfo, ResidenceWithin200ft, DatesofVariance, DaysofVariance, TimeofVarianceFrom, TimeofVarianceTo, VarianceWorkDescription, ReasonforVariance, SiteArchitect, SiteNumofStories, SiteOccupancy, OccupancyType, SiteNumofApts, SiteNumofAptsCurrent, SiteNumofAptsProposed, SiteOwner, SiteOwnerAddress, SiteOwnerStreet, SiteOwnerCity, SiteOwnerState, SiteOwnerZip, WorkProposed, Architect2, Architect2fullAddress, PDFType) VALUES (  @JobListID, @JobNumber, @Applicant, @JobSiteBlock, @JobSiteLot, @JobSiteCNNum, @JobSiteHouseNum, @JobSiteStreet, @JobSiteBorough, @JobSiteState, @Crane1CD, @Crane2CD, @Crane3CD, @Crane4CD, @Crane5CD, @Crane6CD, @CraneUser, @CraneUserInfo, @CraneUserTitle, @WorkPlatformManufacturer, @WorkPlatformModel, @WorkPlatformSuperName, @WorkPlatformSuperPhone, @WorkPlatformSuperFax, @WorkPlatformSuperAddr, @WorkPlatformSuperCity, @WorkPlatformSuperState, @WorkPlatformSuperZip, @FirstVariance, @BIN, @CBNum, @AptorCondoNum, @SpecialPlaceName, @SubName, @SubInfo, @ResidenceWithin200ft, @DatesofVariance, @DaysofVariance, @TimeofVarianceFrom, @TimeofVarianceTo, @VarianceWorkDescription, @ReasonforVariance, @SiteArchitect,  @SiteNumofStories, @SiteOccupancy, @OccupancyType, @SiteNumofApts, @SiteNumofAptsCurrent, @SiteNumofAptsProposed, @SiteOwner, @SiteOwnerAddress, @SiteOwnerStreet, @SiteOwnerCity, @SiteOwnerState, @SiteOwnerZip, @WorkProposed, @Architect2, @Architect2fullAddress, @PDFType )";
                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                // Param.Add(new SqlParameter("@JobID", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[JobID].Value.ToString()))
                Param.Add(new SqlParameter("@JobListID", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[cmbGrdJobNumber.Name].Value.ToString()));
                // Param.Add(new SqlParameter("@CommunityID", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[btnGrdCBNum.Name].Value.ToString()))
                Param.Add(new SqlParameter("@JobNumber", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobNumber].Value.ToString()));
                Param.Add(new SqlParameter("@Applicant", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[ApplicantID].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteBlock", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteBlock].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteLot", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteLot].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteCNNum", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteCNNum].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteHouseNum", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteHouseNum].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteStreet", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteStreet].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteBorough", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteBorough].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteState", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[JobSiteState].Value.ToString()));
                Param.Add(new SqlParameter("@Crane1CD", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCrane1.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane2CD", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCrane2.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane3CD", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCrane3.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane4CD", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCrane4.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane5CD", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCrane5.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane6CD", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCrane6.Name].Value.ToString()));
                Param.Add(new SqlParameter("@CraneUser", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnCraneUser.Name].Value.ToString()));
                Param.Add(new SqlParameter("@CraneUserInfo", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[CraneUserInfo].Value.ToString()));
                Param.Add(new SqlParameter("@CraneUserTitle", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[CraneUserTitle].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformManufacturer", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformManufacturer].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformModel", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformModel].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperName", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperName].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperPhone", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperPhone].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperFax", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperFax].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperAddr", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperAddr].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperCity", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperCity].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperState", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperState].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperZip", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkPlatformSuperZip].Value.ToString()));

                String InsertFirstVarianceVale = string.Empty;

                if (grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ColumnFirstVariance"].Index].Value != null)
                {
                   
                }

                InsertFirstVarianceVale = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ColumnFirstVariance"].Index].Value.ToString();

                Param.Add(new SqlParameter("@FirstVariance", InsertFirstVarianceVale));


                //Param.Add(new SqlParameter("@FirstVariance", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[FirstVariance].Value.ToString()));


                Param.Add(new SqlParameter("@BIN", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[BIN].Value.ToString()));
                Param.Add(new SqlParameter("@CBNum", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[btnGrdCBNum.Name].Value.ToString()));
                Param.Add(new SqlParameter("@AptorCondoNum", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[AptorCondoNum].Value.ToString()));
                Param.Add(new SqlParameter("@SpecialPlaceName", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SpecialPlaceName].Value.ToString()));
                Param.Add(new SqlParameter("@SubName", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[grdBtnSubName.Name].Value.ToString()));
                Param.Add(new SqlParameter("@SubInfo", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SubInfo].Value.ToString()));


                String InsertResidenceWithin = string.Empty;


                //InsertResidenceWithin = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ResidenceWithin"].Index].Value.ToString();

                if (grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ResidenceWithin"].Index].Value != null)
                {
                   

                }

                InsertResidenceWithin = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ResidenceWithin"].Index].Value.ToString();

                Param.Add(new SqlParameter("@ResidenceWithin200ft", InsertResidenceWithin));


                //Param.Add(new SqlParameter("@ResidenceWithin200ft", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[ResidenceWithin200ft].Value.ToString()));


                Param.Add(new SqlParameter("@DatesofVariance", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[DatesofVariance].Value.ToString()));
                Param.Add(new SqlParameter("@DaysofVariance", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[DaysofVariance].Value.ToString()));
                Param.Add(new SqlParameter("@TimeofVarianceFrom", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[TimeofVarianceFrom].Value.ToString()));
                Param.Add(new SqlParameter("@TimeofVarianceTo", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[TimeofVarianceTo].Value.ToString()));
                Param.Add(new SqlParameter("@VarianceWorkDescription", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[VarianceWorkDescription].Value.ToString()));
                Param.Add(new SqlParameter("@ReasonforVariance", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[ReasonforVariance].Value.ToString()));
                Param.Add(new SqlParameter("@SiteArchitect", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteArchitect].Value.ToString()));
                //Param.Add(new SqlParameter("@CommunityBoardID", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[CommunityBoardID].Value.ToString()))
                Param.Add(new SqlParameter("@SiteNumofStories", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteNumofStories].Value.ToString()));


                //Param.Add(new SqlParameter("@SiteOccupancy", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOccupancy].Value.ToString()));

                String InsertSiteOccupancy = string.Empty;


                if (grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["SiteOccu"].Index].Value != null)
                {


                }

                InsertSiteOccupancy = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["SiteOccu"].Index].Value.ToString();

                Param.Add(new SqlParameter("@SiteOccupancy", InsertSiteOccupancy));


                Param.Add(new SqlParameter("@OccupancyType", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[OccupancyType].Value.ToString()));
                Param.Add(new SqlParameter("@SiteNumofApts", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteNumofApts].Value.ToString()));
                Param.Add(new SqlParameter("@SiteNumofAptsCurrent", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteNumofAptsCurrent].Value.ToString()));
                Param.Add(new SqlParameter("@SiteNumofAptsProposed", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteNumofAptsProposed].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwner", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOwner].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerAddress", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOwnerAddress].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerStreet", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOwnerStreet].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerCity", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOwnerCity].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerState", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOwnerState].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerZip", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[SiteOwnerZip].Value.ToString()));
                Param.Add(new SqlParameter("@WorkProposed", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[WorkProposed].Value.ToString()));
                Param.Add(new SqlParameter("@Architect2", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[Architect2].Value.ToString()));
                Param.Add(new SqlParameter("@Architect2fullAddress", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[Architect2fullAddress].Value.ToString()));
                Param.Add(new SqlParameter("@PDFType", grdFormInfo.Rows[grdFormInfo.Rows.Count - 1].Cells[this.dgvPdfTypeCombo.Name].Value.ToString()));
                
                
                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                //    {
                //        KryptonMessageBox.Show("Record Added Successfully");
                //        StMethod.LoginActivityInfo(db, "Insert", this.Text);
                //        btnAdd.Text = "Insert";
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Added Successfully");
                            StMethod.LoginActivityInfoNew(db, "Insert", this.Text);
                            btnAdd.Text = "Insert";
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Added Successfully");
                            StMethod.LoginActivityInfo(db, "Insert", this.Text);
                            btnAdd.Text = "Insert";
                        }
                    }

                }


                FillInfo();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void UpdateFormInfo()
        {
            try
            {
                string Query = "UPDATE VBFormInfo SET JobListID = @JobListID,JobNumber = @JobNumber,Applicant = @Applicant,JobSiteBlock = @JobSiteBlock,JobSiteLot = @JobSiteLot,JobSiteCNNum = @JobSiteCNNum,JobSiteHouseNum = @JobSiteHouseNum,JobSiteStreet = @JobSiteStreet,JobSiteBorough = @JobSiteBorough,JobSiteState = @JobSiteState,Crane1CD = @Crane1CD,Crane2CD = @Crane2CD,Crane3CD = @Crane3CD,Crane4CD = @Crane4CD,Crane5CD = @Crane5CD,Crane6CD = @Crane6CD,CraneUser = @CraneUser,CraneUserInfo = @CraneUserInfo,CraneUserTitle = @CraneUserTitle,WorkPlatformManufacturer = @WorkPlatformManufacturer,WorkPlatformModel = @WorkPlatformModel,WorkPlatformSuperName = @WorkPlatformSuperName,WorkPlatformSuperPhone = @WorkPlatformSuperPhone,WorkPlatformSuperFax = @WorkPlatformSuperFax,WorkPlatformSuperAddr = @WorkPlatformSuperAddr,WorkPlatformSuperCity = @WorkPlatformSuperCity,WorkPlatformSuperState = @WorkPlatformSuperState,WorkPlatformSuperZip = @WorkPlatformSuperZip,FirstVariance = @FirstVariance,BIN = @BIN,CBNum = @CBNum,AptorCondoNum = @AptorCondoNum,SpecialPlaceName = @SpecialPlaceName,SubName = @SubName,SubInfo = @SubInfo,ResidenceWithin200ft = @ResidenceWithin200ft,DatesofVariance = @DatesofVariance,DaysofVariance = @DaysofVariance,TimeofVarianceFrom = @TimeofVarianceFrom,TimeofVarianceTo = @TimeofVarianceTo,VarianceWorkDescription = @VarianceWorkDescription,ReasonforVariance = @ReasonforVariance,SiteArchitect = @SiteArchitect,SiteNumofStories = @SiteNumofStories,SiteOccupancy = @SiteOccupancy,OccupancyType = @OccupancyType,SiteNumofApts = @SiteNumofApts,SiteNumofAptsCurrent = @SiteNumofAptsCurrent,SiteNumofAptsProposed = @SiteNumofAptsProposed,SiteOwner = @SiteOwner,SiteOwnerAddress = @SiteOwnerAddress,SiteOwnerStreet = @SiteOwnerStreet,SiteOwnerCity = @SiteOwnerCity,SiteOwnerState = @SiteOwnerState,SiteOwnerZip = @SiteOwnerZip,WorkProposed = @WorkProposed,Architect2 = @Architect2,Architect2fullAddress = @Architect2fullAddress, PDFType= @PDFType WHERE JobID = @JobID  ";
                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@JobID", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobID].Value.ToString()));
                Param.Add(new SqlParameter("@JobListID", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[cmbGrdJobNumber.Name].Value.ToString()));
                // Param.Add(new SqlParameter("@CommunityID", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString()))
                Param.Add(new SqlParameter("@JobNumber", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobNumber].Value.ToString()));
                Param.Add(new SqlParameter("@Applicant", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteBlock", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBlock].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteLot", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteLot].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteCNNum", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteCNNum].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteHouseNum", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteHouseNum].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteStreet", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteStreet].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteBorough", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteBorough].Value.ToString()));
                Param.Add(new SqlParameter("@JobSiteState", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobSiteState].Value.ToString()));
                Param.Add(new SqlParameter("@Crane1CD", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane2CD", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane3CD", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane4CD", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane5CD", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString()));
                Param.Add(new SqlParameter("@Crane6CD", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString()));
                Param.Add(new SqlParameter("@CraneUser", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCraneUser.Name].Value.ToString()));
                Param.Add(new SqlParameter("@CraneUserInfo", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[CraneUserInfo].Value.ToString()));
                Param.Add(new SqlParameter("@CraneUserTitle", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[CraneUserTitle].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformManufacturer", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformManufacturer].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformModel", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformModel].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperName", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperName].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperPhone", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperPhone].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperFax", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperFax].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperAddr", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperAddr].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperCity", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperCity].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperState", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperState].Value.ToString()));
                Param.Add(new SqlParameter("@WorkPlatformSuperZip", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkPlatformSuperZip].Value.ToString()));

                //Param.Add(new SqlParameter("@FirstVariance", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[FirstVariance].Value.ToString()));


                    String ColumnFirstVarianceVale=string.Empty ;

                    if (grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ColumnFirstVariance"].Index].Value != null)
                    {

                     ColumnFirstVarianceVale = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ColumnFirstVariance"].Index].Value.ToString();
                    }



                Param.Add(new SqlParameter("@FirstVariance", ColumnFirstVarianceVale.ToString()));

                //ColumnFirstVariance


                Param.Add(new SqlParameter("@BIN", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[BIN].Value.ToString()));
                Param.Add(new SqlParameter("@CBNum", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString()));
                Param.Add(new SqlParameter("@AptorCondoNum", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[AptorCondoNum].Value.ToString()));
                Param.Add(new SqlParameter("@SpecialPlaceName", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SpecialPlaceName].Value.ToString()));
                Param.Add(new SqlParameter("@SubName", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnSubName.Name].Value.ToString()));
                Param.Add(new SqlParameter("@SubInfo", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SubInfo].Value.ToString()));


                //Param.Add(new SqlParameter("@ResidenceWithin200ft", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ResidenceWithin200ft].Value.ToString()));


                String ResidenceWithin200ft = string.Empty;

                if (grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ResidenceWithin"].Index].Value != null)
                {

                    ResidenceWithin200ft = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["ResidenceWithin"].Index].Value.ToString();
                }

                
                Param.Add(new SqlParameter("@ResidenceWithin200ft", ResidenceWithin200ft));

                Param.Add(new SqlParameter("@DatesofVariance", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[DatesofVariance].Value.ToString()));
                Param.Add(new SqlParameter("@DaysofVariance", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[DaysofVariance].Value.ToString()));
                Param.Add(new SqlParameter("@TimeofVarianceFrom", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[TimeofVarianceFrom].Value.ToString()));
                Param.Add(new SqlParameter("@TimeofVarianceTo", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[TimeofVarianceTo].Value.ToString()));
                Param.Add(new SqlParameter("@VarianceWorkDescription", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[VarianceWorkDescription].Value.ToString()));
                Param.Add(new SqlParameter("@ReasonforVariance", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ReasonforVariance].Value.ToString()));
                Param.Add(new SqlParameter("@SiteArchitect", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteArchitect].Value.ToString()));
                //Param.Add(new SqlParameter("@CommunityBoardID", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[CommunityBoardID].Value.ToString()))
                Param.Add(new SqlParameter("@SiteNumofStories", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofStories].Value.ToString()));


                //Param.Add(new SqlParameter("@SiteOccupancy", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOccupancy].Value.ToString()));

                String SiteOccupancy = string.Empty;

                if (grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["SiteOccu"].Index].Value != null)
                {

                    SiteOccupancy = grdFormInfo.Rows[grdFormInfo.CurrentCell.RowIndex].Cells[grdFormInfo.Columns["SiteOccu"].Index].Value.ToString();
                }

                Param.Add(new SqlParameter("@SiteOccupancy", SiteOccupancy));


                Param.Add(new SqlParameter("@OccupancyType", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[OccupancyType].Value.ToString()));
                Param.Add(new SqlParameter("@SiteNumofApts", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofApts].Value.ToString()));
                Param.Add(new SqlParameter("@SiteNumofAptsCurrent", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofAptsCurrent].Value.ToString()));
                Param.Add(new SqlParameter("@SiteNumofAptsProposed", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteNumofAptsProposed].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwner", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwner].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerAddress", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerAddress].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerStreet", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerStreet].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerCity", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerCity].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerState", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerState].Value.ToString()));
                Param.Add(new SqlParameter("@SiteOwnerZip", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[SiteOwnerZip].Value.ToString()));
                Param.Add(new SqlParameter("@WorkProposed", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[WorkProposed].Value.ToString()));
                Param.Add(new SqlParameter("@Architect2", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Architect2].Value.ToString()));
                Param.Add(new SqlParameter("@Architect2fullAddress", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[Architect2fullAddress].Value.ToString()));
                Param.Add(new SqlParameter("@PDFType", grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[this.dgvPdfTypeCombo.Name].Value.ToString()));

                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                //    {
                //        KryptonMessageBox.Show("Record Update Successfully");
                //        StMethod.LoginActivityInfo(db, "Update", this.Text);
                //        btnAdd.Text = "Insert";
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Update Successfully");
                            StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                            btnAdd.Text = "Insert";
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Update Successfully");
                            StMethod.LoginActivityInfo(db, "Update", this.Text);
                            btnAdd.Text = "Insert";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void DeleteForminfoRecord()
        {
            try
            {
                string Query = "DELETE  FROM VBFormInfo WHERE JobID = " + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[JobID].Value.ToString();
                SqlCommand CMD = new SqlCommand(Query);
                if (KryptonMessageBox.Show("Are you sure to delete these record!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            if (db.Database.ExecuteSqlCommand(Query) == 1)
                            {
                                KryptonMessageBox.Show("Record Deleted Successfully");
                                StMethod.LoginActivityInfoNew(db, "Delete", this.Text);
                            }
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            if (db.Database.ExecuteSqlCommand(Query) == 1)
                            {
                                KryptonMessageBox.Show("Record Deleted Successfully");
                                StMethod.LoginActivityInfo(db, "Delete", this.Text);
                            }
                        }
                    }

                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    if (db.Database.ExecuteSqlCommand(Query) == 1)
                    //    {
                    //        KryptonMessageBox.Show("Record Deleted Successfully");
                    //        StMethod.LoginActivityInfo(db, "Delete", this.Text);
                    //    }
                    //}
                }

                FillInfo();
            }
            catch (Exception ex)
            {
            }
        }
        private void FillApplicantGrid()
        {
            try
            {
                string Query = "SELECT ApplicantID, ApplicantFirstName, ApplicantLastName, ApplicantMidName, ApplicantBusinessName, ApplicantBusinessAddress, ApplicantBusinessCity, ApplicantBusinessState, ApplicantBusinessZip, ApplicantTitle, ApplicantLicense, ApplicantPhone, Applicantfax FROM VBNetApplicantInfo WHERE ApplicantID<>0";
                //If SelectApplicantID <> String.Empty Then
                //    Query = Query & " AND ApplicantID=" & SelectApplicantID
                //End If
                //////using (EFDbContext db = new EFDbContext())
                //////{
                //////    PdfEditTableBindingSourceApplicationInfo.DataSource = db.Database.SqlQuery<ApplicantInfo>(Query).ToList();
                //////}
                ///
                
                
                //PdfEditTableBindingSourceApplicationInfo.DataSource = StMethod.GetListDT<ApplicantInfo>(Query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    PdfEditTableBindingSourceApplicationInfo.DataSource = StMethod.GetListDTNew<ApplicantInfo>(Query);
                }
                else
                {
                    PdfEditTableBindingSourceApplicationInfo.DataSource = StMethod.GetListDT<ApplicantInfo>(Query);
                }

                //MessageBox.Show("PdfEditTableBindingSourceApplicationInfo Count => " + PdfEditTableBindingSourceApplicationInfo.Count.ToString());


                //grdApplicantInfo.DataSource = GrdDT
            }
            catch (Exception ex)
            {
                //KryptonMessageBox.Show(ex.Message);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void FillCommunityBoardGrid()
        {
            try
            {
                string Query = "SELECT CommunityBoardID, CommunityBoardNum, ChairPerson, Address, City, State, Zip, Phone, Fax FROM CommunityBoard";
                //////using (EFDbContext db = new EFDbContext())
                //////{
                //////    PdfEditTableBindingSourceCommunityBoard.DataSource = db.Database.SqlQuery<CommunityData>(Query, new DataTable()).ToList();
                //////}


                //PdfEditTableBindingSourceCommunityBoard.DataSource = StMethod.GetListDT<CommunityData>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    PdfEditTableBindingSourceCommunityBoard.DataSource = StMethod.GetListDTNew<CommunityData>(Query);
                }
                else
                {
                    PdfEditTableBindingSourceCommunityBoard.DataSource = StMethod.GetListDT<CommunityData>(Query);
                }


                //grdCommunityBoard.DataSource = GrdDT
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void FillCraneInfoGrid()
        {
            try
            {
                string Query = "SELECT CDID, CDNumber, SerialNumber, Make, Model, ModelYear, Capacity, Owner, Expiration, ModelSpaceName, Notes, CraneName, CraneID, OwnerPhone, OwnerFax,  TypMast, TypBoom, TypJIB, TypTotal, EquipmentType, ErectionStyle, TravelCTWT, Dunnage1, Dunnage2, MaxOrLoad, IsChange, IsNewRecord, IsDelete, ChangeDate,  ApprovedChartType FROM VBCDDatabase";
                ////using (EFDbContext db = new EFDbContext())
                ////{
                ////    PdfEditTableBindingSourceCDinfo.DataSource = db.Database.SqlQuery<CDInfoData>(Query, new DataTable()).ToList();
                ////}
                
                
                //PdfEditTableBindingSourceCDinfo.DataSource = StMethod.GetListDT<CDInfoData>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    PdfEditTableBindingSourceCDinfo.DataSource = StMethod.GetListDTNew<CDInfoData>(Query);
                }
                else
                {
                    PdfEditTableBindingSourceCDinfo.DataSource = StMethod.GetListDT<CDInfoData>(Query);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void RefreshdependedGrid()
        {
            try
            {
                if (grdFormInfo.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString()))
                    {
                        FillApplicantGrid();
                        PdfEditTableBindingSourceApplicationInfo.Filter = "ApplicantID=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString();
                    }
                    else
                    {
                        PdfEditTableBindingSourceApplicationInfo.Filter = "ApplicantID=0";
                    }
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString()))
                    {
                        FillCommunityBoardGrid();
                        PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=" + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[btnGrdCBNum.Name].Value.ToString();
                    }
                    else
                    {
                        FillCommunityBoardGrid();
                        PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=0";
                    }
                    string CDQuery = "";
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString()))
                    {
                        CDQuery = CDQuery + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane1.Name].Value.ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString()))
                    {
                        CDQuery = CDQuery + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane2.Name].Value.ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString()))
                    {
                        CDQuery = CDQuery + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane3.Name].Value.ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString()))
                    {
                        CDQuery = CDQuery + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane4.Name].Value.ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString()))
                    {
                        CDQuery = CDQuery + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane5.Name].Value.ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString()))
                    {
                        CDQuery = CDQuery + grdFormInfo.Rows[grdFormInfo.CurrentRow.Index].Cells[grdBtnCrane6.Name].Value.ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(CDQuery.Trim()))
                    {
                        CDQuery = CDQuery.Remove(CDQuery.LastIndexOf(","));
                        FillCraneInfoGrid();
                        PdfEditTableBindingSourceCDinfo.Filter = "CDID IN (" + CDQuery + ")";
                    }
                }
                else
                {
                    PdfEditTableBindingSourceApplicationInfo.Filter = "ApplicantID=0";
                    PdfEditTableBindingSourceCommunityBoard.Filter = "CommunityBoardNum=0";
                    PdfEditTableBindingSourceCDinfo.Filter = "CDID=0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private string SelectCheckString()
        {
            try
            {
                string frmName = this.Name.ToString();
                // DAL.LoginActivityInfo()
                string Querystring = "";
                if (chkCD4.Checked)
                {
                    Querystring = Querystring + "'CD4',";
                }
                if (chkCD7.Checked)
                {
                    Querystring = Querystring + "'CD7',";
                }
                if (chkCD8.Checked)
                {
                    Querystring = Querystring + "'CD8',";
                }
                if (chkCD10.Checked)
                {
                    Querystring = Querystring + "'CD10',";
                }
                if (chkCD16.Checked)
                {
                    Querystring = Querystring + "'CD16',";
                }
                if (chkCD12.Checked)
                {
                    Querystring = Querystring + "'CD12',";
                }
                if (chkCD21.Checked)
                {
                    Querystring = Querystring + "'CD21',";
                }
                if (chkCD22.Checked)
                {
                    Querystring = Querystring + "'CD22',";
                }
                if (chkCD24.Checked)
                {
                    Querystring = Querystring + "'CD24',";
                }
                if (chk_Dot_govt_work_permit_app.Checked)
                {
                    Querystring = Querystring + "'dot govt_work_permit_app',";
                }
                if (chk_Dot_govt_work_permit_reissue_app.Checked)
                {
                    Querystring = Querystring + "'dot govt_work_permit_reissue_app',";
                }
                if (chk_Dot_govt_work_permit_renew_app.Checked)
                {
                    Querystring = Querystring + "'dot govt_work_permit_renew_app',";
                }
                if (chkAEU2.Checked)
                {
                    Querystring = Querystring + "'AEU2',";
                }
                if (chkAEU20.Checked)
                {
                    Querystring = Querystring + "'AEU20',";
                }
                if (chkDebrisLatter.Checked)
                {
                    Querystring = Querystring + "'Debris Latter',";
                }
                if (chkDot_holidayembapp.Checked)
                {
                    Querystring = Querystring + "'dot holidayembapp',";
                }
                if (chkdot_permapp.Checked)
                {
                    Querystring = Querystring + "'dot permapp',";
                }
                if (chkdot_permappreissue.Checked)
                {
                    Querystring = Querystring + "'dot permappreissue',";
                }
                if (chkdot_permapprenew.Checked)
                {
                    Querystring = Querystring + "'dot permapprenew',";
                }
                if (chkdot_regapp.Checked)
                {
                    Querystring = Querystring + "'dot regapp',";
                }
                if (chkdot_roadway_closure_app.Checked)
                {
                    Querystring = Querystring + "'dot roadway_closure_app',";
                }
                if (chkPW5.Checked)
                {
                    Querystring = Querystring + "'PW5',";
                }
                if (string.IsNullOrEmpty(Querystring))
                {
                    return "";
                }
                Querystring = Querystring.Remove(Querystring.Length - 1, 1);
                return Querystring;
                // Querystring = Querystring.Remove(Querystring.LastIndexOf(","), 1)
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private DataTable GetCDInfo(string sWhereClause)
        {
            DataTable dtReturn = null;
            try
            {
                string query = "SELECT * FROM VBCDDatabase WHERE CDID=";
                query += (!string.IsNullOrEmpty(sWhereClause)) ? sWhereClause : "0";


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<CDInfoData>(query).ToList();
                //    dtReturn = Program.ToDataTable<CDInfoData>((List<CDInfoData>)data);
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    

                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<CDInfoData>(query).ToList();
                        dtReturn = Program.ToDataTable<CDInfoData>((List<CDInfoData>)data);
                    }

                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<CDInfoData>(query).ToList();
                        dtReturn = Program.ToDataTable<CDInfoData>((List<CDInfoData>)data);
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
            return dtReturn;
        }
        #endregion

        private void grdFormInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdFormInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 31 && e.RowIndex > -1)
                {
                    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)grdFormInfo.CurrentCell;
                    bool isChecked = (bool)checkbox.EditedFormattedValue;                                       

                    //MessageBox.Show(isChecked.ToString());
                }

                //MessageBox.Show(e.ColumnIndex.ToString());

                if (e.ColumnIndex == 38 && e.RowIndex > -1)
                {
                    DataGridViewCheckBoxCell checkbox2 = (DataGridViewCheckBoxCell)grdFormInfo.CurrentCell;
                    bool isChecked2 = (bool)checkbox2.EditedFormattedValue;
                }

                if (e.ColumnIndex == 47 && e.RowIndex > -1)
                {
                    DataGridViewCheckBoxCell checkbox3 = (DataGridViewCheckBoxCell)grdFormInfo.CurrentCell;
                    bool isChecked3 = (bool)checkbox3.EditedFormattedValue;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdCraneInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

