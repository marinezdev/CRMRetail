using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m = CRMRetail.Modelos;

namespace CRMRetail.Controllers
{
    public class HomeController : Utilidades.Comun
    {
        public ActionResult Index()
        {
            if (ConsultaSesion())
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                List<m.Consultas.ReporteVentas> reporteVentas = n.venta.Socursales_ventasXmes();
                ViewBag.ReporteVentas = reporteVentas;
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                List<m.Consultas.Venta_PorMes> Venta_PorMes = n.venta.Venta_PorMes();
                List<m.Consultas.Venta_PorMes> Venta_Dia = n.venta.Venta_Dia();
                List<m.Consultas.Cliente_Ganados_TOP> Cliente_Ganados_TOP = n.cliente.Cliente_Ganados_TOP();
                List<m.Consultas.Venta_TOP> Venta_TOP = n.venta.Venta_TOP();
                List<m.Consultas.Venta_TOP> Venta_BackOrder = n.venta.Venta_BackOrder();
                m.Consultas.Venta_ResumenMes Venta_ResumenMes = n.venta.Venta_ResumenMes();

                m.Cliente cliente = n.cliente.ConteoUser();
                m.Cliente ordenpendiente = n.cliente.Conteo_BackOrder();
                ViewBag.ContClient = cliente.Id;
                ViewBag.ContBack = ordenpendiente.Id;


                //Labels Graficas
                List<m.Configuracion> SucursalsName = n.configuracion.Seleccionar();
                ViewBag.NSucursal = SucursalsName;

                //Data Pastel
                List<m.Consultas.ReporteVentas> Venta_ResumenMesR = n.venta.Venta_ResumenMesR();
                ViewBag.ResumenM = Venta_ResumenMesR;

                List<m.Consultas.Venta_PorMes> Venta_DiaR = n.venta.Venta_DiaR();
                ViewBag.Venta_DiaR = Venta_DiaR;

                //DATA REPORTES ANUALES

                List<m.Consultas.Venta_PorMes> Venta_anual = n.venta.R_Anual_2023();
                ViewBag.Venta_Anual_2023 = Venta_anual;

                List<m.Consultas.Venta_PorMes> Venta_anual4 = n.venta.R_Anual_2024();
                ViewBag.Venta_Anual_2024 = Venta_anual4;

                ViewBag.Venta_PorMes = Venta_PorMes;
                ViewBag.Venta_Dia = Venta_Dia;
                ViewBag.Cliente_Ganados_TOP = Cliente_Ganados_TOP;
                ViewBag.Venta_TOP = Venta_TOP;
                ViewBag.Venta_BackOrder = Venta_BackOrder;
                ViewBag.Venta_ResumenMes = Venta_ResumenMes;

                /////////////////////////////////PROCESO EMAIL/////////////////////////////////////////////////////////////////////////////////////////////////
                List<m.TallerUser> ListallerUsers = n.venta.Listar_CorreoTaller();

                foreach (var dtUsuario in ListallerUsers)
                {
                    correo.EnvioCorreoTaller(dtUsuario);

                }

                n.venta.ActualizarCorreoTaller();

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
                
        }

        public bool ConsultaSesion()
        {
            bool Actividad = false;
            if (Session["Menu"] != null)
            {
                if (Session["Usuario"] != null)
                {
                    Actividad = true;
                }
            }

            return Actividad;
        }

        public ActionResult CambiarContraseña()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarContraseña(string ClaveActual, string ClaveNueva, string Repetir)
        {
            if (ClaveNueva.Length < 4 || Repetir.Length < 4)
            {
                ViewData["Mensaje"] = "<div class='alert alert-warning' role='alert' style='width:100%'>La contraseña no tiene la longitud requerida, intente de nuevo.</div>";
            }
            else
            {
                if (ClaveNueva == Repetir)
                    if (n.usuarios.ModificarContraseña(ClaveActual, ClaveNueva, (Session["Usuario"] as Modelos.UsuariosRoles).Usuarios.Id) == -1)
                        ViewData["Mensaje"] = "<div class='alert alert-success' role='alert' style='width:100%'>Se actualizó la contraseña correctamente, ahora debe salir del sistema y volver a entrar para que los cambios tengan efecto, de lo contrario, sus datos se perderán.</div>";
                    else
                        ViewData["Mensaje"] = "<div class='alert alert-danger' role='alert' style='width:100%'>No se actualizó la contraseña, hay un error en el sistema, intente de nuevo más tarde.</div>";
                else
                    ViewData["Mensaje"] = "<div class='alert alert-warning' role='alert' style='width:100%'>Hay un error en las contraseñas, intente de nuevo.</div>"; ;
            }
            return View();
        }

        //************************* Procesos Json para reportes ********************************************

        //Ventas diarias por empresa
        public JsonResult VentasDiariasPorEmpresa(int idempresa)
        {
            return Json(n.reportes.ReporteVentasPorDiaPorEmpresa(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Montos diarios por empresa
        public JsonResult MontosDiariosPorEmpresa(int idempresa)
        {
            return Json(n.reportes.ReporteMontosPorDiaPorEmpresa(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Ventas mensuales por empresa
        public JsonResult VentasMensualesPorEmpresaPorMes(int idempresa)
        {
            return Json(n.reportes.ReporteVentasPorMesPorEmpresa(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Montos mensuales por empresa
        public JsonResult MontosMensualesPorEmpresaPorMes(int idempresa)
        {
            return Json(n.reportes.ReporteMontosPorMesPorEmpresa(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Ventas anuales por empresa
        public JsonResult VentasAnualesPorEmpresaPorMes(int idempresa)
        {
            return Json(n.reportes.ReporteVentasAnualPorEmpresa(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Montos anuales por empresa
        public JsonResult MontosAnualesPorEmpresaPorMes(int idempresa)
        {
            return Json(n.reportes.ReporteMontosAnualPorEmpresa(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Ventas Por producto x cliente
        public JsonResult ProductosPorCliente(int idproducto)
        {
            return Json(n.reportes.ProductosXCliente(idproducto), JsonRequestBehavior.AllowGet);
        }

        //Top ten productos por tienda
        public JsonResult ProductosPorTiendaTopTen(int idempresa)
        {
            return Json(n.reportes.TopTenProductosXTienda(idempresa), JsonRequestBehavior.AllowGet);
        }

        //Top ten categorías por tienda
        public JsonResult CategoriasPorTiendaTopTen(int idempresa)
        {
            return Json(n.reportes.TopTenCategoriasXTienda(idempresa), JsonRequestBehavior.AllowGet);
        }


    }
}
