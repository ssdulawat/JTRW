using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class DocTypeData
    {
        public string CategoryName { get; set; }
        public int DocTypical_ID { get; set; }
        public string DocTypical_Text { get; set; }
        public int DocTypical_Category { get; set; }
    }

    public class TypeCategoryData
    {
        public int TypeCategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}