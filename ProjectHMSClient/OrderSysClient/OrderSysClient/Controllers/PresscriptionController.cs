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
    public class PresscriptionController : Controller
    {
        // GET: Presscription
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
            ViewBag.hospital_id = hospital_id;
            return View();
        }
        public ActionResult View(int presscritionId)
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
            ViewBag.presscriptionId = presscritionId;
            ViewBag.hospital_id = hospital_id;
            return View();
        }
        public ActionResult Medicine()
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
            ViewBag.hospital_id = hospital_id;

            return View();
        }
        public ActionResult TestType()
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
            ViewBag.hospital_id = hospital_id;

            return View();
        }
        public ActionResult NewPresscription(int patientId,int appoinmentId)
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
            ViewBag.parientId = patientId;
            ViewBag.appoinmentId = appoinmentId;
            ViewBag.role_type_id = role_type_id;
            ViewBag.role_name = role_name;
            ViewBag.hospital_id = hospital_id;
            return View();
        }
        public ActionResult OldPresscription(int presscriptionId, int patientId)
        {
            string employee_user_name = (string)Session["employee_user_name"];
            string employee_id = (string)Session["employee_id"];
            string role_type_id = (string)Session["role_type_id"];
            string role_name = (string)Session["role_name"];
            string employee_name = (string)Session["employee_name"];
            string hospital_id = (string)Session["hospital_id"];

            ViewBag.presscriptionId = presscriptionId;
            ViewBag.patientId = patientId;
            ViewBag.hospital_id = hospital_id;

            return View();
        }
        public ActionResult PatientHistory(int patientId)
        {
            string employee_user_name = (string)Session["employee_user_name"];
            string employee_id = (string)Session["employee_id"];
            string role_type_id = (string)Session["role_type_id"];
            string role_name = (string)Session["role_name"];
            string employee_name = (string)Session["employee_name"];
            string hospital_id = (string)Session["hospital_id"];
            ViewBag.parientId = patientId;
            ViewBag.hospital_id = hospital_id;

            return View();
        }
        public ActionResult PresscriptionPrint()
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
            ViewBag.hospital_id = hospital_id;

            return View();
        }
        public void GetPresscriptionCrystalReport(int presscriptionId)
        {

            WebClient wbClient = new WebClient();
            string downloadString = "http://localhost:34667/" + "Utility/GetpresscriptionCrystalReport?presscriptionId=" + presscriptionId;
            string apidata = wbClient.DownloadString(downloadString);
            //List<InvoiceReportModel> oPaymentModel = JsonConvert.DeserializeObject<List<InvoiceReportModel>>(apidata);

            List<PresscriptionCrystalReportModel> oPresscriptionCrystalReportModels = JsonConvert.DeserializeObject<List<PresscriptionCrystalReportModel>>(apidata);
            oPresscriptionCrystalReportModels.Distinct().ToList();
            using (var reportDocument = new ReportDocument())
            {
                reportDocument.Load(Server.MapPath("~/Reports/crystal_documents/PresscriptionCrystalReport.rpt"));
                reportDocument.SetDataSource(oPresscriptionCrystalReportModels);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "PresscriptionCrystalReport_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
    }
}