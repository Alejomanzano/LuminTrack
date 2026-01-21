using LuminTrack.Migrations;
using LuminTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static System.Collections.Specialized.BitVector32;

namespace LuminTrack.Controllers
{
    public class UsuariosController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // LISTADO - LIBRE
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // DETALLES - LIBRE
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Usuario usuario = db.Usuarios.Find(id);

            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // CREAR - LIBRE
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(new[] { "Administrador", "Tecnico", "Ciudadano" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario, string Password)
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError("Password", "La contraseña es obligatoria");
            }
            else
            {
                // 🔥 Generar hash ANTES de validar
                usuario.PasswordHash = PasswordHelper.Hash(Password);

                // 🔥 Limpiar error previo si existía
                ModelState.Remove("PasswordHash");
            }

            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roles = new SelectList(new[] { "Administrador", "Tecnico", "Ciudadano" }, usuario.Rol);
            return View(usuario);
        }

        // EDITAR - LIBRE
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
                return HttpNotFound();

            ViewBag.Roles = new SelectList(new[] { "Administrador", "Tecnico", "Ciudadano" }, usuario.Rol);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario, string Password)
        {
            // 🔥 Usuario original desde la BD
            var usuarioDB = db.Usuarios.Find(usuario.Id);

            if (usuarioDB == null)
                return HttpNotFound();

            // Actualizar campos editables
            usuarioDB.Nombre = usuario.Nombre;
            usuarioDB.Apellido = usuario.Apellido;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Rol = usuario.Rol;

            // Si se escribió nueva contraseña
            if (!string.IsNullOrWhiteSpace(Password))
            {
                usuarioDB.PasswordHash = PasswordHelper.Hash(Password);
            }

            // 🔥 Limpiar validación de PasswordHash
            ModelState.Remove("PasswordHash");

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roles = new SelectList(
                new[] { "Administrador", "Tecnico", "Ciudadano" },
                usuario.Rol
            );

            return View(usuario);
        }

        // ELIMINAR - LIBRE
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Usuario usuario = db.Usuarios.Find(id);

            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // LOGIN (OPCIONAL)
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            string hash = PasswordHelper.Hash(password);

            var user = db.Usuarios.FirstOrDefault(
                u => u.Email == email && u.PasswordHash == hash
            );

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["Rol"] = user.Rol;
                Session["Email"] = user.Email;

                if (user.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Rol == "Ciudadano")
                {
                    return RedirectToAction("Index", "Ciudadano");
                }
                else if (user.Rol == "Tecnico")
                {
                    return RedirectToAction("Index", "Tecnico");
                }

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Correo o contraseña incorrectos";
            return View();
        }

        // LOGOUT
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}