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
    public class RoomController : ApiController
    {
         private IRoomRepository roomRepository;

         public RoomController()
        {

            this.roomRepository = new RoomRepository();
        }
         [HttpGet, ActionName("GetAllRoom")]

         public HttpResponseMessage GetAllRoom()
         {

             var data = roomRepository.GetAllRoom();
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);
         }

         [HttpGet, ActionName("GetRoomById")]

         public HttpResponseMessage GetRoomById(int roomId)
         {
             var data = roomRepository.GetRoomById(roomId);
             var format = RequestFormat.JsonFormaterString();
             return Request.CreateResponse(HttpStatusCode.OK, data, format);

         }

         [HttpPost, ActionName("Post")]
         public HttpResponseMessage Post([FromBody]Models.room oroom)
         {
             try
             {
                 if (string.IsNullOrEmpty(oroom.room_no))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Room no can not be empty" });
                 }
                 else
                 {
                     bool chkDuplicate = roomRepository.CheckDuplicateForRoomName(oroom.room_no);
                     if (chkDuplicate == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Room No Already Exists" }, formatter);

                     }
                     else
                     {
                         bool insertRoom = roomRepository.InsertRoom(oroom);
                         if (insertRoom == true)
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Room Information  is saved successfully." }, formatter);
                         }
                         else
                         {
                             var formatter = RequestFormat.JsonFormaterString();
                             return Request.CreateResponse(HttpStatusCode.OK,
                                 new Confirmation { output = "success", msg = "Room Information  is not saved successfully." }, formatter);
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
         public HttpResponseMessage Put([FromBody]Models.room oroom)
         {
             try
             {
                 if (string.IsNullOrEmpty(oroom.room_no))
                 {
                     var format_type = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "Room No can not be empty" });
                 }
                 else
                 {
                     bool updateRoom = roomRepository.UpdateRoom(oroom);
                     if (updateRoom == true)
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                             new Confirmation { output = "success", msg = "Room Information  is updated successfully." }, formatter);
                     }
                     else
                     {
                         var formatter = RequestFormat.JsonFormaterString();
                         return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "error", msg = "Room Information  is not updated successfully." }, formatter);
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
         public HttpResponseMessage Delete([FromBody]Models.room orrom)
         {

             try
             {
                 bool deleteRoom = roomRepository.DeleteRoom(orrom.room_id);
                 if (deleteRoom == true)
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "success", msg = "Room Information  is deleted successfully." }, formatter);
                 }
                 else
                 {
                     var formatter = RequestFormat.JsonFormaterString();
                     return Request.CreateResponse(HttpStatusCode.OK,
                         new Confirmation { output = "error", msg = "Room Information  is not deleted succesfully." }, formatter);
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
