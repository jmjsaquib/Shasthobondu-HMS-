using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private Entities _entities;

        public AdmissionRepository()
        {
            this._entities = new Entities();
        }

        public object GetAllAdmission()
        {
            //return (from adm in _entities.admissions
            //        where 
            //        join dep in _entities.departments on adm.department_id equals dep.department_id
            //        join war in _entities.wards on adm.ward_id equals war.floor_id into wardTable
            //        from subWar in wardTable.DefaultIfEmpty()
            //        join pat in _entities.patients on adm.patient_id equals pat.patient_id
            //        join emp in _entities.employees on adm.reffered_by equals emp.employee_id
            //        join rm in _entities.rooms on adm.room_id equals rm.room_id into RmTable
            //        from subRoom in RmTable.DefaultIfEmpty()
            //        join press in _entities.presscriptions on adm.presscription_id equals press.prescription_id
            //        select new
            //        {
            //            admission_id = adm.admission_id,
            //            admission_date = adm.admission_date,
            //            patient_id = adm.patient_id,
            //            patient_name = pat.full_name,
            //            reffered_by = adm.reffered_by,
            //            doctor_name = emp.employee_name,
            //            department_id = adm.department_id,
            //            department_name = dep.department_name,
            //            ward_id = adm.ward_id,
            //            ward_no = subWar.ward_no,
            //            ward_name = subWar.ward_name,
            //            room_id = adm.room_id,
            //            room_no = subRoom.room_no,
            //            bed_id = adm.bed_id,
            //            status = pat.status,
            //            bed_status=adm.bed_status
            //        }).ToList().OrderByDescending(a => a.admission_id);

            try
            {
                return (from press in _entities.presscriptions
                    join pat in _entities.patients on press.patient_id equals pat.patient_id
                    join appo in _entities.appoinments on press.appoinment_id equals appo.appoinment_id
                    join dep in _entities.departments on appo.department_id equals dep.department_id
                    join doc in _entities.doctors on appo.doctor_id equals doc.doctor_id
                    join emp in _entities.employees on doc.employee_id equals emp.employee_id
                        where pat.status == "presscribed" && press.need_admission == "yes" 
                    select new
                    {
                        prescription_id = press.prescription_id,
                        presscription_date=press.presscription_date,
                        patient_id = press.patient_id,
                        patient_name = pat.full_name,
                        department_id = appo.department_id,
                        department_name = dep.department_name,
                        doctor_name=emp.employee_name
                    }).ToList().OrderByDescending(p => p.prescription_id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object addmissionId(int addmissionId)
        {
            try
            {
                return (from adm in _entities.admissions
                        where adm.admission_id==addmissionId
                        join dep in _entities.departments on adm.department_id equals dep.department_id
                        join war in _entities.wards on adm.ward_id equals war.floor_id into wardTable
                        from subWar in wardTable.DefaultIfEmpty()
                        join pat in _entities.patients on adm.patient_id equals pat.patient_id
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                        from subMed in medTable.DefaultIfEmpty()
                        join emr in _entities.patient_emergency_contact on pat.patient_id equals emr.patient_id into EmerTable
                        from subEmr in EmerTable.DefaultIfEmpty()
                        join emp in _entities.employees on adm.reffered_by equals emp.employee_id
                        join rm in _entities.rooms on adm.room_id equals rm.room_id into RmTable
                        from subRoom in RmTable.DefaultIfEmpty()
                        join rmType in _entities.room_type on subRoom.room_type_id equals rmType.room_type_id into rmTypeTable
                        from subRmType in rmTypeTable.DefaultIfEmpty()
                        join press in _entities.presscriptions on adm.presscription_id equals press.prescription_id
                        select new
                        {
                            admission_id = adm.admission_id,
                            admission_date = adm.admission_date,
                            patient_id = adm.patient_id,
                            reffered_by = adm.reffered_by,
                            daily_cost=adm.daily_cost??0.0m,
                            doctor_name = emp.employee_name,
                            ward_id = adm.ward_id,
                            ward_no = subWar.ward_no,
                            ward_name = subWar.ward_name,
                            bed_cost=subWar.bed_cost,
                            room_id = adm.room_id,
                            room_no = subRoom.room_no,
                            cabin_rent = subRmType.rent,
                            bed_id = adm.bed_id,
                            received_by = adm.received_by,
                            received_date = adm.received_date,
                            received_time = adm.received_time,
                            full_name = pat.full_name,
                            email = pat.email,
                            address = pat.address,
                            status = pat.status,
                            division_id = pat.division_id,
                            district_id = pat.district_id,
                            dob = pat.dob,
                            zip_code = pat.zip_code,
                            phone = pat.phone,
                            nid_id = pat.nid_id,
                            gender = pat.gender,
                            blood_group = subMed.blood_group,
                            blood_pressure = subMed.blood_pressure,
                            height = subMed.height,
                            weight = subMed.weight,
                            age = subMed.age,
                            contact_person_name = subEmr.contact_person_name,
                            relation = subEmr.relation,
                            contact_person_mobile = subEmr.contact_person_mobile,
                            prescription_id = adm.presscription_id,
                            presscription_date = press.presscription_date,
                            department_id = dep.department_id,
                            department_name = dep.department_name
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
                var flag = false;
                if (admission.ward_id !=null)
                {
                    var check =
                    _entities.admissions.FirstOrDefault(
                        a => a.ward_id == admission.ward_id && a.bed_id == admission.bed_id && a.bed_status == "assigned");
                    if (check == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }else if (admission.room_id !=null)
                {
                    var check =
                    _entities.admissions.FirstOrDefault(
                        a => a.room_id == admission.room_id && a.bed_id == admission.bed_id && a.bed_status == "assigned");
                    if (check == null)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag==true)
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
                var dailyCost=0m;
                if (admission.room_id != null)
                {
                    var data = (from rm in _entities.rooms
                        where rm.room_id == admission.room_id
                        join rmtype in _entities.room_type on rm.room_type_id equals rmtype.room_type_id
                        select new
                        {
                            rent=rmtype.rent,
                            no_of_bed=rm.no_of_bed??0
                        }).FirstOrDefault();
                    if (admission.bed_id == 0)
                    {
                        dailyCost = (data.rent*(data.no_of_bed)) ?? 0.0m;
                    }
                    else
                    {
                        dailyCost = data.rent ?? 0m;
                    }

                }else if (admission.ward_id != null)
                {
                    var data = _entities.wards.FirstOrDefault(a => a.ward_id == admission.ward_id);
                    dailyCost = data.bed_cost ?? 0m;
                }
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
                    received_time = admission.received_time,
                    bed_status = "assigned",
                    daily_cost = dailyCost,
                    payment_status = "due"
                };
                _entities.admissions.Add(ad);
                _entities.SaveChanges();

                var patientdata = _entities.patients.FirstOrDefault(p => p.patient_id == admission.patient_id);
                patientdata.status = "admitted";
                _entities.SaveChanges();

                if (admission.ward_id != null)
                {
                    var data = _entities.wards.FirstOrDefault(w => w.ward_id == admission.ward_id);
                    data.assign_bed += 1;
                    data.rest_bed = data.total_bed - data.assign_bed;
                    if (data.rest_bed == 0)
                    {
                        data.ward_status = "full";
                    }
                    _entities.SaveChanges();
                }
                else if (admission.room_id != null)
                {
                    var data = _entities.rooms.FirstOrDefault(r => r.room_id == admission.room_id);
                    if (admission.bed_id == 0 || data.room_rest_bed <= 1)
                    {
                        data.status = "full";
                        data.room_rest_bed = 0;
                        data.room_assign_bed = data.no_of_bed;
                        _entities.SaveChanges();
                    }
                    else
                    {
                        data.room_assign_bed += 1;
                        data.room_rest_bed = data.no_of_bed - data.room_assign_bed;
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


        public object GetAdmissionByWardId(int wardId)
        {
            return _entities.admissions.Where(a => a.ward_id == wardId && a.bed_status == "assigned").ToList().OrderBy(a => a.bed_id);
        }

        public object GetAdmissionByRoomId(int roomid)
        {
            return _entities.admissions.Where(a => a.room_id == roomid && a.bed_status == "assigned").ToList().OrderBy(a => a.bed_id);
        }
    }
}