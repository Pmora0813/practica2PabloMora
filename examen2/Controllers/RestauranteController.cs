using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examen2.Models;

namespace examen2.Controllers
{
    public class RestauranteController : Controller
    {
        private ReservaRestaurante db = new ReservaRestaurante();

        // GET: Restaurante
        public ActionResult Index()
        {
            var restaurante = db.Restaurante.Include(r => r.Categoria);
            return View(restaurante.ToList());
        }

        // GET: Restaurante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurante.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // GET: Restaurante/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombre");
            return View();
        }

        // POST: Restaurante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Restaurante.Add(restaurante);



                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombre", restaurante.idCategoria);
            return View(restaurante);
        }

        // GET: Restaurante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurante.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombre", restaurante.idCategoria);
            return View(restaurante);
        }

        // POST: Restaurante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "nombre", restaurante.idCategoria);
            return View(restaurante);
        }

        public PartialViewResult ordenarRestaurante(string criterio)
        {
            var query = from r in db.Restaurante
                        select r;
            switch (criterio)
            {
                case "asc":
                    query = query.OrderBy(x => x.Categoria.idCategoria);
                    break;
                case "desc":
                    query = query.OrderByDescending(x => x.Categoria.idCategoria);
                    break;
                default:
                    query = query.OrderBy(x => x.Categoria.idCategoria);
                    break;
            }
            return PartialView("_ordenarRestaurante", query);
        }

        // GET: Restaurante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurante.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurante restaurante = db.Restaurante.Find(id);
            db.Restaurante.Remove(restaurante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
