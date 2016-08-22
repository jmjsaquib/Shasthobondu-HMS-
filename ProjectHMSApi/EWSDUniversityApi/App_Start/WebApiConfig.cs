using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HMSDevelopmentApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var enableCorsAttribute = new EnableCorsAttribute(" ",
            //                                      "Origin, Content-Type, Accept",
            //                                      "GET, PUT, POST, DELETE, OPTIONS");
            //config.EnableCors(enableCorsAttribute);

            //config.Routes.MapHttpRoute(
            //    name: "ControllersWithAction",
            //    routeTemplate: "{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
