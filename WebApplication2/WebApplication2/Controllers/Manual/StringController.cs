using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class StringController : Controller
    {
        // GET: String
        public ActionResult Index()
        {
            return View();
        }

        // GET: String/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: String/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: String/Create
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

        // GET: String/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: String/Edit/5
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

        // GET: String/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: String/Delete/5
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
