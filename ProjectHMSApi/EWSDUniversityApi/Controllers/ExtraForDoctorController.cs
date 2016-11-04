using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;

namespace HMSDevelopmentApi.Controllers
{
    public class ExtraForDoctorController : ApiController
    {
         private IEmployeeRepository employeeRepository;
         public ExtraForDoctorController()
        {
             this.employeeRepository = new Employeerepository();
         }
         [System.Web.Http.HttpGet, ActionName("GetAllDepartmentWiseDoctor")]

         public HttpResponseMessage GetAllDepartmentWiseDoctor(int hospital_id)
         {

             var data = employeeRepository.GetAllDepartmentWiseDoctor(hospital_id);
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);
         }
    }
}
