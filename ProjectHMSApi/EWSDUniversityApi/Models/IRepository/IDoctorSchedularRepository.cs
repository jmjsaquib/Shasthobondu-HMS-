using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDoctorSchedularRepository
    {
        object GetAllSchedular();

        object GetAllSchedularDepartmentid(int deparmentId);

        object GetAllSchedularByDoctorId(int doctorId);

        bool InsertSchedule(StronglyType.RosterDetailsListModel rosterDetailsList);

        bool UpdateSchedule(doctor_schedule doctorSchedule);

        bool DeleteRoster(int p);

        object GetAllSchedularBydeparmentDoctorId(int departmentId, int doctorId, int hospital_id);
    }
}
