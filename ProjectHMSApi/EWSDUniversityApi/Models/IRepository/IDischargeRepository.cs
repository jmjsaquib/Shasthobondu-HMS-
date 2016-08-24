using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDischargeRepository
    {
        object GetAllDischarge();

        object GetDischarById(int dischargeId);

        bool InsertDischarge(StronglyType.DischargeModel discharge);

        bool UpdateDischarge(discharge_type discharge);
    }
}
