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
    public class ReportingController : Controller
    {
        // GET: Reporting
        public ActionResult Patient()
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
        public ActionResult AdmittedPatient()
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
        public void Transaction()
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
            WebClient wbClient = new WebClient();
            string downloadString = "http://localhost:34667/" + "Reporting/GetAllTransactionCrystalReport?hospital_id=" + hospital_id;
            string apidata = wbClient.DownloadString(downloadString);
            //List<InvoiceReportModel> oPaymentModel = JsonConvert.DeserializeObject<List<InvoiceReportModel>>(apidata);

            List<TransactionReportModel> oTransactionModel = JsonConvert.DeserializeObject<List<TransactionReportModel>>(apidata);

            using (var reportDocument = new ReportDocument())
            {
                reportDocument.Load(Server.MapPath("~/Reports/crystal_documents/TransactionReport.rpt"));
                reportDocument.SetDataSource(oTransactionModel);
                reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "AnnualTransactionReport" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm_tt"));
            }
        }
        public ActionResult Doctor()
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
    }
}