using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RopeysDVD
{
    public class GlobalConnection
    {
        public SqlConnection cn;

        public GlobalConnection()
        {
            string sqlcon = System.Configuration.ConfigurationManager.AppSettings.Get("DBConnection").ToString();

            cn = new SqlConnection(sqlcon);
            cn.Open();
        }
    }
}