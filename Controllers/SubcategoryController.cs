using rwa_projekt_katlija_2407.Models;
using rwa_projekt_katlija_2407.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: Subcategory
        [HandleError(View = "NotFound")]
        public ActionResult ShowAllSubcategories()
        {
            var model = Repo.GetSubcategories();
            return View(model);
        }
        [HttpGet]
        [HandleError(View = "NotFound")]
        public ActionResult Edit(int id)
        {
            var subcategory = Repo.GetSubcategory(id);
            List<Category> list = Repo.GetCategories().ToList();
            var model = new EditSubcategoryVM
            {
                Categories = new SelectList(list, "IDKategorija", "Naziv"),
                Subcategory = subcategory
                
            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSubcategoryVM e)
        {
            if (ModelState.IsValid) { 
            var subcategory = e.Subcategory;
            Repo.UpdateSubcategory(subcategory);
            return RedirectToAction(actionName: "ShowAllSubcategories");
            }
            else
            {
                return View(e);
            }

        }
        public ActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteSubcategory(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditSubcategoryVM c)
        {
            if (ModelState.IsValid) { 
            var subcategory = c.Subcategory;
            Repo.CreateSubcategory(subcategory);
            return RedirectToAction(actionName: "ShowAllSubcategories");
            }
            else
            {
                return View(c);
            }
        }
    }
}