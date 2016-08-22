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
    public class DoctorController : ApiController
    {
       private IDoctorRepository doctorRepository;

       public DoctorController()
        {
            this.doctorRepository = new DoctorRepository();
        }
       [HttpGet, ActionName("GetAllDoctor")]

       public HttpResponseMessage GetAllDoctor()
       {

           var data = doctorRepository.GetAllDoctor();
           var format = RequestFormat.JsonFormaterString();
           return Request.CreateResponse(HttpStatusCode.OK, data, format);
       }

       [HttpGet, ActionName("GetDoctorById")]

       public HttpResponseMessage GetDoctorById(int doctorId)
       {
           var data = doctorRepository.GetDoctorById(doctorId);
           var format = RequestFormat.JsonFormaterString();
           return Request.CreateResponse(HttpStatusCode.OK, data, format);

       }
       
       [HttpPost, ActionName("Post")]
       public HttpResponseMessage Post([FromBody]Models.doctor doc)
       {
           try
           {
               if (doc.employee_id==0)
               {
                   var format_type = RequestFormat.JsonFormaterString();
                   return Request.CreateResponse(HttpStatusCode.OK,
                  new Confirmation { output = "error", msg = "Please select a Doctor" });
               }
               else
               {
                   bool chkDuplicate = doctorRepository.CheckDuplicateForDoctorinfo(doc.employee_id,doc.department_id);
                   if (chkDuplicate != true)
                   {
                       var formatter = RequestFormat.JsonFormaterString();
                       return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Doctor Information is Already Exists" }, formatter);

                   }
                   else
                   {
                       bool insertDoctor = doctorRepository.InsertDoctor(doc);
                       if (insertDoctor == true)
                       {
                           var formatter = RequestFormat.JsonFormaterString();
                           return Request.CreateResponse(HttpStatusCode.OK,
                               new Confirmation { output = "success", msg = "Doctor Information  is saved successfully." }, formatter);
                       }
                       else
                       {
                           var formatter = RequestFormat.JsonFormaterString();
                           return Request.CreateResponse(HttpStatusCode.OK,
                               new Confirmation { output = "error", msg = "Doctor Information  is not saved successfully." }, formatter);
                       }
                   }

               }
           }
           catch (Exception ex)
           {

               var formatter = RequestFormat.JsonFormaterString();
               return Request.CreateResponse(HttpStatusCode.OK,
                new Confirmation { output = "error", msg = ex.ToString() }, formatter);
           }
       }
       [HttpPut, ActionName("Put")]
       public HttpResponseMessage Put([FromBody]Models.doctor doc)
       {
           try
           {
               if (string.IsNullOrEmpty(doc.doctor_fees)|| doc.doctor_appoinment_count==0 )
               {
                   var format_type = RequestFormat.JsonFormaterString();
                   return Request.CreateResponse(HttpStatusCode.OK,
                  new Confirmation { output = "error", msg = "Please Check your input" });
               }
               else
               {
                      bool updateDoctor = doctorRepository.updateDoctor(doc);
                      if (updateDoctor == true)
                       {
                           var formatter = RequestFormat.JsonFormaterString();
                           return Request.CreateResponse(HttpStatusCode.OK,
                               new Confirmation { output = "success", msg = "Doctor Information  is Updated successfully." }, formatter);
                       }
                       else
                       {
                           var formatter = RequestFormat.JsonFormaterString();
                           return Request.CreateResponse(HttpStatusCode.OK,
                               new Confirmation { output = "error", msg = "Doctor Information  is not Updated successfully." }, formatter);
                       }
                   

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
