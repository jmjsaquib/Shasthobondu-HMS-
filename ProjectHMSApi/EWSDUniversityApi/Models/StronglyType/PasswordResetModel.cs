using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class PasswordResetModel
    {
        public string employee_user_name { get; set; }
        public string employee_password { get; set; }
        public int employee_id { get; set; }
        public string new_user_name { get; set; }
        public string new_password { get; set; }
    }
}