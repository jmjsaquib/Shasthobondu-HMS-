using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class WardGeneralDataModel
    {
        public List<room_ward_mapping> mappingdata { get; set; }
        public ward generalData { get; set; }
       

    }
}