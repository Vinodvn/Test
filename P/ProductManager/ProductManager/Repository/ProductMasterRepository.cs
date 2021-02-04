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
    public class ProductMasterRepository
    {
        SqlConnection Connection;
        Message _message;
        public ProductMasterRepository()
        {
            Connection = ConnectionString.GetConnection();
        }

        public Message AddUpdate(int ProductID,int CategoryID,string ProductName, bool IsActive)
        {
            var parms = new DynamicParameters();
            parms.Add("@ProductID", ProductID);
            parms.Add("@ProductName", ProductName);
            parms.Add("@CategoryID", CategoryID);
            parms.Add("@IsActive", IsActive);
            parms.Add("@MessageID", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
            parms.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

            Connection.Execute("usp_AddUpdateProductMaster", parms, commandType: CommandType.StoredProcedure);
            string MessageID = parms.Get<string>("@MessageID");
            string Message = parms.Get<string>("@Message");
            return _message = new Message { MessageStatusId = Convert.ToInt16(MessageID), MessageText = Message };

        }
        public mProductMaster SelectByPrimary(int PrimaryID)
        {
            var Catergory = Connection.Query<mProductMaster>("usp_ProcuctSelectByPrimary",new { PrimaryID= PrimaryID} ,commandType: CommandType.StoredProcedure);
            return Catergory.FirstOrDefault();
        }
        public IEnumerable<mProductMaster> List(int PageNumber, int PageSize)
        {
            return Connection.Query<mProductMaster>("usp_GetProductMasterList", commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<mCatergory> GetCategory()
        {
            return Connection.Query<mCatergory>("usp_GetCategory", commandType: CommandType.StoredProcedure);
            //return list;
        }
    }
}