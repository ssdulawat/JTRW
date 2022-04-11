using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class CBoardData
    {
        public int CommunityBoardID { get; set; }
        public int CommunityBoardNum { get; set; }
        public string ChairPerson { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public object IsChange { get; set; }
        public object IsNewRecord { get; set; }
        public object IsDelete { get; set; }
        public object ChangeDate { get; set; }
    }
}
