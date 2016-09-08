using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDoctorRosterRepository
    {
        object GetAllRoster();

        object GetAllRosterByDepartmentId(int deparmentId);

        object GetAllRosterByDoctorId(int doctorId);

        bool CheckDuplicateForRosterName(doctor_roster odDoctorRoster);

        bool InsertRoster(doctor_roster odDoctorRoster);

        bool UpdateRoster(doctor_roster odDoctorRoster);

        bool DeleteRoster(int p);
    }
}
