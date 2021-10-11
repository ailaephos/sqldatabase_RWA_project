using rwa_projekt_katlija_2407.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
      
                return View();
         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = new HttpCookie("userData");
                cookie["user"] = user.Username;
                cookie["pass"] = user.Password;
                cookie.Expires = DateTime.Now.AddMinutes(20);
                Response.Cookies.Add(cookie);
                return Redirect("~/Customers.aspx");
            }
            else
            {
                return View(user);
            }
        }
    }
}