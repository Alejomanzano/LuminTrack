using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuminTrack.Controllers
{
    public class CiudadanoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Ciudadano")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}