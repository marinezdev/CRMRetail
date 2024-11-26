using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m = CRMRetail.Modelos;

namespace CRMRetail.Controllers
{
    public class AdministracionController : Utilidades.Comun
    {
        public ActionResult Ofertas()
        {
            List<m.Producto> productos = n.producto.Producto_Seleccionar();
            ViewBag.Poductos = productos;

            List<m.Producto> porcentual = n.producto.List_Porcentaje();
            ViewBag.porcentual = porcentual;
            return View();

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            ViewBag.Usuarios = n.usuarios.Seleccionar();
            ViewBag.Roles = Datos.Catalogos.Seleccionar("Roles");
            ViewBag.Empresas = Datos.Catalogos.Seleccionar("cat_sucursal");
            return View();
        }

        public ActionResult Roles()
        {
            ViewBag.Roles = n.roles.Seleccionar();
            return View();
        }
       
        public ActionResult Menu()
        {
            ViewBag.Menu = n.menu.Seleccionar();
            return View();
        }

        public ActionResult MenuRoles()
        {
            ViewBag.MenuRoles = n.menu.SeleccionarMenuRol();
            ViewBag.OpcionesMenu = Datos.Catalogos.Seleccionar("Menu");
            ViewBag.Roles = Datos.Catalogos.Seleccionar("Roles");
            return View();
        }

        //Pantalla para agregar socursales
        public ActionResult Configuracion()
        {
            ViewBag.Configuracion = n.configuracion.Seleccionar();
            return View();
        }

        [HttpGet]
        public ActionResult Catalogos(int id=0)
        {
            if (id > 0 )
            {
                ViewBag.Tabla = Datos.Catalogos.Seleccionar(Tablas(id));
                ViewBag.NombreTabla = Tablas(id);
            }
            else
            {
                ViewBag.Tabla = null;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Catalogos(string nombre, string tabla)
        {
            Datos.Catalogos.Guardar(tabla, "Nombre", nombre);
            ViewBag.Tabla = Datos.Catalogos.Seleccionar(tabla);
            return View();
        }

        public ActionResult Eliminar(int id, string tabla)
        {
           var R= Datos.Catalogos.Eliminar(tabla, id);
            return Json(R);
        }


        #region *******************Procedimientos Json

        // Usuarios
        public JsonResult UsuarioSeleccionarPorId(int id)
        {
            return Json(n.usuarios.SeleccionarPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UsuarioAgregar(string nombre, string clave, string contraseña, string correo, int rol, int empresa)
        {
            m.Usuarios mus = new m.Usuarios();
            mus.Nombre = nombre;
            mus.Clave = clave;
            mus.Contraseña = contraseña;
            mus.Correo = correo;
            mus.Empresa = empresa;
            if (n.usuarios.Agregar(mus, rol) == 2)
            {
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UsuarioModificar(string nombre, string clave, string contraseña, string correo, string activo, int rol, int empresa, int id)
        {
            m.Usuarios mus = new m.Usuarios();
            mus.Nombre = nombre;
            mus.Clave = clave;
            mus.Contraseña = contraseña;
            mus.Correo = correo;
            mus.Activo = activo == "1" ? true : false;
            mus.Empresa = empresa;
            mus.Id = id;
            if (n.usuarios.Modificar(mus, rol) >= 1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            { 
                return Json(0, JsonRequestBehavior.AllowGet); 
            }            
        }
        //Sucursales
        public JsonResult SucursalAgregar(string nombre)
        {
            m.Configuracion mus = new m.Configuracion();
            mus.Nombre = nombre;
            if (n.configuracion.Agregar(mus) >= 1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }

        // Roles
        public JsonResult RolSeleccionarPorId(int id)
        {
            return Json(n.roles.SeleccionarPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult RolAgregar(string nombre, string pagina, string controlador)
        {
            m.Roles items = new m.Roles();
            items.Nombre = nombre;
            items.Pagina = pagina;
            items.Controlador = controlador;
            if (n.roles.Agregar(items) == -1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RolModificar(string nombre, string pagina, string controlador, string activo, int id)
        {
            m.Roles items = new m.Roles();
            items.Nombre = nombre;
            items.Pagina = pagina;
            items.Controlador = controlador;
            items.Activo = activo == "1" ? true : false;
            items.Id = id;
            if (n.roles.Modificar(items) == -1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        //MenuRoles
        public JsonResult MenuRolSeleccionarPorId(int id)
        {
            return Json(n.menu.SeleccionarMenuRolPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MenuRolAgregar(int idmenu, int idrol, string activo)
        {
            m.MenuRoles items = new m.MenuRoles();
            items.IdMenu = idmenu;
            items.IdRol = idrol;
            items.Activo = activo == "1" ? true : false;
            if (n.menu.AgregarMenuRol(items) > 0)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult MenuRolModificar(int idmenu, int idrol, string activo, int id)
        {
            m.MenuRoles items = new m.MenuRoles();
            items.Id = id;
            items.IdMenu = idmenu;
            items.IdRol = idrol;
            items.Activo = activo == "1" ? true : false;
            if (n.menu.ModificarMenuRol(items) == -1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }


        //Menu
        public JsonResult MenuSeleccionarPorId(int id)
        {
            return Json(n.menu.SeleccionarPorId(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult MenuAgregar(string idjquery, string ruta, string icono, string nombre, string activo)
        {
            m.Menu items = new m.Menu();
            items.IdJQuery = idjquery;
            items.Ruta = ruta;
            items.Icono = icono;
            items.Nombre = nombre;
            items.Activo = activo == "1" ? true : false;
            if (n.menu.Agregar(items) == -1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult MenuModificar(string idjquery, string ruta, string icono, string nombre, string activo, int id)
        {
            m.Menu items = new m.Menu();
            items.IdJQuery = idjquery;
            items.Ruta = ruta;
            items.Icono = icono;
            items.Nombre = nombre;
            items.Activo = activo == "1" ? true : false;
            items.Id = id;
            if (n.menu.Modificar(items) == -1)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        //Internos
        private string Tablas(int id)
        {
            string nombretabla = "";
            switch(id)
            {
                case 1:
                    nombretabla = "OrigenCliente";
                    break;
                case 2:
                    nombretabla = "ProductosCategoria";
                    break;
                case 3:
                    nombretabla = "Talleres";
                    break;
                case 4:
                    nombretabla = "TipoCliente";
                    break;
                case 5:
                    nombretabla = "TipoVenta";
                    break;
                case 6:
                    nombretabla = "cat_PorcentualOferta";
                    break;
            }
            return nombretabla;
        }

    }
}
