using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IWardRepository
    {
        object GetAllWard(int hsopital_id);

        object GetWardById(int wardId);

        bool CheckDuplicateForWardName(string wardname,string wing,int? floor_id,int? hospital_id);

        bool UpdateWard(ward ward);

        bool InsertWard(ward ward);

        bool DeleteWard(int wardId);

        bool CheckDuplicateForWardNameUpdae(ward ward);

        object GetWardByForAdmissionId(string wardTypeValue, string wardForWhomValue, int departmentId);
    }
}
