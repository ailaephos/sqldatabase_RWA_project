using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models
{
    public class Subcategory
    {
        public int IDPotkategorija { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in the Name field")]

        public string Naziv { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please fill in the Category field")]
        [Range(1, 9999999999999999.99, ErrorMessage = "Please define a category!")]
        public int KategorijaID { get; set; }
        [Display(Name = "Category")]

        public string Kategorija { get; set; }
    }
}