using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderSysClient.Controllers
{
    public class AdmissionController : Controller
    {
        // GET: Admission
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
        public ActionResult Edit(int admissionId)
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
            ViewBag.admissionId = admissionId;
            ViewBag.hospital_id = hospital_id;

            return View();
        }
        public ActionResult Add(int presscritionId, int? patientId)
        {
            string employee_user_name = (string)Session["employee_user_name"];
            string employee_id = (string)Session["employee_id"];
            string role_type_id = (string)Session["role_type_id"];
            string role_name = (string)Session["role_name"];
            string employee_name = (string)Session["employee_name"];
            string hospital_id = (string)Session["hospital_id"];


            ViewBag.presscritionId = presscritionId;
            ViewBag.patientId = patientId;
            ViewBag.hospital_id = hospital_id;

            return View();
        }
    }
}