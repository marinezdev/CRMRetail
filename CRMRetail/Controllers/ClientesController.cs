using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m = CRMRetail.Modelos;

namespace CRMRetail.Controllers
{
    public class ClientesController : Utilidades.Comun
    {
        /// <summary>
        /// CONSULTA DE CLIENTES LISTADO
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<m.Cliente> clientes = n.cliente.Cliente_Seleccionar();
            ViewBag.Clientes = clientes;
            
            return View();
        }

        [HttpPost]
        public JsonResult Cliente_Seleccionar_Id(m.Cliente cliente)
        {
            m.Cliente dt = n.cliente.Cliente_Seleccionar_Id(cliente);
            List<m.Direccion> direccions = n.direccion.Direcciones_Seleccionar_IdCliente(cliente);

            if(direccions.Count > 0)
            {
                dt.Estado = direccions[0].Estado;
                dt.IdPoblacion = direccions[0].IdPoblacion;
                dt.Poblacion = direccions[0].Poblacion;
                dt.Colonia = direccions[0].Colonia;
                dt.IdCP = direccions[0].IdCP;
                dt.CP = direccions[0].CP;
                dt.NumExterior = direccions[0].NumExterior;
                dt.NumInterior = direccions[0].NumInterior;
                dt.Calle = direccions[0].Calle;
                dt.EntreCalles = direccions[0].EntreCalles;
                dt.Referencias = direccions[0].Referencias;
                dt.FiscalEntrega = direccions[0].FiscalEntrega;
                dt.Flag = direccions[0].Flag;
                dt.IdDireccion = direccions[0].IdDireccion;

                if (dt.Flag == 0)
                {
                    if (direccions.Count > 1)
                    {
                        dt.Estado2 = direccions[1].Estado;
                        dt.IdPoblacion2 = direccions[1].IdPoblacion;
                        dt.Poblacion2 = direccions[1].Poblacion;
                        dt.Colonia2 = direccions[1].Colonia;
                        dt.IdCP2 = direccions[1].IdCP;
                        dt.CP2 = direccions[1].CP;
                        dt.NumExterior2 = direccions[1].NumExterior;
                        dt.NumInterior2 = direccions[1].NumInterior;
                        dt.Calle2 = direccions[1].Calle;
                        dt.EntreCalles2 = direccions[1].EntreCalles;
                        dt.Referencias2 = direccions[1].Referencias;
                        dt.IdDireccion2 = direccions[1].IdDireccion;

                    }

                }
            }


            return Json(dt);
        }

        public JsonResult Membresia(m.Cliente cliente)
        {
            m.Cliente dt = n.cliente.ObtenerDuracionMembresia(cliente);

            return Json(dt);
        }

        [HttpPost]
        public JsonResult Cliente_Seleccionar_Detalle_Id(m.Cliente cliente)
        {
            m.Cliente dt = n.cliente.ClienteSeleccionarDetallePorId(cliente.Id);

            List<m.Direccion> direccions = n.direccion.Direcciones_Seleccionar_IdCliente(cliente);

            if (direccions.Count > 0)
            {
                dt.IdDireccion = direccions[0].IdDireccion;
                dt.IdEstado = direccions[0].IdEstado;
                dt.Estado = direccions[0].Estado;
                dt.IdPoblacion = direccions[0].IdPoblacion;
                dt.Poblacion = direccions[0].Poblacion;
                dt.IdColonia = direccions[0].IdColonia;
                dt.Colonia = direccions[0].Colonia;
                dt.IdCP = direccions[0].IdCP;
                dt.CP = direccions[0].CP;
                dt.NumExterior = direccions[0].NumExterior;
                dt.NumInterior = direccions[0].NumInterior;
                dt.Calle = direccions[0].Calle;
                dt.EntreCalles = direccions[0].EntreCalles;
                dt.Referencias = direccions[0].Referencias;
                dt.FiscalEntrega = direccions[0].FiscalEntrega;
                dt.Flag = direccions[0].Flag;

                if (dt.Flag == 0)
                {
                    if (direccions.Count > 1)
                    {
                        dt.IdDireccion2 = direccions[1].IdDireccion;
                        dt.IdEstado2 = direccions[1].IdEstado;
                        dt.Estado2 = direccions[1].Estado;
                        dt.IdPoblacion2 = direccions[1].IdPoblacion;
                        dt.Poblacion2 = direccions[1].Poblacion;
                        dt.Colonia2 = direccions[1].Colonia;
                        dt.IdCP2 = direccions[1].IdCP;
                        dt.CP2 = direccions[1].CP;
                        dt.NumExterior2 = direccions[1].NumExterior;
                        dt.NumInterior2 = direccions[1].NumInterior;
                        dt.Calle2 = direccions[1].Calle;
                        dt.EntreCalles2 = direccions[1].EntreCalles;
                        dt.Referencias2 = direccions[1].Referencias;

                    }

                }
            }

            return Json(dt);
        }

        /// <summary>
        /// AGREGAR NUEVOS CLIENTES
        /// </summary>
        /// <returns></returns>
        public ActionResult Agregar()
        {
            ViewBag.CatEstados = n.catEstados.Seleccionar();
            ViewBag.Sucursales = n.catSucursal.Seleccionar();

            return View();
        }

        public ActionResult Modificar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Consulta_DelegacionMunicipio(m.Catalogos Catalogos)
        {
            List<m.Catalogos> Poblaciones = n.catPoblacion.Seleccionar(Catalogos.Id);

            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_Colonias(m.Catalogos Catalogos)
        {
            List<m.Catalogos> Poblaciones = n.catColonias.Seleccionar(Catalogos.Id);

            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_CP(m.Catalogos Catalogos)
        {
            List<m.Catalogos> Poblaciones = n.catCP.Seleccionar(Catalogos.Id);

            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult CP_Busqueda(m.Catalogos Catalogos)
        {
            List<m.Direccion> Poblaciones = n.catCP.Cat_CP_Busqueda(Catalogos.Nombre);

            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult NuevoCliente(m.Cliente cliente)
        {
            m.Mensajes resultado = new m.Mensajes();
            // Registra al nuevo cliente
            if (cliente.TipoPersona == 1)
            {
                cliente.FechaConstitucion = "";
            }
            else
            {
                cliente.ApellidoPaterno = "";
                cliente.ApellidoMaterno = "";
                cliente.Sexo = "";
                cliente.FechaNacimiento = "";
                cliente.MesCumple = "";
                cliente.DiaCumple = "";
            }

            if (String.IsNullOrEmpty(cliente.DiaCumple))
            {
                cliente.DiaCumple = "";
            } 
            if (String.IsNullOrEmpty(cliente.TelefonoLocal))
            {
                cliente.TelefonoLocal = "";
            }
            if (String.IsNullOrEmpty(cliente.FechaNacimiento))
            {
                cliente.FechaNacimiento = "";
            }
            if (String.IsNullOrEmpty(cliente.RFC))
            {
                cliente.RFC = "";
            }

            m.Cliente dt = n.cliente.RegistrarCliente(cliente);
            
            if(dt.IdCliente > 0)
            {
                //verificación datos BD  
                m.Direccion direccionFiscal = new m.Direccion();
                resultado.Resultado = 1;
                resultado.Texto = "Cliente: "+ cliente.Nombre + " "+ cliente.ApellidoPaterno + " " + cliente.ApellidoMaterno;

                // Fiscal
                if (String.IsNullOrEmpty(cliente.NumInterior))
                {
                    cliente.NumInterior = "";
                }
                if (String.IsNullOrEmpty(cliente.EntreCalles))
                {
                    cliente.EntreCalles = "";
                }
                if (String.IsNullOrEmpty(cliente.Referencias))
                {
                    cliente.Referencias = "";
                }
                if (cliente.IdEstado == 0)
                {
                    cliente.IdEstado = 34;
                }
                if (cliente.IdPoblacion==0)
                {
                    cliente.IdPoblacion = 2463;
                }
                if (cliente.IdColonia == 0)
                {
                    cliente.Colonia = "prueba";
                }
                if (cliente.IdCP == 0)
                {
                    cliente.IdCP = 32484;
                }
                if (String.IsNullOrEmpty(cliente.NumExterior))
                {
                    cliente.NumExterior = "";
                }
                if (String.IsNullOrEmpty(cliente.Calle))
                {
                    cliente.Calle = "";
                }

                direccionFiscal.IdCliente = dt.IdCliente;
                direccionFiscal.NumInterior = cliente.NumInterior;
                direccionFiscal.EntreCalles = cliente.EntreCalles;
                direccionFiscal.Referencias = cliente.Referencias;
                direccionFiscal.IdEstado = cliente.IdEstado;
                direccionFiscal.IdPoblacion = cliente.IdPoblacion;
                direccionFiscal.Colonia = cliente.Colonia;
                direccionFiscal.IdCP = cliente.IdCP;
                direccionFiscal.NumExterior = cliente.NumExterior;
                direccionFiscal.Calle = cliente.Calle;
                direccionFiscal.FiscalEntrega = 1;
                direccionFiscal.Flag = 1;
                if (cliente.FiscalEntrega == 1)
                {
                    direccionFiscal.Flag = 0;
                }

                m.Mensajes mensajes = n.direccion.RegistrarDireccionCliente(direccionFiscal);

                // Entrega
                if (cliente.FiscalEntrega == 1)
                {
                    //verificación datos BD  
                    m.Direccion direccionEntrega = new m.Direccion();

                    if (String.IsNullOrEmpty(cliente.NumInterior2))
                    {
                        cliente.NumInterior2 = "";
                    }
                    if (String.IsNullOrEmpty(cliente.EntreCalles2))
                    {
                        cliente.EntreCalles2 = "";
                    }
                    if (String.IsNullOrEmpty(cliente.Referencias2))
                    {
                        cliente.Referencias2 = "";
                    }
                    if (cliente.IdEstado2==0)
                    {
                        direccionEntrega.IdEstado2 = 34;
                    }
                    if (cliente.IdPoblacion2 == 0)
                    {
                        direccionEntrega.IdPoblacion2 = 2463;
                    }
                    if (cliente.IdColonia2 == 0)
                    {
                        cliente.Colonia2 = "prueba";
                    }
                    if (cliente.IdCP2 == 0)
                    {
                        direccionEntrega.IdCP2 = 32484;
                    }
                    if (String.IsNullOrEmpty(cliente.NumExterior2))
                    {
                        direccionEntrega.NumExterior2 = "";
                    }
                    if (String.IsNullOrEmpty(cliente.Calle2))
                    {
                        cliente.Calle2 = "";
                    }
                   
                    direccionEntrega.IdCliente = dt.IdCliente;
                    direccionEntrega.NumInterior = cliente.NumInterior2;
                    direccionEntrega.EntreCalles = cliente.EntreCalles2;
                    direccionEntrega.Referencias = cliente.Referencias2;
                    direccionEntrega.IdEstado = cliente.IdEstado2;
                    direccionEntrega.IdPoblacion = cliente.IdPoblacion2;
                    direccionEntrega.Colonia = cliente.Colonia2;
                    direccionEntrega.IdCP = cliente.IdCP2;
                    direccionEntrega.NumExterior = cliente.NumExterior2;
                    direccionEntrega.Calle = cliente.Calle2;

                    direccionEntrega.Flag = 1;
                    direccionEntrega.FiscalEntrega = 0;
                    n.direccion.RegistrarDireccionCliente(direccionEntrega);
                }
            }
            else
            {
                resultado.Resultado = 0;
                resultado.Texto = dt.Resultado;
            }
            

            return Json(resultado);
        }

        [HttpPost]
        public JsonResult BuscarClienteRFC(m.Cliente cliente)
        {
            m.Cliente dt = n.cliente.BuscarClienteRFC(cliente);
            return Json(dt);
        }

        [HttpPost]
        public JsonResult ModificarDetalle(m.Modelos modelos)
        {
            n.cliente.Modificar(modelos);
            return Json(1);
        }

        [HttpPost]
        public ActionResult Agregar(string Nombre, string APaterno, string AMaterno, string DFiscal, string DEntrega, string RFC,
        string TFijo, string TCelular, string SexoRadio, int Tipo, int Origen, string Correo, int PersonaRadio, string FNacimiento = "")
        {
            
            //Validación de correo

            if (!Correo.Contains("@"))
            {
                TempData["Mensaje"] = "<div class='alert alert-danger' role'alert'>Correo incorrecto, revise y escriba correctamente el correo, de lo contrario, no se le permitirá guardar los datos.</div>";
                return View("Agregar");
            }

            //Validar si el campo FNacimiento es un dato fecha
            if (FNacimiento == "")
            {
                if (RFC.Length == 13)
                {
                    var año = RFC.Substring(4, 2);
                    var mes = RFC.Substring(6, 2);
                    var dia = RFC.Substring(8, 2);
                    FNacimiento = dia + "/" + mes + "/" + año;
                }
                else if (RFC.Length==12)
                {
                    var año = RFC.Substring(3, 2);
                    var mes = RFC.Substring(5, 2);
                    var dia = RFC.Substring(7, 2);
                    FNacimiento = dia + "/" + mes + "/" + año;
                }
            }

            string FechaValida ;
            if (EsFecha(FNacimiento))
            {
                FechaValida = FNacimiento;
             }
            else
            {
                FechaValida = "1900/01/01";
            }

            m.Clientes cl = new m.Clientes()
            {
                Nombre = Nombre,
                ApellidoPaterno = APaterno,
                ApellidoMaterno = AMaterno,
                DireccionFiscal = DFiscal,
                DireccionEntrega = DEntrega,
                RFC = RFC,
                TelefonoFijo = string.IsNullOrEmpty(TFijo) ? "0" : TFijo,
                TelefonoCelular = TCelular,
                Sexo = SexoRadio,
                FechaNacimiento = DateTime.Parse(FechaValida),
                Tipo = Tipo,
                Origen = Origen,
                Correo = Correo,
                FisicaMoral = PersonaRadio

            };
            ViewData["Mensaje"] = n.clientes.Agregar(cl);
            return View("Index", n.clientes.Seleccionar());
        }

        [HttpGet]
        public ActionResult Modificar(int id)
        {
            ViewBag.ProductosPorCliente = n.productos.SeleccionarCompradosPorCliente(id);
            return View(n.clientes.SeleccionarPorId(id));
        }

        [HttpPost]
        public ActionResult Modificar(string Nombre, string APaterno, string AMaterno, string DFiscal, string DEntrega, string RFC,
        string TFijo, string TCelular, string SexoRadio, int Tipo, int Origen, string Correo, int PersonaRadio, int Id, string FNacimiento)
        {

            var fecha = FNacimiento;
            string FechaValida = "";

            if (RFC.Length == 13)
                {
                    var año = RFC.Substring(4, 2);
                    var mes = RFC.Substring(6, 2);
                    var dia = RFC.Substring(8, 2);
                    FechaValida = dia + "/" + mes + "/" + año;
                }
                else if (RFC.Length==12)
                {
                    var año = RFC.Substring(3, 2);
                    var mes = RFC.Substring(5, 2);
                    var dia = RFC.Substring(7, 2);
                    FechaValida = dia + "/" + mes + "/" + año;
                }

            m.Clientes cl = new m.Clientes()
            {
                Nombre = Nombre,
                ApellidoPaterno = APaterno,
                ApellidoMaterno = AMaterno,
                DireccionFiscal = DFiscal,
                DireccionEntrega = DEntrega,
                RFC = RFC,
                TelefonoFijo = TFijo,
                TelefonoCelular = TCelular,
                Sexo = SexoRadio,
                FechaNacimiento = DateTime.Parse(FechaValida),
                Tipo = Tipo,
                Origen = Origen,
                Correo = Correo,
                FisicaMoral = PersonaRadio,
                Id=Id

            };
            ViewData["Mensaje"] = "3";
            n.clientes.Modificar(cl);
            return View("Index", n.clientes.Seleccionar());
        }

        //Procesos Json

        public JsonResult ClienteSeleccionarPorId(m.Cliente items)
        {
            return Json(n.cliente.Cliente_Seleccionar_Id(items), JsonRequestBehavior.AllowGet);
        }



        public JsonResult ClienteSeleccionarPorIdProducto(int idproducto)
        {
            return Json(n.clientes.SeleccionarPorIdProducto(idproducto), JsonRequestBehavior.AllowGet);
        }

        private bool EsFecha(string fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
