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
    
    public partial class payment
    {
        public int payment_id { get; set; }
        public Nullable<int> payment_type_id { get; set; }
        public Nullable<int> patient_id { get; set; }
        public Nullable<int> admission_id { get; set; }
        public Nullable<int> discharge_id { get; set; }
        public Nullable<int> payment_method_id { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public string amount_without_adjustment { get; set; }
        public string adjustment_criteria { get; set; }
        public string adjustment_amount { get; set; }
        public string amount_with_adjustment { get; set; }
    }
}
