﻿using HMSDevelopmentApi.Models;
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
    public class PresscriptionController : ApiController
     {
         private IPresscriptionRepository presscriptionRepository;

         public PresscriptionController()
         {
             this.presscriptionRepository=new PresscriptionRepository();
         }
         [HttpGet, ActionName("GetAllPresscription")]
         public HttpResponseMessage GetAllPresscription(string status,int hospital_id)
         {

             var data = presscriptionRepository.GetAllPresscription(status, hospital_id);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         [HttpGet, ActionName("GetAllPresscriptionOfCurrentDate")]
         public HttpResponseMessage GetAllPresscriptionOfCurrentDate(string currentDate)
         {

             var data = presscriptionRepository.GetAllPresscriptionOfCurrentDate(currentDate);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         [HttpGet, ActionName("GetAllPresscriptionByDoctorID")]
         public HttpResponseMessage GetAllPresscriptionByDoctorID(int employeeId, string today)
         {

             var data = presscriptionRepository.GetAllPresscriptionByDoctorID(employeeId, today);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         [HttpGet, ActionName("GetAllPresscriptionByPresscriptionId")]
         public HttpResponseMessage GetAllPresscriptionByPresscriptionId(int presscriptionid)
         {

             var data = presscriptionRepository.GetAllPresscriptionByPresscriptionId(presscriptionid);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         [HttpGet, ActionName("GetAllPresscriptionBypatientId")]
         public HttpResponseMessage GetAllPresscriptionBypatientId(int patientId)
         {

             var data = presscriptionRepository.GetAllPresscriptionBypatientId(patientId);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         [HttpGet, ActionName("GetPresscriptionDetails")]
         public HttpResponseMessage GetPresscriptionDetails(int patientId,int presscriptionId)
         {

             var data = presscriptionRepository.GetPresscriptionDetails(patientId, presscriptionId);
             var format_type = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
         }
         [HttpPost, ActionName("Post")]

         public HttpResponseMessage Post([FromBody]Models.StronglyType.PresscriptionDataModel press)
         {

             bool insertdata = presscriptionRepository.insert(press);
             if (insertdata == true)
             {
                 var format_type = RequestFormat.JsonFormaterString();
                 return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Presscription information is saved Successfully" }, format_type);
             }
             else
             {
                 var format_type = RequestFormat.JsonFormaterString();
                 return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Something is wrong!!!" }, format_type);
             }
         }
     }
}
