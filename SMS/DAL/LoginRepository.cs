using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.DAL
{
    public class LoginRepository
    {
        internal DataSet CheckUserLogin(Login obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@UserName",obj.UserName),
                new SqlParameter("@Password",obj.Password)
            };
            DataSet ds = DBHelper.ExecuteQuery("CheckUserLogin", para);
            return ds;
        }
    }
}