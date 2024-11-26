using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMRetail.Utilidades
{
    public static class CustomHelpers
    {
        /// <summary>
        /// Crea un menú por rol
        /// </summary>
        /// <param name="id">Id de rol</param>
        /// <returns></returns>
        public static string Menu(int id)
        {
            Datos.Tablas.Menu ne = new Datos.Tablas.Menu();
            string cadena = string.Empty;
            foreach (var item in ne.SeleccionarMenuPorIdRol(id))
            {
                cadena += "<li class='nav-item' id='" + item.Menu.IdJQuery + "'>";
                cadena += "<a href=" + item.Menu.Ruta + ">";
                cadena += "<i class='" + item.Menu.Icono + "'></i>";
                cadena += "<p>" + item.Menu.Nombre + "</p>";
                cadena += "</a>";
                cadena += "</li>";
            }
            cadena += "<li>&nbsp;</li>";
            return cadena;
        }

        public static MvcHtmlString ContenidoPlantillas()
        {
            Comun comun = new Comun();
            var datos = comun.n.marketingcorreoplantillas.Seleccionar();

            string contenido = "";

            contenido += "<div class='row'>";

            for (int i = 0; i < datos.Count();)
            {
                contenido += "<div class='col-md-3'>";
                contenido += "   <div class='card'>";
                contenido += "       <div class='card-body'>";
                contenido += "           <div class='card-text'>" + datos[i].Nombre + "</div>";
                contenido += "           <center><img src='../../assets/img/" + datos[i].Nombre + ".png' style='border:1px solid gray;' class='responsiva' /></center>";
                contenido += "           <br />";
                contenido += "           <div class='text-center text-small'>";
                contenido += "              <a href='#' onclick='CopiarCodigo(" + datos[i].Id + ");'>Copiar</a> | <a href='#' data-toggle='modal' data-target='#ModalVistaPrevia' data-id='" + datos[i].Nombre + ".png'>Vista Previa</a>";
                contenido += "           </div>";
                contenido += "       </div>";
                contenido += "   </div>";
                contenido += "</div>";
                i++;
            }
            contenido += "</div>";

            return MvcHtmlString.Create(contenido);
        }
    }
}