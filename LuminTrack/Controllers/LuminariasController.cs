using LuminTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LuminTrack.Controllers
{
    public class LuminariasController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Luminarias
        public ActionResult Index()
        {
            return View(db.Luminarias.ToList());
        }

        // GET: Luminarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Luminaria luminaria = db.Luminarias.Find(id);

            if (luminaria == null)
                return HttpNotFound();

            return View(luminaria);
        }

        // GET: Luminarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Luminarias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Luminaria luminaria)
        {
            if (ModelState.IsValid)
            {
                db.Luminarias.Add(luminaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(luminaria);
        }

        // GET: Luminarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Luminaria luminaria = db.Luminarias.Find(id);

            if (luminaria == null)
                return HttpNotFound();

            return View(luminaria);
        }

        // POST: Luminarias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Luminaria luminaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(luminaria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(luminaria);
        }

        // GET: Luminarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Luminaria luminaria = db.Luminarias.Find(id);

            if (luminaria == null)
                return HttpNotFound();

            return View(luminaria);
        }

        // POST: Luminarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Luminaria luminaria = db.Luminarias.Find(id);
            db.Luminarias.Remove(luminaria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}