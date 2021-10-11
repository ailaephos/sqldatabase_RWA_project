using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models.ViewModels
{
    public class User
    {
        [Required(ErrorMessage = "Please fill in the Username field")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please fill in the Password field")]
        public string Password { get; set; }
    }
}