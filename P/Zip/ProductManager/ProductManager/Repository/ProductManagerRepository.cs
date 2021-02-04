using Dapper;
using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductManager.Repository
{
    public class ProductManagerRepository
    {
        SqlConnection Connection;
        Message _message;
        public ProductManagerRepository()
        {
            Connection = ConnectionString.GetConnection();
        }

        public IEnumerable<mProductManager> List(int PageNumber, int PageSize)
        {
            return Connection.Query<mProductManager>("usp_GetProductList", commandType: CommandType.StoredProcedure);
        }

    }
}