using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private Entities _entities;
        public DepartmentRepository() {

            this._entities = new Entities();
        }
        public object GetAlldepartmentById(int departmentId)
        {
            return _entities.departments.Where(d => d.department_id == departmentId).FirstOrDefault();
        }

        public List<department> GetAllDepartment()
        {
            return _entities.departments.ToList();
        }

        public bool InsertDepartment(department oDep)
        {
            try
            {
                var insert = new department { 
                    department_id=oDep.department_id,
                    department_name=oDep.department_name,
                    color_id=oDep.color_id
                };
                _entities.departments.Add(insert);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateDepartment(department oDep)
        {
            try
            {
                department dep = _entities.departments.Find(oDep.department_id);
                dep.department_id = oDep.department_id;
                dep.department_name = oDep.department_name;
                dep.color_id = oDep.color_id;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteDepartment(int departmentId)
        {
            try
            {
                department dep = _entities.departments.FirstOrDefault(d => d.department_id == departmentId);
                _entities.departments.Attach(dep);
                _entities.departments.Remove(dep);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool CheckDuplicateForDepartmentName(int? department_id, string department_name)
        {
            var checkUserNameIsExists = _entities.departments.FirstOrDefault(b => b.department_id == department_id && b.department_name == department_name);
            return checkUserNameIsExists == null ? false : true;
        }
    }
}