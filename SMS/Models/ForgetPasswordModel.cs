using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ForgetPasswordModel
    {
        public int Pk_Id { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
    }
}