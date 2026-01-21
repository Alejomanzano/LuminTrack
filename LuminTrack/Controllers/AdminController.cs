using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuminTrack.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            // Seguridad mínima
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}