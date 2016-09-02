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
            return _entities.appoinments.ToList();
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

        public bool insert(appoinment appo)
        {
            try
            {
                appoinment appoinment = new appoinment
                {
                    patient_id = appo.patient_id,
                    doctor_id = appo.doctor_id,
                    department_id = appo.department_id,
                    appoinment_date = appo.appoinment_date,
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
                return true;
            }
            catch (Exception)
            {

                return false;
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