using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace SMS.Models
{
    public class BLCommon
    {
    public static List<SelectListItem> BindState()
    {
        DataSet ds = DBHelper.ExecuteQuery("sp_bindState");
        List<SelectListItem> lst = new List<SelectListItem>();
        lst.Add(new SelectListItem { Text = "select State", Value = "" });
        if(ds!=null && ds.Tables.Count>0)
        {
            foreach (DataRow dr  in ds.Tables[0].Rows)
            {
                lst.Add(new SelectListItem { Text = dr["StateName"].ToString(), Value = dr["Pk_id"].ToString() });

            }
        }
            return lst;
    }
        public static List<SelectListItem> BindCity(string id)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@StateId",string.IsNullOrEmpty(id)?null:id),
            };
            DataSet ds = DBHelper.ExecuteQuery("sp_GetCity",para);
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem { Text = "select State", Value = "" });
            if (id == null)
            {
                lst.Add(new SelectListItem { Text = "select City", Value = "" });
                return lst;
            }
            else if (ds.Tables[0].Rows.Count>0 && ds.Tables[0].Rows[0]["Code"].ToString()=="0")
            {
                lst.Add(new SelectListItem { Text = "City Not Found", Value = "" });
                return lst;
            }
            lst.Add(new SelectListItem { Text = "select City", Value = "" });
            if(ds.Tables[0].Rows.Count>0 && ds.Tables.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    lst.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Pk_Id"].ToString() });
                }
            }
                    return lst;
        }
    }
}