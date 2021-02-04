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
    public class CategoryRepository
    {
        SqlConnection Connection;
        Message _message;
        public CategoryRepository()
        {
            Connection = ConnectionString.GetConnection();
        }

        public Message AddUpdate(int CategoryID,string CategoryName,bool IsActive)
        {
            var parms = new DynamicParameters();
            parms.Add("@CategoryID", CategoryID);
            parms.Add("@CategoryName", CategoryName);
            parms.Add("@IsActive", IsActive);
            parms.Add("@MessageID", dbType: DbType.String, direction: ParameterDirection.Output, size: 10);
            parms.Add("@Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);

            Connection.Execute("usp_AddUpdateCategory", parms, commandType: CommandType.StoredProcedure);
            string MessageID = parms.Get<string>("@MessageID");
            string Message = parms.Get<string>("@Message");
            return _message = new Message { MessageStatusId = Convert.ToInt16(MessageID), MessageText = Message };

        }
        public mCatergory SelectByPrimary(int PrimaryID)
        {
            var Catergory = Connection.Query<mCatergory>("usp_SelectByPrimary",new { PrimaryID= PrimaryID} ,commandType: CommandType.StoredProcedure);
            return Catergory.FirstOrDefault();
        }
        public IEnumerable<mCatergory> List(int PageNumber, int PageSize)
        {
            return Connection.Query<mCatergory>("usp_GetCategoryList", commandType: CommandType.StoredProcedure);
            //return list;
        }
    }
}