using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class MasterData
    {
        public int TS_MasterItemId { get; set; }
        public string Value { get; set; }
    }

    public class MasterGroup
    {
        public int Id { get; set; }
        public string cGroup { get; set; }
        public string cTrack { get; set; }
    }
}