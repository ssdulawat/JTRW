using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ApplicantInfo
    {
        public int ApplicantID { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
        public string ApplicantMidName { get; set; }
        public string ApplicantBusinessName { get; set; }
        public string ApplicantBusinessAddress { get; set; }
        public string ApplicantBusinessCity { get; set; }
        public string ApplicantBusinessState { get; set; }
        public string ApplicantBusinessZip { get; set; }
        public string ApplicantTitle { get; set; }
        public string ApplicantLicense { get; set; }
        public string ApplicantPhone { get; set; }
        public string Applicantfax { get; set; }
    }


}