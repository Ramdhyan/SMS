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
    public class AdminController : Controller
    {
        
        SessionManager sm = new SessionManager();
        StudentRepository objres = new StudentRepository();

        public ActionResult DashBoard()
        {
            if(Session["LoginId"]==null)
            {
                return RedirectToAction("Login","login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult StudentRegistration()
        {
            ViewBag.State = BLCommon.BindState();
            //ViewBag.City = BLCommon.BindCity(id);
            return View();
        }
        [HttpPost]
        public ActionResult StudentRegistration(StudentModel obj)
        {
            ViewBag.State = BLCommon.BindState();
            HttpPostedFileBase file = Request.Files["ProfilePic"];
            obj.ProfilePic = file.FileName;
            obj.UserType = 3;
            obj.CreatedBy = sm.Pk_Id;
            DataSet ds = objres.StudentRegistrationSave(obj);
            file.SaveAs(Server.MapPath("~/Content/AdminImg/"+ file.FileName));
            if(ds.Tables[0].Rows[0]["Code"].ToString() == "1")
            {
                ModelState.Clear();
                TempData["Remark"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                TempData["Code"]=ds.Tables[0].Rows[0]["Code"].ToString();
              
            }
            else
            {
                TempData["Remark"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                TempData["Code"] = ds.Tables[0].Rows[0]["Code"].ToString();
            }
            return View() ;
        }
        [HttpGet]
        public ActionResult AllStudents( StudentModel obj)
        {
            List<StudentModel> lst = new List<StudentModel>();
            DataSet ds = objres.GetAllStudent(obj.Name,obj.Email,obj.Mobile,obj.Gender);
            if(ds!=null && ds.Tables[0].Rows.Count>0 && ds.Tables.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(new StudentModel
                    {
                        Pk_Sid = (int)dr["Pk_Sid"],
                        Name=dr["Name"].ToString(),
                        FatherName = dr["FatherName"].ToString(),
                        MotherName = dr["MotherName"].ToString(),
                        ParentPhone = dr["ParentPhone"].ToString(),
                        DOB = dr["Name"].ToString(),
                        Email=dr["Email"].ToString(),
                        Mobile = dr["Mobile"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        ProfilePic = dr["ProfilePic"].ToString(),
                        Class = dr["Class"].ToString(),
                        City = dr["City"].ToString(),
                        State = dr["State"].ToString(),
                        Pincode = dr["Pincode"].ToString(),
                        Address = dr["Address"].ToString(),
                        Session = dr["Session"].ToString(),
                        AadharNo = (int)dr["AadharNo"],
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                        UpdatedDate = (DateTime)dr["UpdatedDate"],
                    });
                    obj.stulist = lst;
                }
            }
            return View(obj);
        }
       
       public ActionResult StudentDetails(int Pk_Sid=0)
        {
            
            StudentModel obj = new StudentModel();
            obj.Pk_Sid = Pk_Sid;
            DataSet ds = objres.StudentDetails(Pk_Sid);
            if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                        obj.Pk_Sid = (int)dr["Pk_Sid"];
                        obj.Name = dr["Name"].ToString();
                        obj.FatherName = dr["FatherName"].ToString();
                        obj.MotherName = dr["MotherName"].ToString();
                        obj.ParentPhone = dr["ParentPhone"].ToString();
                        obj.DOB = dr["DOB"].ToString();
                        obj.Email = dr["Email"].ToString();
                        obj.Mobile = dr["Mobile"].ToString();
                        obj.Gender = dr["Gender"].ToString();
                        obj.ProfilePic = dr["ProfilePic"].ToString();
                        obj.Class = dr["Class"].ToString();
                        obj.City = dr["City"].ToString();
                        obj.State = dr["State"].ToString();
                        obj.Pincode = dr["Pincode"].ToString();
                        obj.Address = dr["Address"].ToString();
                        obj.Session = dr["Session"].ToString();
                        obj.AadharNo = (int)dr["AadharNo"];
                        obj.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                };
            }
            return View(obj);
        }
      
    }
}