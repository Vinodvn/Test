using ProductManager.Models;
using ProductManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
    public class CategoryMasterController : Controller
    {
        CategoryRepository DataAccess;
        public CategoryMasterController()
        {
            DataAccess = new CategoryRepository();

        }
        // GET: CategoryMaster
        public ActionResult Index()
        {

            return View(DataAccess.List(1, 10));
        }

        // GET: CategoryMaster/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryMaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMaster/Create
        [HttpPost]
        public ActionResult Create(mCatergory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  Message _message=  DataAccess.AddUpdate(model.CategoryID, model.CategoryName, model.IsActive);
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

        // GET: CategoryMaster/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DataAccess.SelectByPrimary(id));
        }

        // POST: CategoryMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, mCatergory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Message _message = DataAccess.AddUpdate(id, model.CategoryName, model.IsActive);
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

        // GET: CategoryMaster/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryMaster/Delete/5
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
