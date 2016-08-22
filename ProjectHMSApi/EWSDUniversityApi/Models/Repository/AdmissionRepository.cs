using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class AdmissionRepository:IAdmissionRepository
    {
        private Entities _entities;

        public AdmissionRepository()
        {
            this._entities = new Entities();
        }

        public object GetAllAdmission()
        {
            return (from adm in _entities.admissions
                join dep in _entities.departments on adm.department_id equals dep.department_id
                join war in _entities.wards on adm.ward_id equals war.floor_id into wardTable
                from subWar in wardTable.DefaultIfEmpty()
                join pat in _entities.patients on adm.patient_id equals pat.patient_id
                join emp in _entities.employees on adm.reffered_by equals emp.employee_id
                join rm in _entities.rooms on adm.room_id equals rm.room_id into RmTable
                from subRoom in RmTable.DefaultIfEmpty()
                join press in _entities.presscriptions on adm.presscription_id equals press.prescription_id
                select new
                {
                    admission_id=adm.admission_id,
                    admission_date=adm.admission_date,
                    patient_id=adm.patient_id,
                    patient_name=pat.full_name,
                    reffered_by=adm.reffered_by,
                    doctor_name=emp.employee_name,
                    department_id=adm.department_id,
                    department_name=dep.department_name,
                    ward_id=adm.ward_id,
                    ward_no=subWar.ward_no,
                    ward_name=subWar.ward_name,
                    room_id=adm.room_id,
                    room_no=subRoom.room_no,
                    bed_id=adm.bed_id,
                    status=pat.status
                }).ToList().OrderByDescending(a=>a.admission_id);
        }

        public object addmissionId(int addmissionId)
        {
            try
            {
                return (from adm in _entities.admissions
                    join dep in _entities.departments on adm.department_id equals dep.department_id
                    join war in _entities.wards on adm.ward_id equals war.floor_id into wardTable
                    from subWar in wardTable.DefaultIfEmpty()
                    join pat in _entities.patients on adm.patient_id equals pat.patient_id
                    join emp in _entities.employees on adm.reffered_by equals emp.employee_id
                    join rm in _entities.rooms on adm.room_id equals rm.room_id into RmTable
                    from subRoom in RmTable.DefaultIfEmpty()
                    join press in _entities.presscriptions on adm.presscription_id equals press.prescription_id
                    select new
                    {
                        admission_id = adm.admission_id,
                        admission_date = adm.admission_date,
                        patient_id = adm.patient_id,
                        patient_name = pat.full_name,
                        reffered_by = adm.reffered_by,
                        doctor_name = emp.employee_name,
                        ward_id = adm.ward_id,
                        ward_no = subWar.ward_no,
                        ward_name = subWar.ward_name,
                        room_id = adm.room_id,
                        room_no = subRoom.room_no,
                        bed_id = adm.bed_id,
                        received_by=adm.received_by,
                        received_date=adm.received_date,
                        received_time=adm.received_time
                    }).FirstOrDefault();
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool CheckDuplicateForbed(admission admission)
        {
            try
            {
                var check =
                    _entities.admissions.FirstOrDefault(
                        a => a.ward_id == admission.ward_id && a.bed_id == admission.bed_id);
                if (check==null)
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

                return false;
            }
        }

        public bool InsertAdmission(admission admission)
        {
            try
            {
                admission ad = new admission
                {
                    patient_id = admission.patient_id,
                    admission_date = admission.admission_date,
                    reffered_by = admission.reffered_by,
                    department_id = admission.department_id,
                    ward_id = admission.ward_id,
                    room_id = admission.room_id,
                    received_by = admission.received_by,
                    received_date = admission.received_date,
                    presscription_id = admission.presscription_id,
                    bed_id = admission.bed_id,
                    received_time = admission.received_time
                };
                _entities.admissions.Add(ad);
                _entities.SaveChanges();

                var patientdata = _entities.patients.FirstOrDefault(p => p.patient_id == admission.patient_id);
                patientdata.status = "admitted";
                _entities.SaveChanges();

                if (admission.ward_id!=null)
                {
                    var data = _entities.wards.FirstOrDefault(w => w.ward_id == admission.ward_id);
                    data.assign_bed += 1;
                    data.rest_bed = data.rest_bed - data.assign_bed;
                    if (data.rest_bed==0)
                    {
                        data.ward_status = "full";
                    }
                    _entities.SaveChanges();
                }else if (admission.room_id != null)
                {
                    var data = _entities.rooms.FirstOrDefault(r => r.room_id == admission.room_id);
                    if (admission.bed_id==0 || data.room_rest_bed<=1)
                    {
                        data.status = "full";
                        data.room_rest_bed = 0;
                        data.room_assign_bed = data.no_of_bed;
                        _entities.SaveChanges();
                    }
                    else
                    {
                        data.room_assign_bed += 1;
                        data.room_rest_bed = data.room_rest_bed - data.room_assign_bed;
                        _entities.SaveChanges();
                    }
                   
                    
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}