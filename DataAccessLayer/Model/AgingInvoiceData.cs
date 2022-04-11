using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class AgingInvoiceData
    {
        public string CompanyName { get; set; }
        public string DueInvoiceNo { get; set; }
        public string Address { get; set; }
        public int Age15Action { get; set; }
        public int Age30Action { get; set; }
        public int Age45Action { get; set; }
        public int Age60Action { get; set; }
        public int Age75Action { get; set; }
        public int Age90Action { get; set; }
        public int Age105Action { get; set; }
        public int Aging { get; set; }
        public decimal OpeningBalance { get; set; }
        public DateTime DueDate { get; set; }
        public int CompanyID { get; set; }
    }

    //public class AgingDueInvoice
    //{
    //    public int Aging { get; set; }
    //    public string DueInvoiceNo { get; set; }
    //    public DateTime DueDate { get; set; }
    //    public int CompanyID { get; set; }
    //    public decimal Balance { get; set; }
    //}

    public class TrackRateDetail
    {
        public int TrackSubID { get; set; }
        public string TrackSubName { get; set; }
        public string Description { get; set; }
        public string nRate { get; set; }
        public int JobTrackingID { get; set; }
        public string TaskHandler { get; set; }
        public DateTime AddDate { get; set; }
        public int CompanyID { get; set; }
        public string DeleteItemTimeService { get; set; }
    }

    public class InvoiceAging
    {
        public int Age15Action { get; set; }
        public int Age30Action { get; set; }
        public int Age45Action { get; set; }
        public int Age60Action { get; set; }
        public int Age75Action { get; set; }
        public int Age90Action { get; set; }
        public int Age105Action { get; set; }
        public int Aging { get; set; }
    }

}
