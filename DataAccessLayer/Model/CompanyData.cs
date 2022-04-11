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

        //public object GetPropValue(object source, string propertyName)
        //{
        //    var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
        //    return property?.GetValue(source);
        //}


        public object GetPropValue(object obj, String name)
        {
            object objRet = null;

            if (obj == null) return objRet;

            Type type = obj.GetType();
            PropertyInfo info = type.GetProperty(name);

            if (info == null) { return objRet; }

            objRet = info.GetValue(obj, null);
            return objRet;
        }

        //public  T GetPropValue<T>(this Object obj, String name)
        //{
        //    Object retval = GetPropValue(obj, name);
        //    if (retval == null) { return default(T); }

        //    // throws InvalidCastException if types are incompatible
        //    return (T)retval;
        //}
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

    public class dtoCompanyID
    {
        public int CompanyID { get; set; }
    }

    public class dtoEmailaddress
    {
        public string EmailAddress { get; set; }
        public string Address { get; set; }
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
        public string CompanyNo { get; set; }
        public Nullable<bool> DBadClient { get; set; }
        public Nullable<DateTime> CreditPassDate { get; set; }
        //public int TableVersionId { get; set; }
        public Nullable<int> TableVersionId { get; set; }
        public decimal? ServRate { get; set; }
        public string OfficeFax { get; set; }
        public string officePhone { get; set; }
        public string TypicalInvoiceType { get; set; }
    }

    public class CompanyColorNew
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
        public string CompanyNo { get; set; }
        public Nullable<bool> DBadClient { get; set; }
        public Nullable<DateTime> CreditPassDate { get; set; }
        public Nullable<int> TableVersionId { get; set; }
        public decimal? ServRate { get; set; }
        public string OfficeFax { get; set; }
        public string officePhone { get; set; }
        public string TypicalInvoiceType { get; set; }
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
    }

    public class CompanyDataEdit
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
    }

    public class DueInvoice
    {
        public Nullable<int> Aging { get; set; }
        public string DueInvoiceNo { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }

    public class DueInvoiceEmail : DueInvoice
    {
        public string EmailAddress { get; set; }
    }

    public class DueInvoiceAging : DueInvoice
    {
        public decimal InvoiceAgingID { get; set; }
    }

    public class CompanyDue
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

    public class CompanyEmails
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string JobNumber { get; set; }
        public string EmailAddress { get; set; }
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
        public string Password { get; set; }
    }

    public class CompanyInfo
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string CompanyNo { get; set; }
        public string Country { get; set; }
        public string FedExNUM { get; set; }
        public int IBMNUM { get; set; }
        public string AirborneExpNUM { get; set; }
        public string DotInsuranceExp { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age0Action { get; set; }
        public int Age15Action { get; set; }
        public int Age30Action { get; set; }
        public int Age45Action { get; set; }
        public int Age60Action { get; set; }
        public int Age75Action { get; set; }
        public int Age90Action { get; set; }
        public int Age105Action { get; set; }
        public int Aging { get; set; }
        public double OpeningBalance { get; set; }
        public int DueInvoiceNo { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDisable { get; set; }
        public bool IsChange { get; set; }
        public object IsNewRecord { get; set; }
        public object IsDelete { get; set; }
        public DateTime ChangeDate { get; set; }
        public int DBadClient { get; set; }
        public bool IsCreditPass { get; set; }
        public DateTime CreditPassDate { get; set; }
        public int TableVersionId { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeFax { get; set; }
        public string TypicalInvoiceType { get; set; }
        public double ServRate { get; set; }
    }

    public class CompanyAging
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public Nullable<int> Age15Action { get; set; }
        public Nullable<int> Age30Action { get; set; }
        public Nullable<int> Age45Action { get; set; }
        public Nullable<int> Age60Action { get; set; }
        public Nullable<int> Age75Action { get; set; }
        public Nullable<int> Age90Action { get; set; }
        public Nullable<int> Age105Action { get; set; }
        public Nullable<int> Aging { get; set; }
    }

    public class dtoDueInvoices
    {
        public string CompanyName { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
        public Nullable<int> Aging { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<decimal> InvoiceAgingID { get; set; }
        public Nullable<int> CompanyID { get; set; }
    }

   
}