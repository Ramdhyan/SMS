using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class ChangePassword
    {
        public int Pk_Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConFirmPassword { get; set; }
        public string LoginId { get; set; }
    }
}