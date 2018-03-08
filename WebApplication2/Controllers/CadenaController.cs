using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CadenaController : Controller
    {
        // GET: Cadena

        public ActionResult Index() //Mostrar los recorridos del árbol 
        {
            return View();
        }

        // GET: Cadena/Details/5
        public ActionResult Details(int id) //Cargar los archivos
        {
            return View();
        }

        // GET: Cadena/Create
        public ActionResult Create() //Agregar nodo
        {
            return View();
        }

        // POST: Cadena/Create
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

        // GET: Cadena/Edit/5
        public ActionResult Edit(int id) 
        {
            return View();
        }

        // POST: Cadena/Edit/5
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

        // GET: Cadena/Delete/5
        public ActionResult Delete(int id) //Eliminar un nodo
        {
            return View();
        }

        // POST: Cadena/Delete/5
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
