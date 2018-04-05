using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DBContext;
using WebApplication2.Models;
using TDA_NoLineales.Clases;

namespace WebApplication2.Controllers
{
    public class EnteroController : Controller
    {
        DefaultConnection db = DefaultConnection.getInstance;
        // GET: Entero
        public ActionResult Index()
        {
            
            if (db.ENTEROS._raiz!= null)
            {
                
                bool DON = false;
                DON = db.ENTEROS.EsDegenerado(db.ENTEROS._raiz);
                
                if (DON == true)
                {
                    
                    ViewBag.Mostrar = " Es degenerado";
                }
                else
                {
                    ViewBag.Mostrar = " No es degenerado";
                }

                if (Math.Abs(db.ENTEROS.FB) == 1)
                {
                    ViewBag.Show = " Esta equilibrado";
                }
                else
                {
                    ViewBag.Show = "Esta desequilibrado";
                }
            }
            return View();
        }

        // GET: Entero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entero/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase jsonFile)
        {
            try
            {
                // TODO: Add insert logic here
                if (Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
                {
                    jsonFile.SaveAs(Server.MapPath("~/JSONFiles" + Path.GetFileName(jsonFile.FileName)));
                    StreamReader sr = new StreamReader(Server.MapPath("~/JSONFiles" + Path.GetFileName(jsonFile.FileName)));
                    string data = sr.ReadToEnd();
                     ArbolBinarioBusqueda<int> entero = new ArbolBinarioBusqueda<int>();
                    entero._raiz= JsonConvert.DeserializeObject<Nodo<int>>(data);
                    entero.Pre(entero._raiz);
                    List<int> aux = entero.PreList;
                    for (int i = 0; i < aux.Count; i++)
                    {
                        Entero e = new Entero();
                        e.valor = aux[i];
                        Nodo<Entero> nodo = new Nodo<Entero>(e, CompararEntero);
                        db.ENTEROS.Insertar(nodo);
                    }
                   
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
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
        public ActionResult Post()
        {
            db.ENTEROS.Post(db.ENTEROS._raiz);
      
            return View(db.ENTEROS.PostList);
        }
        public ActionResult Pre()
        {
            db.ENTEROS.Pre(db.ENTEROS._raiz);

            return View(db.ENTEROS.PreList);
        }

        public ActionResult In()
        {
            db.ENTEROS.In(db.ENTEROS._raiz);
            return View(db.ENTEROS.InList);
        }

        public static int CompararEntero(Entero _actual, Entero _nuevo)
        {
            return _actual.valor.CompareTo(_nuevo.valor);
        }
    }
}
