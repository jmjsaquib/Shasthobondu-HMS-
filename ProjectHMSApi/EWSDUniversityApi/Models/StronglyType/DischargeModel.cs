using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class DischargeModel:discharge
    {
       public List<discharge_medicine_mapping> medicine { get; set; }

    }
}