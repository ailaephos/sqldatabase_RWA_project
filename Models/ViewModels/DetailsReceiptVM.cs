using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models.ViewModels
{
    public class DetailsReceiptVM
    {
        public Komercijalist Komercijalist { get; set; }
        public KreditnaKartica CreditCard { get; set; }
        public Receipt Receipt { get; set; }
        public IEnumerable<Item> Items { get; set; } 
    }
}