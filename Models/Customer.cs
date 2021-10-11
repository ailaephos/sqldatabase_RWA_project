using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models
{
    [Serializable]
    public class Customer
    {
      
         public int IDKupac { get; set; }
        [Required(ErrorMessage = "Please fill in the Name field")]
        [Display(Name = "Name")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Please fill in the Surname field")]
        [Display(Name = "Surname")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Please fill in the Email field")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill in the Telephone field")]
        [Display(Name = "Telephone")]
        public string Telefon { get; set; }
        [Display(Name = "State")]
      
        public string Drzava { get; set; }
    
        [Display(Name = "City name")]
        public string Grad { get; set; }
        [Required(ErrorMessage = "Please fill in the State field")]
        [Display(Name = "State")]
        public int DrzavaID { get; set; }
        [Required(ErrorMessage = "Please fill in the City field")]
        [Display(Name = "City")]
        public int GradID { get; set; }
    }
}