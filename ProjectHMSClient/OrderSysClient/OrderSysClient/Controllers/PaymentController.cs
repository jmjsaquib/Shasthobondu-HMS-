using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using OrderSysClient.Reports.crystal_models;

namespace OrderSysClient.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
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
        public ActionResult Add(int patientId, int admissionId)
        {
            string employee_user_name = (string)Session["employee_user_name"];
            string employee_id = (string)Session["employee_id"];
            string role_type_id = (string)Session["role_type_id"];
            string role_name = (string)Session["role_name"];
            string employee_name = (string)Session["employee_name"];
            string hospital_id = (string)Session["hospital_id"];
            ViewBag.patientId = patientId;
            ViewBag.admissionId = admissionId;
            ViewBag.hospital_id = hospital_id;
            return View();
        }
        //To create crystal report of Invoice. (jakaria...)
        public void GetPaymentInvoice(int paymentId)
        {

            WebClient wbClient = new WebClient();
            string downloadString = "http://localhost:34667/" + "Utility/GetInvoiceCrystalReport?payment_id=" + paymentId;
            string apidata = wbClient.DownloadString(downloadString);
            //List<InvoiceReportModel> oPaymentModel = JsonConvert.DeserializeObject<List<InvoiceReportModel>>(apidata);

            List<InvoiceReportModel> oPaymentModel = JsonConvert.DeserializeObject<List<InvoiceReportModel>>(apidata);

            using (var reportDocument = new ReportDocument())
            {
                reportDocument.Load(Server.MapPath("~/Reports/crystal_documents/Invoice.rpt"));
                reportDocument.SetDataSource(oPaymentModel);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "AdmissionPaymentInvoice_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public ActionResult InvoiceList()
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
    }
    
}