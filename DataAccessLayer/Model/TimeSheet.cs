﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class TimeSheet
    {
        public string Name { get; set; }
        public double Time { get; set; }
        //public string TimeSheetID { get; set; }
        public string TimeSheetID { get; set; }
        public long EmployeeDetailsId { get; set; }
        public long JobListID { get; set; }
        public double BilableRate { get; set; }
        public double Total { get; set; }
        public string JobNumber { get; set; }
        public string PM { get; set; }
    }


    public class TimeSheetMain
    {
        public string Name { get; set; }
        public double Time { get; set; }
        //public string TimeSheetID { get; set; }
        public long TimeSheetID { get; set; }
        public long EmployeeDetailsId { get; set; }
        public long JobListID { get; set; }
        public double BilableRate { get; set; }
        public double Total { get; set; }
        public string JobNumber { get; set; }
        public string PM { get; set; }
    }


    public class TimeSheet2
    {
        public string Name { get; set; }
        public double Time { get; set; }
        public long TimeSheetID { get; set; }
        public long EmployeeDetailsId { get; set; }
        public long JobListID { get; set; }
        public double BilableRate { get; set; }
        public double Total { get; set; }
        public string JobNumber { get; set; }
        public string PM { get; set; }
    }
}