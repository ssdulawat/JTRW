//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobList
    {
        public int JobListID { get; set; }
        public string JobNumber { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> ContactsID { get; set; }
        public string Description { get; set; }
        public string HouseNum { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Borough { get; set; }
        public string Handler { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string ContactsEmails { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerFax { get; set; }
        public string ACContacts { get; set; }
        public string ACEmail { get; set; }
        public Nullable<bool> IsChange { get; set; }
        public Nullable<bool> IsNewRecord { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public string Clienttext { get; set; }
        public string PMrv { get; set; }
        public Nullable<bool> IsDisable { get; set; }
        public Nullable<int> InvoiceClient { get; set; }
        public string InvoiceContact { get; set; }
        public string InvoiceEmailAddress { get; set; }
        public string InvoiceACContacts { get; set; }
        public string InvoiceACEmail { get; set; }
        public Nullable<int> RateVersionId { get; set; }
        public string TypicalInvoiceType { get; set; }
        public bool IsInvoiceHold { get; set; }
        public Nullable<decimal> ServRate { get; set; }
        public Nullable<bool> AdminInvoice { get; set; }
    }
}