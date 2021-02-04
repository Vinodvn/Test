using ProductManager.Models;
using ProductManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
    public class ProductMasterController : Controller
    {
        ProductMasterRepository DataAccess;
        public ProductMasterController()
        {
            DataAccess = new ProductMasterRepository();
        }
        // GET: ProductMaster
        public ActionResult Index()
        {
            return View(DataAccess.List(1, 10));
        }

        // GET: ProductMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductMaster/Create
        public ActionResult Create()
        {
            mProductMaster mProduct = new mProductMaster();
            IEnumerable<mCatergory> Category = DataAccess.GetCategory();
            ViewBag.Category = Category;
            return View();
        }

        // POST: ProductMaster/Create
        [HttpPost]
        public ActionResult Create(mProductMaster model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Message _message = DataAccess.AddUpdate(model.ProductID, model.CategoryID, model.ProductName, model.IsActive);
                    return RedirectToAction("Index");
                }
                return View(model);
                // TODO: Add insert logic here


            }
            catch
            {
                return View();
            }
        }

        // GET: ProductMaster/Edit/5
        public ActionResult Edit(int id)
        {
            mProductMaster mProduct = new mProductMaster();
            IEnumerable<mCatergory> Category = DataAccess.GetCategory();
            ViewBag.Category = Category;
            return View(DataAccess.SelectByPrimary(id));
        }

        // POST: ProductMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, mProductMaster model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Message _message = DataAccess.AddUpdate(id, model.CategoryID, model.ProductName, model.IsActive);
                    return RedirectToAction("Index");
                }
                return View(model);
                // TODO: Add insert logic here


            }
            catch
            {
                return View();
            }
        }

        // GET: ProductMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
