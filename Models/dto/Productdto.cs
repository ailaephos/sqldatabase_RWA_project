using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models.dto
{
    public class Productdto
    {
     
        public string Naziv { get; set; }   
        public string BrojProizvoda { get; set; }
       
        public string Boja { get; set; }    
        public decimal CijenaBezPDV { get; set; }      
        public int PotkategorijaID { get; set; }


    }
}