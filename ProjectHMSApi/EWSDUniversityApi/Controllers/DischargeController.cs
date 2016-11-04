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
    public class DischargeController : ApiController
    {
        private IDischargeRepository dischargeRepository;

        public DischargeController()
        {
            this.dischargeRepository=new DischargeRepository();
        }
        [HttpGet, ActionName("GetAllDischarge")]

        public HttpResponseMessage GetAllDischarge(int hospital_id)
        {

            var data = dischargeRepository.GetAllDischarge(hospital_id);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllDischargeByDepartmentId")]

        public HttpResponseMessage GetAllDischargeByDepartmentId(int departmentId)
        {

            var data = dischargeRepository.GetAllDischargeByDepartmentId(departmentId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetDischarById")]

        public HttpResponseMessage GetDischarById(int dischargeId)
        {
            var data = dischargeRepository.GetDischarById(dischargeId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }

        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.StronglyType.DischargeModel discharge)
        {
            try
            {
                        bool insertDischarge = dischargeRepository.InsertDischarge(discharge);
                        if (insertDischarge == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Discharge Information  is saved successfully." }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "error", msg = "Discharge Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.discharge_type discharge)
        {
            try
            {
                bool updateDischarge = dischargeRepository.UpdateDischarge(discharge);
                if (updateDischarge == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Discharge Information  is updated successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Discharge Information  is not updated successfully." }, formatter);
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
