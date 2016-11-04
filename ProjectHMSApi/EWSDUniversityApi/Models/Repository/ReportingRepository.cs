using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class ReportingRepository:IReportingRepository
    {
        private Entities _entities;

        public ReportingRepository()
        {
            this._entities=new Entities();
        }

        public object GetAllPatientInfo(string status, int hospital_id)
        {
            try
            {
                //var data = "select pat.patient_id,pat.full_name,pat.dob,med.age,med.blood_group,'' as CountPat,''as CountAppo,''as CountEntry,''as CountAdmit,''as CountDeath"
                //           + " from patient as pat LEFT JOIN patient_health_info as med"
                //           + " on pat.patient_id=med.patient_id"
                //           + " UNION ALL"
                //           +" SELECT '','','','','',COUNT(patient.patient_id),'','','',''"
                //           + " from patient"
                //           + " UNION ALL"
                //           +" SELECT '','','','','','',COUNT(patient.patient_id),'','',''"
                //           + " from patient"
                //           + " where patient.`status`='appoinmented'"
                //           + " UNION ALL"
                //           +" SELECT '','','','','','','',COUNT(patient.patient_id),'',''"
                //           + " from patient"
                //           + " where patient.`status`='entry'"
                //           + " UNION ALL"
                //           +" SELECT '','','','','','','','',COUNT(patient.patient_id),''"
                //           + " from patient"
                //           + " where patient.`status`='admitted'"
                //           + " UNION ALL"
                //           + " SELECT '','','','','','','','','',COUNT(patient.patient_id)"
                //           + " from patient"
                //           + " where patient.`status`='death'";

                //var reportData = _entities.Database.SqlQuery<PatientReportModel>(data).ToList().DefaultIfEmpty();
                if (status == "superadmin")
                {
                    var employeeCount = _entities.employees.Count();
                    var totalTransaction = _entities.payments.Sum(t => t.amount_with_adjustment);
                    var doctorCount = _entities.doctors.Count();
                    var departmentCount = _entities.departments.Count();
                    var CountPat = _entities.patients.Count();
                    var CountAppo = _entities.patients.Count(e => e.status == "appoinmented");
                    var countEntry = _entities.patients.Count(e => e.status == "entry");
                    var CountDeath = _entities.patients.Count(e => e.status == "death");
                    var CountAdmit = _entities.patients.Count(e => e.status == "admitted");
                    var totalhospital = _entities.meta_info.Count();

                    var requireData = new PatientReportModel
                    {
                        CountPat = CountPat,
                        CountAppo = CountAppo,
                        CountEntry = countEntry,
                        CountDeath = CountDeath,
                        CountAdmit = CountAdmit,
                        employeeCount = employeeCount,
                        doctorCount = doctorCount,
                        departmentCount = departmentCount,
                        totalTransaction = totalTransaction,
                        totalClient = totalhospital

                    };

                    return requireData;
                }
                else
                {
                    var employeeCount = _entities.employees.Count(e=>e.hospital_id==hospital_id);
                    var totalTransaction = _entities.payments.Sum(t => t.amount_with_adjustment);
                    var doctorData = (from doc in _entities.doctors
                        join emp in _entities.employees on doc.employee_id equals emp.employee_id
                        where emp.hospital_id == hospital_id
                        select new
                        {
                            doctorCount=doc.doctor_id
                        }).ToList();
                    var doctorCount = doctorData.Count();
                    var departmentCount = _entities.departments.Count(e => e.hospital_id == hospital_id);
                    var CountPat = _entities.patients.Count();
                    var CountAppo = _entities.patients.Count(e => e.status == "appoinmented"&& e.hospital_id == hospital_id);
                    var countEntry = _entities.patients.Count(e => e.status == "entry" && e.hospital_id == hospital_id);
                    var countDonor = _entities.patients.Count(e => e.status == "entry");
                    var CountDeath = _entities.patients.Count(e => e.status == "death" && e.hospital_id == hospital_id);
                    var CountAdmit = _entities.patients.Count(e => e.status == "admitted" && e.hospital_id == hospital_id);

                    var requireData = new PatientReportModel
                    {
                        CountPat = CountPat,
                        CountAppo = CountAppo,
                        CountEntry = countEntry,
                        CountDeath = CountDeath,
                        CountAdmit = CountAdmit,
                        employeeCount = employeeCount,
                        doctorCount = doctorCount,
                        departmentCount = departmentCount,
                        totalTransaction = totalTransaction,
                        countDonor = countDonor

                    };

                    return requireData;
                }
               
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public object GetAllPatientTrackingByStatus(string track)
        {
            try
            {
                return (from pat in _entities.patients
                        where pat.status==track
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


        public object GetAllTransactionCrystalReport(int hospital_id)
        {
            try
            {
                //var data = _entities.meta_info.FirstOrDefault(m=>m.hospital_id==hospital_id);
                var employeeCount = _entities.employees.Count();
                var totalTransaction = _entities.payments.Where(t=>t.hospital_id==hospital_id).ToList().Sum(t=>t.amount_with_adjustment);
                var doctorCount = (from doc in _entities.doctors
                    join emp in _entities.employees on doc.employee_id equals emp.employee_id
                    where emp.hospital_id == hospital_id
                    select new
                    {
                        doctor_id=doc.doctor_id
                    }).Count();
                var departmentCount = _entities.departments.Count(e=>e.hospital_id==hospital_id);
                var CountPat = _entities.patients.Count();
                var CountAppo = _entities.patients.Count(e => e.status == "appoinmented");
                var countEntry = _entities.patients.Count(e => e.status == "entry");
                var CountDeath = _entities.patients.Count(e => e.status == "death");
                var CountAdmit = _entities.patients.Count(e => e.status == "admitted");
                var requireData = (from da in _entities.meta_info
                                   where da.hospital_id == hospital_id
                    join div in _entities.divisions on da.division_id equals div.division_id
                    join dist in _entities.districts on da.district_id equals dist.district_id
                    select new TransactionReportModel
                    {
                        hospital_name = da.hospital_name,
                        division_name = div.division_name,
                        district_name = dist.district_name,
                        web = da.web,
                        email = da.email,
                        fax = da.fax,
                        phone = da.phone,
                        meta_address = da.address,
                        logo_path = da.logo_path,
                        CountPat = CountPat,
                        CountAdmit = CountAdmit,
                        CountAppo = CountAppo,
                        CountDeath = CountDeath,
                        CountEntry = countEntry,
                        departmentCount = departmentCount,
                        doctorCount = doctorCount,
                        employeeCount = employeeCount,
                        totalTransaction = totalTransaction
                    }).ToList();
                return requireData;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object GetAllDailyTransaction(int departmentId, string today)
        {
            try
            {
                DateTime dt = DateTime.Parse(today);
                Console.WriteLine(dt.ToString("dd/MM/yyyy"));
                var data = (from pay in _entities.payments
                            join adm in _entities.admissions on pay.admission_id equals adm.admission_id
                            join dep in _entities.departments on adm.department_id equals dep.department_id
                            join pat in _entities.patients on adm.patient_id equals pat.patient_id
                            where dep.department_id == departmentId && pay.payment_date==dt.Date
                            select new
                            {
                                admission_id = adm.admission_id,
                                admission_date = adm.admission_date,
                                patient_id = adm.patient_id,
                                patient_name = pat.full_name,
                                department_id = adm.department_id,
                                department_name = dep.department_name,
                                payment_status = adm.payment_status,
                                payment_id = pay.payment_id,
                                payment_date = pay.payment_date,
                                amount_with_adjustment = pay.amount_with_adjustment
                            }).ToList().OrderByDescending(a => a.payment_id);
                return data;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}