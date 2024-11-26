using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m = CRMRetail.Modelos;

namespace CRMRetail.Controllers
{
    public class LoginController : Utilidades.Comun
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string clave, string contraseña)
        {
            int idusuario = n.usuarios.Valida(clave, contraseña);
            if (idusuario > 0)
            {
                m.UsuariosRoles musuariorol;
                Session["Usuario"] = musuariorol = n.usuarios.SeleccionarDetalle(idusuario);
                Session["Menu"] = Utilidades.CustomHelpers.Menu(musuariorol.Roles.Id);
                //ir a la página de inicio, sería el dashboard, pero no disponible para todos los roles
                return RedirectToAction(musuariorol.Roles.Pagina, musuariorol.Roles.Controlador);
            }
            else
            {
                //devolver al login, clave incorrecta o inexistente
                ViewData["Mensaje"] = "Falso";
                return View();
            }
        }

        public ActionResult RecuperarContraseña()
        {
            return View();
        }

        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Login");
        }

    }
}
