using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IAdmissionRepository
    {
        object GetAllAdmission();

        object addmissionId(int addmissionId);

        bool CheckDuplicateForbed(admission admission);

        bool InsertAdmission(admission admission);
    }
}
