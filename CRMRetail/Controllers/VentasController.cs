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
    public class VentasController : Utilidades.Comun
    {
        public ActionResult Index()
        {
            if (ConsultaSesion())
            {
                List<m.Consultas.Venta_TOP> Ventas = n.venta.Venta_Selecionar();
                ViewBag.Ventas = Ventas;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult purchase()
        {
            if (ConsultaSesion())
            {
                // Obtener el valor de la sesión "Usuario" en otro controlador
                var musuariorol = (m.UsuariosRoles)Session["Usuario"];

                // Acceder al ID de usuario
                int idUsuario = musuariorol.Usuarios.Id;
                ViewBag.IdUser = idUsuario;


                List<m.Cliente> clientes = n.cliente.Cliente_Seleccionar();
                List<m.Producto> productos = n.producto.Producto_Seleccionar();
                List<m.Catalogos> Horarios = n.catHorarios.Seleccionar();
                ViewBag.CatEstados = n.catEstados.Seleccionar();

                ViewBag.Sucursales = n.catSucursal.Seleccionar();
                //INFORMACION CLIENTES
                ViewBag.Clientes = clientes;
                ViewBag.Productos = productos;
                ViewBag.Horario = Horarios;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        //AGREGA DATOS DE SESION PRODUCTO
        [HttpPost]
        public JsonResult AgregarProducto(m.VentaProducto ventaProducto)
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();

            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }

            int busqueda = 0;
            foreach (var dtProducto in LstNuevosProductoVenta)
            {
                // SI EL VALOR ES EL MISMO, SOLO ACTUALIZAMOS LA CANTIDAD.
                if(dtProducto.IdProducto == ventaProducto.IdProducto)
                {
                    dtProducto.Cantidad += ventaProducto.Cantidad;
                    busqueda = 1;
                }
            }
            
            // SI EL PRODUCTO ES NUEVO
            if(busqueda == 0)
            {
                // LISTADO DE PRECIOS QUE TIENE DISPONIBLE EL NUEVO PRODUCTO
                List<m.Catalogos> cat_precios = n.producto.Producto_Precios_Listar_Nombres(ventaProducto.IdProducto);
                // INFORMACION DEL PRODUCTO
                m.Producto producto = new m.Producto();
                producto.Id = ventaProducto.IdProducto;
                producto = n.producto.Producto_Seleccionar_Id(producto);

                m.NuevoProductoVenta jsonObject = new m.NuevoProductoVenta()
                {
                    IdProducto = producto.Id,
                    Producto = new
                    {
                        Nombre = producto.Nombre,
                        SKU = producto.SKU,
                    },
                    Cantidad = ventaProducto.Cantidad,
                    CatPrecios = cat_precios,
                    IdCatPrecios = 2,
                    Precio = producto.PrecioPublico,
                    BackOrder = 0,
                };

                LstNuevosProductoVenta.Add(jsonObject);
            }
            

            Session["VentaProducto"] = LstNuevosProductoVenta;

            /*/ RETORNAR TODA LA LISTA DE OBJETOS.
            * IdProducto
            * Nombre del producto y SKU
            * Cantidad
            * Cat_precios
            * IdCatPrecios
            * Precio unitario
            * Precio Total
            */

            return Json(LstNuevosProductoVenta);
        }

        [HttpPost]
        public JsonResult ConsultaProductosAgregados()
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();

            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }
            return Json(LstNuevosProductoVenta);
        }


        [HttpPost]
        public JsonResult ConsultaPrecio(m.VentaProducto ventaProducto)
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();

            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }
            
            // CONSULTA LOS NUEVOS VALORES
            m.Producto producto = n.producto.Producto_Selecionar_Precio(ventaProducto.IdPrecio, ventaProducto.IdProducto);

            foreach (var dtProducto in LstNuevosProductoVenta)
            {
                if(dtProducto.IdProducto == ventaProducto.IdProducto)
                {
                    dtProducto.IdCatPrecios = ventaProducto.IdPrecio;
                    dtProducto.Precio = producto.Precio;
                }
            }

            Session["VentaProducto"] = LstNuevosProductoVenta;
            
            return Json(producto);
        }

        [HttpPost]
        public JsonResult ActulizarCantidad(m.VentaProducto ventaProducto)
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();

            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }

            // CONSULTA LOS NUEVOS VALORES
            foreach (var dtProducto in LstNuevosProductoVenta)
            {
                if (dtProducto.IdProducto == ventaProducto.IdProducto)
                {
                    dtProducto.Cantidad = ventaProducto.Cantidad;
                }
            }

            Session["VentaProducto"] = LstNuevosProductoVenta;

            return Json(ventaProducto);
        }

        [HttpPost]
        public JsonResult ActulizarPrecio(m.VentaProducto ventaProducto)
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();
            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }

            // CONSULTA LOS NUEVOS VALORES
            foreach (var dtProducto in LstNuevosProductoVenta)
            {
                if (dtProducto.IdProducto == ventaProducto.IdProducto)
                {
                    dtProducto.Precio = ventaProducto.Precio;
                }
            }

            Session["VentaProducto"] = LstNuevosProductoVenta;
            return Json(ventaProducto);
        }

        [HttpPost]
        public JsonResult ActualizarBackOrder(m.VentaProducto ventaProducto)
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();
            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }

            // CONSULTA LOS NUEVOS VALORES
            foreach (var dtProducto in LstNuevosProductoVenta)
            {
                if (dtProducto.IdProducto == ventaProducto.IdProducto)
                {
                    dtProducto.BackOrder = ventaProducto.BackOrder;
                }
            }

            Session["VentaProducto"] = LstNuevosProductoVenta;
            return Json(ventaProducto);
        }
        //ELIMINA DATOS DE SESION PRODUCTO
        [HttpPost]
        public JsonResult EliminarProducto(m.VentaProducto ventaProducto)
        {
            List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();
            if (Session["VentaProducto"] != null)
            {
                LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
            }

            for(int a = 0; a < LstNuevosProductoVenta.Count; a++)
            {
                if (LstNuevosProductoVenta[a].IdProducto == ventaProducto.IdProducto)
                {
                    LstNuevosProductoVenta.RemoveAt(a);
                }
                
            }

            Session["VentaProducto"] = LstNuevosProductoVenta;
            return Json(LstNuevosProductoVenta);
        }

        [HttpPost]
        public JsonResult RNuevaDireccion(m.Direccion data)
        {

           var r = n.direccion.RegistroDireccionFlash(data); 

            Session["DireccionCliente"] = r;
             
            return Json(r);
        }
        [HttpPost]
        public JsonResult verificar(m.Cliente data)
        {

            var r = n.cliente.Consultar_tipoCliente(data);

            return Json(r);
        }

        public JsonResult Taller(m.Cliente data)
        {

            var r = n.cliente.Consultar_taller (data);

            return Json(r);
        }

        //1
        [HttpPost]
        public JsonResult Direcciones_Seleccionar_List_IdCliente(m.Cliente cliente)
        {
            m.Direccion DireccionCliente = new m.Direccion();
            List<m.Direccion> direccion = n.direccion.Direcciones_Seleccionar_List_IdCliente(cliente);

            if (Session["DireccionCliente"] != null)
            {
                DireccionCliente = (m.Direccion)Session["DireccionCliente"];

                foreach (var dtdireccion in direccion)
                {
                    // SI EL VALOR ES EL MISMO, SOLO ACTUALIZAMOS LA CANTIDAD.
                    if (dtdireccion.Id == DireccionCliente.Id)
                    {
                        dtdireccion.Select = 1;
                    }
                    else
                    {
                        dtdireccion.Select = 0;
                    }
                }
            }


            return Json(direccion);
        }
        //2
        [HttpPost]
        public JsonResult DireccionSeleccionada(m.Cliente cliente)
        {
            // lñlegca el Id del cliente, flag id de la direccion 
            m.Direccion DireccionCliente = new m.Direccion();
            DireccionCliente.Id = cliente.Flag;

            List<m.Direccion> direccion = n.direccion.Direcciones_Seleccionar_List_IdCliente(cliente);

            foreach (var dtdireccion in direccion)
            {
                // SI EL VALOR ES EL MISMO, SOLO ACTUALIZAMOS LA CANTIDAD.
                if (dtdireccion.Id == cliente.Flag)
                {
                    dtdireccion.Select = 1;
                    DireccionCliente.Select = 1;
                }
                else
                {
                    dtdireccion.Select = 0;
                }
            }

            Session["DireccionCliente"] = DireccionCliente;

            return Json(direccion);
        }
        //3
        [HttpPost]
        public JsonResult SeleccionarDireccion(m.Cliente cliente)
        {
            // lñlegca el Id del cliente, flag id de la direccion 
            m.Direccion DireccionCliente  = new m.Direccion();

            DireccionCliente.Select = 0;


            if (Session["DireccionCliente"] != null)
            {
                DireccionCliente = (m.Direccion)Session["DireccionCliente"];

                List<m.Direccion> direccion = n.direccion.Direcciones_Seleccionar_List_IdCliente(cliente);
                bool busqueda = false;
                foreach (var dtdireccion in direccion)
                {
                    if (dtdireccion.Id == DireccionCliente.Id)
                    {
                        DireccionCliente.Estado = dtdireccion.Estado;
                        DireccionCliente.Poblacion = dtdireccion.Poblacion;
                        DireccionCliente.Colonia = dtdireccion.Colonia;
                        DireccionCliente.CP = dtdireccion.CP;
                        DireccionCliente.Calle = dtdireccion.Calle;
                        DireccionCliente.NumExterior = DireccionCliente.NumExterior;
                        DireccionCliente.NumInterior = DireccionCliente.NumInterior;
                        DireccionCliente.EntreCalles = DireccionCliente.EntreCalles;
                        DireccionCliente.Referencias = DireccionCliente.Referencias;
                        //parametro faltante???
                        DireccionCliente.IdDireccion = dtdireccion.IdDireccion;

                        busqueda = true;
                    }
                }

                if (!busqueda)
                {
                    DireccionCliente.Select = 0;
                }
            }
            
            return Json(DireccionCliente);
        }
        //4
        [HttpPost]
        public JsonResult NuevaVenta(m.VentaNueva ventaNueva,List<m.Producto> Objetotaller)
        {
            // REGISTRAR NUEVO CLIENTE.
            m.Cliente cliente = new m.Cliente();
            m.Mensajes resultado = new m.Mensajes();

            m.UsuariosRoles musuariorol = new m.UsuariosRoles();
            if (Session["Usuario"] != null)
            {
                musuariorol = (m.UsuariosRoles)Session["Usuario"];
            }

            m.Direccion DireccionCliente = new m.Direccion();
            if (Session["DireccionCliente"] != null)
            {
                DireccionCliente = (m.Direccion)Session["DireccionCliente"];
            }

            int IdCliente = 0;
            int IdDireccion = DireccionCliente.IdDireccion;
            ////////////////////////////DATOS CLIENTE //////////////////////////////////////////
            cliente.TipoPersona = ventaNueva.TipoPersona;
            cliente.Nombre = ventaNueva.Nombre;
            cliente.ApellidoPaterno = ventaNueva.ApellidoPaterno;
            cliente.ApellidoMaterno = ventaNueva.ApellidoMaterno;
            cliente.Sexo = ventaNueva.Sexo;
            cliente.FechaNacimiento = ventaNueva.FechaNacimiento;
            cliente.FechaConstitucion = ventaNueva.FechaConstitucion;
            cliente.RFC = ventaNueva.RFC;
            cliente.Correo = ventaNueva.Correo;
            cliente.TelefonoMovil = ventaNueva.TelefonoMovil;
            cliente.TelefonoLocal = ventaNueva.TelefonoLocal;
            cliente.IdTipoCliente = ventaNueva.IdTipoCliente;
            cliente.IdOrigenCliente = ventaNueva.IdOrigenCliente;
            cliente.IdSucursal = ventaNueva.IdSucursal;



            if (ventaNueva.TipoPersona == 1)
            {
                cliente.FechaConstitucion = "";
            }
            else
            {
                cliente.ApellidoPaterno = "";
                cliente.ApellidoMaterno = "";
                cliente.Sexo = "";
                cliente.FechaNacimiento = "";
            }

            if (String.IsNullOrEmpty(ventaNueva.TelefonoLocal))
            {
                cliente.TelefonoLocal = "";
            }


            if(ventaNueva.NuevoCliente == 1)
            {
                m.Cliente dt = n.cliente.RegistrarCliente(cliente);
                if (dt.IdCliente > 0)
                {
                    resultado.Resultado = 1;
                    IdCliente = dt.IdCliente;

                    if (ventaNueva.DireccionFiscal == 1)
                    {
                        m.Direccion direccionFiscal = new m.Direccion();
                        m.Mensajes mensajes = new m.Mensajes();

                        // Registra direcciones 
                        // Fiscal
                        direccionFiscal.IdCliente = dt.IdCliente;
                        direccionFiscal.IdEstado = ventaNueva.IdEstado;
                        direccionFiscal.IdPoblacion = ventaNueva.IdPoblacion;
                        direccionFiscal.Colonia = ventaNueva.Colonia;
                        direccionFiscal.IdCP = ventaNueva.IdCP;
                        direccionFiscal.NumExterior = ventaNueva.NumExterior;
                        direccionFiscal.Calle = ventaNueva.Calle;
                        direccionFiscal.NumInterior = ventaNueva.NumInterior;
                        direccionFiscal.EntreCalles = ventaNueva.EntreCalles;
                        direccionFiscal.Referencias = ventaNueva.Referencias;

                        if (String.IsNullOrEmpty(ventaNueva.NumInterior))
                        {
                            direccionFiscal.NumInterior = "";
                        }
                        if (String.IsNullOrEmpty(ventaNueva.EntreCalles))
                        {
                            direccionFiscal.EntreCalles = "";
                        }
                        if (String.IsNullOrEmpty(ventaNueva.Referencias))
                        {
                            direccionFiscal.Referencias = "";
                        }

                        direccionFiscal.FiscalEntrega = 1;
                        direccionFiscal.Flag = 1;

                        if (ventaNueva.DireccionEntrega == 1)
                        {
                            direccionFiscal.Flag = 0;
                        }

                        mensajes = n.direccion.RegistrarDireccionCliente(direccionFiscal);

                        // Entrega
                        if (ventaNueva.DireccionEntrega == 1)
                        {
                            m.Direccion direccionEntrega = new m.Direccion();
                            direccionEntrega.IdCliente = dt.IdCliente;
                            direccionEntrega.IdEstado = ventaNueva.IdEstado2;
                            direccionEntrega.IdPoblacion = ventaNueva.IdPoblacion2;
                            direccionEntrega.Colonia = ventaNueva.Colonia2;
                            direccionEntrega.IdCP = ventaNueva.IdCP2;
                            direccionEntrega.NumExterior = ventaNueva.NumExterior2;
                            direccionEntrega.NumInterior = ventaNueva.NumInterior2;
                            direccionEntrega.Calle = ventaNueva.Calle2;
                            direccionEntrega.EntreCalles = ventaNueva.EntreCalles2;
                            direccionEntrega.Referencias = ventaNueva.Referencias2;
                            direccionEntrega.Flag = 1;
                            direccionEntrega.FiscalEntrega = 0;

                            if (String.IsNullOrEmpty(ventaNueva.NumInterior2))
                            {
                                direccionEntrega.NumInterior = "";
                            }
                            if (String.IsNullOrEmpty(ventaNueva.EntreCalles2))
                            {
                                direccionEntrega.EntreCalles = "";
                            }
                            if (String.IsNullOrEmpty(ventaNueva.Referencias2))
                            {
                                direccionEntrega.Referencias = "";
                            }

                            
                            mensajes = n.direccion.RegistrarDireccionCliente(direccionEntrega);
                        }

                        if(mensajes.Resultado == 1)
                        {
                            IdDireccion = Convert.ToInt32(mensajes.Texto);
                        }
                        
                    }
                }
                else
                {
                    resultado.Resultado = 0;
                    resultado.Texto = dt.Resultado;
                }
            }
            else
            {

                resultado.Resultado = 1;
                //OBTENEMOS EL ID DEL USUARIO SELECCIONADO
                IdCliente = ventaNueva.IdCliente;
                IdDireccion = DireccionCliente.IdDireccion;


            }

            
            if(resultado.Resultado > 0)
            {
                decimal Total = 0;
                int BackOrder = 0;
                int IdVenta = 0;
                List<m.NuevoProductoVenta> LstNuevosProductoVenta = new List<m.NuevoProductoVenta>();

                if (Session["VentaProducto"] != null)
                {
                    //////////////////////DATOS PRODUCTOS/////////////////////////
                    
                    LstNuevosProductoVenta = (List<m.NuevoProductoVenta>)Session["VentaProducto"];
                }

                
                // CONSULTA LOS NUEVOS VALORES
                foreach (var dtProducto in LstNuevosProductoVenta)
                {
                    Total += dtProducto.Precio * dtProducto.Cantidad;
                    if(dtProducto.BackOrder == 1)
                    {
                        BackOrder += 1;
                    }
                }

                // REGISTRAR VENTA (INFORMACION DE PAGO)
                m.Venta venta = new m.Venta();

                venta.IdCliente = IdCliente;
                //Registro venta segun sesion
                //venta.IdUsuario = musuariorol.Usuarios.Id;

                venta.IdUsuario = ventaNueva.IdVendedor;
                venta.IdSucursal = ventaNueva.IdSucursal;
                venta.IdFormaPago = ventaNueva.IdFormaPago;
                venta.IdTarjeta = ventaNueva.IdFormaPagoTarjeta;
                venta.IdTipoEntrega = ventaNueva.IdTipoEntrega;
                venta.IdEstatus = 1;
                venta.Monto = Total;

                if (BackOrder > 0)
                {
                    venta.IdEstatus = 2;
                }

                resultado = n.venta.Venta_Agregar(venta);


                //Resgistro dependiente del tipo de entrega inmediata=1 programada=2
                if (ventaNueva.IdTipoEntrega == 2)
                {
                    // REGISTRAR ENVIO 
                    if (resultado.Resultado == 1)
                    {
                        IdVenta = Convert.ToInt32(resultado.Texto);
                        m.VentaDireccion ventaDireccion = new m.VentaDireccion();
                        ventaDireccion.IdVenta = IdVenta;
                        ventaDireccion.IdDireccion = IdDireccion;
                        ventaDireccion.IdHorario = ventaNueva.IdHorario;
                        ventaDireccion.FechaEntrega = ventaNueva.FechaEntrega;

                        n.ventaDireccion.VentaDireccion_Agregar(ventaDireccion);
                    }
                }
                

                // REGISTAR ARTICULOS.
                foreach (var dtProducto in LstNuevosProductoVenta)
                {
                    m.VentaProducto ventaProducto = new m.VentaProducto();
                    ventaProducto.IdVenta = Convert.ToInt32(resultado.Texto);
                    ventaProducto.IdProducto = dtProducto.IdProducto;
                    ventaProducto.IdPrecio = dtProducto.IdCatPrecios;
                    ventaProducto.Precio = dtProducto.Precio;
                    ventaProducto.Cantidad = dtProducto.Cantidad;
                    ventaProducto.BackOrder = dtProducto.BackOrder;


                    n.ventaProducto.VentaProducto_Agregar(ventaProducto);
                }

                m.Cliente dataCliente = n.cliente.Cliente_Seleccionar_Id(IdCliente);
                int IdVentaNew = Convert.ToInt32(resultado.Texto);

                correo.EnvioCorreoTicket(LstNuevosProductoVenta, dataCliente, IdVentaNew);

                List<m.Producto> Res = n.cliente.InsertarTaller(Objetotaller, IdVentaNew);

                // Eliminar variable de sesion 
                Session["VentaProducto"] = null;
                Session["DireccionCliente"] = null;
            }


            return Json(resultado);
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

        /// <summary>
        /// NUEVO DESARROLLO, NUEVA VENTA.
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevaVenta()
        {
            List<m.Cliente> clientes = n.cliente.Cliente_Seleccionar();
            List<m.Producto> productos = n.producto.Producto_Seleccionar();
            ViewBag.Sucursales = n.catSucursal.Seleccionar();
            ViewBag.Clientes = clientes;
            ViewBag.Productos = productos;
            return View();
        }

        
    // GET: Ventas
        //public ActionResult Index()
        //{
        //    m.UsuariosRoles usuariosroles = (m.UsuariosRoles)Session["Usuario"];
        //    return View(n.ventas.SeleccionarPorIdUsuario(usuariosroles.Usuarios.Id));
        //}

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Modificar()
        {
            int idventa = Convert.ToInt32((Request.QueryString["Id"]));

            ViewBag.Productos = n.ventaProducto.SeleccionarDetalleProducto(idventa);

            return View();
        }

        [HttpGet]
        public ActionResult ProductosXCliente(int idproducto=1)
        {
            return View(n.reportes.ProductosXCliente(idproducto));
        }

        public ActionResult VentasPorCategoria()
        {
            return View(n.ventasproductos.SeleccionarPorCategoria(1));
        }

        public ActionResult OrdenesPendientes()
        {
            return View(n.ventas.SeleccionarVentasBakcOrderPendientes());
        }

        // Procedimientos Json

        /// <summary>
        /// Agrega una venta de un producto por vez primera (tablas Ventas y VentasProductos)
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public JsonResult VentaAgregar(List<m.Productos> productos)
        {
            DateTime fecha = DateTime.Now;
            DateTime fechaentrega = DateTime.Parse("1900/01/01");
            string horaentrega = "";
            
            if (!productos[1].Fecha.ToString().Contains("01/01/0001"))
            {
                fecha = DateTime.Parse(productos[1].Fecha.ToString());
            }

            if (!productos[1].FechaEntrega.ToString().Contains("01/01/0001"))
            {
                fechaentrega = DateTime.Parse(productos[1].FechaEntrega.ToString());
            }

            if (productos[1].HoraEntrega != null)
            {
                horaentrega = productos[1].HoraEntrega.ToString();
            }


            //Agregar la venta
            var ventaId = n.ventas.Agregar(
                int.Parse(productos[1].SKU), 
                fecha, 
                int.Parse(productos[1].PrecioPublico.ToString()), 
                int.Parse(productos[1].Descripcion), 
                int.Parse(productos[1].PrecioDistribuidor.ToString()),
                int.Parse(productos[1].TarjetaCredito.ToString()),
                fechaentrega,
                horaentrega
                );
            
            //Agregar el producto de la venta
            for (int i=1;i<productos.Count(); i++)
            {
                if (productos[i].Id > 0)
                {
                    var idproducto = productos[i].Id;
                    var cantidad = productos[i].Categoria;

                    var precio = n.productos.SeleccionarPrecioProducto(idproducto);
                        n.ventasproductos.Agregar(
                       ventaId, 
                       idproducto,
                       cantidad,
                       precio
                       );
                }
            }
            return Json(ventaId, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Agrega un nuevo producto a una venta ya hecha
        /// </summary>
        /// <param name="productos"></param>
        /// <returns></returns>
        public JsonResult VentaAgregar2(int idventa, int idproducto, int cantidad)
        {
            var precio = n.productos.SeleccionarPrecioProducto(idproducto);
            //Agregar el producto de la venta
            n.ventasproductos.Agregar(
                idventa,
                idproducto,
                cantidad,
                precio
                );

            return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentaDetalle(int idventa)
        {
            //Detalle de productos de la venta            
            return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentaDetalleCliente(m.Venta venta)
        {
            return Json(n.venta.SeleccionarDetalleCliente(venta.Id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentaProductoSeleccionar(int idventa)
        {
            return Json(n.ventaProducto.SeleccionarDetalleProducto(idventa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasGuardarCambios(int idventa, int idcliente, int tipo, int vendedor, int entrega, string tarjetacredito, string fechaentrega, string horaentrega)
        {
            m.Ventas items = new m.Ventas();
            items.Id = idventa;
            items.Clientes.Id = idcliente;
            items.Tipo = tipo;
            items.Vendedor = vendedor;
            items.TipoEntrega = entrega;
            items.TarjetaCredito = string.IsNullOrEmpty(tarjetacredito) ? 0 : int.Parse(tarjetacredito);
            items.FechaEntrega = string.IsNullOrEmpty(fechaentrega) ? DateTime.Parse("1900/01/01") : DateTime.Parse(fechaentrega);
            items.HoraEntrega = horaentrega;
            n.ventas.Modificar(items);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasProductosAgregarNuevo(int idventa, int idproducto, int cantidad)
        {
            decimal precioproducto = n.productos.SeleccionarPrecioProducto(idproducto);
            n.ventasproductos.Agregar(idventa, idproducto, cantidad, precioproducto);
            return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
        }
        public JsonResult VentasProductosModificarCantidad(int idventa, int idproducto, int cantidad)
        {
            if (cantidad < 1)
            {
                return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
            }
            else
            {
                n.ventasproductos.Modificar_Cantidad(idventa, idproducto, cantidad);
                return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult VentasProductosModificarPrecio(int idventa, int idproducto, decimal precio)
        {
            n.ventasproductos.Modificar_Precio(idventa, idproducto, precio);
            return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasModificarBackOrder(int idventa, int backorder)
        {
            return Json(n.ventas.Modificar_BackOrder(idventa, backorder), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasProductosEliminarRegistro(int idventa, int idproducto)
        {
            n.ventasproductos.EliminarRegistro(idventa, idproducto);
            return Json(n.ventasproductos.SeleccionarPorIdVenta(idventa), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasProductosObtenerPorCategoria(int idcategoria)
        {
            return Json(n.ventasproductos.SeleccionarPorCategoria(idcategoria), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasBackOrderPendientesCuantas()
        {
            return Json(n.ventas.SeleccionarCuantasVentasBackOrderPendiente(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult VentasCancelar(int idventa)
        {            
            return Json(n.ventas.Modificar_Cancelar_Venta(idventa), JsonRequestBehavior.AllowGet);
        }


        //public JsonResult Guardartaller(List<m.Producto> Objetotaller)
        //{
        
        //    List<m.Producto> Res =n.cliente.InsertarTaller(Objetotaller);
        //    return Json(Res);
        //}

    }
}
