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
    public class WardController : ApiController
    {
         private IWardRepository wardRepository;

         public WardController()
        {

            this.wardRepository = new WardRepository();
        }
         [HttpGet, ActionName("GetAllWard")]

         public HttpResponseMessage GetAllWard()
         {

             var data = wardRepository.GetAllWard();
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);
         }

         [HttpGet, ActionName("GetWardById")]

         public HttpResponseMessage GetWardById(int wardId)
         {
             var data = wardRepository.GetWardById(wardId);
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);

         }

         [HttpPost, ActionName("Post")]
         public HttpResponseMessage Post([FromBody]Models.ward ward)
         {
             try
             {
                 if (string.IsNullOrEmpty(ward.ward_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Ward Name can not be empty" });
                 }
                 else
                 {
                     bool chkDuplicate = wardRepository.CheckDuplicateForWardName(ward.ward_name, ward.wing,ward.floor_id);
                     if (chkDuplicate == false)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Duplicate data. Check Ward name or wing.." }, formatter);

                     }
                     else
                     {
                         bool insertWard = wardRepository.InsertWard(ward);
                         if (insertWard == true)
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Ward Information  is saved successfully." }, formatter);
                         }
                         else
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "error", msg = "Ward Information  is not saved successfully." }, formatter);
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
         public HttpResponseMessage Put([FromBody]Models.ward ward)
         {
             try
             {
                 if (string.IsNullOrEmpty(ward.ward_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Ward name can not be empty" });
                 }
                 else
                 {
                     bool chkDuplicate = wardRepository.CheckDuplicateForWardNameUpdae(ward);
                     if (chkDuplicate==false)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Duplicate Data.Check Ward name or wing.." }, formatter);
                     }
                     else
                     {
                         bool updateward = wardRepository.UpdateWard(ward);
                         if (updateward == true)
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Ward Information  is updated successfully." }, formatter);
                         }
                         else
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                             new Confirmation { output = "error", msg = "Ward Information  is not updated successfully." }, formatter);
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

         [HttpDelete, ActionName("Delete")]
         public HttpResponseMessage Delete([FromBody]Models.ward ward)
         {

             try
             {
                 bool deleteWard = wardRepository.DeleteWard(ward.ward_id);
                 if (deleteWard == true)
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "Ward Information  is deleted successfully." }, formatter);
                 }
                 else
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "error", msg = "Ward Information  is not deleted succesfully." }, formatter);
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
