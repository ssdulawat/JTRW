using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ExpenseData
    {
        public long TimeSheetExpencesID { get; set; }
        public long JobListID { get; set; }
        public long EmployeeDetailsId { get; set; }
        public string Bye { get; set; }
        public DateTime Date { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string Qty { get; set; }
        public string Amount { get; set; }
    }

    public class TimeSheetInfo
    {
        public long TimeSheetID { get; set; }
        public string By { get; set; }
        public long JobListID { get; set; }
        public long EmployeeDetailsId { get; set; }
        public DateTime Date { get; set; }
        public string Item { get; set; }
        public string TrackSubName { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public double Qty { get; set; }
        public double Amount { get; set; }
    }
    
    public class InvExpRate
    {
        public Nullable<long> CRVExpensesInvoiceID { get; set; }
        public Nullable<long> JobTrackDetailID { get; set; }
        public string By { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Hrs { get; set; }
        public decimal Rate { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<long> TimeSheetExpencesID { get; set; }
        public Nullable<int> TimeSheetID { get; set; }
    }

    public class dtoInvExpRate
    {
        public Nullable<long> CRVExpensesInvoiceID { get; set; }
        public Nullable<long> JobTrackDetailID { get; set; }
        public string By { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Hrs { get; set; }
        public decimal Rate { get; set; }
        public string Amount { get; set; }
        public Nullable<long> TimeSheetExpencesID { get; set; }
        public Nullable<int> TimeSheetID { get; set; }
    }
    public class InvTimeRate
    {
        public long CRVTimeInvoiceId { get; set; }
        public Nullable<long> JobTrackDetailID { get; set; }
        public string By { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public double Hrs { get; set; }
        public string Rate { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<long> TimeSheetExpencesID { get; set; }
        public Nullable<int> TimeSheetID { get; set; }
    }
}
