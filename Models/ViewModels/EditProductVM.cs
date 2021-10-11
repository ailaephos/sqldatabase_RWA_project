using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Models.ViewModels
{
    public class EditProductVM
    {
        public Product Product { get; set; }
        public SelectList  Subcategories { get; set; }
    }
}