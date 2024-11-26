using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using m = CRMRetail.Modelos;


namespace CRMRetail.Controllers
{
    public class EncuestasController : Utilidades.Comun
    {
        // GET: Encuestas
        public ActionResult Index()
        {
            //Datos Venta Id
            int Id = Convert.ToInt32(Request.QueryString["Id"]);

            m.Cliente cliente = new m.Cliente();
            cliente.Id = Id;

            List<m.Encuesta> Lq1 = n.encuesta.List_Cat_q1_t1();
            ViewBag.q1 = Lq1;
            List<m.Encuesta> Lq2 = n.encuesta.List_Cat_q2_t1();
            ViewBag.q2 = Lq2;
            List<m.Encuesta> Lq3 = n.encuesta.List_Cat_q3_t1();
            ViewBag.q3 = Lq3;

            m.Cliente LInfo = n.encuesta.InfoUsuario(cliente);
            ViewBag.InfoUsuario = LInfo;

            return View();
        }

        public ActionResult FormatoEntrega()
        {
            //Datos Venta Id
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            m.Venta venta = new m.Venta();
            venta.Id = Id;

            m.Cliente cliente = new m.Cliente();
            cliente.Id = Id;

            List<m.Encuesta> Lq1 = n.encuesta.List_Cat_q1_t2();
            ViewBag.q1 = Lq1;

            List<m.Venta> Lventa = n.encuesta.List_venta(venta);
            ViewBag.ListVenta = Lventa;

            m.Cliente LInfo = n.encuesta.InfoUsuario(cliente);
            ViewBag.InfoUsuario = LInfo;


            return View();
        }

        [HttpPost]
        public JsonResult RegistrarEntrega(m.Encuesta DEncuesta)
        {
            m.Encuesta encuesta = n.encuesta.InsertFormatoEntrega(DEncuesta);
            return Json(encuesta);
        }
        
        [HttpPost]
        public JsonResult RegistrarEncuesta(m.Encuesta DEncuesta)
        {
            m.Encuesta encuesta = n.encuesta.InsertEncuestaWeber(DEncuesta);
            return Json(encuesta);
        }
    }
}