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
    public class ShiftTypeController : ApiController
    {
        private IShiftTypeRepository shiftTypeRepository;

        public ShiftTypeController()
        {
            this.shiftTypeRepository=new ShiftTypeRepository();
        }
        [HttpGet, ActionName("GetAllShiftType")]

        public HttpResponseMessage GetAllShiftType(int hospital_id)
        {

            var data = shiftTypeRepository.GetAllShiftType(hospital_id);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetAllShiftTypebyId")]

        public HttpResponseMessage GetAllShiftTypebyId(int shiftTypeID)
        {
            var data = shiftTypeRepository.GetDischarTypeById(shiftTypeID);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.StronglyType.ShiftTypeModel shiftType)
        {
            try
            {
                if (string.IsNullOrEmpty(shiftType.shift_type_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Shift Type name can not be empty" });
                }
                else
                {
                    bool chkDuplicate = shiftTypeRepository.CheckDuplicateForShiftTypeName(shiftType);
                    if (chkDuplicate == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Shift Type Name Already Exists" }, formatter);

                    }
                    else
                    {
                        bool insertShiftType = shiftTypeRepository.InsertShiftType(shiftType);
                        if (insertShiftType == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Shift Type Information  is saved successfully." }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Shift Type Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.StronglyType.ShiftTypeModel shiftType)
        {
            try
            {
                if (string.IsNullOrEmpty(shiftType.shift_type_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Shift Type name can not be empty" });
                }
                else
                {
                    bool updateShiftType = shiftTypeRepository.UpdateShiftType(shiftType);
                    if (updateShiftType == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Shift type Information  is updated successfully." }, formatter);
                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Shift Type Information  is not updated successfully." }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.StronglyType.ShiftTypeModel shiftType)
        {

            try
            {
                bool deleteShiftType = shiftTypeRepository.DeleteShiftType(shiftType.shift_type_id);
                if (deleteShiftType == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Shift Type Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Shift type Information  is not deleted succesfully." }, formatter);
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
