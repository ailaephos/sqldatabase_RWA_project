using rwa_projekt_katlija_2407.Models;
using rwa_projekt_katlija_2407.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Controllers
{
    public class CustomerController : Controller
    {
        [HandleError(View = "NotFound")]
        public ActionResult ShowMoreInfo(int id)
        {
            var num = Repo.GetMaxCustomers();
            var customer = Repo.ShowMoreInfo(id);
            var model = new MoreInfo
            {
                Customer = customer,
                ChangeCustomer = num
        };

            return View(model);

        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCustomerVM editCustomerVM)
        {
            if (ModelState.IsValid) { 
                var customer = editCustomerVM.Customer;                           
                Repo.UpdateCustomer(customer);
                var id = customer.IDKupac;
                return RedirectToAction(actionName: "ShowMoreInfo", routeValues: new { id = id });
            }
            else
            {
                return View(editCustomerVM);
            }
        }
            
        [HttpGet]
        [HandleError(View = "NotFound")]
        public ActionResult Edit(int id)
        {
            var customer = Repo.ShowMoreInfo(id);
            List<State> states = Repo.FillDDLStates().ToList();
            List<City> cities = Repo.FillDDLCities(customer.DrzavaID).ToList();
            var model = new EditCustomerVM
            {
                Customer = customer,
                StatesList = new SelectList(states, "IDDrzava", "Naziv"),
                CitiesList = new SelectList(cities, "IDGrad", "Naziv")

            };
            return View(model);
        }
        [HttpGet]
        public JsonResult FetchCities(int ID)
        {
           
            var data = Repo.FillDDLCities(ID)        
                .Select(city => new { Value = city.IDGrad, Text = city.Naziv });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult FetchCustomer(int id)
        {
            var num = Repo.GetMaxCustomers();
            var customer = Repo.ShowMoreInfo(id);
            var model = new MoreInfo
            {
                Customer = customer,
                ChangeCustomer = num
            };
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Back()
        {
            return Redirect("~/Customers.aspx");
        }

    }
}