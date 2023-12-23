using SMS.DAL;
using SMS.Models;
using SMS.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        SessionManager sm = new SessionManager();
        StudentRepository objres = new StudentRepository();
        // GET: Student
        public ActionResult DashBoard()
        {
            if (Session["LoginId"] == null)
            {
                return RedirectToAction("Login", "login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult ViewProfile(int Pk_Id)
        {
            StudentModel stu = new StudentModel();
            DataSet ds = objres.ViewProfile(Pk_Id);
            if(ds!=null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    stu.Pk_Sid = (int)dr["Pk_Sid"];
                    stu.Name = dr["Name"].ToString();
                    stu.FatherName = dr["FatherName"].ToString();
                    stu.MotherName = dr["MotherName"].ToString();
                    stu.ParentPhone = dr["ParentPhone"].ToString();
                    stu.DOB = dr["DOB"].ToString();
                    stu.Email = dr["Email"].ToString();
                    stu.Mobile = dr["Mobile"].ToString();
                    stu.Gender = dr["Gender"].ToString();
                    stu.ProfilePic = dr["ProfilePic"].ToString();
                    stu.Class = dr["Class"].ToString();
                    stu.City = dr["City"].ToString();
                    stu.State = dr["State"].ToString();
                    stu.Pincode = dr["Pincode"].ToString();
                    stu.Address = dr["Address"].ToString();
                    stu.Session = dr["Session"].ToString();
                    stu.AadharNo = (int)dr["AadharNo"];
                    stu.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                }
            }
            return View(stu);
        }
    }
}