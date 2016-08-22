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

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DistrictController : ApiController
    {
        private IDistrictRepository districtRepository;
        public DistrictController()
        {
            this.districtRepository=new DistrictRepository();
        }
        [HttpGet, ActionName("GetAllDistrict")]

         public HttpResponseMessage GetAllDistrict()
         {

             var data = districtRepository.GetAllDistrict();
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);
         }

         [HttpGet, ActionName("GetDistrictById")]

         public HttpResponseMessage GetDistrictById(int districtid)
         {
             var data = districtRepository.GetDistrictById(districtid);
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);

         }

         [HttpPost, ActionName("Post")]
         public HttpResponseMessage Post([FromBody]Models.district oDistrict)
         {
             try
             {
                 if (string.IsNullOrEmpty(oDistrict.district_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "District name can not be empty" });
                 }
                 else
                 {
                     bool chkDuplicate = districtRepository.CheckDuplicateForDistrictName(oDistrict.district_name);
                     if (chkDuplicate == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "District Name Already Exists" }, formatter);

                     }
                     else
                     {
                         bool insertDistrict = districtRepository.InsertDistrict(oDistrict);
                         if (insertDistrict == true)
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "District Information  is saved successfully." }, formatter);
                         }
                         else
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "District Information  is not saved successfully." }, formatter);
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
         public HttpResponseMessage Put([FromBody]Models.district oDistrict)
         {
             try
             {
                 if (string.IsNullOrEmpty(oDistrict.district_name))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "District name can not be empty" });
                 }
                 else
                 {
                     bool updateDistrict = districtRepository.UpdateDistrict(oDistrict);
                     if (updateDistrict == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                             new Confirmation { output = "success", msg = "District Information  is updated successfully." }, formatter);
                     }
                     else
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "District Information  is not updated successfully." }, formatter);
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
         public HttpResponseMessage Delete([FromBody]Models.district oDistrict)
         {

             try
             {
                 bool deleteDistrict = districtRepository.DeleteDistrict(oDistrict.district_id);
                 if (deleteDistrict == true)
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "District Information  is deleted successfully." }, formatter);
                 }
                 else
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "error", msg = "District Information  is not deleted succesfully." }, formatter);
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
