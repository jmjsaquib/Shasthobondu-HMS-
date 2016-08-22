using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
using HMSDevelopmentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HMSDevelopmentApi.Controllers
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
         private IEmployeeRepository employeeRepository;
         public EmployeeController() {
             this.employeeRepository = new Employeerepository();
         }

         [HttpGet, ActionName("GetAllEmployee")]

         public HttpResponseMessage GetAllEmployee() {

             var data = employeeRepository.GetAllEmployee();
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         
        [System.Web.Http.HttpDelete]

         public HttpResponseMessage DeleteData([FromBody]Models.employee emp)
         {

             var data = employeeRepository.Delete(emp.employee_id);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Deleted Successfully" },format_type);
         }
        [HttpPost, ActionName("Post")]

        public HttpResponseMessage Post([FromBody]Models.employee emp) {
            bool check = employeeRepository.CheckUsername(emp.employee_user_name,emp.employee_email);
            if (check==true)
            {
                bool insert = employeeRepository.insert(emp);
                if (insert == true)
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Employee information is saved Successfully" }, format_type);
                }
                else
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Something is wrong!!!" }, format_type);
                }
            }
            else
            {
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Duplicate user name or email" }, format_type);
            }
        }
        [HttpPut, ActionName("Put")]

        public HttpResponseMessage Put([FromBody]Models.employee emp) {
                bool update = employeeRepository.UpdateEmployee(emp);

                if (update==true)
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Employee information is Updated Successfully" }, format_type);
                }
                else
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Something is wrong!!!" }, format_type);
                }
        }
        //[HttpPut, ActionName("UpdatePersonalData")]

        //public HttpResponseMessage UpdatePersonalData([FromBody]Models.employee emp)
        //{
        //    bool check = employeeRepository.CheckUsername(emp.employee_user_name, emp.employee_email);
        //    if (check == true)
        //    {
        //        bool update = employeeRepository.UpdateFulldataEmployee(emp);

        //        if (update == true)
        //        {
        //            var format_type = RequestFormat.JsonFormaterString();
        //            return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Employee information is Updated Successfully" }, format_type);
        //        }
        //        else
        //        {
        //            var format_type = RequestFormat.JsonFormaterString();
        //            return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Something is wrong!!!" }, format_type);
        //        }
        //    }
        //    else
        //    {
        //        var format_type = RequestFormat.JsonFormaterString();
        //        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Duplicate user name or email" }, format_type);
        //    }
        //}
            }
        }
