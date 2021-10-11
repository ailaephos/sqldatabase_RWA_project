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
    public class ProductController : Controller
    {
        // GET: Product
        [HandleError(View = "NotFound")]
        public ActionResult ShowAllProducts()
        {
            var model = Repo.GetProducts();
            return View(model);
        }
        [HttpGet]
        [HandleError(View = "NotFound")]
        public ActionResult Edit(int id)
        {
            var product = Repo.GetProduct(id);
            List<Subcategory> list = Repo.GetSubcategories().ToList();
            list.Insert(0, new Subcategory { IDPotkategorija = 0 , Naziv="-", Kategorija="-", KategorijaID =0});
        
            var model = new EditProductVM {
                Subcategories = new SelectList(list, "IDPotkategorija", "Naziv"),
                Product = product
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProductVM p)
        {
            if (ModelState.IsValid) { 
            var product = p.Product;
            Repo.UpdateProduct(product);
            return RedirectToAction(actionName: "ShowAllProducts");
            }
            else
            {
                return View(p);
            }

        }
      public ActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteProduct(id);
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
        public ActionResult Create(EditProductVM v)
        {
            if (ModelState.IsValid) { 
            var product = v.Product;
            Repo.CreateProduct(product);
            return RedirectToAction(actionName: "ShowAllProducts");
            }
            else
            {
                return View(v);
            }
        }
    }
}