//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMSDevelopmentApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class room
    {
        public int room_id { get; set; }
        public string room_no { get; set; }
        public string room_description { get; set; }
        public Nullable<int> room_type_id { get; set; }
        public Nullable<int> floor_id { get; set; }
        public Nullable<int> no_of_bed { get; set; }
        public string status { get; set; }
        public Nullable<int> department_id { get; set; }
        public Nullable<int> room_assign_bed { get; set; }
        public Nullable<int> room_rest_bed { get; set; }
    }
}