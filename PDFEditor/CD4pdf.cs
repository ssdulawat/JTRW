using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD4pdf
    {
        private Hashtable CD4ht = new Hashtable();
        #region Constant CD4 data field variable
        private const string CN_Number = "topmostSubform[0].Page1[0].CN_Number[0]";
        private const string ApplicationType_New = "topmostSubform[0].Page1[0].ApplicationType_New[0]";
        private const string ApplicationType_Renewal = "topmostSubform[0].Page1[0].ApplicationType_Renewal[0]";
        private const string ApplicationType_Amendment = "topmostSubform[0].Page1[0].ApplicationType_Amendment[0]";
        private const string EquipType_MobileCrane = "topmostSubform[0].Page1[0].EquipType_MobileCrane[0]";
        private const string EquipType_MobileTowerCrane = "topmostSubform[0].Page1[0].EquipType_MobileTowerCrane[0]";
        private const string EquipType_Fix_ClimberTower = "topmostSubform[0].Page1[0].EquipType_Fix_ClimberTower[0]";
        private const string EquipType_Derrick = "topmostSubform[0].Page1[0].EquipType_Derrick[0]";
        private const string EquipType_MastClimber = "topmostSubform[0].Page1[0].EquipType_MastClimber[0]";
        private const string EquipType_PileDriver = "topmostSubform[0].Page1[0].EquipType_PileDriver[0]";
        private const string Borough = "topmostSubform[0].Page1[0].Borough[0]";
        private const string Block = "topmostSubform[0].Page1[0].Block[0]";
        private const string Lot = "topmostSubform[0].Page1[0].Lot[0]";
        private const string Address = "topmostSubform[0].Page1[0].Address[0]";
        private const string Job_No = "topmostSubform[0].Page1[0].Job_No[0]";
        private const string CD_Number_1 = "topmostSubform[0].Page1[0].CD_Number__1[0]";
        private const string CD_Number_2 = "topmostSubform[0].Page1[0].CD_Number__2[0]";
        private const string CD_Number_3 = "topmostSubform[0].Page1[0].CD_Number__3[0]";
        private const string CD_Number_4 = "topmostSubform[0].Page1[0].CD_Number__4[0]";
        private const string CD_Number_5 = "topmostSubform[0].Page1[0].CD_Number__5[0]";
        private const string CD_Number_6 = "topmostSubform[0].Page1[0].CD_Number__6[0]";
        private const string Serial_Number_1 = "topmostSubform[0].Page1[0].Serial_Number__1[0]";
        private const string Serial_Number_2 = "topmostSubform[0].Page1[0].Serial_Number__2[0]";
        private const string Serial_Number_3 = "topmostSubform[0].Page1[0].Serial_Number__3[0]";
        private const string Serial_Number_4 = "topmostSubform[0].Page1[0].Serial_Number__4[0]";
        private const string Serial_Number_5 = "topmostSubform[0].Page1[0].Serial_Number__5[0]";
        private const string Serial_Number_6 = "topmostSubform[0].Page1[0].Serial_Number__6[0]";
        private const string Expiration_Date_1 = "topmostSubform[0].Page1[0].Expiration_Date__1[0]";
        private const string Expiration_Date_2 = "topmostSubform[0].Page1[0].Expiration_Date__2[0]";
        private const string Expiration_Date_3 = "topmostSubform[0].Page1[0].Expiration_Date__3[0]";
        private const string Expiration_Date_4 = "topmostSubform[0].Page1[0].Expiration_Date__4[0]";
        private const string Expiration_Date_5 = "topmostSubform[0].Page1[0].Expiration_Date__5[0]";
        private const string Expiration_Date_6 = "topmostSubform[0].Page1[0].Expiration_Date__6[0]";
        private const string Mast_ft_1 = "topmostSubform[0].Page1[0].Mast_ft__1[0]";
        private const string Mast_ft_2 = "topmostSubform[0].Page1[0].Mast_ft__2[0]";
        private const string Mast_ft_3 = "topmostSubform[0].Page1[0].Mast_ft__3[0]";
        private const string Mast_ft_4 = "topmostSubform[0].Page1[0].Mast_ft__4[0]";
        private const string Mast_ft_5 = "topmostSubform[0].Page1[0].Mast_ft__5[0]";
        private const string Mast_ft_6 = "topmostSubform[0].Page1[0].Mast_ft__6[0]";
        private const string Boom_ft_1 = "topmostSubform[0].Page1[0].Boom_ft__1[0]";
        private const string Boom_ft_2 = "topmostSubform[0].Page1[0].Boom_ft__2[0]";
        private const string Boom_ft_3 = "topmostSubform[0].Page1[0].Boom_ft__3[0]";
        private const string Boom_ft_4 = "topmostSubform[0].Page1[0].Boom_ft__4[0]";
        private const string Boom_ft_5 = "topmostSubform[0].Page1[0].Boom_ft__5[0]";
        private const string Boom_ft_6 = "topmostSubform[0].Page1[0].Boom_ft__6[0]";
        private const string Jib_ft_1 = "topmostSubform[0].Page1[0].Jib_ft__1[0]";
        private const string Jib_ft_2 = "topmostSubform[0].Page1[0].Jib_ft__2[0]";
        private const string Jib_ft_3 = "topmostSubform[0].Page1[0].Jib_ft__3[0]";
        private const string Jib_ft_4 = "topmostSubform[0].Page1[0].Jib_ft__4[0]";
        private const string Jib_ft_5 = "topmostSubform[0].Page1[0].Jib_ft__5[0]";
        private const string Jib_ft_6 = "topmostSubform[0].Page1[0].Jib_ft__6[0]";
        private const string Total_ft_1 = "topmostSubform[0].Page1[0].Total_ft__1[0]";
        private const string Total_ft_2 = "topmostSubform[0].Page1[0].Total_ft__2[0]";
        private const string Total_ft_3 = "topmostSubform[0].Page1[0].Total_ft__3[0]";
        private const string Total_ft_4 = "topmostSubform[0].Page1[0].Total_ft__4[0]";
        private const string Total_ft_5 = "topmostSubform[0].Page1[0].Total_ft__5[0]";
        private const string Total_ft_6 = "topmostSubform[0].Page1[0].Total_ft__6[0]";
        private const string Appl_Name = "topmostSubform[0].Page1[0].Appl_Name[0]";
        private const string Appl_Email = "topmostSubform[0].Page1[0].Appl_Email[0]";
        private const string Appl_Title = "topmostSubform[0].Page1[0].Appl_Title[0]";
        private const string Appl_Lic_No = "topmostSubform[0].Page1[0].Appl_Lic_No[0]";
        private const string Appl_Bus_Name = "topmostSubform[0].Page1[0].Appl_Bus_Name[0]";
        private const string Appl_Address = "topmostSubform[0].Page1[0].Appl_Address[0]";
        private const string Appl_City = "topmostSubform[0].Page1[0].Appl_City[0]";
        private const string Appl_State = "topmostSubform[0].Page1[0].Appl_State[0]";
        private const string Appl_Zip = "topmostSubform[0].Page1[0].Appl_Zip[0]";
        private const string Appl_Phone = "topmostSubform[0].Page1[0].Appl_Phone[0]";
        private const string Appl_Fax = "topmostSubform[0].Page1[0].Appl_Fax[0]";
        private const string MCS_Name = "topmostSubform[0].Page1[0].MCS_Name[0]";
        private const string MCS_Lic_No = "topmostSubform[0].Page1[0].MCS_Lic_No[0]";
        private const string MCS_Address = "topmostSubform[0].Page1[0].MCS_Address[0]";
        private const string MCS_City = "topmostSubform[0].Page1[0].MCS_City[0]";
        private const string MCS_State = "topmostSubform[0].Page1[0].MCS_State[0]";
        private const string MCS_Zip = "topmostSubform[0].Page1[0].MCS_Zip[0]";
        private const string MCS_Phone = "topmostSubform[0].Page1[0].MCS_Phone[0]";
        private const string MCS_Fax = "topmostSubform[0].Page1[0].MCS_Fax[0]";
        private const string DateTimeField1 = "topmostSubform[0].Page1[0].DateTimeField1[0]";
        private const string Equip_Name = "topmostSubform[0].Page1[0].Equip_Name[0]";
        private const string Equip_email = "topmostSubform[0].Page1[0].Equip_email[0]";
        private const string Equip_Title = "topmostSubform[0].Page1[0].Equip_Title[0]";
        private const string Equip_Company = "topmostSubform[0].Page1[0].Equip_Company[0]";
        private const string Equip_Address = "topmostSubform[0].Page1[0].Equip_Address[0]";
        private const string Equip_City = "topmostSubform[0].Page1[0].Equip_City[0]";
        private const string Equip_State = "topmostSubform[0].Page1[0].Equip_State[0]";
        private const string Equip_Zip = "topmostSubform[0].Page1[0].Equip_Zip[0]";
        private const string Equip_Phone = "topmostSubform[0].Page1[0].Equip_Phone[0]";
        private const string Equip_Fax = "topmostSubform[0].Page1[0].Equip_Fax[0]";
        private const string CSC_Name = "topmostSubform[0].Page1[0].CSC_Name[0]";
        private const string CSC_Lic_No = "topmostSubform[0].Page1[0].CSC_Lic_No[0]";
        private const string CSC_Address = "topmostSubform[0].Page1[0].CSC_Address[0]";
        private const string CSC_City = "topmostSubform[0].Page1[0].CSC_City[0]";
        private const string CSC_State = "topmostSubform[0].Page1[0].CSC_State[0]";
        private const string CSC_Zip = "topmostSubform[0].Page1[0].CSC_Zip[0]";
        private const string CSC_Phone = "topmostSubform[0].Page1[0].CSC_Phone[0]";
        private const string CSC_Fax = "topmostSubform[0].Page1[0].CSC_Fax[0]";
        #endregion
        #region CD4 field Properties
        public string CN_Number_Pro
        {
            get
            {
                return CD4ht[CN_Number].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CN_Number))
                {
                    CD4ht[CN_Number] = value;
                }
                else
                {
                    CD4ht.Add(CN_Number, value);
                }
            }
        }
        public string ApplicationType_New_Pro
        {
            get
            {
                return CD4ht[ApplicationType_New].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(ApplicationType_New))
                {
                    CD4ht[ApplicationType_New] = value;
                }
                else
                {
                    CD4ht.Add(ApplicationType_New, value);
                }
            }
        }
        public string ApplicationType_Renewal_Pro
        {
            get
            {
                return CD4ht[ApplicationType_Renewal].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(ApplicationType_Renewal))
                {
                    CD4ht[ApplicationType_Renewal] = value;
                }
                else
                {
                    CD4ht.Add(ApplicationType_Renewal, value);
                }
            }
        }
        public string ApplicationType_Amendment_Pro
        {
            get
            {
                return CD4ht[ApplicationType_Amendment].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(ApplicationType_Amendment))
                {
                    CD4ht[ApplicationType_Amendment] = value;
                }
                else
                {
                    CD4ht.Add(ApplicationType_Amendment, value);
                }
            }
        }
        public string EquipType_MobileCrane_Pro
        {
            get
            {
                return CD4ht[EquipType_MobileCrane].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(EquipType_MobileCrane))
                {
                    CD4ht[EquipType_MobileCrane] = value;
                }
                else
                {
                    CD4ht.Add(EquipType_MobileCrane, value);
                }
            }
        }
        public string EquipType_MobileTowerCrane_Pro
        {
            get
            {
                return CD4ht[EquipType_MobileTowerCrane].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(EquipType_MobileTowerCrane))
                {
                    CD4ht[EquipType_MobileTowerCrane] = value;
                }
                else
                {
                    CD4ht.Add(EquipType_MobileTowerCrane, value);
                }
            }
        }
        public string EquipType_Fix_ClimberTower_Pro
        {
            get
            {
                return CD4ht[EquipType_Fix_ClimberTower].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(EquipType_Fix_ClimberTower))
                {
                    CD4ht[EquipType_Fix_ClimberTower] = value;
                }
                else
                {
                    CD4ht.Add(EquipType_Fix_ClimberTower, value);
                }
            }
        }
        public string EquipType_Derrick_Pro
        {
            get
            {
                return CD4ht[EquipType_Derrick].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(EquipType_Derrick))
                {
                    CD4ht[EquipType_Derrick] = value;
                }
                else
                {
                    CD4ht.Add(EquipType_Derrick, value);
                }
            }
        }
        public string EquipType_MastClimber_Pro
        {
            get
            {
                return CD4ht[EquipType_MastClimber].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(EquipType_MastClimber))
                {
                    CD4ht[EquipType_MastClimber] = value;
                }
                else
                {
                    CD4ht.Add(EquipType_MastClimber, value);
                }
            }
        }
        public string EquipType_PileDriver_Pro
        {
            get
            {
                return CD4ht[EquipType_PileDriver].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(EquipType_PileDriver))
                {
                    CD4ht[EquipType_PileDriver] = value;
                }
                else
                {
                    CD4ht.Add(EquipType_PileDriver, value);
                }
            }
        }
        public string Borough_Pro
        {
            get
            {
                return CD4ht[Borough].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Borough))
                {
                    CD4ht[Borough] = value;
                }
                else
                {
                    CD4ht.Add(Borough, value);
                }
            }
        }
        public string Block_Pro
        {
            get
            {
                return CD4ht[Block].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Block))
                {
                    CD4ht[Block] = value;
                }
                else
                {
                    CD4ht.Add(Block, value);
                }
            }
        }
        public string Lot_Pro
        {
            get
            {
                return CD4ht[Lot].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Lot))
                {
                    CD4ht[Lot] = value;
                }
                else
                {
                    CD4ht.Add(Lot, value);
                }
            }
        }
        public string Address_Pro
        {
            get
            {
                return CD4ht[Address].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Address))
                {
                    CD4ht[Address] = value;
                }
                else
                {
                    CD4ht.Add(Address, value);
                }
            }
        }
        public string Job_No_Pro
        {
            get
            {
                return CD4ht[Job_No].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Job_No))
                {
                    CD4ht[Job_No] = value;
                }
                else
                {
                    CD4ht.Add(Job_No, value);
                }
            }
        }
        public string CD_Number_1_Pro
        {
            get
            {
                return CD4ht[CD_Number_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CD_Number_1))
                {
                    CD4ht[CD_Number_1] = value;
                }
                else
                {
                    CD4ht.Add(CD_Number_1, value);
                }
            }
        }
        public string CD_Number_2_Pro
        {
            get
            {
                return CD4ht[CD_Number_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CD_Number_2))
                {
                    CD4ht[CD_Number_2] = value;
                }
                else
                {
                    CD4ht.Add(CD_Number_2, value);
                }
            }
        }
        public string CD_Number_3_Pro
        {
            get
            {
                return CD4ht[CD_Number_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CD_Number_3))
                {
                    CD4ht[CD_Number_3] = value;
                }
                else
                {
                    CD4ht.Add(CD_Number_3, value);
                }
            }
        }
        public string CD_Number_4_Pro
        {
            get
            {
                return CD4ht[CD_Number_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CD_Number_4))
                {
                    CD4ht[CD_Number_4] = value;
                }
                else
                {
                    CD4ht.Add(CD_Number_4, value);
                }
            }
        }
        public string CD_Number_5_Pro
        {
            get
            {
                return CD4ht[CD_Number_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CD_Number_5))
                {
                    CD4ht[CD_Number_5] = value;
                }
                else
                {
                    CD4ht.Add(CD_Number_5, value);
                }
            }
        }
        public string CD_Number_6_Pro
        {
            get
            {
                return CD4ht[CD_Number_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CD_Number_6))
                {
                    CD4ht[CD_Number_6] = value;
                }
                else
                {
                    CD4ht.Add(CD_Number_6, value);
                }
            }
        }
        public string Serial_Number_1_Pro
        {
            get
            {
                return CD4ht[Serial_Number_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Serial_Number_1))
                {
                    CD4ht[Serial_Number_1] = value;
                }
                else
                {
                    CD4ht.Add(Serial_Number_1, value);
                }
            }
        }
        public string Serial_Number_2_Pro
        {
            get
            {
                return CD4ht[Serial_Number_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Serial_Number_2))
                {
                    CD4ht[Serial_Number_2] = value;
                }
                else
                {
                    CD4ht.Add(Serial_Number_2, value);
                }
            }
        }
        public string Serial_Number_3_Pro
        {
            get
            {
                return CD4ht[Serial_Number_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Serial_Number_3))
                {
                    CD4ht[Serial_Number_3] = value;
                }
                else
                {
                    CD4ht.Add(Serial_Number_3, value);
                }
            }
        }
        public string Serial_Number_4_Pro
        {
            get
            {
                return CD4ht[Serial_Number_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Serial_Number_4))
                {
                    CD4ht[Serial_Number_4] = value;
                }
                else
                {
                    CD4ht.Add(Serial_Number_4, value);
                }
            }
        }
        public string Serial_Number_5_Pro
        {
            get
            {
                return CD4ht[Serial_Number_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Serial_Number_5))
                {
                    CD4ht[Serial_Number_5] = value;
                }
                else
                {
                    CD4ht.Add(Serial_Number_5, value);
                }
            }
        }
        public string Serial_Number_6_Pro
        {
            get
            {
                return CD4ht[Serial_Number_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Serial_Number_6))
                {
                    CD4ht[Serial_Number_6] = value;
                }
                else
                {
                    CD4ht.Add(Serial_Number_6, value);
                }
            }
        }
        public string Expiration_Date_1_Pro
        {
            get
            {
                return CD4ht[Expiration_Date_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Expiration_Date_1))
                {
                    CD4ht[Expiration_Date_1] = value;
                }
                else
                {
                    CD4ht.Add(Expiration_Date_1, value);
                }
            }
        }
        public string Expiration_Date_2_Pro
        {
            get
            {
                return CD4ht[Expiration_Date_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Expiration_Date_2))
                {
                    CD4ht[Expiration_Date_2] = value;
                }
                else
                {
                    CD4ht.Add(Expiration_Date_2, value);
                }
            }
        }
        public string Expiration_Date_3_Pro
        {
            get
            {
                return CD4ht[Expiration_Date_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Expiration_Date_3))
                {
                    CD4ht[Expiration_Date_3] = value;
                }
                else
                {
                    CD4ht.Add(Expiration_Date_3, value);
                }
            }
        }
        public string Expiration_Date_4_Pro
        {
            get
            {
                return CD4ht[Expiration_Date_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Expiration_Date_4))
                {
                    CD4ht[Expiration_Date_4] = value;
                }
                else
                {
                    CD4ht.Add(Expiration_Date_4, value);
                }
            }
        }
        public string Expiration_Date_5_Pro
        {
            get
            {
                return CD4ht[Expiration_Date_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Expiration_Date_5))
                {
                    CD4ht[Expiration_Date_5] = value;
                }
                else
                {
                    CD4ht.Add(Expiration_Date_5, value);
                }
            }
        }
        public string Expiration_Date_6_Pro
        {
            get
            {
                return CD4ht[Expiration_Date_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Expiration_Date_6))
                {
                    CD4ht[Expiration_Date_6] = value;
                }
                else
                {
                    CD4ht.Add(Expiration_Date_6, value);
                }
            }
        }
        public string Mast_ft_1_Pro
        {
            get
            {
                return CD4ht[Mast_ft_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Mast_ft_1))
                {
                    CD4ht[Mast_ft_1] = value;
                }
                else
                {
                    CD4ht.Add(Mast_ft_1, value);
                }
            }
        }
        public string Mast_ft_2_Pro
        {
            get
            {
                return CD4ht[Mast_ft_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Mast_ft_2))
                {
                    CD4ht[Mast_ft_2] = value;
                }
                else
                {
                    CD4ht.Add(Mast_ft_2, value);
                }
            }
        }
        public string Mast_ft_3_Pro
        {
            get
            {
                return CD4ht[Mast_ft_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Mast_ft_3))
                {
                    CD4ht[Mast_ft_3] = value;
                }
                else
                {
                    CD4ht.Add(Mast_ft_3, value);
                }
            }
        }
        public string Mast_ft_4_Pro
        {
            get
            {
                return CD4ht[Mast_ft_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Mast_ft_4))
                {
                    CD4ht[Mast_ft_4] = value;
                }
                else
                {
                    CD4ht.Add(Mast_ft_4, value);
                }
            }
        }
        public string Mast_ft_5_Pro
        {
            get
            {
                return CD4ht[Mast_ft_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Mast_ft_5))
                {
                    CD4ht[Mast_ft_5] = value;
                }
                else
                {
                    CD4ht.Add(Mast_ft_5, value);
                }
            }
        }
        public string Mast_ft_6_Pro
        {
            get
            {
                return CD4ht[Mast_ft_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Mast_ft_6))
                {
                    CD4ht[Mast_ft_6] = value;
                }
                else
                {
                    CD4ht.Add(Mast_ft_6, value);
                }
            }
        }
        public string Boom_ft_1_Pro
        {
            get
            {
                return CD4ht[Boom_ft_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Boom_ft_1))
                {
                    CD4ht[Boom_ft_1] = value;
                }
                else
                {
                    CD4ht.Add(Boom_ft_1, value);
                }
            }
        }
        public string Boom_ft_2_Pro
        {
            get
            {
                return CD4ht[Boom_ft_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Boom_ft_2))
                {
                    CD4ht[Boom_ft_2] = value;
                }
                else
                {
                    CD4ht.Add(Boom_ft_2, value);
                }
            }
        }
        public string Boom_ft_3_Pro
        {
            get
            {
                return CD4ht[Boom_ft_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Boom_ft_3))
                {
                    CD4ht[Boom_ft_3] = value;
                }
                else
                {
                    CD4ht.Add(Boom_ft_3, value);
                }
            }
        }
        public string Boom_ft_4_Pro
        {
            get
            {
                return CD4ht[Boom_ft_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Boom_ft_4))
                {
                    CD4ht[Boom_ft_4] = value;
                }
                else
                {
                    CD4ht.Add(Boom_ft_4, value);
                }
            }
        }
        public string Boom_ft_5_Pro
        {
            get
            {
                return CD4ht[Boom_ft_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Boom_ft_5))
                {
                    CD4ht[Boom_ft_5] = value;
                }
                else
                {
                    CD4ht.Add(Boom_ft_5, value);
                }
            }
        }
        public string Boom_ft_6_Pro
        {
            get
            {
                return CD4ht[Boom_ft_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Boom_ft_6))
                {
                    CD4ht[Boom_ft_6] = value;
                }
                else
                {
                    CD4ht.Add(Boom_ft_6, value);
                }
            }
        }
        public string Jib_ft_1_Pro
        {
            get
            {
                return CD4ht[Jib_ft_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Jib_ft_1))
                {
                    CD4ht[Jib_ft_1] = value;
                }
                else
                {
                    CD4ht.Add(Jib_ft_1, value);
                }
            }
        }
        public string Jib_ft_2_Pro
        {
            get
            {
                return CD4ht[Jib_ft_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Jib_ft_2))
                {
                    CD4ht[Jib_ft_2] = value;
                }
                else
                {
                    CD4ht.Add(Jib_ft_2, value);
                }
            }
        }
        public string Jib_ft_3_Pro
        {
            get
            {
                return CD4ht[Jib_ft_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Jib_ft_3))
                {
                    CD4ht[Jib_ft_3] = value;
                }
                else
                {
                    CD4ht.Add(Jib_ft_3, value);
                }
            }
        }
        public string Jib_ft_4_Pro
        {
            get
            {
                return CD4ht[Jib_ft_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Jib_ft_4))
                {
                    CD4ht[Jib_ft_4] = value;
                }
                else
                {
                    CD4ht.Add(Jib_ft_4, value);
                }
            }
        }
        public string Jib_ft_5_Pro
        {
            get
            {
                return CD4ht[Jib_ft_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Jib_ft_5))
                {
                    CD4ht[Jib_ft_5] = value;
                }
                else
                {
                    CD4ht.Add(Jib_ft_5, value);
                }
            }
        }
        public string Jib_ft_6_Pro
        {
            get
            {
                return CD4ht[Jib_ft_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Jib_ft_6))
                {
                    CD4ht[Jib_ft_6] = value;
                }
                else
                {
                    CD4ht.Add(Jib_ft_6, value);
                }
            }
        }
        public string Total_ft_1_Pro
        {
            get
            {
                return CD4ht[Total_ft_1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Total_ft_1))
                {
                    CD4ht[Total_ft_1] = value;
                }
                else
                {
                    CD4ht.Add(Total_ft_1, value);
                }
            }
        }
        public string Total_ft_2_Pro
        {
            get
            {
                return CD4ht[Total_ft_2].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Total_ft_2))
                {
                    CD4ht[Total_ft_2] = value;
                }
                else
                {
                    CD4ht.Add(Total_ft_2, value);
                }
            }
        }
        public string Total_ft_3_Pro
        {
            get
            {
                return CD4ht[Total_ft_3].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Total_ft_3))
                {
                    CD4ht[Total_ft_3] = value;
                }
                else
                {
                    CD4ht.Add(Total_ft_3, value);
                }
            }
        }
        public string Total_ft_4_Pro
        {
            get
            {
                return CD4ht[Total_ft_4].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Total_ft_4))
                {
                    CD4ht[Total_ft_4] = value;
                }
                else
                {
                    CD4ht.Add(Total_ft_4, value);
                }
            }
        }
        public string Total_ft_5_Pro
        {
            get
            {
                return CD4ht[Total_ft_5].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Total_ft_5))
                {
                    CD4ht[Total_ft_5] = value;
                }
                else
                {
                    CD4ht.Add(Total_ft_5, value);
                }
            }
        }
        public string Total_ft_6_Pro
        {
            get
            {
                return CD4ht[Total_ft_6].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Total_ft_6))
                {
                    CD4ht[Total_ft_6] = value;
                }
                else
                {
                    CD4ht.Add(Total_ft_6, value);
                }
            }
        }
        public string Appl_Name_Pro
        {
            get
            {
                return CD4ht[Appl_Name].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Name))
                {
                    CD4ht[Appl_Name] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Name, value);
                }
            }
        }
        public string Appl_Email_Pro
        {
            get
            {
                return CD4ht[Appl_Email].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Email))
                {
                    CD4ht[Appl_Email] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Email, value);
                }
            }
        }
        public string Appl_Title_Pro
        {
            get
            {
                return CD4ht[Appl_Title].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Title))
                {
                    CD4ht[Appl_Title] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Title, value);
                }
            }
        }
        public string Appl_Lic_No_Pro
        {
            get
            {
                return CD4ht[Appl_Lic_No].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Lic_No))
                {
                    CD4ht[Appl_Lic_No] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Lic_No, value);
                }
            }
        }
        public string Appl_Bus_Name_Pro
        {
            get
            {
                return CD4ht[Appl_Bus_Name].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Bus_Name))
                {
                    CD4ht[Appl_Bus_Name] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Bus_Name, value);
                }
            }
        }
        public string Appl_Address_Pro
        {
            get
            {
                return CD4ht[Appl_Address].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Address))
                {
                    CD4ht[Appl_Address] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Address, value);
                }
            }
        }
        public string Appl_City_Pro
        {
            get
            {
                return CD4ht[Appl_City].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_City))
                {
                    CD4ht[Appl_City] = value;
                }
                else
                {
                    CD4ht.Add(Appl_City, value);
                }
            }
        }
        public string Appl_State_Pro
        {
            get
            {
                return CD4ht[Appl_State].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_State))
                {
                    CD4ht[Appl_State] = value;
                }
                else
                {
                    CD4ht.Add(Appl_State, value);
                }
            }
        }
        public string Appl_Zip_Pro
        {
            get
            {
                return CD4ht[Appl_Zip].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Zip))
                {
                    CD4ht[Appl_Zip] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Zip, value);
                }
            }
        }
        public string Appl_Phone_Pro
        {
            get
            {
                return CD4ht[Appl_Phone].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Phone))
                {
                    CD4ht[Appl_Phone] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Phone, value);
                }
            }
        }
        public string Appl_Fax_Pro
        {
            get
            {
                return CD4ht[Appl_Fax].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Appl_Fax))
                {
                    CD4ht[Appl_Fax] = value;
                }
                else
                {
                    CD4ht.Add(Appl_Fax, value);
                }
            }
        }
        public string MCS_Name_Pro
        {
            get
            {
                return CD4ht[MCS_Name].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_Name))
                {
                    CD4ht[MCS_Name] = value;
                }
                else
                {
                    CD4ht.Add(MCS_Name, value);
                }
            }
        }
        public string MCS_Lic_No_Pro
        {
            get
            {
                return CD4ht[MCS_Lic_No].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_Lic_No))
                {
                    CD4ht[MCS_Lic_No] = value;
                }
                else
                {
                    CD4ht.Add(MCS_Lic_No, value);
                }
            }
        }
        public string MCS_Address_Pro
        {
            get
            {
                return CD4ht[MCS_Address].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_Address))
                {
                    CD4ht[MCS_Address] = value;
                }
                else
                {
                    CD4ht.Add(MCS_Address, value);
                }
            }
        }
        public string MCS_City_Pro
        {
            get
            {
                return CD4ht[MCS_City].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_City))
                {
                    CD4ht[MCS_City] = value;
                }
                else
                {
                    CD4ht.Add(MCS_City, value);
                }
            }
        }
        public string MCS_State_Pro
        {
            get
            {
                return CD4ht[MCS_State].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_State))
                {
                    CD4ht[MCS_State] = value;
                }
                else
                {
                    CD4ht.Add(MCS_State, value);
                }
            }
        }
        public string MCS_Zip_Pro
        {
            get
            {
                return CD4ht[MCS_Zip].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_Zip))
                {
                    CD4ht[MCS_Zip] = value;
                }
                else
                {
                    CD4ht.Add(MCS_Zip, value);
                }
            }
        }
        public string MCS_Phone_Pro
        {
            get
            {
                return CD4ht[MCS_Phone].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_Phone))
                {
                    CD4ht[MCS_Phone] = value;
                }
                else
                {
                    CD4ht.Add(MCS_Phone, value);
                }
            }
        }
        public string MCS_Fax_Pro
        {
            get
            {
                return CD4ht[MCS_Fax].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(MCS_Fax))
                {
                    CD4ht[MCS_Fax] = value;
                }
                else
                {
                    CD4ht.Add(MCS_Fax, value);
                }
            }
        }
        public string DateTimeField1_Pro
        {
            get
            {
                return CD4ht[DateTimeField1].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(DateTimeField1))
                {
                    CD4ht[DateTimeField1] = value;
                }
                else
                {
                    CD4ht.Add(DateTimeField1, value);
                }
            }
        }
        public string Equip_Name_Pro
        {
            get
            {
                return CD4ht[Equip_Name].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Name))
                {
                    CD4ht[Equip_Name] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Name, value);
                }
            }
        }
        public string Equip_email_Pro
        {
            get
            {
                return CD4ht[Equip_email].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_email))
                {
                    CD4ht[Equip_email] = value;
                }
                else
                {
                    CD4ht.Add(Equip_email, value);
                }
            }
        }
        public string Equip_Title_Pro
        {
            get
            {
                return CD4ht[Equip_Title].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Title))
                {
                    CD4ht[Equip_Title] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Title, value);
                }
            }
        }
        public string Equip_Company_Pro
        {
            get
            {
                return CD4ht[Equip_Company].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Company))
                {
                    CD4ht[Equip_Company] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Company, value);
                }
            }
        }
        public string Equip_Address_Pro
        {
            get
            {
                return CD4ht[Equip_Address].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Address))
                {
                    CD4ht[Equip_Address] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Address, value);
                }
            }
        }
        public string Equip_City_Pro
        {
            get
            {
                return CD4ht[Equip_City].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_City))
                {
                    CD4ht[Equip_City] = value;
                }
                else
                {
                    CD4ht.Add(Equip_City, value);
                }
            }
        }
        public string Equip_State_Pro
        {
            get
            {
                return CD4ht[Equip_State].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_State))
                {
                    CD4ht[Equip_State] = value;
                }
                else
                {
                    CD4ht.Add(Equip_State, value);
                }
            }
        }
        public string Equip_Zip_Pro
        {
            get
            {
                return CD4ht[Equip_Zip].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Zip))
                {
                    CD4ht[Equip_Zip] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Zip, value);
                }
            }
        }
        public string Equip_Phone_Pro
        {
            get
            {
                return CD4ht[Equip_Phone].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Phone))
                {
                    CD4ht[Equip_Phone] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Phone, value);
                }
            }
        }
        public string Equip_Fax_Pro
        {
            get
            {
                return CD4ht[Equip_Fax].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(Equip_Fax))
                {
                    CD4ht[Equip_Fax] = value;
                }
                else
                {
                    CD4ht.Add(Equip_Fax, value);
                }
            }
        }
        public string CSC_Name_Pro
        {
            get
            {
                return CD4ht[CSC_Name].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_Name))
                {
                    CD4ht[CSC_Name] = value;
                }
                else
                {
                    CD4ht.Add(CSC_Name, value);
                }
            }
        }
        public string CSC_Lic_No_Pro
        {
            get
            {
                return CD4ht[CSC_Lic_No].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_Lic_No))
                {
                    CD4ht[CSC_Lic_No] = value;
                }
                else
                {
                    CD4ht.Add(CSC_Lic_No, value);
                }
            }
        }
        public string CSC_Address_Pro
        {
            get
            {
                return CD4ht[CSC_Address].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_Address))
                {
                    CD4ht[CSC_Address] = value;
                }
                else
                {
                    CD4ht.Add(CSC_Address, value);
                }
            }
        }
        public string CSC_City_Pro
        {
            get
            {
                return CD4ht[CSC_City].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_City))
                {
                    CD4ht[CSC_City] = value;
                }
                else
                {
                    CD4ht.Add(CSC_City, value);
                }
            }
        }
        public string CSC_State_Pro
        {
            get
            {
                return CD4ht[CSC_State].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_State))
                {
                    CD4ht[CSC_State] = value;
                }
                else
                {
                    CD4ht.Add(CSC_State, value);
                }
            }
        }
        public string CSC_Zip_Pro
        {
            get
            {
                return CD4ht[CSC_Zip].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_Zip))
                {
                    CD4ht[CSC_Zip] = value;
                }
                else
                {
                    CD4ht.Add(CSC_Zip, value);
                }
            }
        }
        public string CSC_Phone_Pro
        {
            get
            {
                return CD4ht[CSC_Phone].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_Phone))
                {
                    CD4ht[CSC_Phone] = value;
                }
                else
                {
                    CD4ht.Add(CSC_Phone, value);
                }
            }
        }
        public string CSC_Fax_Pro
        {
            get
            {
                return CD4ht[CSC_Fax].ToString();
            }
            set
            {
                if (CD4ht.ContainsKey(CSC_Fax))
                {
                    CD4ht[CSC_Fax] = value;
                }
                else
                {
                    CD4ht.Add(CSC_Fax, value);
                }
            }
        }

        #endregion
        public void FillCD4pdfForm(string Path)
        {
            try
            {
                //Source File stream declare here where the pickup the source file to read
                PdfReader pdfRDR = new PdfReader(Path);
                //Save open file dialouge declare here to save generated pdf to destination derive
                SaveFileDialog pdfSave = new SaveFileDialog();
                pdfSave.Filter = "PDF file|*.pdf";
                //Data Access class object
                if (pdfSave.ShowDialog() == DialogResult.OK)
                {
                    PdfStamper pdfStm = new PdfStamper(pdfRDR, new FileStream(pdfSave.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite), '\0', true);
                    //Declare form field name colletion from pdf file
                    AcroFields AF = pdfStm.AcroFields;
                    foreach (DictionaryEntry Element in CD4ht)
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
