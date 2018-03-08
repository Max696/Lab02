using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class IntController : Controller
    {
        // GET: Int
        public ActionResult Index()
        {
            return View();
        }

        // GET: Int/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Int/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Int/Create
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

        // GET: Int/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Int/Edit/5
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

        // GET: Int/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Int/Delete/5
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
