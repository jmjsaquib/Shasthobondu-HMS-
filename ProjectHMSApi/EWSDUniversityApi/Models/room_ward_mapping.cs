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
    
    public partial class room_ward_mapping
    {
        public int room_ward_mapping_id { get; set; }
        public Nullable<int> room_id { get; set; }
        public Nullable<int> ward_id { get; set; }
        public Nullable<int> department_id { get; set; }
        public string assigned_date { get; set; }
    }
}
