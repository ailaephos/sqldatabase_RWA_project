using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rwa_projekt_katlija_2407.Models.Filters
{
    public class LogInFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
                    HttpCookie cookie = filterContext.HttpContext.Request.Cookies["userData"];
            if (cookie == null && filterContext.HttpContext.Request.RawUrl != "/LogIn/Index")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "LogIn" }, { "Action", "Index" } });
            }

            base.OnActionExecuting(filterContext);

        }
    }
}