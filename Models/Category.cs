using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models
{
    public class Category
    {
      
        public int IDKategorija { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in the Name field")]
        public string Naziv { get; set; }
    }
}