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
    public class DoctorSchedularController : ApiController
    {
        private IDoctorSchedularRepository doctorSchedular;

        public DoctorSchedularController()
        {
            this.doctorSchedular=new DoctorSchedularRepository();
        }
        [HttpGet, ActionName("GetAllSchedular")]

        public HttpResponseMessage GetAllSchedular()
        {

            var data = doctorSchedular.GetAllSchedular();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        public HttpResponseMessage GetAllSchedularBydeparmentDoctorId(int departmentId,int doctorId)
        {

            var data = doctorSchedular.GetAllSchedularBydeparmentDoctorId(departmentId, doctorId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllSchedularDepartmentid")]

        public HttpResponseMessage GetAllSchedularDepartmentid(int deparmentId)
        {

            var data = doctorSchedular.GetAllSchedularDepartmentid(deparmentId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllSchedularByDoctorId")]

        public HttpResponseMessage GetAllSchedularByDoctorId(int doctorId)
        {
            var data = doctorSchedular.GetAllSchedularByDoctorId(doctorId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.StronglyType.RosterDetailsListModel rosterDetailsList)
        {

            try
            {
                bool insert = doctorSchedular.InsertSchedule(rosterDetailsList);
                if (insert == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Roster Information  is saved successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Roster Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.doctor_schedule doctorSchedule)
        {
            try
            {
                bool update = doctorSchedular.UpdateSchedule(doctorSchedule);
                if (update == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Roster Information  is updated successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "success", msg = "Roster Information  is not updated successfully." }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.doctor_schedule doctorSchedule)
        {

            try
            {
                bool delete = doctorSchedular.DeleteRoster(doctorSchedule.doctor_schdule_id);
                if (delete == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Roster Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Roster Information  is not deleted succesfully." }, formatter);
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
