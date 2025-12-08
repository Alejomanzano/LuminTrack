using LuminTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LuminTrack.Controllers
{
    public class OrdenesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Ordenes
        public ActionResult Index()
        {
            return View(db.OrdenesTrabajo.ToList());
        }

        // GET: Ordenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrdenTrabajo orden = db.OrdenesTrabajo.Find(id);

            if (orden == null)
                return HttpNotFound();

            return View(orden);
        }

        // GET: Ordenes/Create
        public ActionResult Create()
        {
            ViewBag.Reportes = new SelectList(db.Reportes, "Id", "Descripcion");
            ViewBag.Luminarias = new SelectList(db.Luminarias, "Id", "Tipo");

            return View();
        }

        // POST: Ordenes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdenTrabajo orden, HttpPostedFileBase evidencia)
        {
            if (evidencia != null && evidencia.ContentLength > 0)
            {
                string ruta = "/Uploads/" + evidencia.FileName;
                evidencia.SaveAs(Server.MapPath("~" + ruta));
                orden.FotoEvidenciaURL = ruta;
            }

            if (ModelState.IsValid)
            {
                db.OrdenesTrabajo.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Reportes = new SelectList(db.Reportes, "Id", "Descripcion", orden.ReporteId);
            ViewBag.Luminarias = new SelectList(db.Luminarias, "Id", "Tipo", orden.LuminariaId);

            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrdenTrabajo orden = db.OrdenesTrabajo.Find(id);

            if (orden == null)
                return HttpNotFound();

            ViewBag.Reportes = new SelectList(db.Reportes, "Id", "Descripcion", orden.ReporteId);
            ViewBag.Luminarias = new SelectList(db.Luminarias, "Id", "Tipo", orden.LuminariaId);

            return View(orden);
        }

        // POST: Ordenes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdenTrabajo orden, HttpPostedFileBase evidencia)
        {
            if (evidencia != null && evidencia.ContentLength > 0)
            {
                string ruta = "/Uploads/" + evidencia.FileName;
                evidencia.SaveAs(Server.MapPath("~" + ruta));
                orden.FotoEvidenciaURL = ruta;
            }

            if (ModelState.IsValid)
            {
                db.Entry(orden).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Reportes = new SelectList(db.Reportes, "Id", "Descripcion", orden.ReporteId);
            ViewBag.Luminarias = new SelectList(db.Luminarias, "Id", "Tipo", orden.LuminariaId);

            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            OrdenTrabajo orden = db.OrdenesTrabajo.Find(id);

            if (orden == null)
                return HttpNotFound();

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenTrabajo orden = db.OrdenesTrabajo.Find(id);
            db.OrdenesTrabajo.Remove(orden);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}