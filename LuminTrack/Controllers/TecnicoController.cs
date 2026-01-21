using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuminTrack.Controllers
{
    public class TecnicoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Tecnico")
                return RedirectToAction("Login", "Usuarios");

            return View();
        }
    }
}