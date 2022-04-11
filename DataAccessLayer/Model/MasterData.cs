using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class MasterData
    {
        public long TS_MasterItemId { get; set; }
        public string Value { get; set; }
    }

    public class MasterGroup
    {
        public int Id { get; set; }
        public string cGroup { get; set; }
        public string cTrack { get; set; }
    }

    public partial class TS_ItemMASS
    {
        public string ItemName { get; set; }
        public string Value { get; set; }
    }
}