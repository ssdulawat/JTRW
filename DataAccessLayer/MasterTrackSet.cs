//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class MasterTrackSet
    {
        public int Id { get; set; }
        public string TrackSet { get; set; }
        public string TrackName { get; set; }
        public Nullable<bool> IsNewRecord { get; set; }
        public Nullable<bool> IsChange { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}