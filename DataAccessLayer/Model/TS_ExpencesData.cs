using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class TS_ExpencesData
    {
        public long TimeSheetExpencesID { get; set; }
        public Nullable<long> JobListID { get; set; }
        public Nullable<long> EmployeeDetailsId { get; set; }
        public string Job_Number { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public Nullable<int> TrackSubID { get; set; }
        public string status { get; set; }
        public string BillState { get; set; }
        public string TrackSubName { get; set; }
        public Nullable<double> Expences { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string AdminStatus { get; set; }
    }

    public class TS_Clients
    {
        public int JobListID { get; set; }
        public string Job_Number { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string PM { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }

    public class TS_Exp_Status
    {
        public string EUser { get; set; }
        public string Job_Number { get; set; }
        public DateTime Date { get; set; }
        public string TrackSubComment { get; set; }
        public Nullable<double> Amount { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public string AdminStatus { get; set; }
        public string BillState { get; set; }
    }
}
