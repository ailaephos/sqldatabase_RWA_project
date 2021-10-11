using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rwa_projekt_katlija_2407
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "FetchCit",
              url: "FetchCities/{ID}",
              defaults: new { controller = "Customer", action = "FetchCities", ID = UrlParameter.Optional }
              );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { id = UrlParameter.Optional }
               );

        }
    }
}
