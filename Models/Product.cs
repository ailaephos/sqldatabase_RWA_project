using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models
{
    public class Product
    {
        public int IDProizvod { get; set; }
        [Required(ErrorMessage = "Please fill in the Name field")]
        [Display(Name = "Name")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Please fill in the No. field")]
        [Display(Name = "No.")]  
        public string BrojProizvoda { get; set; }
        [Required(ErrorMessage = "Please fill in the Quantity field")]
        [Display(Name = "Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a number!")]
        public int Kolicina { get; set; }
        [Display(Name = "Color")]
        [Required(ErrorMessage = "Please fill in the Color field")]
        public string Boja { get; set; }
        [Display(Name = "Price (no PDV)")]
        [Required(ErrorMessage = "Please fill in the Price field")]
        [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?", ErrorMessage ="You must enter a number with two decimal places!")]
        [Range(0, 9999999999999999.99)]
        public decimal CijenaBezPDV { get; set; }
        [Required(ErrorMessage = "Please fill in the Subcategory field")]
        [Display(Name = "Subcategory")]
        [Range(1, 9999999999999999.99, ErrorMessage="Please define a subcategory!")]

        public int PotkategorijaID { get; set; }
   
        public string Potkategorija { get; set; }
    }
}