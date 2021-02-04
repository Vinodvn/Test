using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManager.Interface
{
    public interface ICategoryMaster
    {
        string AddUpdate(string FormCollection);
        mCatergory SelectByPrimary(int PrimaryID);
        List<mCatergory> List(int PrimaryID);
    }
}