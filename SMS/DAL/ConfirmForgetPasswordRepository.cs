using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.DAL
{
    public class ConfirmForgetPasswordRepository
    {
        internal DataSet ConfirmForgetPassword(ConfirmForgetPassword model)
        {
            SqlParameter[] param = {
            new SqlParameter("@LoginId",model.LoginId),
            new SqlParameter("@NewPassword",model.NewPassword),
            new SqlParameter("@Email",model.EmailId),
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_ConfirmForgetPassword", param);
            return ds;
        }
    }
}