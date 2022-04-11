using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class AppSettings
    {
        public string CompareSchedule { get; set; }
        public bool CompareActiveTimer { get; set; }
        public bool ActiveWebUpload { get; set; }        
    }
}
