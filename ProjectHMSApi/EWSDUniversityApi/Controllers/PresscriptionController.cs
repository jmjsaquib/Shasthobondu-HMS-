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
    public class PresscriptionController : ApiController
     {
         private IPresscriptionRepository presscriptionRepository;

         public PresscriptionController()
         {
             this.presscriptionRepository=new PresscriptionRepository();
         }
         [HttpGet, ActionName("GetAllPresscription")]
         public HttpResponseMessage GetAllPresscription()
         {

             var data = presscriptionRepository.GetAllPresscription();
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
