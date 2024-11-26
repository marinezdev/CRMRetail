using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m = CRMRetail.Modelos;

namespace CRMRetail.Controllers
{
    public class MarketingController : Utilidades.Comun
    {
        // GET: Marketing
        public ActionResult Index()
        {
            return View(n.marketing.Seleccionar());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(string Clave, string Nombre, DateTime Inicio, DateTime Fin, string Objetivo,  
        DateTime Envios, DateTime InicioEvento,
		DateTime FinEvento, string HoraInicio, 	string HoraFin, string Ubicacion, string Descripcion,
        int? Correo = 0, int? Facebook = 0, int? Linkedin = 0, int? Llamada = 0, int? PaginaASAE = 0)
        {
            m.UsuariosRoles usuariosroles = (m.UsuariosRoles)Session["Usuario"];
            m.Marketing items = new m.Marketing()
            {
                Clave = Clave,
                Nombre = Nombre,
                Inicio = Inicio,
                Fin = Fin,
                Objetivo = Objetivo,
                Estado = 1,
                Usuario = usuariosroles.Usuarios.Id,
                Correo = (int)Correo,
                Facebook = (int)Facebook,
                Linkedin = (int)Linkedin,
                Llamada = (int)Llamada,
                PaginaASAE = (int)PaginaASAE,
                Envios = Envios,
                InicioEvento = InicioEvento,
                FinEvento = FinEvento,
                HoraInicio = HoraInicio,
                HoraFin = HoraFin,
                Ubicacion = Ubicacion,
                Descripcion = Descripcion
            };            
            Session["IdCampaña"] = n.marketing.Agregar(items);
            ViewBag.Productos = Datos.Catalogos.SeleccionarProductosPorNombre();
            return View("Clientes"); ;
        }

        public ActionResult Clientes()
        {
            ViewBag.Productos = Datos.Catalogos.SeleccionarProductosPorNombre();
            return View();
        }

        public ActionResult Correo()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Correo(string IdCampaña, string asunto, string contenido)
        {
            var boton1 = Request.Form["Boton1"];
            var boton2 = Request.Form["Boton2"];
            if (boton1 != null)
            {
                n.marketingcorreo.Agregar(IdCampaña, asunto, contenido);
                return View("Index", n.marketing.Seleccionar());
            }
            else if (boton2 != null)
            {
                n.marketingcorreo.Agregar(IdCampaña, asunto, contenido);
                return RedirectToRoute(new { controller = "Marketing", action = "CorreoModificar", IdCampaña = IdCampaña });
            }

            return View("Index", n.marketing.Seleccionar());
        }

        [HttpGet]
        public ActionResult Modificar(int idcampaña)
        {
            ViewBag.Productos = Datos.Catalogos.SeleccionarProductosPorNombre();
            return View(n.marketing.SeleccionarPorId(idcampaña));
        }

        public ActionResult Modificar(string Clave, string Nombre, DateTime Inicio, DateTime Fin, string Objetivo,
        DateTime Envios, DateTime InicioEvento,
        DateTime FinEvento, string HoraInicio, string HoraFin, string Ubicacion, string Descripcion, int Id,
        int? Correo = 0, int? Facebook = 0, int? Linkedin = 0, int? Llamada = 0, int? PaginaASAE = 0)
        {
            m.Marketing items = new m.Marketing()
            {
                Clave = Clave,
                Nombre = Nombre,
                Inicio = Inicio,
                Fin = Fin,
                Objetivo = Objetivo,
                Correo = (int)Correo,
                Facebook = (int)Facebook,
                Linkedin = (int)Linkedin,
                Llamada = (int)Llamada,
                PaginaASAE = (int)PaginaASAE,
                Envios = Envios,
                InicioEvento = InicioEvento,
                FinEvento = FinEvento,
                HoraInicio = HoraInicio,
                HoraFin = HoraFin,
                Ubicacion = Ubicacion,
                Descripcion = Descripcion,
                Id = Id
            };   
            n.marketing.Modificar(items);
            ViewData["Mensaje"] = "1";
            ViewBag.Productos = Datos.Catalogos.SeleccionarProductosPorNombre();
            return View(n.marketing.SeleccionarPorId(Id));
        }

        public ActionResult ClientesModificar(int idcampaña)
        {
            return View(n.marketingclientes.SeleccionarPorIdCampaña(idcampaña));
        }

        public ActionResult CorreoModificar(int idcampaña)
        {
            ViewBag.Productos = Datos.Catalogos.SeleccionarProductosPorNombre();
            return View(n.marketingcorreo.SeleccionarPorIdCampaña(idcampaña.ToString()));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CorreoModificar(int idcampaña, string asunto, string contenido)
        {
            m.UsuariosRoles usuariosroles = (m.UsuariosRoles)Session["Usuario"];
            var boton1 = Request.Form["Boton1"];
            var boton2 = Request.Form["Boton2"];
            string resultado = "";
            var ok = n.marketingcorreo.Modificar(idcampaña.ToString(), asunto, contenido);
            if (ok == 0)
                n.marketingcorreo.Agregar(idcampaña.ToString(), asunto, contenido);
            if (boton1 != null)
            {
                ViewBag.EstadoActual = n.marketing.SeleccionarPorId(idcampaña).Estado;
                return View("Index", n.marketing.Seleccionar());
            }
            else if (boton2 != null)
            { 
                //Implementación con envío de archivo ics para que el contacto agende el evento en su correo
                var cloche = n.marketing.SeleccionarPorId(idcampaña);
                var composicioncorreo = n.marketingcorreo.SeleccionarPorIdCampaña(idcampaña.ToString());
                var usuario = n.usuarios.SeleccionarPorId(usuariosroles.Usuarios.Id);
                string fechainicioevento = cloche.InicioEvento.ToString("yyyy/MM/dd") + " " + cloche.HoraInicio + ":00";
                string fechafinevento = cloche.FinEvento.ToString("yyyy/MM/dd") + " " + cloche.HoraFin + ":00";
                if (composicioncorreo.Cuerpo.Contains("[nombre]"))
                {
                    string nombre = usuario.Usuarios.Nombre;
                    string id = usuario.Usuarios.Id.ToString();
                    composicioncorreo.Cuerpo = composicioncorreo.Cuerpo.Replace("[nombre]", nombre);
                    if (composicioncorreo.Cuerpo.Contains("[campa]"))
                        composicioncorreo.Cuerpo = composicioncorreo.Cuerpo.Replace("[campa]", Utilerias.Cifrado.Encriptar(idcampaña.ToString()));
                    if (composicioncorreo.Cuerpo.Contains("[conta]"))
                        composicioncorreo.Cuerpo = composicioncorreo.Cuerpo.Replace("[conta]", Utilerias.Cifrado.Encriptar(id));
                    if (composicioncorreo.Cuerpo.Contains("[agenda]"))
                    {
                        composicioncorreo.Cuerpo = composicioncorreo.Cuerpo.Replace("[agenda]", "");
                        correo.AgendaParaEventos(usuario.Usuarios.Correo
                            , ""
                            , "Eventos Weber"
                            , "Prueba de Visibilidad"
                            , composicioncorreo.Cuerpo
                            , cloche.Clave + ".ics"
                            , cloche.Nombre
                            , fechainicioevento
                            , fechafinevento
                            , nombre
                            , usuario.Usuarios.Correo
                            , cloche.Nombre
                            , cloche.Descripcion
                            , cloche.Ubicacion
                            );

                    }
                    else
                    {
                        correo.EnviarCorreo(usuario.Usuarios.Correo, "Prueba de Visibilidad", asunto, composicioncorreo.Cuerpo);
                    }
                }
                else
                {
                    correo.EnviarCorreo(usuario.Usuarios.Correo, "Prueba de Visibilidad", asunto, composicioncorreo.Cuerpo);
                }
                ViewBag.EstadoActual = n.marketing.SeleccionarPorId(idcampaña).Estado;
                return View("CorreoModificar", n.marketingcorreo.SeleccionarPorIdCampaña(idcampaña.ToString()));
            }


            return View(resultado);

        }

        public ActionResult Recordatorios(int idcampaña)
        {
            ViewBag.Productos = Datos.Catalogos.SeleccionarProductosPorNombre();
            return View(n.marketingrecordatorios.SeleccionarPorIdCampaña(idcampaña.ToString()));
        }

        public ActionResult RecordatoriosAgregar()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecordatoriosAgregar(int idcampaña, DateTime fecha, string asunto, string editor, int enviara)
        {
            m.UsuariosRoles usuariosroles = (m.UsuariosRoles)Session["Usuario"];

            m.MarketingRecordatorios items = new m.MarketingRecordatorios();
            items.IdCampaña = idcampaña;
            items.Envio = fecha;
            items.Asunto = asunto;
            items.Cuerpo = editor;
            items.EnviarA = enviara;

            var boton1 = Request.Form["Boton1"];
            var boton2 = Request.Form["Boton2"];
            if (boton1 != null)
            {
                n.marketingrecordatorios.Agregar(items);
                return View("Index", n.marketing.Seleccionar());
            }
            else if (boton2 != null)
            {
                int obtenido = n.marketingrecordatorios.Agregar(items);
                var cuerpocorreo = n.marketingrecordatorios.SeleccionarPorId(obtenido);
                var usuario = n.usuarios.SeleccionarPorId(usuariosroles.Usuarios.Id);
                if (cuerpocorreo.Cuerpo.Contains("[nombre]"))
                {
                    string nombre = usuario.Usuarios.Nombre;
                    string id = usuario.Usuarios.Id.ToString();
                    cuerpocorreo.Cuerpo = cuerpocorreo.Cuerpo.Replace("[nombre]", nombre);
                    if (cuerpocorreo.Cuerpo.Contains("[campa]"))
                        cuerpocorreo.Cuerpo = cuerpocorreo.Cuerpo.Replace("[campa]", Utilerias.Cifrado.Encriptar(idcampaña.ToString()));
                    if (cuerpocorreo.Cuerpo.Contains("[conta]"))
                        cuerpocorreo.Cuerpo = cuerpocorreo.Cuerpo.Replace("[conta]", Utilerias.Cifrado.Encriptar(id));
                    correo.EnviarCorreo(usuario.Usuarios.Correo, "Prueba de Visibilidad", asunto, cuerpocorreo.Cuerpo);
                }
                else
                {
                    correo.EnviarCorreo(usuario.Usuarios.Correo, "Prueba de Visibilidad", asunto, cuerpocorreo.Cuerpo);
                }

                //n.marketingrecordatorios.Agregar_Registro(items);
                return RedirectToRoute(new { controller = "Marketing", action = "Recordatorios", IdCampaña = idcampaña });
            }

            return View();
        }

        public ActionResult RecordatoriosModificar(int recordatorio)
        {
            return View(n.marketingrecordatorios.SeleccionarPorId(recordatorio));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecordatoriosModificar(int recordatorio, DateTime fecha, string asunto, string contenido, int enviara)
        {
            m.UsuariosRoles usuariosroles = (m.UsuariosRoles)Session["Usuario"];

            m.MarketingRecordatorios items = new m.MarketingRecordatorios();
            items.Id = recordatorio;
            items.Envio = fecha;
            items.Asunto = asunto;
            items.Cuerpo = contenido;
            items.EnviarA = enviara;

            var boton1 = Request.Form["Boton1"];
            var boton2 = Request.Form["Boton2"];
            if (boton1 != null)
            {
                n.marketingrecordatorios.Modificar(items);
                var detalle = n.marketingrecordatorios.SeleccionarPorId(items.Id);
                return View("Recordatorios", n.marketingrecordatorios.SeleccionarPorIdCampaña(detalle.IdCampaña.ToString()));
            }
            else if (boton2 != null)
            {
                if (contenido.Contains("[nombre]"))
                {
                    n.marketingrecordatorios.Modificar(items);
                    var usuario = n.usuarios.SeleccionarPorId(usuariosroles.Usuarios.Id);                    
                    string nombre = usuario.Usuarios.Nombre;
                    contenido = contenido.Replace("[nombre]", nombre);
                    correo.EnviarCorreo(usuario.Usuarios.Correo, "Prueba de Visibilidad", asunto, contenido);
                    return RedirectToRoute(new { controller = "Marketing", action = "RecordatoriosModificar", recordatorio = recordatorio });
                }
                else
                {
                    n.marketingrecordatorios.Modificar(items);
                    var usuario = n.usuarios.SeleccionarPorId(usuariosroles.Usuarios.Id);
                    correo.EnviarCorreo(usuario.Usuarios.Correo, "Prueba de Visibilidad", asunto, contenido);
                    return RedirectToRoute(new { controller = "Marketing", action = "RecordatoriosModificar", recordatorio = recordatorio });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult RecordatoriosEnviar(int idcampaña, int recordatorio)
        {
            var recordatoriocorreo = n.marketingrecordatorios.SeleccionarPorId(recordatorio);
            if (recordatoriocorreo.EnviarA == 1)
            {
                foreach (var items in n.marketingclientes.SeleccionarPorIdCampaña(idcampaña))
                {
                    if (recordatoriocorreo.Cuerpo.Contains("[nombre]"))
                    {
                        string nombre = items.Clientes.Nombre + " " + items.Clientes.ApellidoPaterno + " " + items.Clientes.ApellidoMaterno;
                        recordatoriocorreo.Cuerpo = recordatoriocorreo.Cuerpo.Replace("[nombre]", nombre);
                        correo.EnviarCorreo(items.Clientes.Correo, "Prueba de Visibilidad", recordatoriocorreo.Asunto, recordatoriocorreo.Cuerpo);
                    }
                    else
                    {
                        correo.EnviarCorreo(items.Clientes.Correo, "Prueba de Visibilidad", recordatoriocorreo.Asunto, recordatoriocorreo.Cuerpo);
                    }
                    recordatoriocorreo = n.marketingrecordatorios.SeleccionarPorId(recordatorio);
                }
            }
            else if (recordatoriocorreo.EnviarA > 1)
            {
                //foreach (var items in n.marketingclientes.SeleccionarPorIdCampañaFiltrado(idcampaña, recordatoriocorreo.EnviarA.ToString()))
                //{
                //    if (recordatoriocorreo.Cuerpo.Contains("[nombre]"))
                //    {
                //        string nombre = items.Contactos.Nombre + " " + items.Contactos.ApellidoPaterno + " " + items.Contactos.ApellidoMaterno;
                //        recordatoriocorreo.Cuerpo = recordatoriocorreo.Cuerpo.Replace("[nombre]", nombre);
                //        correo.EnviarCorreo(items.Contactos.Correo, "Prueba de Visibilidad", recordatoriocorreo.Asunto, recordatoriocorreo.Cuerpo);
                //    }
                //    else
                //    {
                //        correo.EnviarCorreo(items.Contactos.Correo, "Prueba de Visibilidad", recordatoriocorreo.Asunto, recordatoriocorreo.Cuerpo);
                //    }
                //}
            }

            TempData["Mensaje"] = "<div class='alert alert-success' role'alert'>Se envió el correo a los contactos de la campaña</div>";
            return RedirectToRoute(new { controller = "Marketing", action = "Recordatorios", idcampaña = idcampaña });
        }

        //Procesos Json

        public JsonResult ClientesAgregarACampaña(int idproducto, int idcampaña)
        {
            foreach(var items in n.clientes.SeleccionarPorIdProducto(idproducto))
            { 
                n.marketingclientes.Agregar(items.Id, idcampaña);
            }
            return Json(n.marketingclientes.SeleccionarPorIdCampaña(idcampaña), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketingCorreoPlantilla(int id)
        {
            return Json(n.marketingcorreoplantillas.SeleccionarPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketingClienteEliminar(int idcampaña, string idcliente)
        {
            n.marketingclientes.Eliminar(idcampaña, idcliente);
            return Json(n.marketingclientes.SeleccionarPorIdCampaña(idcampaña), JsonRequestBehavior.AllowGet);
        }

    }
}
