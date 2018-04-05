using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TDA_NoLineales.Clases;
using WebApplication2.DBContext;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class PaisController : Controller
    {
        
        DefaultConnection db = DefaultConnection.getInstance;
        
        // GET: Pais
        public ActionResult Index()
        {
            if (db.Paises._raiz != null)
            {
                bool DON = false;
                DON = db.Paises.EsDegenerado(db.Paises._raiz);
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

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
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
                    db.Paises._raiz = JsonConvert.DeserializeObject<Nodo<Pais>>(data);
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
        
        public ActionResult POST()
        {
            db.Paises.Post(db.Paises._raiz);
   
            return View(db.Paises.PostList);
        }

        public ActionResult Pre()
        {
            db.Paises.Pre(db.Paises._raiz);
            return View(db.Paises.PreList);
        }

        public ActionResult In()
        {
            db.Paises.In(db.Paises._raiz);
            return View(db.Paises.InList);
        }
        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
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

        // GET: Pais/Delete/5
        public ActionResult Delete(Pais id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Pais n = db.Paises.InList.Find(x => x.nombre == id.nombre);
            if (n == null)
                return Index();
            else
                return View(n);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Pais n = db.Paises.InList.Find(x => x.nombre == id);
                db.Paises.Eliminar(n);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
