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
    public class RoomTypeController : ApiController
    {
         private IRoomTypeRepository roomTypeRepository;

         public RoomTypeController()
        {

            this.roomTypeRepository = new RoomTypeRepository();
        }

        [HttpGet, ActionName("GetAllRoomType")]

        public HttpResponseMessage GetAllRoomType()
        {

            var data = roomTypeRepository.GetAllRoomType();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetRoomTypeById")]

        public HttpResponseMessage GetRoomTypeById(int roomTypeId)
        {
            var data = roomTypeRepository.GetRoomTypeById(roomTypeId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }

        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.room_type roomType)
        {
            try
            {
                if (string.IsNullOrEmpty(roomType.room_type_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Room Type name can not be empty" });
                }
                else
                {
                    bool chkDuplicate = roomTypeRepository.CheckDuplicateForRoomTypeName(roomType.room_type_id, roomType.room_type_name);
                    if (chkDuplicate == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Room Type Name Already Exists" }, formatter);

                    }
                    else
                    {
                        bool insertRoomTye = roomTypeRepository.InsertRoomType(roomType);
                        if (insertRoomTye == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Room Type Information  is saved successfully." }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Room Type Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.room_type roomType)
        {
            try
            {
                if (string.IsNullOrEmpty(roomType.room_type_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Room Type name can not be empty" });
                }
                else
                {
                    bool updateRoomType = roomTypeRepository.UpdateRoomType(roomType);
                    if (updateRoomType == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Room type Information  is updated successfully." }, formatter);
                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Room Type Information  is not updated successfully." }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.room_type roomType)
        {

            try
            {
                bool deleteRoomType = roomTypeRepository.DeleteRoomType(roomType.room_type_id);
                if (deleteRoomType == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Room Type Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Room type Information  is not deleted succesfully." }, formatter);
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
