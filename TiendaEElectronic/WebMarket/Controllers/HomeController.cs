using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMarket.Controllers
{
    public class HomeController : Controller
    {
        private Models.TiendaEntities bd = new Models.TiendaEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string id="")
        {
            var p = bd.Producto
                .Where(x => x.Denominacion.Contains(id))
                .Take(20)
                .ToList();
            ViewBag.clave = id;
            return View(p);
        }

        public ActionResult Producto(string id)
        {
            ViewBag.producto = id;
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }
    }
}