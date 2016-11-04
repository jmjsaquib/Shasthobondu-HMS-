using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IPaymentRepository
    {
        object GetAllPayment(int hospital_id);

        object GetPaymentById(int paymentId);

        object Insertpayment(StronglyType.PaymentInsertModel opModel);

        object GetAllPaymentMethod();

        object GetInvoiceCrystalReport(int payment_id);

        object GetAllInvoiceList(string invoice, int hospital_id);
    }
}
