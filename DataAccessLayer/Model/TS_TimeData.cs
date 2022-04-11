using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class TS_TimeData
    {
        public long TimeSheetID { get; set; }
        public Nullable<long> JobListID { get; set; }
        public Nullable<long> EmployeeDetailsId { get; set; }
        public string Job_Number { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public Nullable<int> TrackSubID { get; set; }
        public string status { get; set; }
        public Nullable<double> Time { get; set; }
        public string BillState { get; set; }
        public string TrackSubName { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string AdminStatus { get; set; }
        public Nullable<long> JobTrackingId { get; set; }
    }

    public class TS_TimeStatus
    {
        public string Tuser { get; set; }
        public string Job_Number { get; set; }
        public DateTime Date { get; set; }
        public double Time { get; set; }
        public string TrackSubComment { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public string AdminStatus { get; set; }
        public string BillState { get; set; }
    }

    public class TS_LoginName
    {
        public string Name { get; set; }
        public decimal Time { get; set; }
    }

    public class PCHours
    {
        public int TimeSheetID { get; set; }
        public int JobListID { get; set; }
        public int EmployeeDetailsId { get; set; }
        public string Job_Number { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int TrackSubID { get; set; }
        public double Time { get; set; }
    }
}
