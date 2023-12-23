using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Login
    {
        public string Pk_Id { get; set; }
        [Required(ErrorMessage = "Please Enter LoginId")]
        [Display(Name = "Login ID")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}