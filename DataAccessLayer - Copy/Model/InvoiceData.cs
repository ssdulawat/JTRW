using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class InvoiceData
    {
        public DateTime InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int JobTrackDetailID { get; set; }
        public DateTime JobNumber { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public object Date { get; set; }
        public int Hrs { get; set; }
        public double Rate { get; set; }
        public string JobTrackSubName { get; set; }
        public object byname { get; set; }
        public object Amount { get; set; }
        public string Clienttext { get; set; }
        public int Expenses { get; set; }
        public string ReportType { get; set; }
    }

    public class InvoiceRptView
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string JobTrackSubName { get; set; }
        public double Hrs { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public int JobTrackDetailID { get; set; }
        public DateTime JobNumber { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public double BalanceDue { get; set; }
        public object Aging { get; set; }
        public object OpeningBal { get; set; }
        public string Account { get; set; }
        public object Date { get; set; }
        public object byname { get; set; }
        public object Amount { get; set; }
        public object Clienttext { get; set; }
    }

    public class InvoiceDetail
    {
        public DateTime JobNumber { get; set; }
        public int JobTrackDetailID { get; set; }
        public DateTime InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string invoiceAddress { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public double BalanceDue { get; set; }
    }

    public class A_FileInfo
    {
        public string FileName { get; set; }
        public DateTime FileDateTime { get; set; }
    }

    public class InvoiceRptAll
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public DateTime Date { get; set; }
        public double Hrs { get; set; }
        public int Rate { get; set; }
        public string JobTrackSubName { get; set; }
        public string byname { get; set; }
        public string Amount { get; set; }
        public string Clienttext { get; set; }
        public int Expenses { get; set; }
        public string ReportType { get; set; }
    }

    public class InvoiceRptExpanse
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Expenses { get; set; }
        public int JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public double BalanceDue { get; set; }
        public object Aging { get; set; }
        public object OpeningBal { get; set; }
        public string byname { get; set; }
    }

    public class InvoiceExport
    {
        public int JobTrackDetailID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public double BalanceDue { get; set; }
        public object Aging { get; set; }
        public object OpeningBal { get; set; }
        public int JobListID { get; set; }
        public string CompanyName { get; set; }
        public string JobNumber { get; set; }
        public object JobAddress { get; set; }
    }
    public class InvoiceJobDtl
    {
        public int InvoiceRptID { get; set; }
        public int TrackSubID { get; set; }
        public string JobTrackSubName { get; set; }
        public int JobTrackDetailID { get; set; }
        public double Hrs { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
    }

    public class InvoiceRptTime
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public int JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public string PONo { get; set; }
        public double PaymentCr { get; set; }
        public double BalanceDue { get; set; }
        public object Aging { get; set; }
        public object OpeningBal { get; set; }
        public int Rate { get; set; }
        public string Clienttext { get; set; }
        public string Name { get; set; }
        public string JobTrackSubName { get; set; }
    }
}
