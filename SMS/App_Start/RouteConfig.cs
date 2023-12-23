using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "DashBoard", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Student",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Student", action = "DashBoard", id = UrlParameter.Optional }
           );
            routes.MapRoute(
            name: "Teacher",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Teachers", action = "DashBoard", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
