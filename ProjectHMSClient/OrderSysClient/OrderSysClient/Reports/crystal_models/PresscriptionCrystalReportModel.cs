using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSysClient.Reports.crystal_models
{
    public class PresscriptionCrystalReportModel
    {
        public DateTime appoinment_date { get; set; }
        public DateTime presscription_date { get; set; }
        public int appoinment_serial { get; set; }
        public int appoinment_id { get; set; }
        public int patient_id { get; set; }
        public int prescription_id { get; set; }
        public string appoinment_time { get; set; }
        public int doctor_registration_number { get; set; }

        public int department_id { get; set; }
        public int doctor_id { get; set; }
        public string full_name { get; set; }
        public string pat_address { get; set; }
        public int nid_id { get; set; }
        public int age { get; set; }
        public double height { get; set; }
        public string blood_pressure { get; set; }
        public double weight { get; set; }
        public string gender { get; set; }
        public string blood_group { get; set; }
        public string doctor_name { get; set; }
        public string department_name { get; set; }
        public string status { get; set; }
        public string dob { get; set; }
        public string hospital_name { get; set; }
        public string meta_address { get; set; }
        public string division_name { get; set; }
        public string district_name { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string logo_path { get; set; }
        public string chief_complaints { get; set; }
        public string chief_complaints_duration { get; set; }
        public string drug_allergies_name { get; set; }
        public string health_condition_name { get; set; }
        public string medicine_name { get; set; }
        public string medicine_power { get; set; }
        public string dosage { get; set; }
        public string how_long { get; set; }
        public string route_of_administration { get; set; }
        public string rules { get; set; }
        public string suggestion_name { get; set; }
        public string test_type_name { get; set; }
        public string need_admission { get; set; }
        public string diease_name { get; set; }
    }
}