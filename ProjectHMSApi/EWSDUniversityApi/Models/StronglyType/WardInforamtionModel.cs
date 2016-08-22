using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class WardInforamtionModel:ward
    {
        public int room_ward_mapping_id { get; set; }
        public Nullable<int> room_id { get; set; }
        public Nullable<int> ward_id { get; set; }
        public Nullable<int> room_type_id { get; set; }
        public Nullable<int> floor_id { get; set; }
        public Nullable<int> department_id { get; set; }
        public string assigned_date { get; set; }
        public string department_name { get; set; }
        public string room_no { get; set; }
        public string floor_name { get; set; }
        public string room_type_name { get; set; }
        public string room_description { get; set; }


    }
}