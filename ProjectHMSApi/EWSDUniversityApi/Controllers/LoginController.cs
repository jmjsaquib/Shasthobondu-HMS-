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
using HMSDevelopmentApi.Models;

namespace HMSDevelopmentApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        private ILoginRepository loginRepository;

        public LoginController()
        {
            this.loginRepository=new LoginRepository();
        }

        [HttpGet, ActionName("GetuserLogin")]

        public HttpResponseMessage GetuserLogin(string employee_user_name, string employee_password)
        {
            if (string.IsNullOrEmpty(employee_user_name))
            {
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "User Name can not be empty" });
            }else if (string.IsNullOrEmpty(employee_password))
            {
                var format_type = RequestFormat.JsonFormaterString();
                return Request.CreateResponse(HttpStatusCode.OK,
                    new Confirmation { output = "error", msg = "password can not be empty" });
            }
            else
            {
                var login = loginRepository.GetLogin(employee_user_name,employee_password);
                if (login!=null)
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK, new Confirmation { output = "success", msg = "Login Successfully", returnvalue = login }, formatter);
                }
                else
                {
                    var formatter = RequestFormat.JsonFormaterString();
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new Confirmation { output = "error", msg = "Please enter valid username or password" }, formatter);
                }
            }
        }
    }
}
