using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class TaskListData
    {
        public long TaskLisiId { get; set; }
        public string JobNumber { get; set; }
        public string PM { get; set; }
        public string TM { get; set; }
        public string Description { get; set; }
        public Nullable< DateTime> Date { get; set; }
        public Nullable<DateTime> CompletedByDate { get; set; }
        public string Status { get; set; }
       
    }
}
