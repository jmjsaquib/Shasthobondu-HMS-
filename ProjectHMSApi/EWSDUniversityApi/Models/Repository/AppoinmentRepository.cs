using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.WebPages;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class AppoinmentRepository:IAppoinmentRepository
    {
        private Entities _entities;

        public AppoinmentRepository()
        {
            this._entities=new Entities();
        }
        public object GetAllAppoinment()
        {
            try
            {
                return (from pat in _entities.patients
                        where pat.status=="entry"
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                        from subMed in medTable.DefaultIfEmpty()
                        select new GetAllpatientModel
                        {
                            patient_id = pat.patient_id,
                            full_name = pat.full_name,
                            gender = pat.gender,
                            blood_group = subMed.blood_group,
                            dob = pat.dob,
                            status = pat.status,

                        }).ToList().OrderByDescending(p => p.patient_id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public object AppoinmentListForDoctor(int doctorId)
        {
            return (from appo in _entities.appoinments
                where appo.doctor_id == doctorId
                select new
                {
                    appoinment_date=appo.appoinment_date,
                    appoinment_serial=appo.appoinment_serial,

                }).ToList();
        }

        public object Delete(int appoinmentId)
        {
            throw new NotImplementedException();
        }

        public object insert(StronglyType.AppoinmentValidationModel appo)
        {
            try
            {
                appoinment appoinment = new appoinment
                {
                    patient_id = appo.patient_id,
                    doctor_id = appo.doctor_id,
                    department_id = appo.department_id,
                    appoinment_date = DateTime.Parse(appo.appoinment_date),
                    appoinment_time = appo.appoinment_time,
                    purpose = appo.purpose,
                    patient_type = appo.patient_type,
                    appoinment_type = appo.appoinment_type,
                    appoinment_serial = appo.appoinment_serial


                };
                _entities.appoinments.Add(appoinment);
                _entities.SaveChanges();

                var patientInfo = _entities.patients.FirstOrDefault(p => p.patient_id == appo.patient_id);
                patientInfo.status = "appoinmented";
                _entities.SaveChanges();
                var id = _entities.appoinments.Max(a => a.appoinment_id);
                var returnData = _entities.appoinments.FirstOrDefault(a => a.appoinment_id == id);
                return returnData;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public object AppoinmentValiadationForDoctor(int doctorId, string today)
        {
            try
            {
                //return (from appo in _entities.appoinments
                //        where appo.doctor_id == doctorId && appo.appoinment_date >= DateTime.Parse(today)
                //        group appo.appoinment_serial by new
                //        {
                //            appo.appoinment_date,
                //            appo.appoinment_serial
                //        } into appoTable
                //        select new
                //        {
                //            appoinment_date = appoTable.Key.appoinment_date,
                //            appoinment_serial = appoTable.Key.appoinment_serial ?? 0,
                //            count = appoTable.Count()

                //        }).ToList();
                var data= "select appoinment_date,COUNT(appoinment_id) as 'Count',appoinment_serial "
                      + " from appoinment where doctor_id="+doctorId +" AND appoinment_date >='"+today
                      + "' GROUP BY appoinment_date"
                      + " ORDER BY (appoinment_date)";

                var appoinementData = _entities.Database.SqlQuery<AppoinmentValidationModel>(data).ToList().DefaultIfEmpty();
                return appoinementData;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }



        public object AppoinmentListForDoctor(int doctorId, string expectedDate)
        {
            try
            {
                var data = "select * "
                      + " from appoinment as appo where appo.doctor_id=" + doctorId + " AND appo.appoinment_date ='" + expectedDate
                      + "' ORDER BY appo.appoinment_serial";

                var appoinementSerialData = _entities.Database.SqlQuery<AppoinmentValidationModel>(data).ToList().DefaultIfEmpty();
                return appoinementSerialData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}