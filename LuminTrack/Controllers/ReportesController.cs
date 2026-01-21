using LuminTrack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        private bool EsAdmin()
        {
            return Session["Rol"] != null && Session["Rol"].ToString() == "Administrador";
        }

        private bool EsCiudadano()
        {
            return Session["Rol"] != null && Session["Rol"].ToString() == "Ciudadano";
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
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuarios");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reporte reporte)
        {
            if (Session["Rol"] == null)
                return RedirectToAction("Login", "Usuarios");

            reporte.UsuarioEmail = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.Reportes.Add(reporte);
                db.SaveChanges();

                if (EsCiudadano())
                    return RedirectToAction("MisReportes");

                return RedirectToAction("Index");
            }

            return View(reporte);
        }


        // GET: Reportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!EsAdmin())
                return RedirectToAction("Index", "Home");

            if (id == null)
                return HttpNotFound();

            var reporte = db.Reportes.Find(id);
            return View(reporte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reporte reporte)
        {
            if (!EsAdmin())
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                db.Entry(reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!EsAdmin())
                return RedirectToAction("Index", "Home");

            var reporte = db.Reportes.Find(id);
            return View(reporte);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!EsAdmin())
                return RedirectToAction("Index", "Home");

            var reporte = db.Reportes.Find(id);
            db.Reportes.Remove(reporte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MisReportes()
        {
            ViewBag.Email = User.Identity.Name;
            ViewBag.Auth = User.Identity.IsAuthenticated;

            var reportes = db.Reportes.ToList();
            return View(reportes);
        }
    }
}