using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
   public class ColorEmailData
    {
        public int ColorID { get; set; }
        public string EmailSubject { get; set; }
        public string EmailDescription { get; set; }
    }
}