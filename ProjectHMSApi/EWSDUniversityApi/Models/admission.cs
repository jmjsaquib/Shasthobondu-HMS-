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
    
    public partial class admission
    {
        public int admission_id { get; set; }
        public Nullable<int> patient_id { get; set; }
        public string admission_date { get; set; }
        public Nullable<int> reffered_by { get; set; }
        public Nullable<int> department_id { get; set; }
        public Nullable<int> ward_id { get; set; }
        public Nullable<int> room_id { get; set; }
        public Nullable<int> received_by { get; set; }
        public string received_date { get; set; }
        public string received_time { get; set; }
        public Nullable<int> presscription_id { get; set; }
        public Nullable<int> bed_id { get; set; }
        public string bed_status { get; set; }
        public string payment_status { get; set; }
        public Nullable<decimal> daily_cost { get; set; }
    }
}
