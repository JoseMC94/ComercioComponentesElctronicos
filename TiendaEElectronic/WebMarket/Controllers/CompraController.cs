using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMarket.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Paso01()
        {
            return View();
        }
        public ActionResult Paso02()
        {
            return View();
        }
        public ActionResult Paso03()
        {
            return View();
        }
        public ActionResult Paso04()
        {
            return View();

        }

        [HttpPost]
        public JsonResult RealizarPedido(List<Pedido> p)
        {
            //validar
            // guardar en base de datos el pedido
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public class Pedido
        {
            public int ProductoId { get; set; }
            public string Denominacion { get; set; }
            public int Cantidad { get; set; }
            public string Imagen { get; set; }
            public decimal Precio { get; set; }
        }
    }
}