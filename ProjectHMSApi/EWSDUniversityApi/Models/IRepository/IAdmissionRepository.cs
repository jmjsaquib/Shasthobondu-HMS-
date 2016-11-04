using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IAdmissionRepository
    {
        object GetAllAdmission(int hospital_id);

        object addmissionId(int addmissionId);

        bool CheckDuplicateForbed(admission admission);

        bool InsertAdmission(admission admission);

        object GetAdmissionByWardId(int wardId);

        object GetAdmissionByRoomId(int roomid);
    }
}
