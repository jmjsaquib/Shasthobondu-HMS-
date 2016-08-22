using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class GetAllpatientModel
    {
        public Nullable<int> patient_id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string status { get; set; }
        public string blood_group { get; set; }
        public string doctor_name { get; set; }
        public string need_admission { get; set; }
        public Nullable<int> appoinment_id { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public Nullable<int> presscription_id { get; set; }


    }
}