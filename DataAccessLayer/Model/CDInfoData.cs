﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class CDInfoData
    {
        public int CDID { get; set; }
        public string CDNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string Capacity { get; set; }
        public string Owner { get; set; }
        public string Expiration { get; set; }
        public string ModelSpaceName { get; set; }
        public string Notes { get; set; }
        public string CraneName { get; set; }
        public string CraneID { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerFax { get; set; }
        public string TypMast { get; set; }
        public string TypBoom { get; set; }
        public string TypJIB { get; set; }
        public string TypTotal { get; set; }
        public string EquipmentType { get; set; }
        public string ErectionStyle { get; set; }
        public string TravelCTWT { get; set; }
        public string Dunnage1 { get; set; }
        public string Dunnage2 { get; set; }
        public string MaxOrLoad { get; set; }
        public Nullable<bool> IsChange { get; set; }
        public Nullable<bool> IsNewRecord { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public string ApprovedChartType { get; set; }
    }

    public class CDInfoData2
    {
        public int CDID { get; set; }
        public string CDNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string Capacity { get; set; }
        public string Owner { get; set; }
        public string Expiration { get; set; }
        public string ModelSpaceName { get; set; }
        public string Notes { get; set; }
        public string CraneName { get; set; }
        public string CraneID { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerFax { get; set; }
        public string TypMast { get; set; }
        public string TypBoom { get; set; }
        public string TypJIB { get; set; }
        public string TypTotal { get; set; }
        public string EquipmentType { get; set; }
        public string ErectionStyle { get; set; }
        public string TravelCTWT { get; set; }
        public string Dunnage1 { get; set; }
        public string Dunnage2 { get; set; }
        public string MaxOrLoad { get; set; }
        public Nullable<bool> IsChange { get; set; }
        public Nullable<bool> IsNewRecord { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public string ApprovedChartType { get; set; }
    }


    public class CDInfoContact
    {
        public int CDID { get; set; }
        public string Capacity { get; set; }

        public int CDNumber { get; set; }
        //public string CDNumber { get; set; }

        public string CraneID { get; set; }
        public string CraneName { get; set; }
        public string EquipmentType { get; set; }
        public string Expiration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string ModelSpaceName { get; set; }
        public string Notes { get; set; }
        public string Owner { get; set; }
        public string OwnerFax { get; set; }
        public string OwnerPhone { get; set; }
        public string SerialNo { get; set; }
        public string TypeBoom { get; set; }
        public string TypeJIB { get; set; }
        public string TypeMast { get; set; }
        public string TypeTotal { get; set; }
        public string ApprovedChartType { get; set; }
        public string Dunnage1 { get; set; }
        public string Dunnage2 { get; set; }
        public string TravelCtwt { get; set; }
    }


    public class CDInfoContactNew
    {
        public int CDID { get; set; }
        public string Capacity { get; set; }
        public string CDNumber { get; set; }
        public string CraneID { get; set; }
        public string CraneName { get; set; }
        public string EquipmentType { get; set; }
        public string Expiration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string ModelSpaceName { get; set; }
        public string Notes { get; set; }
        public string Owner { get; set; }
        public string OwnerFax { get; set; }
        public string OwnerPhone { get; set; }
        public string SerialNumber { get; set; }
        public string TypBoom { get; set; }
        public string TypJIB { get; set; }
        public string TypMast { get; set; }
        public string TypTotal { get; set; }
        public string ApprovedChartType { get; set; }
        public string Dunnage1 { get; set; }
        public string Dunnage2 { get; set; }
        public string TravelCtwt { get; set; }
    }
}