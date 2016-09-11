using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HMSDevelopmentApi.Models;
using HMSDevelopmentApi.Models.IRepository;
using HMSDevelopmentApi.Models.Repository;
using Newtonsoft.Json;

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class DoctorRosterController : ApiController
    {
        private IDoctorRosterRepository doctorRoster;

        public DoctorRosterController()
        {
            this.doctorRoster=new DoctorRosterRepository();
        }
        [HttpGet, ActionName("GetAllRoster")]

        public HttpResponseMessage GetAllRoster()
        {

            var data = doctorRoster.GetAllRoster();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllRosterByDepartmentId")]

        public HttpResponseMessage GetAllRosterByDepartmentId(int deparmentId)
        {

            var data = doctorRoster.GetAllRosterByDepartmentId(deparmentId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAllRosterByDoctorId")]

        public HttpResponseMessage GetAllRosterByDoctorId(int doctorId)
        {
            var data = doctorRoster.GetAllRosterByDoctorId(doctorId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpGet, ActionName("Post")]
        public HttpResponseMessage Post(string Title,DateTime Start,DateTime End, bool IsAllDay, string RecurrenceException,string RecurrenceRule, int doctor_id, int department_id)
        {

            try
            {
                if (string.IsNullOrEmpty(Title))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Roster title can not be empty" });
                }
                else
                {
                    Models.doctor_roster odDoctorRoster = new doctor_roster
                    {
                        Title = Title,
                        Start = Start,
                        End = End,
                        IsAllDay = Convert.ToString(IsAllDay),
                        RecurrenceException = RecurrenceException,
                        RecurrenceRule = RecurrenceRule,
                        doctor_id = doctor_id,
                        department_id = department_id

                    };
                    bool chkDuplicate = doctorRoster.CheckDuplicateForRosterName(odDoctorRoster);
                    if (chkDuplicate == false)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Roster is Already Exists" }, formatter);

                    }
                    else
                    {
                        bool insert = doctorRoster.InsertRoster(odDoctorRoster);
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
                                new Confirmation { output = "success", msg = "Roster Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.doctor_roster odDoctorRoster)
        {
            try
            {
                if (string.IsNullOrEmpty(odDoctorRoster.Title))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "Roster title can not be empty" });
                }
                else
                {
                    bool update = doctorRoster.UpdateRoster(odDoctorRoster);
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

            }
            catch (Exception ex)
            {

                var formatter = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = ex.ToString() }, formatter);
            }
        }

        [HttpDelete, ActionName("Delete")]
        public HttpResponseMessage Delete([FromBody]Models.doctor_roster odDoctorRoster)
        {

            try
            {
                bool delete = doctorRoster.DeleteRoster(odDoctorRoster.doctor_roster_id);
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
