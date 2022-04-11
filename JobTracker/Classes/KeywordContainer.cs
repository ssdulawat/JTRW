using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Classes
{
    public class KeywordContainer
    {
        public string Keyword { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public KeywordContainer(string key_word, string Column_Name)
        {
            Keyword = key_word;
            ColumnName = Column_Name;
            Value = "";
        }
    }
}
