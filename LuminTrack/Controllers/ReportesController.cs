using LuminTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LuminTrack.Controllers
{
    public class ReportesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Reportes
        public ActionResult Index()
        {
            return View(db.Reportes.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
                return HttpNotFound();

            return View(reporte);
        }

        // GET: Reportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reportes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reporte reporte, HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                string ruta = "/Uploads/" + foto.FileName;
                foto.SaveAs(Server.MapPath("~" + ruta));
                reporte.FotoURL = ruta;
            }

            if (ModelState.IsValid)
            {
                db.Reportes.Add(reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
                return HttpNotFound();

            return View(reporte);
        }

        // POST: Reportes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reporte reporte, HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                string ruta = "/Uploads/" + foto.FileName;
                foto.SaveAs(Server.MapPath("~" + ruta));
                reporte.FotoURL = ruta;
            }

            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Reporte reporte = db.Reportes.Find(id);
            if (reporte == null)
                return HttpNotFound();

            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reporte reporte = db.Reportes.Find(id);
            db.Reportes.Remove(reporte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}