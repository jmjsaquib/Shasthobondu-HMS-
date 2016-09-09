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
    public class DepartmentController : ApiController
    {
        private IDepartmentRepository departmentRepository;

        public DepartmentController()
        {

            this.departmentRepository = new DepartmentRepository();
        }

        [HttpGet, ActionName("GetAllDepartment")]

        public HttpResponseMessage GetAllDepartment()
        {

            var data = departmentRepository.GetAllDepartment();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }

        [HttpGet, ActionName("GetDepartmentById")]

        public HttpResponseMessage GetDepartmentById(int departmentId)
        {
            var data = departmentRepository.GetAlldepartmentById(departmentId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }

        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.department oDepartment)
        {
            try
            {
                if (string.IsNullOrEmpty(oDepartment.department_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "User name can not be empty" });
                }
                else
                {
                    bool chkDuplicate = departmentRepository.CheckDuplicateForDepartmentName(oDepartment.department_id, oDepartment.department_name);
                    if (chkDuplicate == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Department Name Already Exists" }, formatter);

                    }
                    else
                    {
                        Models.department insert = new Models.department
                        {
                            department_name = oDepartment.department_name,
                            color_id = oDepartment.color_id
                        };
                        bool insertDepartment = departmentRepository.InsertDepartment(insert);
                        if (insertDepartment == true)
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Department Information  is saved successfully." }, formatter);
                        }
                        else
                        {
                            var formatter = RequestFormat.JsonFormaterString();
                            return Request.CreateResponse(HttpStatusCode.OK,
                                new Confirmation { output = "success", msg = "Department Information  is not saved successfully." }, formatter);
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
        public HttpResponseMessage Put([FromBody]Models.department oDepartment)
        {
            try
            {
                if (string.IsNullOrEmpty(oDepartment.department_name))
                {
                    var format_type = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                   new Confirmation { output = "error", msg = "User name can not be empty" });
                }
                else
                {

                    Models.department update = new Models.department
                    {
                        department_id = oDepartment.department_id,
                        department_name = oDepartment.department_name,
                        color_id = oDepartment.color_id
                    };
                    bool updateDepartment = departmentRepository.UpdateDepartment(update);
                    if (updateDepartment == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Department Information  is updated successfully." }, formatter);
                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Department Information  is not updated successfully." }, formatter);
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
        public HttpResponseMessage Delete([FromBody]Models.department oDepartment)
        {

            try
            {
                bool deleteDepartment = departmentRepository.DeleteDepartment(oDepartment.department_id);
                if (deleteDepartment == true)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "success", msg = "Department Information  is deleted successfully." }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Department Information  is not deleted succesfully." }, formatter);
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
