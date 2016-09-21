using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSysClient.Reports.crystal_models
{
    public class AppoinmentInvoiceModel
    {
        public int patient_id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string pat_address { get; set; }
        public string doctor_name { get; set; }
        public int doctor_id { get; set; }
        public int appoinment_id { get; set; }
        public DateTime appoinment_date { get; set; }
        public int department_id { get; set; }
        public int age { get; set; }
        public string department_name { get; set; }
        public string hospital_name { get; set; }
        public string meta_address { get; set; }
        public string division_name { get; set; }
        public string district_name { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string logo_path { get; set; }
        public string doctor_fees { get; set; }
    }
}