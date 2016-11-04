using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class HospitalInfoModel
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
        public string employee_name { get; set; }
        public string employee_email { get; set; }
        public string employee_user_name { get; set; }
        public string employee_password { get; set; }

    }
}