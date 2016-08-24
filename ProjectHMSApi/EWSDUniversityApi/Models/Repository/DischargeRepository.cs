using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class DischargeRepository:IDischargeRepository
    {
        private Entities _entities;

        public DischargeRepository()
        {
            this._entities = new Entities();
        }


        public object GetAllDischarge()
        {
            return (from dis in _entities.discharges
                join adm in _entities.admissions on dis.admission_id equals adm.admission_id
                join pat in _entities.patients on dis.patient_id equals pat.patient_id
                join dep in _entities.departments on dis.department_id equals dep.department_id
                join disType in _entities.discharge_type on dis.discharge_type_id equals disType.discharge_type_id
                join emp in _entities.employees on dis.discharge_by_id equals emp.employee_id into EmpTable
                from subEmp in EmpTable.DefaultIfEmpty()
                select new
                {
                    discharge_id=dis.discharge_id,
                    patient_id=dis.patient_id,
                    admission_id=dis.admission_id,
                    patient_name=pat.full_name,
                    discharge_date=dis.discharge_date,
                    discharge_by = subEmp.employee_name,
                    department_id=dep.department_id,
                    discharge_by_id=dis.discharge_by_id,
                    department_name=dep.department_name,
                    admission_date=adm.admission_date,
                    discharge_type_id=dis.discharge_type_id,
                    discharge_type_name=disType.discharge_type_name,
                    status = pat.status

                }).ToList().OrderByDescending(d=>d.discharge_id);
        }

        public object GetDischarById(int dischargeId)
        {
            return (from dis in _entities.discharges
                    join adm in _entities.admissions on dis.admission_id equals adm.admission_id
                    join pat in _entities.patients on dis.patient_id equals pat.patient_id
                    join dep in _entities.departments on dis.department_id equals dep.department_id
                    join disType in _entities.discharge_type on dis.discharge_type_id equals disType.discharge_type_id
                    join emp in _entities.employees on dis.discharge_by_id equals emp.employee_id into EmpTable
                    from subEmp in EmpTable.DefaultIfEmpty()
                    select new
                    {
                        discharge_id = dis.discharge_id,
                        patient_id = dis.patient_id,
                        patient_name = pat.full_name,
                        discharge_date = dis.discharge_date,
                        advice_on_discharge = dis.advice_on_discharge,
                        condition_during_discharge = dis.condition_during_discharge,
                        discharge_by = subEmp.employee_name,
                        department_name = dep.department_name,
                        discharge_type_id = dis.discharge_type_id,
                        discharge_type_name = disType.discharge_type_name

                    }).FirstOrDefault();
        }

        public bool InsertDischarge(StronglyType.DischargeModel discharge)
        {
            try
            {
                Models.discharge dis = new discharge
                {
                    patient_id = discharge.patient_id,
                    admission_id = discharge.admission_id,
                    discharge_date = discharge.discharge_date,
                    discharge_type_id = discharge.discharge_type_id,
                    advice_on_discharge = discharge.advice_on_discharge,
                    condition_during_discharge = discharge.condition_during_discharge,
                    discharge_by_id = discharge.discharge_by_id,
                    department_id=discharge.department_id
                };
                _entities.discharges.Add(dis);
                _entities.SaveChanges();

                int maxid = _entities.discharges.Max(d => d.discharge_id);
                if (discharge.medicine !=null)
                {
                    foreach (var item in discharge.medicine)
                    {
                        discharge_medicine_mapping map = new discharge_medicine_mapping
                        {
                            discharge_id = maxid,
                            medicine_id = item.medicine_id,
                            medicine_power = item.medicine_power,
                            dosage = item.dosage,
                            route_of_administration = item.route_of_administration,
                            rules = item.rules,
                            how_long = item.how_long
                        };
                        _entities.discharge_medicine_mapping.Add(map);
                        _entities.SaveChanges();
                    }
                }
                //release the bed of word / cabin
                var releasedata = _entities.admissions.FirstOrDefault(a => a.admission_id == discharge.admission_id);

                if (releasedata.room_id!=null)
                {
                    releasedata.bed_status = "blank";
                    var data = _entities.rooms.FirstOrDefault(w => w.room_id == releasedata.room_id);
                    data.room_assign_bed -= 1;
                    data.room_rest_bed = data.no_of_bed - data.room_assign_bed;
                    if (data.status=="full")
                    {
                        data.status = "Waiting";
                    }
                    _entities.SaveChanges();

                }else if (releasedata.ward_id != null)
                {
                    releasedata.bed_status = "blank";
                    var data = _entities.wards.FirstOrDefault(w => w.ward_id == releasedata.ward_id);
                    data.assign_bed -= 1;
                    data.rest_bed = data.total_bed - data.assign_bed;
                    if (data.ward_status=="full")
                    {
                        data.ward_status = "waiting";
                    }
                    _entities.SaveChanges();
                }

                var patientdata = _entities.patients.FirstOrDefault(p => p.patient_id == discharge.patient_id);
                patientdata.status = "discharged";
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDischarge(discharge_type discharge)
        {
            throw new NotImplementedException();
        }
    }
}