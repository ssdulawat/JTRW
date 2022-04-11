using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
   public class ContactsData
    {
        public int ContactsID { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactTitle { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Notes { get; set; }
        public string SpecialRiggerNUM { get; set; }
        public string MasterRiggerNUM { get; set; }
        public string SpecialSignNUM { get; set; }
        public string MasterSignNUM { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string FaxNumber { get; set; }
        public string AlternativePhone { get; set; }
        public string FieldPhone { get; set; }
        public string Pager { get; set; }
        public int Accounting { get; set; }
        public bool IsChange { get; set; }
        public object IsNewRecord { get; set; }
        public object IsDelete { get; set; }
        public DateTime ChangeDate { get; set; }
    }

    public class ContactsData2
    {
        //public int ContactsID { get; set; }
        //public int CompanyID { get; set; }

        //string queryString = "SELECT FirstName, MiddleName, LastName, ContactTitle,Address, City,State, PostalCode,  Country, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix,  HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager ,Accounting FROM  Contacts where CompanyID= " + companyID + " and (IsDelete=0 or IsDelete is null)  order by ContactsID";

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactTitle { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //public int PostalCode { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Notes { get; set; }
        public string SpecialRiggerNUM { get; set; }
        public string MasterRiggerNUM { get; set; }
        public string SpecialSignNUM { get; set; }
        public string MasterSignNUM { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
       
       
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string FaxNumber { get; set; }
        public string AlternativePhone { get; set; }
        public string FieldPhone { get; set; }
        public string Pager { get; set; }

        public Nullable<bool> Accounting { get; set; }
        //public bool Accounting { get; set; }
        //public int Accounting { get; set; }

        //public bool IsChange { get; set; }
        //public object IsNewRecord { get; set; }
        //public object IsDelete { get; set; }
        //public DateTime ChangeDate { get; set; }
    }





    public class InvoiceContacts
    {
        public int ContactId { get; set; }
        public string Contact { get; set; }
    }

    public class InvContactEmail: InvoiceContacts
    {
        public string EmailAddress { get; set; }
    }

    public class InvContactEmail2 : InvoiceContacts
    {
        public string EmailAddress { get; set; }
        public string Contact { get; set; }
        public string ContactsID { get; set; }
    }
}
