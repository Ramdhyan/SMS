using SMS.DAL;
using SMS.Models;
using SMS.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class LoginController : Controller
    {
        SessionManager sm = new SessionManager();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login obj )
        {
            
            LoginRepository objRep = new LoginRepository();
            DataSet ds = objRep.CheckUserLogin(obj);
            if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                if (ds.Tables[0].Rows[0]["Code"].ToString() == "1")
                {
                    sm.Pk_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Pk_Id"]);
                    sm.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                    sm.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    sm.DisplayName = ds.Tables[0].Rows[0]["Name"].ToString();
                    sm.ProfilePic = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                    if (sm.UserType.Contains("Admin"))
                    {
                        return RedirectToAction("DashBoard", "Admin");

                    }
                    else if (sm.UserType.Contains("Teacher"))
                    {
                        return RedirectToAction("DashBoard", "Teacher");

                    }
                    else if (sm.UserType.Contains("Student"))
                    {
                        return RedirectToAction("DashBoard", "Student");

                    }
                    else if (sm.UserType.Contains("Management"))
                    {
                        return RedirectToAction("DashBoard", "Management");

                    }
                    else
                    {
                        return RedirectToAction("DashBoard", "Admin");

                    }
                }
               
                     else
                    {
                        ViewBag.InvalidLogin = ds.Tables[0].Rows[0]["Remark"].ToString();
                        TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                        return View("Login");
                    
                }
            }
            return View("Login");
        }
        public ActionResult LogOut()
        {
            sm.KillSessions();
            return RedirectToAction("Login","login");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if(Session["LoginId"]==null)
            {
                return RedirectToAction("Login","Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword model)
        {
            model.Pk_Id = sm.Pk_Id;
            model.LoginId = sm.LoginId;
            ChangePasswordRepository objrep = new ChangePasswordRepository();
            DataSet ds = objrep.ChangePassword(model);
            if(ds !=null && ds.Tables[0].Rows.Count>0 && ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows[0]["Code"].ToString()=="1")
                {
                    TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                    TempData["code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                }
                else
                {
                    TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                    TempData["code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordModel model)//mail is sending match otp pr work karna hai  
        {
            ForgetPasswordRepository objrep = new ForgetPasswordRepository();
            sm.LoginId = model.LoginId;
            sm.EmailId = model.Email;
            DataSet ds = objrep.ForgetPassword(model);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Code"].ToString() == "1")
                {
                    Random r = new Random();
                    int otp=r.Next(0, 9999);
                    Session["OTP"] = otp;
                    string to = model.Email;
                    string from = "kushwaharamdhyan1382002@gmail.com";
                    string subject = "Verification OTP From SMS.";
                    string body = "Your OTP for Forget Password Is " + otp + " Use this Otp To verify.";
                    MailMessage message = new MailMessage(from,to,subject,body);
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("kushwaharamdhyan1382002@gmail.com", "lvbc chbt qwla rbcm");
                    client.Send(message);
                    TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                    TempData["code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                    return RedirectToAction("VerifyOtp", "Login");
                }
                else
                {
                    TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                    TempData["code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                }
            }
                    return View();
        }
        [HttpGet]
        public ActionResult VerifyOtp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult verifyOtp(MatchOtp obj)
        {
            var sessionOtp = Session["OTP"].ToString();
            if(obj.otp== sessionOtp)
            {
               // TempData["Message"] = "OTP sent Successfully";
            return RedirectToAction("ConfirmForgetPassword", "Login");
            }
            else
            {
                TempData["Message"] = "Please Enter Correct Otp";

            }
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmForgetPassword(ConfirmForgetPassword model)
        {
            sm.LoginId = model.LoginId;
            sm.EmailId = model.EmailId;
            ConfirmForgetPasswordRepository objrep = new ConfirmForgetPasswordRepository();
            DataSet ds = objrep.ConfirmForgetPassword(model);
            if(ds !=null && ds.Tables[0].Rows.Count>0 && ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows[0]["Code"].ToString() == "1")
                {
                    TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                    TempData["code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                }
                else
                {
                    TempData["msg"] = ds.Tables[0].Rows[0]["Remark"].ToString();
                    TempData["code"] = ds.Tables[0].Rows[0]["Code"].ToString();
                }
            }
            return View();
        }
    }
}