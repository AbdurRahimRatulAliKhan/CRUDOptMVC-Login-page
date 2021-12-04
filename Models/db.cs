using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CRUDOptMVC.Models;

namespace CRUDOptMVC.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D1JFGGI;Initial Catalog=login_page;Integrated Security=True");

        public int LoginCheck(Ad_login ad)
        {
            SqlCommand com = new SqlCommand("login_page", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@user_name", ad.user_name);
            com.Parameters.AddWithValue("@password_", ad.password_);

            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;

        }
    }
}
