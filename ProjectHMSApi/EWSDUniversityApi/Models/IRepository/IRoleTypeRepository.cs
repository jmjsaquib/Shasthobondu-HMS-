using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    public interface IRoleTypeRepository
    {
        object GetAllRoleTypeById(int roleTypeId);
        List<role_type> GetAllRoleType();
        bool InsertRoleType(role_type oRoleType);
        bool UpdateRoleType(role_type oRoleType);
        bool DeleteRoleType(int roleTypeId);
        bool CheckDuplicateForRoleTypeName(int? role_type_id, string role_name);
    }
}
