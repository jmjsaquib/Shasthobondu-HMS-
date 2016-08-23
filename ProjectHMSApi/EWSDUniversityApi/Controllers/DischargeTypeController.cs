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
    public class DischargeTypeController : ApiController
    {
        private IDischargeTypeRepository dischargeType;

        public DischargeTypeController()
        {
            this.dischargeType=new DischargeTypeRepository();
        }

        [HttpGet, ActionName("GetAllDischarType")]

        public HttpResponseMessage GetAllDischarType()
        {

            var data = dischargeType.GetAllDischarType();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetDischarTypeById")]

        public HttpResponseMessage GetRoomTypeById(int dischargeId)
        {
            var data = dischargeType.GetDischarTypeById(dischargeId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }

        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.discharge_type discharge)
        {
            try
            {
                if (string.IsNullOrEmpty(discharge.discharge_type_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Discharge Type name can not be empty" });
                }
                else
                {
                    bool chkDuplicate = dischargeType.CheckDuplicateForDischargeTypeName(discharge);
                    if (chkDuplicate == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Discharge Type Name Already Exists" }, formatter);

                    }
                    else
                    {
                        bool insertDischargeType = dischargeType.InsertDischargeType(discharge);
                        if (insertDischargeType == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Discharge Type Information  is saved successfully." }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Discharge Type Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.discharge_type discharge)
        {
            try
            {
                if (string.IsNullOrEmpty(discharge.discharge_type_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Discharge Type name can not be empty" });
                }
                else
                {
                    bool updateDischargeType = dischargeType.UpdateDischargeType(discharge);
                    if (updateDischargeType == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Discharge type Information  is updated successfully." }, formatter);
                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Discharge Type Information  is not updated successfully." }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.discharge_type discharge)
        {

            try
            {
                bool deleteDischargeType = dischargeType.DeleteDischargeType(discharge.discharge_type_id);
                if (deleteDischargeType == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Discharge Type Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Discharge type Information  is not deleted succesfully." }, formatter);
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
