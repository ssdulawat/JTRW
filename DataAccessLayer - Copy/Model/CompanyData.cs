using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class CompanyAction
    {
        public Nullable<int> Age0Action { get; set; }
        public Nullable<int> Age15Action { get; set; }
        public Nullable<int> Age30Action { get; set; }
        public Nullable<int> Age45Action { get; set; }
        public Nullable<int> Age60Action { get; set; }
        public Nullable<int> Age75Action { get; set; }
        public Nullable<int> Age90Action { get; set; }
        public Nullable<int> Age105Action { get; set; }
        public Nullable<int> Aging { get; set; }
        public bool DBadClient { get; set; }
        public bool IsCreditPass { get; set; }
        public DateTime? CreditPassDate { get; set; }
        public string DueInvoiceNo { get; set; }

        public string GetPropertyValue(string propertyName)
        {
            try
            {
                var value = this.GetType().GetProperty(propertyName).GetValue(this, null) as string;
                return value;
            }
            catch { return null; }
        }

        public object GetPropValue(object source, string propertyName)
        {
            var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            return property?.GetValue(source);
        }
    }

    public class AgingHistory
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int Aging { get; set; }
        public DateTime UDate { get; set; }
        public int Userid { get; set; }
        public string UserN { get; set; }
    }

    public class CompanyIDs
    {
        public string CompanyName { get; set; }
        public int CompanyID { get; set; }
    }

    public class CraneUser
    {
        public int ContactsID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactTitle { get; set; }
        public string CompanyName { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FaxNumber { get; set; }
        public string PostalCode { get; set; }
    }

    public class CompanyColor
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string DotInsuranceExp { get; set; }
        public Nullable<int> TableVersionId { get; set; }
        public decimal? ServRate { get; set; }
        //public Nullable<int> TableVersionId { get; set; }
        public string AirborneExpNUM { get; set; }
        public string IBMNUM { get; set; }
        public string FedExNUM { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Age0Action { get; set; }
        public Nullable<int> Age15Action { get; set; }
        public Nullable<int> Age30Action { get; set; }
        public Nullable<int> Age45Action { get; set; }
        public Nullable<int> Age60Action { get; set; }
        public Nullable<int> Age75Action { get; set; }
        public Nullable<int> Age90Action { get; set; }
        public Nullable<int> Age105Action { get; set; }
        public string Age0ActionColor { get; set; }
        public string Age15ActionColor { get; set; }
        public string Age30ActionColor { get; set; }
        public string Age45ActionColor { get; set; }
        public string Age60ActionColor { get; set; }
        public string Age75ActionColor { get; set; }
        public string Age90ActionColor { get; set; }
        public string Age105ActionColor { get; set; }
        public Nullable<bool> IsDisable { get; set; }
        public Nullable<bool> DBadClient { get; set; }
        public string CompanyNo { get; set; }
        public string OfficeFax { get; set; }
        public string officePhone { get; set; }
        public string TypicalInvoiceType { get; set; }
        public Nullable<DateTime> CreditPassDate { get; set; }        
    }

    public class CompanyData
    {
        public int ContactsID { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
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
        public int Accounting { get; set; }
    }


    public class InvoiceContactT
    {
        public int ContactId { get; set; }
        public string Contact { get; set; }
    }

    public class DueInvoice
    {
        public int Aging { get; set; }
        public string DueInvoiceNo { get; set; }
        public DateTime DueDate { get; set; }
        public int CompanyID { get; set; }
        public double Balance { get; set; }
    }

    public class CompanyDue
    {
        public string CompanyName { get; set; }
        public int DueInvoiceNo { get; set; }
        public string Address { get; set; }
        public int Age15Action { get; set; }
        public int Age30Action { get; set; }
        public int Age45Action { get; set; }
        public int Age60Action { get; set; }
        public int Age75Action { get; set; }
        public int Age90Action { get; set; }
        public int Age105Action { get; set; }
        public int Aging { get; set; }
        public double OpeningBalance { get; set; }
        public DateTime DueDate { get; set; }
        public int CompanyID { get; set; }
    }

    public class CompanyEmails
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime JobNumber { get; set; }
        public object EmailAddress { get; set; }
    }

    public class CompanyUsers
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string DotInsuranceExp { get; set; }
        public string AirborneExpNUM { get; set; }
        public string IBMNUM { get; set; }
        public string FedExNUM { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
    }
}