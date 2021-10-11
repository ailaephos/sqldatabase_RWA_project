using rwa_projekt_katlija_2407.Models;
using rwa_projekt_katlija_2407.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Controllers
{
    public class ReceiptController : Controller
    {
        // GET: Receipt
        [HandleError(View = "NotFound")]
        public ActionResult ShowReceipts(int id)
        {
            var customer = Repo.ShowMoreInfo(id);
            var model = new ReceiptVM
            {
                Customer = customer,
                Receipts = Repo.GetReceipts(id).ToList()
            };
            return View(model);
        }
        [HandleError(View = "NotFound")]
        public ActionResult ShowDetails(int id)
        {
            var receipt = Repo.GetReceipt(id);
            var items = Repo.GetItems(id);
            var model = new DetailsReceiptVM
            {
                Receipt = receipt,
                Items = items,
                Komercijalist = Repo.GetKomercijalist(id),
                CreditCard = Repo.GetCreditCard(id)
            };
            return View(model);
        }
    }
}