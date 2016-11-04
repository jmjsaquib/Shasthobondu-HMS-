using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DoctorSchedularRepository:IDoctorSchedularRepository
    {
        private Entities _entities;

        public DoctorSchedularRepository()
        {
            this._entities=new Entities();
        }


        public object GetAllSchedular()
        {
            try
            {
                return (from docSche in _entities.doctor_schedule
                    join shift in _entities.shift_type on docSche.shif_type_id equals shift.shift_type_id
                    select new 
                    {
                        doctor_schdule_id = docSche.doctor_schdule_id,
                        doctor_id = docSche.doctor_id,
                        department_id = docSche.department_id,
                        fri = docSche.fri,
                        shif_type_id = docSche.shif_type_id,
                        mon = docSche.mon,
                        sat = docSche.sat,
                        sun = docSche.sun,
                        thurs = docSche.thurs,
                        tues = docSche.tues,
                        wed = docSche.wed,
                        shift_type_name=shift.shift_type_name

                    }).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object GetAllSchedularDepartmentid(int deparmentId)
        {
            try
            {
                return (from docSche in _entities.doctor_schedule
                        where docSche.department_id==deparmentId
                        join shift in _entities.shift_type on docSche.shif_type_id equals shift.shift_type_id
                        join doc in _entities.doctors on docSche.doctor_id equals doc.doctor_id
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id    
                        
                        select new
                        {
                            doctor_schdule_id = docSche.doctor_schdule_id,
                            doctor_id = docSche.doctor_id,
                            department_id = docSche.department_id,
                            fri = docSche.fri??"no",
                            shif_type_id = docSche.shif_type_id,
                            mon = docSche.mon ?? "no",
                            sat = docSche.sat ?? "no",
                            sun = docSche.sun ?? "no",
                            thurs = docSche.thurs ?? "no",
                            tues = docSche.tues ?? "no",
                            wed = docSche.wed ?? "no",
                            shift_type_name = shift.shift_type_name,
                            employee_name=emp.employee_name,
                            shift_from=shift.shift_from,
                            shift_to=shift.shift_to

                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetAllSchedularByDoctorId(int doctorId)
        {
            try
            {
                return (from docSche in _entities.doctor_schedule
                        where docSche.doctor_id==doctorId
                        join shift in _entities.shift_type on docSche.shif_type_id equals shift.shift_type_id
                        select new
                        {
                            doctor_schdule_id = docSche.doctor_schdule_id,
                            doctor_id = docSche.doctor_id,
                            department_id = docSche.department_id,
                            fri = docSche.fri,
                            shif_type_id = docSche.shif_type_id,
                            mon = docSche.mon,
                            sat = docSche.sat,
                            sun = docSche.sun,
                            thurs = docSche.thurs,
                            tues = docSche.tues,
                            wed = docSche.wed,
                            shift_type_name = shift.shift_type_name

                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InsertSchedule(StronglyType.RosterDetailsListModel rosterDetailsList)
        {
            try
            {
                List<doctor_schedule> dataCheck = new List<doctor_schedule>();
                int departmentId=0;
                int doctorid=0;
                foreach (var item in rosterDetailsList.rosterDetailsList)
                {
                    departmentId = item.department_id??0;
                    doctorid = item.doctor_id??0;
                    break;
                }
                dataCheck =
                    _entities.doctor_schedule.Where(d => d.department_id == departmentId && d.doctor_id == doctorid)
                        .ToList();
                if (dataCheck.Count > 1)
                {
                    foreach (var item in dataCheck)
                    {
                        foreach (var inputitem in rosterDetailsList.rosterDetailsList)
                        {
                            if (item.doctor_schdule_id == inputitem.doctor_schdule_id)
                            {
                                var data =
                            _entities.doctor_schedule.FirstOrDefault(
                                d => d.doctor_schdule_id == item.doctor_schdule_id);
                                data.sat = inputitem.sat;
                                data.sun = inputitem.sun;
                                data.mon = inputitem.mon;
                                data.tues = inputitem.tues;
                                data.wed = inputitem.wed;
                                data.thurs = inputitem.thurs;
                                data.fri = inputitem.fri;
                                _entities.SaveChanges();
                            }
                        }
                        //var remove =
                        //    _entities.doctor_schedule.FirstOrDefault(
                        //        d => d.doctor_schdule_id == item.doctor_schdule_id);
                        //_entities.doctor_schedule.Attach(remove);
                        //_entities.doctor_schedule.Remove(remove);
                        //_entities.SaveChanges();
                    }
                }
                else
                {
                    foreach (var item in rosterDetailsList.rosterDetailsList)
                    {
                        doctor_schedule sug = new doctor_schedule
                        {
                            shif_type_id = item.shif_type_id,
                            doctor_id = item.doctor_id,
                            department_id = item.department_id,
                            sat = item.sat,
                            sun = item.sun,
                            mon = item.mon,
                            tues = item.tues,
                            wed = item.wed,
                            thurs = item.thurs,
                            fri = item.fri


                        };
                        _entities.doctor_schedule.Add(sug);
                        _entities.SaveChanges();
                    }
                }
                
                
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool UpdateSchedule(doctor_schedule doctorSchedule)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoster(int p)
        {
            throw new NotImplementedException();
        }


        public object GetAllSchedularBydeparmentDoctorId(int departmentId, int doctorId, int hospital_id)
        {
            try
            {
                 var data=new object();
                var dataCheck = _entities.doctor_schedule.Where(d => d.department_id == departmentId && d.doctor_id == doctorId).ToArray();
                if (dataCheck.Length==0)
                {
                    data=(from shift in _entities.shift_type
                          where shift.hospital_id==hospital_id
                            select new
                            {
                                fri = "no",
                                shif_type_id = shift.shift_type_id,
                                mon = "no",
                                sat = "no",
                                sun = "no",
                                thurs ="no",
                                tues = "no",
                                wed = "no",
                                shift_type_name = shift.shift_type_name

                            }).ToList();
                }
                else
                {
                    data=(from docSche in _entities.doctor_schedule
                            
                            join shift in _entities.shift_type on docSche.shif_type_id equals shift.shift_type_id
                          where docSche.department_id == departmentId && docSche.doctor_id == doctorId && shift.hospital_id==hospital_id
                            select new
                            {
                                doctor_schdule_id = docSche.doctor_schdule_id,
                                doctor_id = docSche.doctor_id,
                                department_id = docSche.department_id,
                                fri = docSche.fri ?? "no",
                                shif_type_id = docSche.shif_type_id,
                                mon = docSche.mon ?? "no",
                                sat = docSche.sat ?? "no",
                                sun = docSche.sun ?? "no",
                                thurs = docSche.thurs ?? "no",
                                tues = docSche.tues ?? "no",
                                wed = docSche.wed ?? "no",
                                shift_type_name = shift.shift_type_name

                            }).ToList();
                }
                return data;



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}