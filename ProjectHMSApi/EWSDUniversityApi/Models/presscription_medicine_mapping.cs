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
    
    public partial class presscription_medicine_mapping
    {
        public int presscription_medicine_mapping_id { get; set; }
        public Nullable<int> presscription_id { get; set; }
        public Nullable<int> medicine_id { get; set; }
        public string medicine_power { get; set; }
        public string dosage { get; set; }
        public string how_long { get; set; }
        public string route_of_administration { get; set; }
        public string rules { get; set; }
    }
}