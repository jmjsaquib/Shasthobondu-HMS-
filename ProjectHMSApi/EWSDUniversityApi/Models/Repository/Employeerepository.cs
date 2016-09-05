using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.Repository
{
    public class Employeerepository:IEmployeeRepository
    {
        private Entities _entities;
        public Employeerepository() {
            this._entities = new Entities();
        }

        public object GetAllEmployee()
        {
            try
            {
                var data = (from emp in _entities.employees
                            join role in _entities.role_type on emp.role_type_id equals role.role_type_id into roleTable
                            from subRole in roleTable.DefaultIfEmpty()
                            join dep in _entities.departments on emp.department_id equals dep.department_id into depTable
                            from subDep in depTable.DefaultIfEmpty()
                            select new {
                                employee_id=emp.employee_id,
                                employee_name=emp.employee_name,
                                joining_date=emp.joining_date,
                                department_id=emp.department_id,
                                designation=emp.designation,
                                role_type_id=subRole.role_type_id,
                                employee_code=emp.employee_code,
                                department_name=subDep.department_name,
                                role_name=subRole.role_name,
                                employee_user_name=emp.employee_user_name,
                                employee_email=emp.employee_email
                            }).ToList();
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object GetAllEmployeeDoctor()
        {
            return (from doc in _entities.doctors
                    where doc.available == "yes"
                    join emp in _entities.employees on doc.employee_id equals emp.employee_id into empTble
                    from subEmp in empTble.DefaultIfEmpty()
                    join dep in _entities.departments on doc.department_id equals dep.department_id into depTable
                    from subDep in depTable.DefaultIfEmpty()
                    select new
                    {
                        department_id = doc.department_id,
                        doctor_id = doc.doctor_id,
                        employee_id = doc.employee_id,
                        department_name = subDep.department_name,
                        employee_name = subEmp.employee_name,
                        doctor_fees = doc.doctor_fees,
                        doctor_appoinment_count = doc.doctor_appoinment_count,
                        doctor_available_time_from = doc.doctor_available_time_from,
                        doctor_available_time_to = doc.doctor_available_time_to,
                        available = doc.available,
                        doctor_registration_number = doc.doctor_registration_number
                    }).ToList();
        }
        public object GetAllDepartmentWiseDoctor()
        {
            try
            {
                return _entities.employees.Where(e => e.role_type_id == 3 && e.employee_status == "waiting").ToList();
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public object Delete(int employee_id)
        {
            try
            {
                var data = _entities.employees.FirstOrDefault(e => e.employee_id == employee_id);
                _entities.employees.Attach(data);
                _entities.employees.Remove(data);
                var docData = _entities.doctors.FirstOrDefault(e => e.employee_id == employee_id);
                _entities.doctors.Attach(docData);
                _entities.doctors.Remove(docData);
                _entities.SaveChanges();
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public bool insert(employee emp)
        {
            try
            {
                var serial = _entities.employees.Max(e => e.employee_serial);
                if (serial==null)
                {
                    serial = 10001;
                }
                else
                {
                    serial++;
                }
                var emp_code = "hms" + serial +"/"+ DateTime.Now.Year;

                employee empployee = new employee { 
                employee_name=emp.employee_name,
                employee_user_name=emp.employee_user_name,
                employee_password=emp.employee_password,
                department_id=emp.department_id,
                designation=emp.designation,
                role_type_id=emp.role_type_id,
                employee_address=emp.employee_address,
                employee_serial=serial,
                employee_code=emp_code,
                joining_date=emp.joining_date,
                nid=emp.nid,
                employee_email=emp.employee_email,
                hospital_id = emp.hospital_id,
                employee_status = "waiting"
                };
                _entities.employees.Add(empployee);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CheckUsername(string employee_user_name, string employee_email)
        {
            try
            {
                var data = _entities.employees.FirstOrDefault(e=>e.employee_user_name==employee_user_name);
                var email = _entities.employees.FirstOrDefault(m=>m.employee_email==employee_email);
                if (data==null && email==null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public bool UpdateEmployee(employee emp)
        {
            try
            {
                employee empployee = _entities.employees.FirstOrDefault(e => e.employee_id == emp.employee_id);
                if (empployee != null)
                {
                    empployee.employee_name = emp.employee_name;
                    empployee.joining_date = emp.joining_date;
                    empployee.department_id = emp.department_id;
                    empployee.designation = emp.designation;
                    empployee.role_type_id = emp.role_type_id;
                    _entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool UpdateFulldataEmployee(employee emp)
        {
            try
            {
                employee empployee = _entities.employees.FirstOrDefault(e => e.employee_id == emp.employee_id);
                if (empployee != null)
                {
                    empployee.employee_user_name = emp.employee_user_name;
                    empployee.employee_password = emp.employee_password;
                    empployee.employee_address = emp.employee_address;
                    empployee.employee_id = emp.employee_id;
                    _entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}