using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OrderSysClient.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public static string httpRequest()
        {
            string http = "http://localhost:34667/";
            return http;
        }

        public ActionResult RedirectToAdmin()
        {
            string employee_user_name = (string)Request.QueryString["employee_user_name"];
            string employee_id = (string)Request.QueryString["employee_id"];
            string role_type_id = (string)Request.QueryString["role_type_id"];
            string role_name = (string)Request.QueryString["role_name"];
            string employee_name = (string)Request.QueryString["employee_name"];
            string hospital_id = (string)Request.QueryString["hospital_id"];
            string hospital_name = (string)Request.QueryString["hospital_name"];
            //string hospital_name = "";
            //try
            //{
            //    WebClient wbClient = new WebClient();
            //    string url = httpRequest();
            //    string data = wbClient.DownloadString(url + "MetaInfo/GetMetainfoById?hospitalId=" + hospital_id);
            //    hospital_name = (String)JsonConvert.DeserializeObject(data, (typeof(string)));

            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}

            Session["employee_user_name"] = employee_user_name;
            Session["employee_id"] = employee_id;
            Session["role_type_id"] = role_type_id;
            Session["role_name"] = role_name;
            Session["employee_name"] = employee_name;
            Session["hospital_name"] = hospital_name;
            Session["hospital_id"] = hospital_id;

            return Redirect("/Dashboard/Index");

        }
        public ActionResult RedrictToLogin()
        {

            Session.Clear();
            
            Session.Abandon();
            return Redirect("/login/Index");
        }
    }
}