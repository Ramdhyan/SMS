using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.DAL
{
    public class ChangePasswordRepository
    {
        internal DataSet ChangePassword(ChangePassword model)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Pk_Id", model.Pk_Id),
                new SqlParameter("@LoginId", model.LoginId),
                new SqlParameter("@OldPassword",model.OldPassword),
                new SqlParameter("@NewPassword", model.NewPassword),
                new SqlParameter("@ConFirmPassword", model.ConFirmPassword)
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_changepassword", para);
            return ds;
        }

        
    }
}