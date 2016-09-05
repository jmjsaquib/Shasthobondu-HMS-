using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class DischargeListModel
    {
        public Nullable<int> admission_id { get; set; }
        public string admission_date { get; set; }
        public Nullable<int> patient_id { get; set; }
        public string patient_name { get; set; }
        public Nullable<int> department_id { get; set; }
        public string department_name { get; set; }
        public string payment_status { get; set; }
        public Nullable<int> payment_id { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; } 
    }
}