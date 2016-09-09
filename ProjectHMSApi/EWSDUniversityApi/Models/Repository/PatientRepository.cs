using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;
using WebGrease.Css.Ast.MediaQuery;

namespace HMSDevelopmentApi.Models.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private Entities _entities;

        public PatientRepository()
        {
            this._entities=new Entities();
        }
        public object GetAllPatient()
        {
            try
            {
                return (from pat in _entities.patients

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

                        }).ToList().OrderBy(p => p.patient_id);


            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public object GetPatientById(int patientId)
        {
            try
            {
                return (from pat in _entities.patients
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into MedTable
                        from subMed in MedTable.DefaultIfEmpty()
                        join div in _entities.divisions on pat.division_id equals  div.division_id into DivTable
                        from subDiv in DivTable.DefaultIfEmpty()
                        join dis in _entities.districts on pat.district_id equals dis.district_id into DisTable
                        from subDis in DisTable.DefaultIfEmpty()
                        join emr in _entities.patient_emergency_contact on pat.patient_id equals  emr.patient_id into EmerTable
                        from subEmr in EmerTable.DefaultIfEmpty()

                        where pat.patient_id==patientId
                        select new
                        {
                            patient_id = pat.patient_id,
                            full_name = pat.full_name,
                            email=pat.email,
                            address=pat.address,
                            status=pat.status,
                            division_id=pat.division_id,
                            division_name=subDiv.division_name,
                            district_id=pat.district_id,
                            district_name=subDis.district_name,
                            zip_code=pat.zip_code,
                            phone=pat.phone,
                            nid_id=pat.nid_id,
                            gender = pat.gender,
                            blood_group = subMed.blood_group,
                            blood_pressure = subMed.blood_pressure,
                            height = subMed.height,
                            weight = subMed.weight,
                            age = subMed.age,
                            dob = pat.dob,
                            contact_person_name=subEmr.contact_person_name,
                            relation=subEmr.relation,
                            contact_person_mobile=subEmr.contact_person_mobile
                        }).FirstOrDefault();
            }
            catch (Exception)
            {
                    
                throw;
            }
        }

        public bool CheckDuplicateForpatientinfo(string user_name, string email)
        {
            try
            {
                var checkpateintUsername = _entities.patients.FirstOrDefault(p => p.user_name == user_name);
                var checkpatientemail = _entities.patients.FirstOrDefault(p => p.email == email);
                if (checkpatientemail !=null && checkpateintUsername!=null)
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
                    
                throw;
            }
        }

        public bool Insertpatient(StronglyType.PatientInformationModel pat)
        {
            try
            {
                patient p = new patient
                {
                    full_name = pat.Patient.full_name,
                    gender = pat.Patient.gender,
                    address = pat.Patient.address,
                    division_id = pat.Patient.division_id,
                    district_id = pat.Patient.district_id,
                    email = pat.Patient.email,
                    phone = pat.Patient.phone,
                    nid_id = pat.Patient.nid_id,
                    dob = pat.Patient.dob,
                    zip_code = pat.Patient.zip_code,
                    status = "entry",
                    role_type_id = 1
                    
                    
                };
                _entities.patients.Add(p);
                _entities.SaveChanges();

                int lastpatientId = _entities.patients.Max(pa => pa.patient_id);
                var emergencyData = new patient_emergency_contact
                {
                    patient_id = lastpatientId,
                    contact_person_name = pat.Emergency.contact_person_name,
                    contact_person_mobile = pat.Emergency.contact_person_mobile,
                    relation=pat.Emergency.relation
                };
                _entities.patient_emergency_contact.Add(emergencyData);
                patient_health_info healthInfo = new patient_health_info
                {
                    patient_id = lastpatientId,
                    blood_group = pat.HealthInfos.blood_group,
                    age =pat.HealthInfos.age,
                    height = pat.HealthInfos.height,
                    weight = pat.HealthInfos.weight,
                    blood_pressure = pat.HealthInfos.blood_pressure

                };
                _entities.patient_health_info.Add(healthInfo);
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public bool Updatepatient(StronglyType.PatientInformationModel pat)
        {
            try
            {
                var patientPersonalInfo = _entities.patients.FirstOrDefault(p => p.patient_id == pat.Patient.patient_id);
                patientPersonalInfo.full_name = pat.Patient.full_name;
                patientPersonalInfo.address = pat.Patient.address;
                patientPersonalInfo.email = pat.Patient.email;
                patientPersonalInfo.division_id = pat.Patient.division_id;
                patientPersonalInfo.dob = pat.Patient.dob;
                patientPersonalInfo.district_id = pat.Patient.district_id;
                patientPersonalInfo.zip_code = pat.Patient.zip_code;
                patientPersonalInfo.gender = pat.Patient.gender;
                patientPersonalInfo.nid_id = pat.Patient.nid_id;
                patientPersonalInfo.phone = pat.Patient.phone;
                _entities.SaveChanges();

                var patientHealinfo =
                    _entities.patient_health_info.FirstOrDefault(h => h.patient_id == pat.Patient.patient_id);
                patientHealinfo.age = pat.HealthInfos.age;
                patientHealinfo.blood_group = pat.HealthInfos.blood_group;
                patientHealinfo.blood_pressure = pat.HealthInfos.blood_pressure;
                patientHealinfo.height = pat.HealthInfos.height;
                patientHealinfo.weight = pat.HealthInfos.weight;
                _entities.SaveChanges();

                var emergencyContact =
                    _entities.patient_emergency_contact.FirstOrDefault(e => e.patient_id == pat.Patient.patient_id);
                emergencyContact.contact_person_mobile = pat.Emergency.contact_person_mobile;
                emergencyContact.contact_person_name = pat.Emergency.contact_person_name;
                emergencyContact.relation = pat.Emergency.relation;
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