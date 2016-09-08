using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class RosterDataModel
    {
        public int doctor_roster_id { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> start { get; set; }
        public Nullable<System.DateTime> end { get; set; }
        public string description { get; set; }
        public Nullable<int> recurrenceID { get; set; }
        public string recurrenceRule { get; set; }
        public string recurrenceException { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public Nullable<int> department_id { get; set; }
        public string isAllDay { get; set; }
    }
}