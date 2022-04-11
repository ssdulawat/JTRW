using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class MasterTrackSetData
    {
        public int Id { get; set; }
        public string TrackSet { get; set; }
        public string TrackName { get; set; }
    }

    public class dtoMasterTrack
    {
        public int Id { get; set; }
        public string TrackName { get; set; }
    }
}