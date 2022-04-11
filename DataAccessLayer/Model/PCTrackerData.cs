using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class InOutData
    {
        public DateTime UserIn { get; set; }
        public DateTime UserOut { get; set; }
        public DateTime Date { get; set; }
    }

    public class dtoPunchedHrs:InOutData
    {
        public double PunchedHrs { get; set; }
    }

    public class dtoHoursWorked:InOutData
    {
        public double HoursWorked { get; set; }
    }

    public class UserList
    {
        public int EmployeeDetailsId { get; set; }
        public string Name { get; set; }
    }

    public class HrsByDate
    {
        public double HoursWorked { get; set; }
        public DateTime Date { get; set; }
    }

    public class dtoUserBillRate
    {
        public string UserName { get; set; }
        public string BillableRate { get; set; }
    }
}
