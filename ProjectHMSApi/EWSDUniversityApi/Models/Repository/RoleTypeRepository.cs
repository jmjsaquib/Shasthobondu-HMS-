using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class RoleTypeRepository:IRoleTypeRepository
    {
          private Entities _entities;

        public RoleTypeRepository() {
            this._entities = new Entities();
        }
        public object GetAllRoleTypeById(int roleTypeId)
        {
            return _entities.role_type.Where(r=>r.role_type_id==roleTypeId).FirstOrDefault();
        }

        public List<role_type> GetAllRoleType()
        {
            return _entities.role_type.Where(r=>r.role_type_id !=7).ToList();
        }

        public bool InsertRoleType(role_type oRoleType)
        {
            try
            {

                var insert = new role_type
                {
                    role_name = oRoleType.role_name,
                    role_description = oRoleType.role_description,
                    hospital_id = oRoleType.hospital_id
                };
                _entities.role_type.Add(insert);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateRoleType(role_type oRoleType)
        {
            try
            {
                role_type RoleType = _entities.role_type.Find(oRoleType.role_type_id);
                RoleType.role_type_id=oRoleType.role_type_id;
                RoleType.role_name = oRoleType.role_name;
                RoleType.role_description = oRoleType.role_description;
                _entities.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteRoleType(int roleTypeId)
        {
            try
            {
                role_type oRoleType = _entities.role_type.FirstOrDefault(r=>r.role_type_id==roleTypeId);
                _entities.role_type.Attach(oRoleType);
                _entities.role_type.Remove(oRoleType);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool CheckDuplicateForRoleTypeName(int? role_type_id, string role_name)
        {
            var chkRoleTypeNameExists = _entities.role_type.FirstOrDefault(b => b.role_type_id == role_type_id && b.role_name == role_name );
            return chkRoleTypeNameExists == null ? false : true;
        }
    }
}