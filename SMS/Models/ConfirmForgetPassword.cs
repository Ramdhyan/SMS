using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ConfirmForgetPassword
    {
        public string LoginId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmailId { get; set; }
    }
}