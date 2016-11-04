using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class PatientReportModel
    {

        public Nullable<int> CountPat { get; set; }
        public Nullable<int> CountAppo { get; set; }
        public Nullable<int> CountEntry { get; set; }
        public Nullable<int> CountDeath { get; set; }
        public Nullable<int> CountAdmit { get; set; }
        public Nullable<int> employeeCount { get; set; }
        public Nullable<int> doctorCount { get; set; }
        public Nullable<int> departmentCount { get; set; }
        public Nullable<decimal> totalTransaction { get; set; }
        public Nullable<decimal> totalClient { get; set; }
        public Nullable<decimal> countDonor { get; set; }
    }
}