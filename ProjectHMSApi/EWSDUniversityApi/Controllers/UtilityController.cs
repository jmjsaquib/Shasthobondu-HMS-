﻿using HMSDevelopmentApi.Models.IRepository;
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
       
        public UtilityController()
        {
             this.employeeRepository = new Employeerepository();
            this.paymentRepository=new PaymentRepository();
         }
        [HttpGet, ActionName("GetAllEmployeeDoctor")]

        public HttpResponseMessage GetAllEmployeeDoctor()
        {

            var data = employeeRepository.GetAllEmployeeDoctor();
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
        
    }
}
