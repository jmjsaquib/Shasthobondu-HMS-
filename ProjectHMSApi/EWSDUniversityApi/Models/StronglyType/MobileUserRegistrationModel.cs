using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class MobileUserRegistrationModel
    {
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public Nullable<int> nid { get; set; }

    }
}