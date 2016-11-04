using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.CrystalReports;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private Entities _entities;

        public PaymentRepository()
        {
            this._entities = new Entities();
        }

        public object GetAllPayment(int hospital_id)
        {
            try
            {
                return (from adm in _entities.admissions
                        where adm.payment_status == "due"
                        join dep in _entities.departments on adm.department_id equals dep.department_id
                        join pat in _entities.patients on adm.patient_id equals pat.patient_id
                        where dep.hospital_id==hospital_id
                        select new
                        {
                            admission_id = adm.admission_id,
                            admission_date = adm.admission_date,
                            patient_id = adm.patient_id,
                            patient_name = pat.full_name,
                            department_id = adm.department_id,
                            department_name = dep.department_name,
                            payment_status = adm.payment_status
                        }).ToList().OrderByDescending(a => a.admission_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetPaymentById(int paymentId)
        {
            try
            {
                return _entities.payments.FirstOrDefault(p => p.payment_id == paymentId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object Insertpayment(StronglyType.PaymentInsertModel opModel)
        {
            try
            {
                discharge dis = new discharge
                {
                    discharge_date = opModel.discharge_date,
                    admission_id = opModel.payment.admission_id,
                    patient_id = opModel.payment.patient_id
                };
                _entities.discharges.Add(dis);
                _entities.SaveChanges();

                var maxId = _entities.discharges.Max(d => d.discharge_id);
                payment data = new payment
                {
                    patient_id = opModel.payment.patient_id,
                    discharge_id = maxId,
                    admission_id = opModel.payment.admission_id,
                    payment_date = DateTime.Now.Date,
                    payment_type_id = opModel.payment.payment_type_id,
                    payment_method_id = opModel.payment.payment_method_id,
                    adjustment_criteria = opModel.payment.adjustment_criteria,
                    adjustment_amount = opModel.payment.adjustment_amount,
                    amount_with_adjustment = opModel.payment.amount_with_adjustment,
                    amount_without_adjustment = opModel.payment.amount_without_adjustment,
                    chargable_days = opModel.payment.chargable_days,
                    hospital_id = opModel.payment.hospital_id

                };
                _entities.payments.Add(data);
                _entities.SaveChanges();

                if (opModel.cheque != null)
                {
                    var maxID = _entities.payments.Max(p => p.payment_id);

                    payment_cheque_details details = new payment_cheque_details
                    {
                        bank_id = opModel.cheque.bank_id,
                        payment_id = maxID,
                        account_no = opModel.cheque.account_no,
                        cheque_no = opModel.cheque.cheque_no,
                        check_date = opModel.cheque.check_date
                    };
                    _entities.payment_cheque_details.Add(details);
                    _entities.SaveChanges();
                }
                var admissionData = _entities.admissions.FirstOrDefault(a => a.admission_id == opModel.payment.admission_id);
                admissionData.payment_status = "confirmed";
                _entities.SaveChanges();

                var maxPaymentId = _entities.payments.Max(a => a.payment_id);
                var returnData = _entities.payments.FirstOrDefault(a => a.payment_id == maxPaymentId);
                return returnData;
            }
            catch (Exception)
            {

                return null;
            }
        }


        public object GetAllPaymentMethod()
        {
            try
            {
                return _entities.payment_method.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetInvoiceCrystalReport(int payment_id)
        {
            try
            {
                var data = (from pay in _entities.payments
                            where pay.payment_id == payment_id
                            join pat in _entities.patients on pay.patient_id equals pat.patient_id into pattable
                            from subPat in pattable.DefaultIfEmpty()
                            join med in _entities.patient_health_info on subPat.patient_id equals med.patient_id into MedTable
                            from subMed in MedTable.DefaultIfEmpty()
                            join adm in _entities.admissions on pay.admission_id equals adm.admission_id into AdmTable
                            from subAdm in AdmTable.DefaultIfEmpty()
                            join dep in _entities.departments on subAdm.department_id equals dep.department_id
                            join doc in _entities.doctors on subAdm.reffered_by equals doc.doctor_id into DocTable
                            from subDoc in DocTable.DefaultIfEmpty()
                            join emp in _entities.employees on subDoc.employee_id equals emp.employee_id into empTable
                            from subEmp in empTable.DefaultIfEmpty() 
                            join meta in _entities.meta_info on pay.hospital_id equals meta.hospital_id into HosTable 
                            from subMeta in HosTable.DefaultIfEmpty()
                            join div in _entities.divisions on subMeta.division_id equals div.division_id
                            join dist in _entities.districts on subMeta.district_id equals dist.district_id
                            join war in _entities.wards on subAdm.ward_id equals war.ward_id into WardTable
                            from subWard in WardTable.DefaultIfEmpty()
                            join rm in _entities.rooms on subAdm.room_id equals rm.room_id into RmTable
                            from subRm in RmTable.DefaultIfEmpty()
                            join rmType in _entities.room_type on subRm.room_type_id equals rmType.room_type_id
                            join dis in _entities.discharges on pay.discharge_id equals dis.discharge_id
                            join payMethod in _entities.payment_method on pay.payment_method_id equals
                                payMethod.payment_method_id
                            select new InvoiceModelForCrystalReport
                            {
                                patient_id = subPat.patient_id,
                                full_name = subPat.full_name,
                                gender = subPat.gender,
                                dob = subPat.dob,
                                age = subMed.age,
                                pat_address = subPat.address,
                                discharge_id = dis.discharge_id,
                                discharge_date = dis.discharge_date,
                                payment_method_name = payMethod.payment_method_name,
                                department_id = dep.department_id,
                                department_name = dep.department_name,
                                admission_id = subAdm.admission_id,
                                admission_date = subAdm.admission_date,
                                bed_id = subAdm.bed_id,
                                daily_cost = subAdm.daily_cost,
                                doctor_id = subDoc.doctor_id,
                                doctor_name = subEmp.employee_name,
                                doctor_fees = subDoc.doctor_fees,
                                hospital_id = subEmp.hospital_id,
                                hospital_name = subMeta.hospital_name,
                                division_name = div.division_name,
                                district_name = dist.district_name,
                                web = subMeta.web,
                                email = subMeta.email,
                                fax = subMeta.fax,
                                phone = subMeta.phone,
                                meta_address = subMeta.address,
                                room_no = subRm.room_no,
                                ward_name = subWard.ward_name,
                                payment_id = pay.payment_id,
                                payment_date = pay.payment_date,
                                logo_path = subMeta.logo_path,
                                amount_with_adjustment = pay.amount_with_adjustment,
                                amount_without_adjustment = pay.amount_without_adjustment,
                                adjustment_amount = pay.adjustment_amount,
                                chargable_days = pay.chargable_days,
                                adjustment_criteria = pay.adjustment_criteria

                            }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public object GetAllInvoiceList(string invoice,int hospital_id)
        {
            try
            {
                var maxid = _entities.payments.Max(p => p.payment_id);
                var data= (from pay in _entities.payments
                           where pay.hospital_id==hospital_id
                        join adm in _entities.admissions on pay.admission_id equals adm.admission_id
                        join dep in _entities.departments on adm.department_id equals dep.department_id
                        join pat in _entities.patients on adm.patient_id equals pat.patient_id
                        select new
                        {
                            admission_id = adm.admission_id,
                            admission_date = adm.admission_date,
                            patient_id = adm.patient_id,
                            patient_name = pat.full_name,
                            department_id = adm.department_id,
                            department_name = dep.department_name,
                            payment_status = adm.payment_status,
                            payment_id=pay.payment_id,
                            payment_date=pay.payment_date,
                            maxId=maxid
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