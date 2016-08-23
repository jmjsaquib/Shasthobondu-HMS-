using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDischargeTypeRepository
    {
        object GetAllDischarType();

        object GetDischarTypeById(int dischargeId);

        bool CheckDuplicateForDischargeTypeName(discharge_type discharge);

        bool InsertDischargeType(discharge_type discharge);

        bool UpdateDischargeType(discharge_type discharge);

        bool DeleteDischargeType(int dischargeId);
    }
}
