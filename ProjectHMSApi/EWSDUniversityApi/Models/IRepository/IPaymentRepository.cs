using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSDevelopmentApi.Models.IRepository
{
    interface IPaymentRepository
    {
        object GetAllPayment();

        object GetPaymentById(int paymentId);

        object Insertpayment(StronglyType.PaymentInsertModel opModel);

        object GetAllPaymentMethod();
    }
}
