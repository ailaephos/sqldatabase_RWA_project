using rwa_projekt_katlija_2407.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
      [HandleError(View="NotFound")]
        public ActionResult ShowAllCategories() 
        {
           
            var model = Repo.GetCategories();
                return View(model);
        }
        [HandleError(View = "NotFound")]
        [HttpGet]


        public ActionResult Edit(int id)
        {
            var model = Repo.GetCategory(id);      
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category c)
        {
            if (ModelState.IsValid) { 
            Repo.UpdateCategory(c);
            return RedirectToAction(actionName: "ShowAllCategories");
            }
            else
            {
                return View(c);
            }
        }
        [HttpGet]
        [HandleError(View = "NotFound")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid) { 
            Repo.CreateCategory(c);
            return RedirectToAction(actionName: "ShowAllCategories");
            }
            else
            {
                return View(c);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteCategory(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);             
            }
        }
    }
}