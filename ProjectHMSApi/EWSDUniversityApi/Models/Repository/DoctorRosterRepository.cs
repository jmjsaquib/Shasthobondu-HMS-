using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DoctorRosterRepository:IDoctorRosterRepository
    {
        private Entities _entities;

        public DoctorRosterRepository()
        {
            this._entities=new Entities();
        }


        public object GetAllRoster()
        {
            try
            {
                return (from ros in _entities.doctor_roster
                    join doc in _entities.doctors on ros.doctor_id equals doc.doctor_id
                    join emp in _entities.employees on doc.employee_id equals emp.employee_id
                    join dep in _entities.departments on ros.department_id equals dep.department_id
                    select new 
                    {
                        doctor_roster_id=ros.doctor_roster_id,
                        doctor_id=ros.doctor_id,
                        department_id = ros.department_id,
                        color_id=dep.color_id,
                        description = ros.Description,
                        title = ros.Title,
                        end = ros.End,
                        isAllDay = ros.IsAllDay,
                        recurrenceException = ros.RecurrenceException,
                        recurrenceId = ros.RecurrenceID ,
                        recurrenceRule = ros.RecurrenceRule,
                        start = ros.Start,
                        doctor_name=emp.employee_name,
                        department_name=dep.department_name
                    }).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object GetAllRosterByDepartmentId(int deparmentId)
        {
            try
            {
                return (from ros in _entities.doctor_roster
                        join doc in _entities.doctors on ros.doctor_id equals doc.doctor_id
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id
                        join dep in _entities.departments on ros.department_id equals dep.department_id
                        where dep.department_id==deparmentId
                        select new
                        {
                            doctor_roster_id = ros.doctor_roster_id,
                            doctor_id = ros.doctor_id,
                            department_id = ros.department_id,
                            description = ros.Description,
                            title = ros.Title,
                            end = ros.End,
                            isAllDay = ros.IsAllDay,
                            recurrenceException = ros.RecurrenceException,
                            recurrenceId = ros.RecurrenceID,
                            recurrenceRule = ros.RecurrenceRule,
                            start = ros.Start,
                            doctor_name = emp.employee_name,
                            department_name = dep.department_name,
                            color_id = dep.color_id,
                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetAllRosterByDoctorId(int doctorId)
        {
            try
            {
                return (from ros in _entities.doctor_roster
                        join doc in _entities.doctors on ros.doctor_id equals doc.doctor_id
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id
                        join dep in _entities.departments on ros.department_id equals dep.department_id
                        where doc.doctor_id==doctorId
                        select new
                        {
                            doctor_roster_id = ros.doctor_roster_id,
                            doctor_id = ros.doctor_id,
                            department_id = ros.department_id,
                            description = ros.Description,
                            title = ros.Title,
                            end = ros.End,
                            isAllDay = ros.IsAllDay,
                            recurrenceException = ros.RecurrenceException,
                            recurrenceId = ros.RecurrenceException,
                            recurrenceRule = ros.RecurrenceException,
                            start = ros.Start,
                            doctor_name = emp.employee_name,
                            department_name = dep.department_name,
                            color_id = dep.color_id,
                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckDuplicateForRosterName(doctor_roster odDoctorRoster)
        {
            try
            {
                var data = _entities.doctor_roster.Where(d=>d.Title==odDoctorRoster.Title && d.department_id==odDoctorRoster.department_id && d.Start==odDoctorRoster.Start && d.End==odDoctorRoster.End);
                if (data == null)
                {
                    return true;
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

        public bool InsertRoster(doctor_roster odDoctorRoster)
        {
            try
            {
                doctor_roster roster = new doctor_roster
                {
                    doctor_id = odDoctorRoster.doctor_id,
                    department_id = odDoctorRoster.department_id,
                    Title = odDoctorRoster.Title,
                    Description = odDoctorRoster.Description,
                    End = odDoctorRoster.End,
                    IsAllDay = odDoctorRoster.IsAllDay,
                    RecurrenceException = odDoctorRoster.RecurrenceException,
                    RecurrenceID = odDoctorRoster.RecurrenceID,
                    RecurrenceRule = odDoctorRoster.RecurrenceRule,
                    Start = odDoctorRoster.Start
                };
                _entities.doctor_roster.Add(roster);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateRoster(doctor_roster odDoctorRoster)
        {
            try
            {
                doctor_roster data =
                    _entities.doctor_roster.FirstOrDefault(d => d.doctor_roster_id == odDoctorRoster.doctor_roster_id);
                data.Description = odDoctorRoster.Description;
                data.End = odDoctorRoster.End;
                data.IsAllDay = odDoctorRoster.IsAllDay;
                data.RecurrenceException = odDoctorRoster.RecurrenceException;
                data.RecurrenceID = odDoctorRoster.RecurrenceID;
                data.RecurrenceRule = odDoctorRoster.RecurrenceRule;
                data.Start = odDoctorRoster.Start;
                data.Title = odDoctorRoster.Title;
                data.doctor_id = odDoctorRoster.doctor_id;
                data.department_id = odDoctorRoster.department_id;

                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteRoster(int p)
        {
            try
            {
                var data =
                   _entities.doctor_roster.FirstOrDefault(d => d.doctor_roster_id == p);
                _entities.doctor_roster.Attach(data);
                _entities.doctor_roster.Remove(data);
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