using HMSDevelopmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    public interface IUserPermissionRepository
    {

        List<role_permission> GetAllPermissionForRole(int roleId);

        object GetAllModuleForRole();
    }
}
