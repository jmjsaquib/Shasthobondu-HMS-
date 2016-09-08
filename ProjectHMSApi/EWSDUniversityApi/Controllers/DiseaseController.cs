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
    public class DiseaseController : ApiController
     {
         private IDiseaseRepository diseaseRepository;

         public DiseaseController()
         {
             this.diseaseRepository=new DiseaseRepository();
         }
         [HttpGet, ActionName("GetAllDisease")]

         public HttpResponseMessage GetAllDisease()
         {

             var data = diseaseRepository.GetAllDisease();
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);
         }

         [HttpGet, ActionName("GetAllDiseaseById")]

         public HttpResponseMessage GetAllDiseaseById(int diseaseId)
         {
             var data = diseaseRepository.GetAllDiseaseById(diseaseId);
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);

         }

         [HttpPost, ActionName("Post")]
         public HttpResponseMessage Post([FromBody]Models.disease disease)
         {
             try
             {
                 if (string.IsNullOrEmpty(disease.disease_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Disease name can not be empty" });
                 }
                 else
                 {
                     bool chkDuplicate = diseaseRepository.CheckDuplicateFoDiseaseName(disease);
                     if (chkDuplicate == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Diease Name Already Exists" }, formatter);

                     }
                     else
                     {
                         bool insert = diseaseRepository.InsertDiease(disease);
                         if (insert == true)
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Diease Information  is saved successfully." }, formatter);
                         }
                         else
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Diease Information  is not saved successfully." }, formatter);
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
         public HttpResponseMessage Put([FromBody]Models.disease disease)
         {
             try
             {
                 if (string.IsNullOrEmpty(disease.disease_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Disease name can not be empty" });
                 }
                 else
                 {
                     bool update = diseaseRepository.UpdateDiease(disease);
                     if (update == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                             new Confirmation { output = "success", msg = "Diease Information  is updated successfully." }, formatter);
                     }
                     else
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "Diease Information  is not updated successfully." }, formatter);
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
         public HttpResponseMessage Delete([FromBody]Models.disease disease)
         {

             try
             {
                 bool delete = diseaseRepository.DeleteDiease(disease);
                 if (delete == true)
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "Diease Information  is deleted successfully." }, formatter);
                 }
                 else
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "error", msg = "Diease Information  is not deleted succesfully." }, formatter);
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
