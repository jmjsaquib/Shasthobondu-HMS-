using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;

namespace HMSDevelopmentApi.Models.Repository
{
    public class PresscriptionRepository : IPresscriptionRepository
    {
        private Entities _entities;

        public PresscriptionRepository()
        {
            this._entities = new Entities();
        }

        public object GetAllPresscription()
        {
            return _entities.presscriptions.ToList();
        }

        public object GetAllPresscriptionByPresscriptionId(int presscriptionid)
        {
            try
            {
                return (from press in _entities.presscriptions
                        where press.prescription_id == presscriptionid
                        join pat in _entities.patients on press.patient_id equals pat.patient_id
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                        from subMed in medTable.DefaultIfEmpty()
                        join div in _entities.divisions on pat.division_id equals div.division_id into DivTable
                        from subDiv in DivTable.DefaultIfEmpty()
                        join dis in _entities.districts on pat.district_id equals dis.district_id into DisTable
                        from subDis in DisTable.DefaultIfEmpty()
                        join emr in _entities.patient_emergency_contact on pat.patient_id equals emr.patient_id into EmerTable
                        from subEmr in EmerTable.DefaultIfEmpty()
                        join appo in _entities.appoinments on pat.patient_id equals appo.patient_id into AppoTable
                        from subAppo in AppoTable.DefaultIfEmpty()
                        join dep in _entities.departments on subAppo.department_id equals dep.department_id
                        join emp in _entities.employees on subAppo.doctor_id equals emp.employee_id into Emptable
                        from subEmp in Emptable.DefaultIfEmpty()
                        join pressMed in _entities.presscription_medicine_mapping on press.prescription_id equals pressMed.presscription_id
                        join pressTest in _entities.presscription_test_type_mapping on press.prescription_id equals pressTest.presscription_id into TestTAble
                        from subTest in TestTAble.DefaultIfEmpty()
                        join pressDrug in _entities.presscription_drug_allergies_mapping on press.prescription_id equals pressDrug.presscription_id into DrugTAble
                        from subDrug in DrugTAble.DefaultIfEmpty()
                        join pressHealth in _entities.presscription_health_condition_mapping on press.prescription_id equals pressHealth.presscription_id into HealthTAble
                        from subHealth in HealthTAble.DefaultIfEmpty()
                        join pressSuggestiong in _entities.presscription_suggestion_mapping on press.prescription_id equals pressSuggestiong.presscription_id into SuggestiongTAble
                        from subSuggestiong in SuggestiongTAble.DefaultIfEmpty()
                        select new
                        {
                            patient_id = pat.patient_id,
                            full_name = pat.full_name,
                            email = pat.email,
                            address = pat.address,
                            status = pat.status,
                            division_id = pat.division_id,
                            division_name = subDiv.division_name,
                            district_id = pat.district_id,
                            district_name = subDis.district_name,
                            dob=pat.dob,
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
                            appoinment_id = subAppo.appoinment_id,
                            doctor_id = subAppo.doctor_id ?? 0,
                            doctor_name = subEmp.employee_name,
                            prescription_id = press.prescription_id,
                            presscription_date=press.presscription_date,
                            department_id=dep.department_id,
                            department_name=dep.department_name

                        }).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool insert(StronglyType.PresscriptionDataModel press)
        {
            try
            {
                presscription presscription = new presscription
                {
                    patient_id = press.patient_id,
                    appoinment_id = press.appoinment_id,
                    presscription_date = DateTime.Now.ToString(),
                    need_admission = press.need_admission,
                    disease_id = press.disease_id,

                };
                _entities.presscriptions.Add(presscription);
                _entities.SaveChanges();

                int maxPresscriptionId = _entities.presscriptions.Max(p => p.prescription_id);

                foreach (var item in press.Suggestion)
                {
                    presscription_suggestion_mapping sug = new presscription_suggestion_mapping
                    {
                        presscription_id = maxPresscriptionId,
                        suggestion_name = item.suggestion_name
                    };
                    _entities.presscription_suggestion_mapping.Add(sug);
                    _entities.SaveChanges();
                }
                foreach (var item in press.drug)
                {
                    presscription_drug_allergies_mapping drg = new presscription_drug_allergies_mapping
                    {
                        presscription_id = maxPresscriptionId,
                        drug_allergies_name = item.drug_allergies_name
                    };
                    _entities.presscription_drug_allergies_mapping.Add(drg);
                    _entities.SaveChanges();
                }
                foreach (var item in press.health)
                {
                    presscription_health_condition_mapping hlt = new presscription_health_condition_mapping
                    {
                        presscription_id = maxPresscriptionId,
                        health_condition_name = item.health_condition_name
                    };
                    _entities.presscription_health_condition_mapping.Add(hlt);
                    _entities.SaveChanges();
                }
                foreach (var item in press.med)
                {
                    presscription_medicine_mapping medi = new presscription_medicine_mapping
                    {
                        presscription_id = maxPresscriptionId,
                        medicine_id = item.medicine_id,
                        medicine_power = item.medicine_power,
                        dosage = item.dosage,
                        how_long = item.how_long,
                        rules = item.rules,
                        route_of_administration = item.route_of_administration
                    };
                    _entities.presscription_medicine_mapping.Add(medi);
                    _entities.SaveChanges();
                }
                foreach (var item in press.test)
                {
                    presscription_test_type_mapping tst = new presscription_test_type_mapping
                    {
                        presscription_id = maxPresscriptionId,
                        test_type_id = item.test_type_id
                    };
                    _entities.presscription_test_type_mapping.Add(tst);
                    _entities.SaveChanges();
                }
                foreach (var item in press.complaints)
                {
                    presscription_complaints_mapping com = new presscription_complaints_mapping
                    {
                        presscription_id = maxPresscriptionId,
                        chief_complaints = item.chief_complaints,
                        chief_complaints_duration = item.chief_complaints_duration
                    };
                    _entities.presscription_complaints_mapping.Add(com);
                    _entities.SaveChanges();
                }
                var patientdata = _entities.patients.FirstOrDefault(p => p.patient_id == press.patient_id);
                patientdata.status = "presscribed";
                _entities.SaveChanges();
                var medData = _entities.patient_health_info.FirstOrDefault(m => m.patient_id == patientdata.patient_id);
                medData.blood_pressure = press.blood_pressure;
                medData.weight = press.weight;
                _entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }





        public object GetAllPresscriptionByPatientId(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}