using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HMSDevelopmentApi.Controllers{
     [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class DivisionController : ApiController
    {
        private IDivisionRepository divisionRepository;
        public DivisionController(){
            this.divisionRepository=new DivisionRepository();
        }
        [HttpGet, ActionName("GetAllDivision")]

         public HttpResponseMessage GetAllDivision()
         {

             var data = divisionRepository.GetAllDivision();
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);
         }

         [HttpGet, ActionName("GetDivisionById")]

         public HttpResponseMessage GetDivisionById(int divisionid)
         {
             var data = divisionRepository.GetDivisionById(divisionid);
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);

         }

         [HttpPost, ActionName("Post")]
         public HttpResponseMessage Post([FromBody]Models.division oDivision)
         {
             try
             {
                 if (string.IsNullOrEmpty(oDivision.division_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Division name can not be empty" });
                 }
                 else
                 {
                     bool chkDuplicate = divisionRepository.CheckDuplicateForDivisionName(oDivision.division_name);
                     if (chkDuplicate == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Division Name Already Exists" }, formatter);

                     }
                     else
                     {
                         bool insertDivision = divisionRepository.InsertDivision(oDivision);
                         if (insertDivision == true)
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Division Information  is saved successfully." }, formatter);
                         }
                         else
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Division Information  is not saved successfully." }, formatter);
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
         public HttpResponseMessage Put([FromBody]Models.division oDivision)
         {
             try
             {
                 if (string.IsNullOrEmpty(oDivision.division_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Division name can not be empty" });
                 }
                 else
                 {
                     bool updateDivision = divisionRepository.UpdateDivision(oDivision);
                     if (updateDivision == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                             new Confirmation { output = "success", msg = "Division Information  is updated successfully." }, formatter);
                     }
                     else
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "Division Information  is not updated successfully." }, formatter);
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

         [HttpDelete, ActionName("Delete")]
         public HttpResponseMessage Delete([FromBody]Models.division oDivision)
         {

             try
             {
                 bool deleteDivision = divisionRepository.DeleteDivision(oDivision.division_id);
                 if (deleteDivision == true)
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "Division Information  is deleted successfully." }, formatter);
                 }
                 else
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "error", msg = "Division Information  is not deleted succesfully." }, formatter);
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
