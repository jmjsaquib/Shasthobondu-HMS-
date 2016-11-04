using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDischargeRepository
    {
        object GetAllDischarge(int hospital_id);

        object GetDischarById(int dischargeId);

        bool InsertDischarge(StronglyType.DischargeModel discharge);

        bool UpdateDischarge(discharge_type discharge);

        object GetAllDischargeByDepartmentId(int departmentId);
    }
}
