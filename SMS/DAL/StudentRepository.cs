using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace SMS.DAL
{
    public class StudentRepository
    {
        internal DataSet StudentRegistrationSave(StudentModel obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Name",obj.Name),
                new SqlParameter("@FatherName",obj.FatherName),
                new SqlParameter("@MotherName",obj.MotherName),
                new SqlParameter("@ParentPhone",obj.ParentPhone),
                new SqlParameter("@Email",obj.Email),
                new SqlParameter("@Mobile",obj.Mobile),
                new SqlParameter("@Gender",obj.Gender),
                new SqlParameter("@ProfilePic",obj.ProfilePic),
                new SqlParameter("@DOB",obj.DOB),
                new SqlParameter("@City",obj.City),
                new SqlParameter("@State",obj.State),
                new SqlParameter("@Pincode",obj.Pincode),
                new SqlParameter("@Address",obj.Address),
                new SqlParameter("@Class",obj.Class),
                new SqlParameter("@Session",obj.Session),
                new SqlParameter("@AadharNo",obj.AadharNo),
                new SqlParameter("@CreatedBy",obj.CreatedBy),
                new SqlParameter("@UpdatedBy",obj.UpdatedBy),
                new SqlParameter("@UserType",obj.UserType),
                new SqlParameter("@DeletedBy",obj.DeletedBy)
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_StudentRegistration", param);
            if (ds.Tables[0].Rows[0]["Code"].ToString() == "1")
            {
                string loginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                string password = ds.Tables[0].Rows[0]["Password"].ToString();

                string to = obj.Email;
                string from = "kushwaharamdhyan1382002@gmail.com";
                string subject = "Login Credentials For SMS.";
                string body = "Your Credentials for Access the SMS portal,Your Password Is " + password + " and LoginId=" + loginId + " Use this Credentials  To Login on SMS.";
                MailMessage message = new MailMessage(from, to, subject, body);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("kushwaharamdhyan1382002@gmail.com", "lvbc chbt qwla rbcm");
                client.Send(message);
            }
            return ds;
        }

        internal DataSet GetAllStudent(string Name = null, string Email = null,string Mobile=null,string Gender=null)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Name",Name),
                new SqlParameter("@Email",Email),
                new SqlParameter("@Mobile",Mobile),
                new SqlParameter("@Gender",Gender),
            };
           DataSet ds=DBHelper.ExecuteQuery("sp_GetAllStudent",para);
            return ds;
        }

        internal DataSet StudentDetails(int Pk_Sid)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Pk_Id",Pk_Sid),
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_StudentDetails", para);
            return ds;
        }

        internal DataSet ViewProfile(int Pk_Id)
        {
            SqlParameter[] para =
          {
                new SqlParameter("@Pk_Id",Pk_Id),
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_ViewProfile", para);
            return ds;
        }
    }
                   
}