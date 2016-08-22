﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private Entities _entities;

        public LoginRepository()
        {
            this._entities = new Entities();
        }



        public object GetLogin(string employee_user_name, string employee_password)
        {
            try
            {
                var data = (from emp in _entities.employees
                            where (emp.employee_user_name == employee_user_name && emp.employee_password == employee_password)
                            join meta in _entities.meta_info on emp.hospital_id equals meta.hospital_id into metaTable
                            from subMeta in metaTable.DefaultIfEmpty()
                            join role in _entities.role_type on emp.role_type_id equals role.role_type_id into roleTable
                            from subRole in roleTable.DefaultIfEmpty()
                            select new {
                                role_type_id=emp.role_type_id,
                                employee_user_name=emp.employee_user_name,
                                employee_id=emp.employee_id,
                                hospital_id=emp.hospital_id,
                                hospital_name=subMeta.hospital_name,
                                employee_email=emp.employee_email,
                                employee_name=emp.employee_name,
                                role_name=subRole.role_name
                                            
                            }).FirstOrDefault();
                  
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}