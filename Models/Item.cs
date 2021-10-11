using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models 
{ 

    public class Item
    {
        public string Naziv { get; set; }
        public string Kategorija { get; set; }
        public string Potkategorija { get; set; }
        public int Kolicina { get; set; }
        public decimal CijenaPoKomadu { get; set; }
        public decimal UkupnaCijena { get; set; }
    }
}