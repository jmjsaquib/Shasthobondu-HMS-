using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IPatientRepository
    {
        object GetAllPatient();

        object GetPatientById(int patientId);

        bool CheckDuplicateForpatientinfo(string user_name, string email);

        bool Insertpatient(StronglyType.PatientInformationModel pat);

        bool Updatepatient(StronglyType.PatientInformationModel pat);
    }
}
