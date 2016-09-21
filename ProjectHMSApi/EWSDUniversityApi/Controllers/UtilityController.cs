using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
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
    public class UtilityController : ApiController
    {
        private IEmployeeRepository employeeRepository;
        private IPaymentRepository paymentRepository;
        private IPresscriptionRepository presscriptionRepository;
       
        public UtilityController()
        {
             this.employeeRepository = new Employeerepository();
            this.paymentRepository=new PaymentRepository();
            this.presscriptionRepository=new PresscriptionRepository();
         }
        [HttpGet, ActionName("GetAllEmployeeDoctor")]

        public HttpResponseMessage GetAllEmployeeDoctor( string empStatus)
        {

            var data = employeeRepository.GetAllEmployeeDoctor(empStatus);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllPaymentMethod")]

        public HttpResponseMessage GetAllPaymentMethod(string status)
        {

            var data = paymentRepository.GetAllPaymentMethod();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetInvoiceCrystalReport")]

        public HttpResponseMessage GetInvoiceCrystalReport(int payment_id)
        {

            var data = paymentRepository.GetInvoiceCrystalReport(payment_id);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllDoctorBydepartmentId")]

        public HttpResponseMessage GetAllDoctorBydepartmentId(int departmentID)
        {

            var data = employeeRepository.GetAllDoctorBydepartmentId(departmentID);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetpresscriptionCrystalReport")]

        public HttpResponseMessage GetpresscriptionCrystalReport(int presscriptionId)
        {

            var data = presscriptionRepository.GetpresscriptionCrystalReport(presscriptionId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpPut, ActionName("UpdatePersonalData")]

        public HttpResponseMessage UpdatePersonalData([FromBody]Models.StronglyType.PasswordResetModel empPeResetModel)
        {
            bool update = employeeRepository.UpdatePasswordEmployee(empPeResetModel);

            if (update == true)
            {
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Account Information is Updated Successfully" }, format_type);
            }
            else
            {
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Something is wrong!!!" }, format_type);
            }
        }
        
    }
}
