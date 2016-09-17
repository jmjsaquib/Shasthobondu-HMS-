using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class CurrentDatePresscriptionForPrintModel
    {
        public string appoinment_date { get; set; }
        public Nullable<DateTime> presscription_date { get; set; }
        public Nullable<int> appoinment_serial { get; set; }
        public int appoinment_id { get; set; }
        public Nullable<int> patient_id { get; set; }
        public Nullable<int> prescription_id { get; set; }
        public string appoinment_time { get; set; }
        public Nullable<int> department_id { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string blood_group { get; set; }
        public string employee_name { get; set; }
        public string department_name { get; set; }
        public string status { get; set; }
        public string dob { get; set; }
    }
}