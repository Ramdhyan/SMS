using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StudentModel
    {
        public int Pk_Sid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string ParentPhone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Gender { get; set; }
        public string ProfilePic { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Pincode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Session { get; set; }
        [Required]
        public int AadharNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UserType { get; set; }
        public int UpdatedBy { get; set; }
        public int DeletedBy { get; set; }
        public List<StudentModel> stulist { get; set; }
    }
}