using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class ShiftTypeModel
    {
        public int shift_type_id { get; set; }
        public string shift_type_name { get; set; }
        public string shift_from { get; set; }
        public string shift_to { get; set; }
    }
}