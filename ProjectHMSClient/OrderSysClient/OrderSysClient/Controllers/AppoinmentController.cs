using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using OrderSysClient.Reports.crystal_models;

namespace OrderSysClient.Controllers
{
    public class AppoinmentController : Controller
    {
        // GET: Appoinment
        public ActionResult Index()
        {
            string employee_user_name = (string)Session["employee_user_name"];
            string employee_id = (string)Session["employee_id"];
            string role_type_id = (string)Session["role_type_id"];
            string role_name = (string)Session["role_name"];
            string employee_name = (string)Session["employee_name"];
            string hospital_id = (string)Session["hospital_id"];

            if (employee_id == null || employee_user_name == null || role_type_id == null)
            {
                Response.Redirect("/Login/Index");
            }
            return View();
        }
        public ActionResult Add(int patientId)
        {
            string employee_user_name = (string)Session["employee_user_name"];
            string employee_id = (string)Session["employee_id"];
            string role_type_id = (string)Session["role_type_id"];
            string role_name = (string)Session["role_name"];
            string employee_name = (string)Session["employee_name"];
            string hospital_id = (string)Session["hospital_id"];

            if (employee_id == null || employee_user_name == null || role_type_id == null)
            {
                Response.Redirect("/Login/Index");
            }
            ViewBag.patientId = patientId;
            ViewBag.hospital_id = hospital_id;
            return View();
        }
        public void GetAppoinmentInvoice(int appoinmentId)
        {

            WebClient wbClient = new WebClient();
            string downloadString = "http://localhost:34667/" + "Appoinment/AppoinmentInvoiceCrystalReport?appoinmentId=" + appoinmentId;
            string apidata = wbClient.DownloadString(downloadString);
            //List<InvoiceReportModel> oPaymentModel = JsonConvert.DeserializeObject<List<InvoiceReportModel>>(apidata);

            List<AppoinmentInvoiceModel> oAppoinmnetModel = JsonConvert.DeserializeObject<List<AppoinmentInvoiceModel>>(apidata);

            using (var reportDocument = new ReportDocument())
            {
                reportDocument.Load(Server.MapPath("~/Reports/crystal_documents/AppoinmentInvoice.rpt"));
                reportDocument.SetDataSource(oAppoinmnetModel);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "AppoinmentPaymentInvoice_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
    }
}