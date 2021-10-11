using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rwa_projekt_katlija_2407.Models.ViewModels
{
    public class EditCustomerVM
    {

        public Customer Customer { get; set; }

        public SelectList StatesList { get; set; }
        public SelectList CitiesList { get; set; }
    }
}