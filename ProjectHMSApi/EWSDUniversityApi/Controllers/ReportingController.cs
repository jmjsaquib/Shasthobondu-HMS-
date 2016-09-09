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
    public class ReportingController : ApiController
    {
        private IReportingRepository reportingRepository;

        public ReportingController()
        {
            this.reportingRepository=new ReportingRepository();
        }
        [HttpGet, ActionName("GetAllPatientInfo")]
        public HttpResponseMessage GetAllPatientInfo(string status)
        {

            var data = reportingRepository.GetAllPatientInfo(status);
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
        [HttpGet, ActionName("GetAllPatientTrackingByStatus")]
        public HttpResponseMessage GetAllPatientTrackingByStatus(string track)
        {

            var data = reportingRepository.GetAllPatientTrackingByStatus(track);
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
        [HttpGet, ActionName("GetAllTransactionCrystalReport")]
        public HttpResponseMessage GetAllTransactionReport()
        {

            var data = reportingRepository.GetAllTransactionCrystalReport();
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
        [HttpGet, ActionName("GetAllDailyTransaction")]
        public HttpResponseMessage GetAllDailyTransaction(int departmentId, string today)
        {

            var data = reportingRepository.GetAllDailyTransaction(departmentId, today);
            var format_type = RequestFormat.JsonFormaterString();
            return Request.CreateResponse(HttpStatusCode.OK, data, format_type);
        }
    }
}
