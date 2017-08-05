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

        public ActionResult Buscar(string id = "")
        {
            var p = bd.Producto
                .Where(x => x.Denominacion.Contains(id))
                .Take(20)
                .ToList();
            ViewBag.clave = id;
            return View(p);
        }

        public ActionResult LoginVista()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult RegistrarV()
        {
            return View();
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


        public ActionResult Login(string usuario, string clave)
        {
            var u = bd.Cliente.FirstOrDefault(x => x.Usuario == usuario && x.Clave == clave);
            if (u != null)
            {
                Helper.SessionHelper.AddUserToSession(u.ClienteId.ToString());
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Helper.SessionHelper.DestroyUserSession();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RegistrarCliente(Models.Cliente c)
        {
            bd.Cliente.Add(c);
            bd.SaveChanges();

            Helper.SessionHelper.AddUserToSession(c.ClienteId.ToString());

            return RedirectToAction("Index", "Home");
        }

        public static string ObtenerNombreUsuario()
        {
            using (var b = new Models.TiendaEntities())
            {
                return b.Cliente.Find(Helper.SessionHelper.GetUser()).Nombres;
            }
        }

    }
}