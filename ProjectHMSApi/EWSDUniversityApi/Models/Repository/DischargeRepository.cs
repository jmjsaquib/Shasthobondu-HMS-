using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

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
            return (from adm in _entities.admissions
                    where adm.payment_status == "confirmed"
                    join dep in _entities.departments on adm.department_id equals dep.department_id
                    join war in _entities.wards on adm.ward_id equals war.floor_id into wardTable     
                    from subWar in wardTable.DefaultIfEmpty()
                    join rm in _entities.rooms on adm.room_id equals rm.room_id into RmTable
                    from subRoom in RmTable.DefaultIfEmpty()
                    join pat in _entities.patients on adm.patient_id equals pat.patient_id
                    join pay in _entities.payments on adm.admission_id equals pay.admission_id into payTable
                    from subPay in payTable.DefaultIfEmpty()
                    select new
                    {
                        admission_id = adm.admission_id,
                        admission_date = adm.admission_date,
                        patient_id = adm.patient_id,
                        patient_name = pat.full_name,
                        department_id = adm.department_id,
                        department_name = dep.department_name,
                        payment_status = adm.payment_status,
                        payment_id=subPay.payment_id,
                        payment_date=(subPay.payment_date),
                        ward_id = adm.ward_id??0,
                        ward_no = subWar.ward_no??"N/A",
                        ward_name = subWar.ward_name ?? "N/A",
                        room_id = adm.room_id??0,
                        room_no = subRoom.room_no ?? "N/A",
                        bed_id = adm.bed_id,
                    }).ToList().OrderByDescending(a=>a.admission_id);
        }
        public object GetAllDischargeByDepartmentId(int departmentId)
        {
            try
            {
                return (from adm in _entities.admissions
                        where adm.payment_status == "confirmed" && adm.department_id==departmentId
                        join dep in _entities.departments on adm.department_id equals dep.department_id
                        join war in _entities.wards on adm.ward_id equals war.floor_id into wardTable
                        from subWar in wardTable.DefaultIfEmpty()
                        join rm in _entities.rooms on adm.room_id equals rm.room_id into RmTable
                        from subRoom in RmTable.DefaultIfEmpty()
                        join pat in _entities.patients on adm.patient_id equals pat.patient_id
                        join pay in _entities.payments on adm.admission_id equals pay.admission_id into payTable
                        from subPay in payTable.DefaultIfEmpty()
                        select new
                        {
                            admission_id = adm.admission_id,
                            admission_date = adm.admission_date,
                            patient_id = adm.patient_id,
                            patient_name = pat.full_name,
                            department_id = adm.department_id,
                            department_name = dep.department_name,
                            payment_status = adm.payment_status,
                            payment_id = subPay.payment_id,
                            payment_date = (subPay.payment_date),
                            ward_id = adm.ward_id ?? 0,
                            ward_no = subWar.ward_no ?? "N/A",
                            ward_name = subWar.ward_name ?? "N/A",
                            room_id = adm.room_id ?? 0,
                            room_no = subRoom.room_no ?? "N/A",
                            bed_id = adm.bed_id,
                        }).ToList().OrderByDescending(a => a.admission_id);
            }
            catch (Exception)
            {
                    
                throw;
            }
        }
        public object GetDischarById(int dischargeId)
        {
            return (from dis in _entities.discharges
                    where dis.discharge_id==dischargeId
                    join adm in _entities.admissions on dis.admission_id equals adm.admission_id
                    join pat in _entities.patients on dis.patient_id equals pat.patient_id
                    join dep in _entities.departments on dis.department_id equals dep.department_id
                    join disType in _entities.discharge_type on dis.discharge_type_id equals disType.discharge_type_id
                    join doc in _entities.doctors on dis.discharge_by_id equals doc.doctor_id
                    join emp in _entities.employees on doc.employee_id equals emp.employee_id into EmpTable
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

                var tempDischargeData = _entities.discharges.FirstOrDefault(d => d.admission_id == discharge.admission_id);
                if (tempDischargeData != null)
                {
                    tempDischargeData.discharge_type_id = discharge.discharge_type_id;
                    tempDischargeData.advice_on_discharge = discharge.advice_on_discharge;
                    tempDischargeData.condition_during_discharge = discharge.condition_during_discharge;
                    tempDischargeData.discharge_by_id = discharge.discharge_by_id;
                    tempDischargeData.department_id = discharge.department_id;
                    tempDischargeData.patient_id = discharge.patient_id;

                    _entities.SaveChanges();

                    if (discharge.medicine != null)
                    {
                        foreach (var item in discharge.medicine)
                        {
                            discharge_medicine_mapping map = new discharge_medicine_mapping
                            {
                                discharge_id = tempDischargeData.discharge_id,
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

                    if (releasedata.room_id != null)
                    {
                        releasedata.bed_status = "blank";
                        var data = _entities.rooms.FirstOrDefault(w => w.room_id == releasedata.room_id);
                        data.room_assign_bed -= 1;
                        data.room_rest_bed = data.no_of_bed - data.room_assign_bed;
                        if (data.status == "full")
                        {
                            data.status = "Waiting";
                        }
                        _entities.SaveChanges();

                    }
                    else if (releasedata.ward_id != null)
                    {
                        releasedata.bed_status = "blank";
                        var data = _entities.wards.FirstOrDefault(w => w.ward_id == releasedata.ward_id);
                        data.assign_bed -= 1;
                        data.rest_bed = data.total_bed - data.assign_bed;
                        if (data.ward_status == "full")
                        {
                            data.ward_status = "waiting";
                        }
                        _entities.SaveChanges();
                    }
                    var checkDischarge =
                        _entities.discharge_type.FirstOrDefault(d => d.discharge_type_id == discharge.discharge_type_id);
                    if (checkDischarge.discharge_type_name.Contains("Death"))
                    {
                        var patientdata = _entities.patients.FirstOrDefault(p => p.patient_id == discharge.patient_id);
                        patientdata.status = "Death";
                        _entities.SaveChanges();
                        return true;
                    }
                    else
                    {
                        var patientdata = _entities.patients.FirstOrDefault(p => p.patient_id == discharge.patient_id);
                        patientdata.status = "entry";
                        _entities.SaveChanges();
                        return true;
                    }
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

        public bool UpdateDischarge(discharge_type discharge)
        {
            throw new NotImplementedException();
        }


       
    }
}