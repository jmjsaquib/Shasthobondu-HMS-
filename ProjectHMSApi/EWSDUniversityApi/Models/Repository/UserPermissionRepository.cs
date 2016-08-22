using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class UserPermissionRepository:IUserPermissionRepository
    {
        private Entities _entities;

        public UserPermissionRepository()
        {
            this._entities = new Entities();
        }

        public List<role_permission> GetAllPermissionForRole(int roleId)
        {
            try
            {
                List<role_permission> data = _entities.role_permission.Where(r => r.role_type_id == roleId).ToList();
                return data;
            }
            catch (Exception e)
            {
                    
                throw ;
            }
        }

        public object GetAllModuleForRole()
        {
            try
            {
                var data = _entities.modules.ToList().OrderBy(m=>m.module_sort);
                return data;
            }
            catch (Exception)
            {
                    
                throw;
            }
        }
    }
}