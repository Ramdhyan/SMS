using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult DashBoard()
        {
            if (Session["LoginId"] == null)
            {
                return RedirectToAction("Login", "login");
            }
            return View();
        }
    }
}