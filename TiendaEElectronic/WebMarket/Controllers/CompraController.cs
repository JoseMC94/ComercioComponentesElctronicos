using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMarket.Controllers
{
    public class CompraController : Controller
    {
        private Models.TiendaEntities bd = new Models.TiendaEntities();
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
            var cliente = bd.Cliente.Find(Helper.SessionHelper.GetUser());
            return View(cliente);

        }
        public ActionResult Paso04()
        {
            return View();

        }

        [HttpPost]
        public JsonResult RealizarPedido(List<Pedido> p)
        {
            // guardar en base de datos
            var clienteid = Helper.SessionHelper.GetUser();
            var pcab = new Models.Pedido
            {
                ClienteId = clienteid,
                Estado = "P",
                Fecha = DateTime.Now
            };

            bd.Pedido.Add(pcab);
            bd.SaveChanges();


            foreach (var item in p)
            {
                var pdet = new Models.PedidoDetalle
                {
                    PedidoId = pcab.PedidoId,
                    Cantidad = item.Cantidad,
                    ProductoId = item.ProductoId
                };
                bd.PedidoDetalle.Add(pdet);
                bd.SaveChanges();
            }
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