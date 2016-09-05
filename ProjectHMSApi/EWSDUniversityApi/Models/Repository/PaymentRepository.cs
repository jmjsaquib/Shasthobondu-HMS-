using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.StronglyType;

namespace HMSDevelopmentApi.Models.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private Entities _entities;

        public PaymentRepository()
        {
            this._entities=new Entities();
        }

        public object GetAllPayment()
        {
            try
            {
                return (from adm in _entities.admissions
                    where adm.payment_status == "due"
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
                    amount_without_adjustment = opModel.payment.amount_without_adjustment
                    
                };
                _entities.payments.Add(data);
                _entities.SaveChanges();

                if (opModel.cheque!=null)
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
    }
}