using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSDevelopmentApi.Models.StronglyType
{
    public class PaymentInsertModel
    {
        public payment_cheque_details cheque { get; set; }
        public payment payment { get; set; }
        public string discharge_date { get; set; }

    }
}