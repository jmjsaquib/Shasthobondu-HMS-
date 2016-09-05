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
    public class AppoinmentController : ApiController
    {
        private IAppoinmentRepository appoinmentRepository;

        public AppoinmentController()
        {
            this.appoinmentRepository=new AppoinmentRepository();
        }
        [HttpGet, ActionName("GetAllAppoinment")]

        public HttpResponseMessage GetAllAppoinment()
        {

            var data = appoinmentRepository.GetAllAppoinment();
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
        [HttpGet, ActionName("AppoinmentListForDoctor")]

        public HttpResponseMessage AppoinmentListForDoctor(int doctorId, string expectedDate)
        {

            var data = appoinmentRepository.AppoinmentListForDoctor(doctorId, expectedDate);
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
        [HttpGet, ActionName("AppoinmentValiadationForDoctor")]

        public HttpResponseMessage AppoinmentValiadationForDoctor(int doctorId,string today)
        {

            var data = appoinmentRepository.AppoinmentValiadationForDoctor(doctorId, today);
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }

        [System.Web.Http.HttpDelete]

        public HttpResponseMessage Delete(int appoinmentId)
        {

            var data = appoinmentRepository.Delete(appoinmentId);
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Deleted Successfully" }, format_type);
        }
        [HttpPost, ActionName("Post")]

        public HttpResponseMessage Post([FromBody]Models.StronglyType.AppoinmentValidationModel appo)
        {

            var insert = appoinmentRepository.insert(appo);
                if (insert != null)
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Appoinment information is saved Successfully",returnvalue = insert}, format_type);
                }
                else
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Something is wrong!!!" }, format_type);
                }
        }
    }
}
