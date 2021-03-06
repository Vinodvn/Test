﻿using ProductManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManager.Controllers
{
   
    public class ProductManagerController : Controller
    {
        ProductManagerRepository DataAccess;
        public ProductManagerController()
        {
            DataAccess = new ProductManagerRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            return View(DataAccess.List(1, 10));
        }

        // GET: ProductManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductManager/Delete/5
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
