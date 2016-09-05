using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class BloodDonationDataModel
    {
        public Nullable<int> patient_id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public Nullable<int> division_id { get; set; }
        public string division_name { get; set; }
        public Nullable<int> district_id { get; set; }
        public string district_name { get; set; }
        public string zip_code { get; set; }
        public string phone { get; set; }
        public Nullable<int> nid_id { get; set; }
        public string blood_group { get; set; }
        public Nullable<double> height { get; set; }
        public Nullable<double> weight { get; set; }
        public Nullable<int> age { get; set; }
        public string dob { get; set; }
        public Nullable<System.DateTime> last_donation_date { get; set; }
        public string last_donation_place { get; set; }
        public string blood_pressure { get; set; }
        public Nullable<int> donation_serial { get; set; }

    }
}