using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class MasterTrackSubData
    {
        public string TrackSet { get; set; }
        public string TrackName { get; set; }
        public string TrackSubName { get; set; }
        public decimal nRate { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public string CalColor { get; set; }
        public int Id { get; set; }
    }

    public class M_TrackSubAccountOnly
    {
        public string Account { get; set; }
    }

    public class dtoTSNameOnly
    {
        public string TrackSubName { get; set; }
    }

    public class dtoMTSubItem
    {
        public string TrackSet { get; set; }
        public string TrackName { get; set; }
        public string TrackSubName { get; set; }
        public string Account { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Description { get; set; }
    }

    public class dtoTrackOnly
    {
        public string cTrack { get; set; }
    }
}
