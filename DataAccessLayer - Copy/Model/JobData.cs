using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class JobOwner
    {
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
    }

    public class JobNumList
    {
        public int joblistID { get; set; }
        public string JobNumber { get; set; }
    }

    public class JobForm
    {
        public int JobID { get; set; }
        public int JobListID { get; set; }
        public int Applicant { get; set; }
        public DateTime JobNumber { get; set; }
        public int JobSiteBlock { get; set; }
        public int JobSiteLot { get; set; }
        public string JobSiteCNNum { get; set; }
        public int JobSiteHouseNum { get; set; }
        public string JobSiteStreet { get; set; }
        public string JobSiteBorough { get; set; }
        public string JobSiteState { get; set; }
        public int Crane1CD { get; set; }
        public int Crane2CD { get; set; }
        public int Crane3CD { get; set; }
        public int Crane4CD { get; set; }
        public int Crane5CD { get; set; }
        public int Crane6CD { get; set; }
        public int CraneUser { get; set; }
        public string CraneUserInfo { get; set; }
        public string CraneUserTitle { get; set; }
        public string WorkPlatformManufacturer { get; set; }
        public string WorkPlatformModel { get; set; }
        public string WorkPlatformSuperName { get; set; }
        public string WorkPlatformSuperPhone { get; set; }
        public string WorkPlatformSuperFax { get; set; }
        public string WorkPlatformSuperAddr { get; set; }
        public string WorkPlatformSuperCity { get; set; }
        public string WorkPlatformSuperState { get; set; }
        public string WorkPlatformSuperZip { get; set; }
        public int FirstVariance { get; set; }
        public int BIN { get; set; }
        public int CBNum { get; set; }
        public string AptorCondoNum { get; set; }
        public string SpecialPlaceName { get; set; }
        public int SubName { get; set; }
        public string SubInfo { get; set; }
        public int ResidenceWithin200ft { get; set; }
        public string DatesofVariance { get; set; }
        public string DaysofVariance { get; set; }
        public string TimeofVarianceFrom { get; set; }
        public string TimeofVarianceTo { get; set; }
        public string VarianceWorkDescription { get; set; }
        public string ReasonforVariance { get; set; }
        public int SiteArchitect { get; set; }
        public int SiteNumofStories { get; set; }
        public int SiteOccupancy { get; set; }
        public string OccupancyType { get; set; }
        public string SiteNumofApts { get; set; }
        public string SiteNumofAptsCurrent { get; set; }
        public string SiteNumofAptsProposed { get; set; }
        public string SiteOwner { get; set; }
        public int SiteOwnerAddress { get; set; }
        public string SiteOwnerStreet { get; set; }
        public string SiteOwnerCity { get; set; }
        public string SiteOwnerState { get; set; }
        public int SiteOwnerZip { get; set; }
        public string WorkProposed { get; set; }
        public string Architect2 { get; set; }
        public string Architect2fullAddress { get; set; }
        public object PDFType { get; set; }
    }

    public class RateServType
    {
        public int RateVersionId { get; set; }
        public double ServRate { get; set; }
        public string TypicalInvoiceType { get; set; }
    }

    public class JobComments
    {
        public string Track { get; set; }
        public string TrackSub { get; set; }
        public string Comments { get; set; }
    }
    public class JobClients
    {
        public string JobNumber { get; set; }
        public string Description { get; set; }
        public string Clienttext { get; set; }
        public string JobAddress { get; set; }
        public string Borough { get; set; }
        public string Handler { get; set; }
        public int CompanyID { get; set; }
        public string ContactsAddress { get; set; }
        public string ContactsFaxNumber { get; set; }
        public string ContactsWorkPhone { get; set; }
        public string AllContactsEmail { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public object WorkPhone { get; set; }
        public object FaxNumber { get; set; }
        public object EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string TypicalInvoiceType { get; set; }
    }

    public class JobNumberData
    {
        public int JobListID { get; set; }
        public DateTime JobNumber { get; set; }
        public int CompanyID { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public string Handler { get; set; }
        public string Borough { get; set; }
        public string Address { get; set; }
        public object Contacts { get; set; }
        public object EmailAddress { get; set; }
        public object ContactsID { get; set; }
        public string CompanyName { get; set; }
        public string ACContacts { get; set; }
        public string ACEmail { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerFax { get; set; }
        public string CompanyNo { get; set; }
    }

}
