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
    
    public partial class meta_info
    {
        public int meta_info_id { get; set; }
        public Nullable<int> hospital_id { get; set; }
        public string hospital_name { get; set; }
        public string address { get; set; }
        public Nullable<int> division_id { get; set; }
        public Nullable<int> district_id { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string logo_path { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
    }
}
