using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderSysClient.Reports.crystal_models
{
    public class TransactionReportModel
    {
        public int CountPat { get; set; }
        public int CountAppo { get; set; }
        public int CountEntry { get; set; }
        public int CountDeath { get; set; }
        public int CountAdmit { get; set; }
        public int employeeCount { get; set; }
        public int doctorCount { get; set; }
        public int departmentCount { get; set; }
        public decimal totalTransaction { get; set; }
        public string hospital_name { get; set; }
        public string meta_address { get; set; }
        public string division_name { get; set; }
        public string district_name { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string logo_path { get; set; }
    }
}