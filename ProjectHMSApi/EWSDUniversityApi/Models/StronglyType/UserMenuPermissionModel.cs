using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class UserMenuPermissionModel
    {
        public int module_id { get; set; }
        public string module_name { get; set; }
        public Nullable<int> module_sort { get; set; }
        public string module_url { get; set; }
        public Nullable<int> module_parent_id { get; set; }
        public string module_alias { get; set; }
        public string module_icon { get; set; }
        

        public int role_permission_id { get; set; }
        public Nullable<int> role_type_id { get; set; }
        public bool module_status { get; set; }
    }
}