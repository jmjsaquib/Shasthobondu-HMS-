using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSysClient.Reports.crystal_models
{
    public class InvoiceReportModel
    {
        public int patient_id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string pat_address { get; set; }
        public string doctor_name { get; set; }
        public int doctor_id { get; set; }
        public int admission_id { get; set; }
        public string admission_date { get; set; }
        public int department_id { get; set; }
        public int age { get; set; }
        public string department_name { get; set; }
        public int payment_type_id { get; set; }
        public int discharge_id { get; set; }
        public int payment_method_id { get; set; }
        public DateTime payment_date { get; set; }
        public decimal amount_without_adjustment { get; set; }
        public string adjustment_criteria { get; set; }
        public decimal adjustment_amount { get; set; }
        public decimal amount_with_adjustment { get; set; }
        public string discharge_date { get; set; }
        public string payment_method_name { get; set; }
        public int bank_id { get; set; }
        public string bank_name { get; set; }
        public int cheque_no { get; set; }
        public int account_no { get; set; }
        public string check_date { get; set; }
        public int payment_id { get; set; }
        public decimal doctor_fees { get; set; }
        public int meta_info_id { get; set; }
        public int hospital_id { get; set; }
        public int bed_id { get; set; }
        public int chargable_days { get; set; }
        public string hospital_name { get; set; }
        public string meta_address { get; set; }
        public string division_name { get; set; }
        public string district_name { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string logo_path { get; set; }
        public string room_no { get; set; }
        public string ward_name { get; set; }
        public decimal daily_cost { get; set; }
    }
}