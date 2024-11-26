using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMRetail.Utilidades
{
    public class Comun : Controller
    {
        public Utilerias.Correo correo;
        public Datos.Negocio n;

        public Comun()
        {
            correo = new Utilerias.Correo();
            n = new Datos.Negocio();
            
        }
    }
}