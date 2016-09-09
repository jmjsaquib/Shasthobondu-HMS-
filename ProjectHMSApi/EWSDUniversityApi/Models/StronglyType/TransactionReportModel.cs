using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class TransactionReportModel 
    {
        public string hospital_name { get; set; }
        public string meta_address { get; set; }
        public string division_name { get; set; }
        public string district_name { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string web { get; set; }
        public string logo_path { get; set; }
        public Nullable<int> CountPat { get; set; }
        public Nullable<int> CountAppo { get; set; }
        public Nullable<int> CountEntry { get; set; }
        public Nullable<int> CountDeath { get; set; }
        public Nullable<int> CountAdmit { get; set; }
        public Nullable<int> employeeCount { get; set; }
        public Nullable<int> doctorCount { get; set; }
        public Nullable<int> departmentCount { get; set; }
        public Nullable<decimal> totalTransaction { get; set; }
    }
}