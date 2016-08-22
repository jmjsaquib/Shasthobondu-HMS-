using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IPresscriptionRepository
    {
        object GetAllPresscription();

        object GetAllPresscriptionByPatientId(int patientId);

        bool insert(StronglyType.PresscriptionDataModel press);

        object GetAllPresscriptionByPresscriptionId(int presscriptionid);
    }
}
