using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.WebPages;
using HMSDevelopmentApi.Models.CrystalReports;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class AppoinmentRepository : IAppoinmentRepository
    {
        private Entities _entities;

        public AppoinmentRepository()
        {
            this._entities = new Entities();
        }
        public object GetAllAppoinment()
        {
            try
            {
                return (from pat in _entities.patients
                        where pat.status == "entry"
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

                        }).ToList().OrderByDescending(p => p.patient_id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public object AppoinmentListForDoctor(int doctorId)
        {
            return (from appo in _entities.appoinments
                    where appo.doctor_id == doctorId
                    select new
                    {
                        appoinment_date = appo.appoinment_date,
                        appoinment_serial = appo.appoinment_serial,

                    }).ToList();
        }

        public object Delete(int appoinmentId)
        {
            throw new NotImplementedException();
        }

        public object insert(StronglyType.AppoinmentValidationModel appo)
        {
            try
            {
                var dateStr = appo.submittedDate+" 00:00";
                DateTime dt = DateTime.ParseExact(dateStr, "yyyy/MM/dd HH:mm", CultureInfo.CurrentCulture);
                appoinment appoinment = new appoinment
                {
                    patient_id = appo.patient_id,
                    doctor_id = appo.doctor_id,
                    department_id = appo.department_id,
                    appoinment_date =dt,
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
                var id = _entities.appoinments.Max(a => a.appoinment_id);
                var returnData = _entities.appoinments.FirstOrDefault(a => a.appoinment_id == id);
                return returnData;
            }
            catch (Exception)
            {

                return null;
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
                var data = "select DATE_FORMAT(appoinment_date,'%m/%d/%Y') as appoinment_date,COUNT(appoinment_id) as 'Count',appoinment_serial "
                      + " from appoinment where doctor_id=" + doctorId + " AND appoinment_date >='" + today
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


        public object AppoinmentInvoiceCrystalReport(int appoinmentId)
        {
            try
            {
                var data = (from appo in _entities.appoinments
                            where appo.appoinment_id == appoinmentId
                            join pat in _entities.patients on appo.patient_id equals pat.patient_id into pattable
                            from subPat in pattable.DefaultIfEmpty()
                            join med in _entities.patient_health_info on subPat.patient_id equals med.patient_id into MedTable
                            from subMed in MedTable.DefaultIfEmpty()
                            join dep in _entities.departments on appo.department_id equals dep.department_id
                            join doc in _entities.doctors on appo.doctor_id equals doc.doctor_id into DocTable
                            from subDoc in DocTable.DefaultIfEmpty()
                            join emp in _entities.employees on subDoc.employee_id equals emp.employee_id into empTable
                            from subEmp in empTable.DefaultIfEmpty()
                            join meta in _entities.meta_info on subEmp.hospital_id equals meta.hospital_id into HosTable
                            from subMeta in HosTable.DefaultIfEmpty()
                            join div in _entities.divisions on subMeta.division_id equals div.division_id
                            join dist in _entities.districts on subMeta.district_id equals dist.district_id
                            select new AppoinmentInvoiceReportModel
                            {
                                patient_id = subPat.patient_id,
                                full_name = subPat.full_name,
                                gender = subPat.gender,
                                dob = subPat.dob,
                                age = subMed.age,
                                pat_address = subPat.address,
                                appoinment_date = appo.appoinment_date,
                                appoinment_serial  =appo.appoinment_serial,
                                appoinment_time = appo.appoinment_time,
                                appoinment_id = appo.appoinment_id,
                                department_id = dep.department_id,
                                department_name = dep.department_name,
                                doctor_id = subDoc.doctor_id,
                                doctor_name ="Dr. "+ subEmp.employee_name,
                                doctor_fees = subDoc.doctor_fees,
                                hospital_name = subMeta.hospital_name,
                                division_name = div.division_name,
                                district_name = dist.district_name,
                                web = subMeta.web,
                                email = subMeta.email,
                                fax = subMeta.fax,
                                phone = subMeta.phone,
                                meta_address = subMeta.address,
                                logo_path = subMeta.logo_path
                               

                            }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}