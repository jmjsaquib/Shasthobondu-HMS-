using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

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
        public object AppoinmentListForDoctor(int employeeId)
        {
            throw new NotImplementedException();
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


        
    }
}