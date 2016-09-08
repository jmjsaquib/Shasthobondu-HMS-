using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaymentController : ApiController
    {
        private IPaymentRepository paymentRepository;

        public PaymentController()
        {
            this.paymentRepository=new PaymentRepository();
        }
        [HttpGet, ActionName("GetAllPayment")]

        public HttpResponseMessage GetAllPayment()
        {

            var data = paymentRepository.GetAllPayment();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllInvoiceList")]

        public HttpResponseMessage GetAllInvoiceList(string invoice)
        {

            var data = paymentRepository.GetAllInvoiceList(invoice);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetPaymentById")]

        public HttpResponseMessage GetPaymentById(int paymentId)
        {
            var data = paymentRepository.GetPaymentById(paymentId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }

        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.StronglyType.PaymentInsertModel opModel)
        {
            try
            {
                var insertPayment = paymentRepository.Insertpayment(opModel);
                if (insertPayment !=null)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Payment Information  is saved successfully.", returnvalue = insertPayment }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Payment Information  is not saved successfully." }, formatter);
                }



            }
            catch (Exception ex)
            {

                var formatter = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                 new Confirmation { output = "error", msg = ex.ToString() }, formatter);
            }
        }
    }
}
