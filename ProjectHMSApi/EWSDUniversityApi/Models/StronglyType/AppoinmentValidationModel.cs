using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class AppoinmentValidationModel
    {
        public string appoinment_date { get; set; }
        public string submittedDate { get; set; }
        public Nullable<int> count { get; set; }
        public Nullable<int> appoinment_serial { get; set; }
        public Nullable<int> appoinment_id { get; set; }
        public Nullable<int> patient_id { get; set; }
        public string appoinment_time { get; set; }
        public Nullable<int> department_id { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public string purpose { get; set; }
        public string patient_type { get; set; }
        public string appoinment_type { get; set; }
    }
}