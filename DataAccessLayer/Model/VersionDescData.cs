using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class VersionDescData
    {
        public string TrackSet { get; set; }
        public string TrackName { get; set; }
        public string TrackSubName { get; set; }
        public int MasterTrackSubItemId { get; set; }
        public double Rate { get; set; }
        public object Description { get; set; }
        public string Account { get; set; }
        public object CalColor { get; set; }
        public int Id { get; set; }
        public int TableVersionId { get; set; }
        public int VersionDescId { get; set; }
    }

    public class VersionDescDataEdit
    {
        public string TrackSet { get; set; }
        public string TrackName { get; set; }
        public string TrackSubName { get; set; }
        public Nullable<int> MasterTrackSubItemId { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public object Description { get; set; }
        public string Account { get; set; }
        public object CalColor { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<int> TableVersionId { get; set; }
        public Nullable<int> VersionDescId { get; set; }
    }
}
