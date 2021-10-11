using rwa_projekt_katlija_2407.Models.Filters;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogInFilter());
        }
    }
}
