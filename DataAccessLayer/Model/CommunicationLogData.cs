using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
   public class CommunicationLogData
    {
        public int CommLogID { get; set; }
        public int CompanyID { get; set; }
        public DateTime InvoiceNo { get; set; }
        public string Method { get; set; }
        public string Notes { get; set; }
        public DateTime CallBackDate { get; set; }
    }

    public class CommunicationLogDataEdit
    {
        public Int64 CommLogID { get; set; }
        public Int64 CompanyID { get; set; }
        public string InvoiceNo { get; set; }
        public string Method { get; set; }
        public string Notes { get; set; }
        public DateTime CallBackDate { get; set; }
    }


    public class CommunicationLogCombo
    {
        public Int64 CommLogID { get; set; }
        public Int64 CompanyID { get; set; }
        //public string InvoiceNo { get; set; }
        public string DueInvoiceNo { get; set; }
        
        public string Method { get; set; }
        public string Notes { get; set; }
        public DateTime CallBackDate { get; set; }
    }
}
