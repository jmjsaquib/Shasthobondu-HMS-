using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class PresscriptionRepository : IPresscriptionRepository
    {
        private Entities _entities;

        public PresscriptionRepository()
        {
            this._entities = new Entities();
        }

        public object GetAllPresscription(string status)
        {
            try
            {
                var data = new object();
                if (status == "forPresscription")
                {
                    data= (from pat in _entities.patients
                            where pat.status == "appoinmented"
                            join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                            from subMed in medTable.DefaultIfEmpty()
                            join appo in _entities.appoinments on pat.patient_id equals appo.patient_id into AppoTable
                            from subAppo in AppoTable.DefaultIfEmpty()
                           join dep in _entities.departments on subAppo.department_id equals dep.department_id
                            join emp in _entities.employees on subAppo.doctor_id equals emp.employee_id into Emptable
                            from subEmp in Emptable.DefaultIfEmpty()
                            select new
                            {
                                patient_id = pat.patient_id,
                                full_name = pat.full_name,
                                gender = pat.gender,
                                blood_group = subMed.blood_group,
                                dob = pat.dob,
                                status = pat.status,
                                appoinment_id = subAppo.appoinment_id,
                                doctor_id = subAppo.doctor_id ?? 0,
                                doctor_name = subEmp.employee_name,
                                department_id = dep.department_id,
                                department_name = dep.department_name,
                                appoinment_date = subAppo.appoinment_date

                            }).ToList().OrderByDescending(p => p.patient_id);
                }else if (status == "forAdmission")
                {
                    data=(from press in _entities.presscriptions
                        where press.need_admission == "yes"
                        join pat in _entities.patients on press.patient_id equals pat.patient_id
                        join appo in _entities.appoinments on pat.patient_id equals appo.patient_id into AppoTable
                        from subAppo in AppoTable.DefaultIfEmpty()
                        join dep in _entities.departments on subAppo.department_id equals dep.department_id
                        join emp in _entities.employees on subAppo.doctor_id equals emp.employee_id into Emptable
                        from subEmp in Emptable.DefaultIfEmpty()
                          where pat.status == "presscribed"
                        select new
                        {
                            patient_id = pat.patient_id,
                            full_name = pat.full_name,
                            appoinment_id = subAppo.appoinment_id,
                            appoinment_date=subAppo.appoinment_date,
                            doctor_id = subAppo.doctor_id ?? 0,
                            doctor_name = subEmp.employee_name,
                            prescription_id = press.prescription_id,
                            presscription_date = press.presscription_date,
                            department_id = dep.department_id,
                            department_name = dep.department_name,
                            need_admission=press.need_admission
                        }).ToList().OrderByDescending(p=>p.prescription_id);
                }
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
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
                        join appo in _entities.appoinments on press.appoinment_id equals appo.appoinment_id into AppoTable
                        from subAppo in AppoTable.DefaultIfEmpty()
                        join doc in _entities.doctors on subAppo.doctor_id equals doc.doctor_id
                        join dep in _entities.departments on subAppo.department_id equals dep.department_id
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id into Emptable
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
                            appoinment_id = subAppo.appoinment_id,
                            doctor_id = subAppo.doctor_id ?? 0,
                            doctor_name = subEmp.employee_name,
                            prescription_id = press.prescription_id,
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
        public object GetPresscriptionDetails(int patientId, int presscriptionId)
        {
            try
            {
                return (from press in _entities.presscriptions
                        where press.prescription_id == presscriptionId && press.patient_id==patientId
                        join pat in _entities.patients on press.patient_id equals pat.patient_id
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                        from subMed in medTable.DefaultIfEmpty()
                        join div in _entities.divisions on pat.division_id equals div.division_id into DivTable
                        from subDiv in DivTable.DefaultIfEmpty()
                        join dis in _entities.districts on pat.district_id equals dis.district_id into DisTable
                        from subDis in DisTable.DefaultIfEmpty()
                        join emr in _entities.patient_emergency_contact on pat.patient_id equals emr.patient_id into EmerTable
                        from subEmr in EmerTable.DefaultIfEmpty()
                        join appo in _entities.appoinments on press.appoinment_id equals appo.appoinment_id into AppoTable
                        from subAppo in AppoTable.DefaultIfEmpty()
                        join doc in _entities.doctors on subAppo.doctor_id equals doc.doctor_id
                        join dep in _entities.departments on subAppo.department_id equals dep.department_id
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id into Emptable
                        from subEmp in Emptable.DefaultIfEmpty()
                        join pressMed in _entities.presscription_medicine_mapping on press.prescription_id equals pressMed.presscription_id
                        join pressMedInfor in _entities.medicines on pressMed.medicine_id equals pressMedInfor.medicine_id
                        join pressTest in _entities.presscription_test_type_mapping on press.prescription_id equals pressTest.presscription_id into TestTAble
                        from subTest in TestTAble.DefaultIfEmpty()
                        join testType in _entities.test_type on subTest.test_type_id equals testType.test_type_id
                        join pressDrug in _entities.presscription_drug_allergies_mapping on press.prescription_id equals pressDrug.presscription_id into DrugTAble
                        from subDrug in DrugTAble.DefaultIfEmpty()
                        join pressHealth in _entities.presscription_health_condition_mapping on press.prescription_id equals pressHealth.presscription_id into HealthTAble
                        from subHealth in HealthTAble.DefaultIfEmpty()
                        join pressSuggestiong in _entities.presscription_suggestion_mapping on press.prescription_id equals pressSuggestiong.presscription_id into SuggestiongTAble
                        from subSuggestiong in SuggestiongTAble.DefaultIfEmpty()
                        join pressComplatains in _entities.presscription_complaints_mapping on press.prescription_id equals pressComplatains.presscription_id into CompaintsTable
                        from subpressComplatains in CompaintsTable.DefaultIfEmpty()
                        join pressDiease in _entities.diseases on press.disease_id equals pressDiease.disease_id into DieaseTable
                        from subpressDiease in DieaseTable.DefaultIfEmpty()
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
                            appoinment_id = subAppo.appoinment_id,
                            appoinment_date = subAppo.appoinment_date,
                            doctor_id = subAppo.doctor_id ?? 0,
                            doctor_name = subEmp.employee_name,
                            prescription_id = press.prescription_id,
                            presscription_date = press.presscription_date,
                            department_id = dep.department_id,
                            department_name = dep.department_name,
                            chief_complaints=subpressComplatains.chief_complaints,
                            chief_complaints_duration=subpressComplatains.chief_complaints_duration,
                            drug_allergies_name=subDrug.drug_allergies_name,
                            health_condition_name=subHealth.health_condition_name,
                            medicine_name=pressMedInfor.medicine_name,
                            medicine_power=pressMed.medicine_power,
                            dosage=pressMed.dosage,
                            how_long=pressMed.how_long,
                            route_of_administration=pressMed.route_of_administration,
                            rules=pressMed.rules,
                            suggestion_name = subSuggestiong.suggestion_name,
                            test_type_name=testType.test_type_name,
                            need_admission = press.need_admission,
                            diease_name=subpressDiease.disease_name??"N/A"


                        }).ToList();

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
                    presscription_date = DateTime.Now.Date,
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
                if (press.need_admission == "yes")
                {
                    patientdata.status = "presscribed";
                }
                else
                {
                    patientdata.status = "entry";
                }
               
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





        


        public object GetAllPresscriptionByDoctorID(int employeeId, string today)
        {
            try
            {

                var data = "select appo.appoinment_date,appo.appoinment_id,appo.appoinment_serial,pat.patient_id,pat.dob, pat.full_name, pat.gender,med.blood_group,pat.`status`,doc.doctor_id,emp.employee_name,dep.department_id,department_name "
                           + " from appoinment as appo, employee as emp,patient as pat,patient_health_info as med,"
                           + " department as dep,doctor as doc "
                           + "where emp.employee_id=" + employeeId +" and pat.status = 'appoinmented'" +" AND appo.appoinment_date ='" + today
                           + "' and emp.employee_id=doc.employee_id"
                           + " and doc.doctor_id=appo.doctor_id"
                           + " and appo.patient_id=pat.patient_id"
                           + " and pat.patient_id=med.patient_id"
                           + " and appo.department_id=dep.department_id"
                           + " ORDER BY (appo.appoinment_serial)";

                var pressData = _entities.Database.SqlQuery<DoctorPresscriptionSerialModel>(data).ToList().DefaultIfEmpty();
                return pressData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public object GetAllPresscriptionBypatientId(int patientId)
        {
            try
            {
                return  (from press in _entities.presscriptions
                         where press.patient_id == patientId 
                    join pat in _entities.patients on press.patient_id equals pat.patient_id
                    join appo in _entities.appoinments on press.appoinment_id equals appo.appoinment_id
                    join dep in _entities.departments on appo.department_id equals dep.department_id
                    join doc in _entities.doctors on appo.doctor_id equals doc.doctor_id
                    join emp in _entities.employees on doc.employee_id equals emp.employee_id
                         
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





        public object GetAllPresscriptionOfCurrentDate(string currentDate)
        {
            try
            {

                var data = "select appo.appoinment_date,appo.appoinment_id,appo.appoinment_serial,pat.patient_id,pat.dob, pat.full_name, pat.gender,med.blood_group,pat.`status`,doc.doctor_id,emp.employee_name,dep.department_id,department_name,press.prescription_id,press.presscription_date "
                           + " from appoinment as appo, employee as emp,patient as pat,patient_health_info as med,"
                           + " department as dep,doctor as doc,presscription as press  "
                           + " where pat.status ='presscribed'"
                          // + " AND press.presscription_date ='" + currentDate+"'"
                           + " and press.patient_id=pat.patient_id"
                           + " and press.appoinment_id=appo.appoinment_id"
                           + " and appo.doctor_id=doc.doctor_id"
                           + " and doc.employee_id=emp.employee_id"
                           + " and doc.department_id=dep.department_id"
                           + " and pat.patient_id=med.patient_id"
                           + " ORDER BY (press.prescription_id) DESC";

                var pressData = _entities.Database.SqlQuery<CurrentDatePresscriptionForPrintModel>(data).ToList().DefaultIfEmpty();
                return pressData;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public object GetpresscriptionCrystalReport(int presscriptionId)
        {
            try
            {
                return (from press in _entities.presscriptions
                        where press.prescription_id == presscriptionId
                        join pat in _entities.patients on press.patient_id equals pat.patient_id
                        join med in _entities.patient_health_info on pat.patient_id equals med.patient_id into medTable
                        from subMed in medTable.DefaultIfEmpty()
                        join appo in _entities.appoinments on press.appoinment_id equals appo.appoinment_id into AppoTable
                        from subAppo in AppoTable.DefaultIfEmpty()
                        join doc in _entities.doctors on subAppo.doctor_id equals doc.doctor_id
                        join dep in _entities.departments on subAppo.department_id equals dep.department_id
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id into Emptable
                        from subEmp in Emptable.DefaultIfEmpty()
                        join meta in _entities.meta_info on subEmp.hospital_id equals meta.hospital_id into metaTable
                        from subMeta in metaTable.DefaultIfEmpty()
                        join pressMed in _entities.presscription_medicine_mapping on press.prescription_id equals pressMed.presscription_id
                        join pressMedInfor in _entities.medicines on pressMed.medicine_id equals pressMedInfor.medicine_id
                        join pressTest in _entities.presscription_test_type_mapping on press.prescription_id equals pressTest.presscription_id into TestTAble
                        from subTest in TestTAble.DefaultIfEmpty()
                        join testType in _entities.test_type on subTest.test_type_id equals testType.test_type_id
                        join pressDrug in _entities.presscription_drug_allergies_mapping on press.prescription_id equals pressDrug.presscription_id into DrugTAble
                        from subDrug in DrugTAble.DefaultIfEmpty()
                        join pressHealth in _entities.presscription_health_condition_mapping on press.prescription_id equals pressHealth.presscription_id into HealthTAble
                        from subHealth in HealthTAble.DefaultIfEmpty()
                        join pressSuggestiong in _entities.presscription_suggestion_mapping on press.prescription_id equals pressSuggestiong.presscription_id into SuggestiongTAble
                        from subSuggestiong in SuggestiongTAble.DefaultIfEmpty()
                        join pressComplatains in _entities.presscription_complaints_mapping on press.prescription_id equals pressComplatains.presscription_id into CompaintsTable
                        from subpressComplatains in CompaintsTable.DefaultIfEmpty()
                        join pressDiease in _entities.diseases on press.disease_id equals pressDiease.disease_id into DieaseTable
                        from subpressDiease in DieaseTable.DefaultIfEmpty()
                        select new PresscriptionCrystalReportModel
                        {
                            patient_id = pat.patient_id,
                            full_name = pat.full_name,
                            pat_address = pat.address,
                            status = pat.status,
                            dob = pat.dob,
                            nid_id = pat.nid_id,
                            gender = pat.gender,
                            blood_group = subMed.blood_group,
                            blood_pressure = subMed.blood_pressure ?? "N/A",
                            height = subMed.height,
                            weight = subMed.weight,
                            age = subMed.age,
                            appoinment_id = subAppo.appoinment_id,
                            appoinment_date = subAppo.appoinment_date,
                            doctor_id = subAppo.doctor_id ?? 0,
                            doctor_name = subEmp.employee_name,
                            doctor_registration_number = doc.doctor_registration_number,
                            prescription_id = press.prescription_id,
                            presscription_date = press.presscription_date,
                            department_id = dep.department_id,
                            department_name = dep.department_name,
                            chief_complaints = subpressComplatains.chief_complaints,
                            chief_complaints_duration = subpressComplatains.chief_complaints_duration,
                            drug_allergies_name = subDrug.drug_allergies_name,
                            health_condition_name = subHealth.health_condition_name,
                            medicine_name = pressMedInfor.medicine_name,
                            medicine_power = pressMed.medicine_power,
                            dosage = pressMed.dosage,
                            how_long = pressMed.how_long,
                            route_of_administration = pressMed.route_of_administration,
                            rules = pressMed.rules,
                            suggestion_name = subSuggestiong.suggestion_name,
                            test_type_name = testType.test_type_name,
                            need_admission = press.need_admission,
                            diease_name = subpressDiease.disease_name ?? "N/A",
                            hospital_name = subMeta.hospital_name,
                            web = subMeta.web,
                            email = subMeta.email,
                            fax = subMeta.fax,
                            phone = subMeta.phone,
                            meta_address = subMeta.address,
                            logo_path = subMeta.logo_path


                        }).Distinct().ToList();
            }
            catch (Exception)
            {
                    
                throw;
            }
        }
    }
}