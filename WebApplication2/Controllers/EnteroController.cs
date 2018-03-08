using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DBContext;
using TDA_NoLineales.Clases;
using System.Net;
using System.IO;

namespace WebApplication2.Controllers
{
    public class EnteroController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;

        // GET: Entero
        public ActionResult Index()
        {
            return View();
        }

        // GET: Entero/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Entero/Create
        public ActionResult CreatePerson()
        {
            return View();
        }

        // POST: Entero/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase jsonFile)
        {
            try
            {
                if (jsonFile != null) //validar que solo sea archivo Json
                {
                    string path = @jsonFile.FileName;
                    StreamReader sr = new StreamReader(Server.MapPath(path));
                    string data = sr.ReadToEnd();
                }
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entero/Edit/5
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

        // GET: Entero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entero/Delete/5
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
