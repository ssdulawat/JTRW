using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class JobTrackingData
    {
        public int JobTrackingID { get; set; }
        public int TrackSubId { get; set; }
        public string TrackSubDescription { get; set; }
    }

    public class JT_Desc
    {
        public int TrackSubId { get; set; }
        public string TrackSubDescription { get; set; }
    }

    public class JobTrackList
    {
        public int JobTrackingID { get; set; }
        public Nullable<int> JobListID { get; set; }
        public string JobNumber { get; set; }
        public string Track { get; set; }
    }

    public class JobTrackListCombo
    {
        public int JobTrackingID { get; set; }
        public Nullable<int> JobListID { get; set; }
        public string JobNumber { get; set; }
        public string Track { get; set; }
    }

    public class JT_JobStatusList
    {
        public int JobListID { get; set; }
        public string JobNumber { get; set; }
        public string TaskHandler { get; set; }
        public string Track { get; set; }
        public string TrackSub { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime Obtained { get; set; }
        public DateTime Expires { get; set; }
        public string BillState { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime NeedDate { get; set; }
        public Nullable<int> JobTrackingID { get; set; }
        public string FinalAction { get; set; }
        public string CalColor { get; set; }
        public Nullable<int> TrackSubID { get; set; }
    }

    public class RateInvoiceDtl
    {
        public string JobTrackSubName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Hrs { get; set; }
        public string Rate { get; set; }
        public Nullable<decimal> InvoiceRptID { get; set; }
        public Nullable<decimal> JobTrackDetailID { get; set; }
        public Nullable<int> JobTrackingID { get; set; }
    }

    public class dtoRateInvoiceDtl
    {
        public string JobTrackSubName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Hrs { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> InvoiceRptID { get; set; }
        public Nullable<decimal> JobTrackDetailID { get; set; }
        public Nullable<int> JobTrackingID { get; set; }
    }

    public class JT_JobLIst
    {
        public int JobTrackingID { get; set; }
        public int JobListID { get; set; }
        public string TaskHandler { get; set; }
        public string TrackName { get; set; }
        public string TrackSubName { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public DateTime? Submitted { get; set; }
        public DateTime? Obtained { get; set; }
        public DateTime? Expires { get; set; }
        public string BillState { get; set; }
        public string FinalAction { get; set; }
        public DateTime? AddDate { get; set; }
        public int TrackSubID { get; set; }
    }
}
