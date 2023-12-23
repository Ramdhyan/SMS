using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace SMS.Models.Helpers
{
    public class SessionManager:IDisposable
    {
        public string LoginId
        {
            get
            {
                if(HttpContext.Current.Session["LoginId"]==null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["LoginId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["loginId"] = value;
            }
        }
        public int Pk_Id
        {
            get
            {
                if (HttpContext.Current.Session["Pk_Id"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(HttpContext.Current.Session["Pk_Id"]);
                }

            }
            set
            {
                HttpContext.Current.Session["Pk_Id"] = value;
            }
        }
             public string DisplayName
        {
            get
            {
                if (HttpContext.Current.Session["DisplayName"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["DisplayName"]);
                }
            }
            set
            {
                HttpContext.Current.Session["DisplayName"] = value;
            }
      
    }
        public string EmailId
        {
            get
            {
                if (HttpContext.Current.Session["EmailId"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["EmailId"]);
                }
            }
            set
            {
                HttpContext.Current.Session["EmailId"] = value;
            }
        }
        public string UserType
        {
            get
            {
                if (HttpContext.Current.Session["UserType"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["UserType"]);
                }
            }
            set
            {
                HttpContext.Current.Session["UserType"] = value;
            }
        }
        public string ProfilePic
        {
            get
            {
                if (HttpContext.Current.Session["ProfilePic"] == null)
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(HttpContext.Current.Session["ProfilePic"]);
                }
            }
            set
            {
                HttpContext.Current.Session["ProfilePic"] = value;
            }
        }
        public string CreatedDate
        {
            get
            {
                if (HttpContext.Current.Session["CreatedDate"] == null)
                {
                    return null;
                }
                else
                {

                    return Convert.ToString(HttpContext.Current.Session["CreatedDate"]);
                }
            }
            set
            {
                HttpContext.Current.Session["CreatedDate"] = value;
            }
        }
        public void KillSessions()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
        }
    }
}