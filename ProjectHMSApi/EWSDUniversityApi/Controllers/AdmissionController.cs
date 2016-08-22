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
    public class AdmissionController : ApiController
    {
        private IAdmissionRepository admissionRepository;

        public AdmissionController()
        {
            this.admissionRepository=new AdmissionRepository();
        }
        [HttpGet, ActionName("GetAllAdmission")]

        public HttpResponseMessage GetAllAdmission()
        {

            var data = admissionRepository.GetAllAdmission();
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);
        }
        [HttpGet, ActionName("GetAdmissionById")]

        public HttpResponseMessage GetAdmissionById(int addmissionId)
        {
            var data = admissionRepository.addmissionId(addmissionId);
            var format = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format);

        }
        [HttpPost, ActionName("Post")]
        public HttpResponseMessage Post([FromBody]Models.admission admission)
        {
            try
            {
                bool chkDuplicate = admissionRepository.CheckDuplicateForbed(admission);
                if (chkDuplicate == false)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "error", msg = "Bed is assigned already..!!!" }, formatter);

                }
                else
                {
                    bool insertAdmission = admissionRepository.InsertAdmission(admission);
                    if (insertAdmission == true)
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "success", msg = "Admission Information  is saved successfully." }, formatter);
                    }
                    else
                    {
                        var formatter = RequestFormat.JsonFormaterString();
                        return Request.CreateResponse(HttpStatusCode.OK,
                            new Confirmation { output = "error", msg = "Admission Information  is not saved successfully." }, formatter);
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
    }
}
