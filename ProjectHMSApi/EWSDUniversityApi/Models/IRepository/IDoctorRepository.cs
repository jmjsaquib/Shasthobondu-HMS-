using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IDoctorRepository
    {
        object GetAllDoctor();

        object GetDoctorById(int doctorId);

        bool CheckDuplicateForDoctorinfo(int? employeeId, int? departmentId);

        bool InsertDoctor(doctor doc);

        bool updateDoctor(doctor doc);

    }
}
