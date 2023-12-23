using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.DAL
{
    public class ForgetPasswordRepository
    {   
        internal DataSet ForgetPassword(ForgetPasswordModel model)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",model.LoginId),
                new SqlParameter("@Email",model.Email)
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_ForgetPassword", para);
            return ds;
        }
    }
}