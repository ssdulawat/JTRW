using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public object Address { get; set; }
        public object Mobile { get; set; }
        public object Designation { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public object EmailAddress { get; set; }
        public string UserType { get; set; }
        public int BillableRate { get; set; }
        public object ActiveUser { get; set; }
        public string FirstName { get; set; }
        public object LastName { get; set; }
        public object MasterItemId { get; set; }
        public object IsDelete { get; set; }
        public int TempId { get; set; }
        public int ReservedOldId { get; set; }
    }
}
