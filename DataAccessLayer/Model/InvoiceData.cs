using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class InvoiceData
    {
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public decimal JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public string PONo { get; set; }
        public decimal PaymentCr { get; set; }
        public string Date { get; set; }
        public double Hrs { get; set; }
        public string Rate { get; set; }
        public string JobTrackSubName { get; set; }
        public string byname { get; set; }
        public string Amount { get; set; }
        public string Clienttext { get; set; }
        public double Expenses { get; set; }
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
        public Nullable<decimal> Hrs { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public string PONo { get; set; }
        public Nullable<decimal> PaymentCr { get; set; }
        public Nullable<decimal> BalanceDue { get; set; }
        public Nullable<int> Aging { get; set; }
        public Nullable<decimal> OpeningBal { get; set; }
        public string Account { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string byname { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Clienttext { get; set; }
    }

    public class InvoiceDetail
    {
        public string JobNumber { get; set; }
        public int JobTrackDetailID { get; set; }
        public string InvoiceNo { get; set; }
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

    public class InvoiceDetailNew
    {
        public string JobNumber { get; set; }
        public int JobTrackDetailID { get; set; }
        public string InvoiceNo { get; set; }
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

    public class QBInvCompare
    {
        public string JobNumber { get; set; }
        public decimal JobTrackDetailID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string invoiceAddress { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string PONo { get; set; }
        public decimal PaymentCr { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal Reimbursement { get; set; }
        public double Expense { get; set; }
        public double Total { get; set; }
        public decimal Revenue { get; set; }
        public string CompanyName { get; set; }
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



    public class InvoiceRptAllNew
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
        //public int Rate { get; set; }
        public double Rate { get; set; }
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
        public int Aging { get; set; }
        public double OpeningBal { get; set; }
        public string byname { get; set; }
    }

    public class InvoiceExport
    {
        public decimal JobTrackDetailID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string PONo { get; set; }
        public Nullable<decimal> PaymentCr { get; set; }
        public Nullable<decimal> BalanceDue { get; set; }
        public Nullable<decimal> Aging { get; set; }
        public Nullable<double> OpeningBal { get; set; }
        public Nullable<decimal> JobListID { get; set; }
        public string CompanyName { get; set; }
        public string JobNumber { get; set; }
        public string JobAddress { get; set; }
    }
    public class InvoiceJobDtl
    {
        public decimal InvoiceRptID { get; set; }
        public int TrackSubID { get; set; }
        public string JobTrackSubName { get; set; }
        public Nullable<decimal> JobTrackDetailID { get; set; }
        public Nullable<decimal> Hrs { get; set; }
        public Nullable<decimal> Rate { get; set; }
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
        public int Aging { get; set; }
        public object OpeningBal { get; set; }
        public int Rate { get; set; }
        public string Clienttext { get; set; }
        public string Name { get; set; }
        public string JobTrackSubName { get; set; }
    }

    public class InvoiceUpload
    {
        public int InvoiceID { get; set; }
        public int JobListID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceFileName { get; set; }
        public byte[] InvoiceFile { get; set; }
        public string Comments { get; set; }
        public string IsUploadInvoice { get; set; }
        public string InvoiceFileType { get; set; }
    }

    public class InvJobList
    {
        public Nullable<int> JobListID { get; set; }
        public string JobNumber { get; set; }
        public string Address { get; set; }
        public string ContactsName { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
    }

    public class InvReduction
    {
        public decimal Reimbursement { get; set; }
        public decimal Expense { get; set; }
        public decimal Revenue { get; set; }
        public decimal Total { get; set; }
    }

    public class InvReductionEdit
    {
        //public int JobTrackDetailId { get; set; }
        public decimal Reimbursement { get; set; }
        public decimal Expense { get; set; }
        public decimal Revenue { get; set; }
        public decimal Total { get; set; }
    }

    public class InvReductionEditNew
    {
        public string Reimbursement { get; set; }
        public string Expense { get; set; }
        public decimal Revenue { get; set; }
        public decimal Total { get; set; }

        //@InvoiceNo as nvarchar(MAX)=null,
        //@Reduction as DECIMAL(10,2)=0.0,
        //@ItemReduc as BIT=0,
        //@TimeReduc as BIT=0)

        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Jobdescription { get; set; }
        public DateTime DueDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public decimal JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public string PONo { get; set; }
        public decimal PaymentCr { get; set; }
        public string Date { get; set; }
        public double Hrs { get; set; }
        public string Rate { get; set; }
        public string JobTrackSubName { get; set; }
        public string byname { get; set; }
        public string Amount { get; set; }
        public string Clienttext { get; set; }
        
        public string ReportType { get; set; }
    }


    public class InvoiceAddress
    {
        public string Contact { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Nullable<Int32> ContactsID { get; set; }
    }

    public class InvoiceAddressSecond
    {
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Nullable<Int32> ContactsID { get; set; }
    }

    public class InvoiceAddressCheck
    {
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }
        public string Contact { get; set; }
        public string ContactsName { get; set; }
        public Nullable<Int32> ContactsID { get; set; }
    }


    public class InvoiceAddresTest
    {
        public string Contact3 { get; set; }
        public string EmailAddress { get; set; }
        //public string Address { get; set; }
        //public string Description { get; set; }
        public Nullable<Int32> CID { get; set; }
    }

    public class InvoiceActions
    {
        public long ActionID { get; set; }
        public string InvoiceNo { get; set; }
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; }
        public string Status { get; set; }
        public long CompanyID { get; set; }
        public string Notes { get; set; }
    }
    public class Invoice_Details
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public long JobTrackDetailID { get; set; }
        public string JobNumber { get; set; }
        public double PaymentCr { get; set; }
        public double Hrs { get; set; }
        public double Rate { get; set; }
        public string Byname { get; set; }
        public double Expenses { get; set; }
        public string ReportType { get; set; }
    }
}
