using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DoctorRepository:IDoctorRepository
    {
        private Entities _entities;

        public DoctorRepository()
        {
            this._entities=new Entities();
        }
        public object GetAllDoctor()
        {
            return (from doc in _entities.doctors
                   
                join emp in _entities.employees on doc.employee_id equals emp.employee_id into empTble
                from subEmp in empTble.DefaultIfEmpty()
                join dep in _entities.departments on doc.department_id equals dep.department_id into depTable
                from subDep in depTable.DefaultIfEmpty()
                select new
                {
                    department_id=doc.department_id,
                    doctor_id=doc.doctor_id,
                    employee_id=doc.employee_id,
                    department_name=subDep.department_name,
                    employee_name=subEmp.employee_name,
                    doctor_fees=doc.doctor_fees,
                    doctor_appoinment_count=doc.doctor_appoinment_count,
                    doctor_available_time_from=doc.doctor_available_time_from,
                    doctor_available_time_to=doc.doctor_available_time_to,
                    available=doc.available,
                    doctor_registration_number=doc.doctor_registration_number
                }).ToList();
        }

        public object GetDoctorById(int doctorId)
        {
            try
            {
                return (from doc in _entities.doctors
                        where doc.doctor_id == doctorId
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id into empTble
                        from subEmp in empTble.DefaultIfEmpty()
                        join dep in _entities.departments on doc.department_id equals dep.department_id into depTable
                        from subDep in depTable.DefaultIfEmpty()
                        select new
                        {
                            department_id = doc.department_id,
                            doctor_id = doc.doctor_id,
                            employee_id=doc.employee_id,
                            department_name = subDep.department_name,
                            employee_name = subEmp.employee_name,
                            doctor_fees = doc.doctor_fees,
                            doctor_appoinment_count = doc.doctor_appoinment_count,
                            doctor_available_time_from = doc.doctor_available_time_from,
                            doctor_available_time_to = doc.doctor_available_time_to,
                           doctor_registration_number=doc.doctor_registration_number,
                            available = doc.available
                        }).FirstOrDefault();
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool CheckDuplicateForDoctorinfo(int? employeeId, int? departmentId)
        {
            try
            {
                var data =
                    _entities.doctors.FirstOrDefault(d => d.employee_id == employeeId && d.department_id == departmentId);
                if (data!=null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool InsertDoctor(doctor doc)
        {
            try
            {
                doctor doct = new doctor
                {
                    employee_id = doc.employee_id,
                    department_id = doc.department_id,
                    doctor_fees = doc.doctor_fees,
                    doctor_appoinment_count = doc.doctor_appoinment_count,
                    doctor_available_time_from = doc.doctor_available_time_from,
                    doctor_available_time_to = doc.doctor_available_time_to,
                    available = doc.available,
                    doctor_registration_number=doc.doctor_registration_number
                };
                _entities.doctors.Add(doct);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                    
                return false;
            }
        }

        public bool updateDoctor(doctor doc)
        {
            try
            {
                var data = _entities.doctors.FirstOrDefault(d => d.doctor_id == doc.doctor_id);
                data.doctor_appoinment_count = doc.doctor_appoinment_count;
                data.doctor_available_time_from = doc.doctor_available_time_from;
                data.doctor_available_time_to = doc.doctor_available_time_to;
                data.available = doc.available;
                data.doctor_fees = doc.doctor_fees;
                data.doctor_registration_number = doc.doctor_registration_number;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        
    }
}