using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IPresscriptionRepository
    {


        bool insert(StronglyType.PresscriptionDataModel press);

        object GetAllPresscriptionByPresscriptionId(int presscriptionid);


        object GetAllPresscriptionByDoctorID(int employeeId, string today);

        object GetAllPresscription(string status);


        object GetAllPresscriptionBypatientId(int patientId);

        object GetPresscriptionDetails(int patientId, int presscriptionId);
    }
}
