using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductManager.Repository
{
    public class ConnectionString
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            return Connection;
        }
    }
}