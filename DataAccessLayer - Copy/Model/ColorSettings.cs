using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    class ColorSettings
    {
    }

    public class EmailColor
    {
        public string ColorCode { get; set; }
        public string EmailDescription { get; set; }
        public int EmaildesID { get; set; }
        public int ColorID { get; set; }
        public string EmailSubject { get; set; }
        public string Color { get; set; }        
    }

    public class Color_Code
    {
        public string ColorCode { get; set; }
        public int ColorID { get; set; }
        public string ColorCodeImage { get; set; }        
    }
}