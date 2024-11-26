using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CRMRetail.Datos;
using CRMRetail.Modelos;
using static System.Net.Mime.MediaTypeNames;

namespace CRMRetail.Utilerias
{
    public class Correo 
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        readonly WSCorreo.CorreoSoapClient correoSoap = new WSCorreo.CorreoSoapClient();
        private string ruta = "http://187.248.23.163:1053/";

        public bool EnviarCorreo(string correoaqueinseenvia, string titulo, string asunto, string mensaje)
        {
            if (correoSoap.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_",
                correoaqueinseenvia, //A quién se va a enviar el correo
                titulo,              //Titulo de quién lo envia
                asunto,              //Asunto del correo
                mensaje) == "Correo Enviado")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AgendaParaEventos(string correo, string correocopia, string de, string asunto, string cuerpo,
        string nombrearchivoics, string tituloeventoagenda, string fechainicioagenda, string fechafinagenda, string organizador, string correoorganizador,
        string asuntoagenda, string descripcionagenda, string ubicacionagenda)
        {
            correoSoap.CorreoAsaeCRM_AgendaEvento(
                        "mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_"
                        , correo
                        , correocopia
                        , de
                        , asunto
                        , cuerpo
                        , nombrearchivoics                   // nombre del archivo ICS
                        , tituloeventoagenda                 // Título del Evento en la agenda
                        , DateTime.Parse(fechainicioagenda)  // Fecha de Incio del Evento [Datetime]
                        , DateTime.Parse(fechafinagenda)     // Fecha de Terminio del Evento [Datetime]
                        , organizador                        // nombre de la persona que organiza
                        , correoorganizador                  // correo de la persona que organiza
                        , asuntoagenda                       // Asunto dentro de la agenda
                        , descripcionagenda                  // descripción del evento
                        , ubicacionagenda                    // Ubicación del evento
                        );

        }

        public bool EnviarCorreoAltaGerente(string nombre, string correogerente, string titulocorreo, string idconfiguracion)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            "<p>Ha sido agregado al sistema para llevar a cabo tareas de responsabilidad próximamente.</p>" +
            "<p>Le llegará un correo con un nueva oportunidad para su atención, sus claves de acceso son las siguientes: </p>" +
            "<h3>Correo de acceso: " + correogerente + "</h3>" +
            "<h3>Contraseña: " + Funciones.ClaveSalida() + "</h3>" +
            "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<p>La clave de acceso debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            "de lo contrario se bloqueará el acceso al sistema.</p><br /><br /><br />";

            string cuerpodelcorreo = "<p>Hola <span style=\"font-weight: bold;\">" + nombre.ToUpper() + "</span></p><p>Ha sido agregado al sistema de " +
                "<span style=\"font-size: 18px; color: rgb(66, 66, 66);\">Gestión de Asuntos CRM</span> para llevar a cabo tareas de responsabilidad próximamente.</p>" +
                "<p>Le llegará un correo con una nueva oportunidad para su atención, sus claves de acceso son las siguientes:</p>" +
                "<p>Correo de acceso: <span style=\"font-weight: bold; \">" + correogerente + "</span></p>" +
                "<p>Contraseña:<span style=\"font-weight: bold;\">5q8T3w</span></p>" +
                "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
                "<p><a href='" + ruta + "'>'" + ruta + "'</a></p>" +
                "<p><span style=\"color: rgb(255, 156, 0);\"> La clave de acceso debe ser cambiada por una personalizada " +
                "<span style=\"text-decoration-line: underline;\"> inmediatamente</span> en la sección Cambiar Contraseña, de lo contrario, se bloqueará el acceso al sistema.</span></p>" +
                "<br /><br /><br />";

            return EnviarCorreo(correogerente, titulocorreo, "Nueva clave de acceso para CRM", cuerpocorreo);
        }

        public bool EnviarCorreoAltaResponsable(string nombre, string correoresponsable, string titulocorreo, string idconfiguracion)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            "<p>Ha sido agregado al sistema para llevar a cabo tareas de responsabilidad próximamente.</p>";
            cuerpocorreo += "<p>Le llegará un correo con un nueva oportunidad para su atención, sus claves de acceso son las siguientes:</p>";
            cuerpocorreo += "<h3>Clave de acceso: " + correoresponsable + "</h3>" +
            "<h3>Contraseña: " + Funciones.ClaveSalida() + "</h3>" +
            "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<p>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            "de lo contrario se bloqueará el acceso al sistema.</p>" +
            "<br /><br /><br />"; ;
            return EnviarCorreo(correoresponsable, titulocorreo, "Nueva clave de acceso para CRM", cuerpocorreo);
        }

        public bool EnviarCorreoBajaResponsable(string nombre, string correoresponsable, string titulocorreo, string idconfiguracion)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            "<p>Ha sido desasignado de la tarea de responsabilidad previamente asignada.</p>" +
            "<p>Gracias por su atención. Si necesita revisar sus asignaciones, dé click en la siguiente liga para accesar:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<p>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            "de lo contrario se bloqueará el acceso al sistema.</p>" +
            "<br /><br /><br />"; ;
            return EnviarCorreo(correoresponsable, titulocorreo, "Desasignación de Responsabilidad CRM", cuerpocorreo);
        }

        public bool EnviarCorreoModificacionResponsable(string nombre, string correoresponsable, string titulocorreo)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>" +
            "<p>Se ha modificado su acceso al sistema cambiando su correo anterior por uno nuevo, accese de nuevo el sistema para comprobarlo y continuar sus asignaciones.</p>";
            cuerpocorreo += "<h3>Nueva Clave de acceso: " + correoresponsable + "</h3>" +
            "<h3>Contraseña: " + Funciones.ClaveSalida() + "</h3>" +
            "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<p>La contraseña debe ser cambiada por una personalizada inmediatamente en la sección Cambiar Contraseña, " +
            "de lo contrario se bloqueará el acceso al sistema.</p>" +
            "<br /><br /><br />"; ;
            return EnviarCorreo(correoresponsable, titulocorreo, "Nueva correo de acceso para CRM", cuerpocorreo);
        }

        public bool EnviarCorreoEscalacion(string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo, string idconfiguracion)
        {
            var cuerpocorreo = "<p>Hola</p>";
            cuerpocorreo += "<p>Se le ha asignado a la siguiente oportunidad para su atención:</p>";
            cuerpocorreo += "<h3>" + tituloasunto + "</h3>" +
                "<h3>Empresa: " + empresaasignada + "</h3>" +
                "<h3>Vencimiento: " + vencimiento + "</h3>" +
                "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
                "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
                "<br /><br /><br />";
            return EnviarCorreo(correoresponsable, titulocorreo, "Escalación de Asunto", cuerpocorreo);
        }

        public bool EnviarCorreoAviso(string nombre, string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo, string idconfiguracion)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>";
            cuerpocorreo += "<p>Se le ha asignado a la siguiente oportunidad para su atención:</p>";
            cuerpocorreo += "<h3>" + tituloasunto + "</h3>" +
                "<h3>Empresa: " + empresaasignada + "</h3>" +
                "<h3>Vencimiento: " + vencimiento + "</h3>" +
                "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
                "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
                "<br /><br /><br />";
            return EnviarCorreo(correoresponsable, titulocorreo, "Aviso de Seguimiento", cuerpocorreo);
        }

        public bool EnviarCorreoCambioFechaVencimiento(string nombre, string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>";
            cuerpocorreo += "<p>Se le informa que ha cambiado la fecha de vencimiento del siguiente asunto:</p>";
            cuerpocorreo += "<h3>" + tituloasunto + "</h3>" +
                "<h3>Empresa: " + empresaasignada + "</h3>" +
                "<h2>Vencimiento: " + vencimiento + "</h2>" +
                "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
                "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
                "<br /><br /><br />";
            return EnviarCorreo(correoresponsable, titulocorreo, "Cambio de fecha de vencimiento", cuerpocorreo);
        }

        public bool EnviarCorreoAsignadoAAsunto(string nombre, string tituloasunto, string empresaasignada, string vencimiento, string correoresponsable, string titulocorreo, string idconfiguracion)
        {
            var cuerpocorreo = "<p>Hola " + nombre.ToUpper() + "</p>";
            cuerpocorreo += "<p>Se le ha asignado a la siguiente oportunidad para su atención del Sistema CRM:</p>";
            cuerpocorreo += "<h3> " + tituloasunto + " </h3>" +
            "<h3>Empresa: " + empresaasignada + "</h3>" +
            "<h3>Vencimiento: " + vencimiento + "</h3>" +
            "<p>Gracias por su atención. Dé click en la siguiente liga para accesar:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<br /><br /><br />";
            return EnviarCorreo(correoresponsable, titulocorreo, "Asignación de Responsabilidades", cuerpocorreo);
        }

        public bool EnviarCorreoRecuperacionContraseña(string correoaquienseenvia)
        {
            var asunto = "Recuperación de Contraseña";
            var mensaje = "<p>Su contraseña para accesar es<p>" +
            "<h2>" + Funciones.ClaveSalida() + "</h2> " +
            "<p>Cambiéla por una personalizada en cuanto accese la aplicación o se bloqueará de nuevo el acceso.</p>" +
            "<p>Ruta para entrar en la aplicación:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<br /><br /><br />";
            return EnviarCorreo(correoaquienseenvia, "CRM", asunto, mensaje);

        }

        public bool EnviarCorreoAvisoAltaBitacoraAResponsable(string correoresponsable, string usuario, string nombreasunto)
        {
            var asunto = "Alta de información en Bitácora por responsable";
            var mensaje = "<p>El usuario " + usuario + " ha dejado nueva información en la bitácora para ser revisada<p>" +
            "<p>del asunto " + nombreasunto + "</p>" +
            "<p>Dé click en la siguiente liga para poder accesarla:</p>" +
            "<h4><a href='" + ruta + "'>" + ruta + "</a></h4>" +
            "<br /><br /><br />";
            return EnviarCorreo(correoresponsable, "CRM", asunto, mensaje);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////PRUEBAS DE CORREO//////////////////////////////////////////////
        public bool EnvioCorreoTicket(List<NuevoProductoVenta> LisProductos,Cliente DCliente,int IdVentaNew)
        {
            bool validacion = false;

            if (correoSoap.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_",
                DCliente.Correo, //A quién se va a enviar el correo
                "Ticket de Compra",              //Titulo de quién lo envia
                "CRM RETAIL", HtmlCorreo(LisProductos, DCliente, IdVentaNew)          //Asunto del correo
                ) == "Correo Enviado")

            {
                validacion = true;


            }
            return validacion;
        }

        public Producto Producto_Seleccionar_Id(int Id)
        {
            b.ExecuteCommandSP("Producto_Seleccionar_Id");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            Producto resultado = new Producto();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.SKU = reader["SKU"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
                resultado.PrecioDistribuidor = Convert.ToDecimal(reader["PrecioDistribuidor"].ToString());
                resultado.PrecioPublico = Convert.ToDecimal(reader["PrecioPublico"].ToString());
                resultado.PrecioDemo = Convert.ToDecimal(reader["PrecioDemo"].ToString());
                resultado.Activo = bool.Parse(reader["activo"].ToString());
                resultado.IdCategoria = int.Parse(reader["idcategoria"].ToString());
                resultado.Categoria = reader["Categoria"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public Venta InserFolioVenta(int Id)
        {
            b.ExecuteCommandSP("InserFolioVenta");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            Venta R = new Venta();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                R.Id = Convert.ToInt32(reader["Folio"].ToString());
            }
            b.CloseConnection();
            return R;
        }

        public Venta InfoVenta(int Id)
        {
            b.ExecuteCommandSP("InfoVenta");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            Venta R = new Venta();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                R.Nombre = reader["Nombre"].ToString();
                R.Fecha = reader["Fecha"].ToString();
                R.Sucursal = reader["Sucursal"].ToString();
                R.Entrega = reader["Entrega"].ToString();

            }
            b.CloseConnection();
            return R;
        }

        public string HtmlCorreo(List<NuevoProductoVenta> LisProductos, Cliente DCliente, int IdVentaNew) {
            string host = HttpContext.Current.Request.Url.Authority;
            Venta folio = InserFolioVenta(IdVentaNew);
            Venta Info = InfoVenta(IdVentaNew);
            string HTML = "" +
            "<!DOCTYPE html>" +
                "<html>" +
                "<head>" +
                "<meta charset='UTF -8'/>" +
                "<title>Ticket de Compra</title>" +
                "<style>" +
                "body{" +
                "font-family: Arial, sans-serif;" +
                "font-size: 14px;" +
                "display: flex;" +
                "justify -content: center;" +
                "align -items: center;" +
                "height: 100vh;" +
                "}" +
                ".container {" +
                "width: 50%;" +
                "}" +
                ".header {" +
                "background -color: #eee;" +
                "padding: 10px;" +
                "margin -bottom: 20px;" +
                "text -align: center;" +
                "}" +
                ".header img {" +
                "max -width: 100%;" +
                "height: auto;" +
                "}" +
                "table {" +
                "border -collapse: collapse;" +
                "margin -top: 20px;" +
                "margin -bottom: 20px;" +
                "width: 100%;" +
                "border: 1px solid #ccc;" +
                "}" +
                "td, th {" +
                "border: 1px solid #ccc;" +
                "padding: 5px;" +
                "}" +
                "th {" +
                "background -color: #f2f2f2;" +
                "text -align: left;" +
                "}" +
                ".footer {" +
                "margin -top: 20px;" +
                "text -align: center;" +
                "}" +
                ".total {" +
                "font -weight: bold;" +
                "}" +
                "</style>" +
                "</head>" +
                "<body>" +
                "<div class='container'>" +
                "<div class='header'>" +
                "<img src='https://i.ibb.co/2dHVrLM/cb589adc50376fda1ebc6e9404b08852-w2500-h1006.png' alt='Logo' style='width: 200px;'>" +
                "<h1>Ticket de Compra</h1>" +
                "<p>Estimado Cliente: <b>"+DCliente.Nombre+"</b> a continuación se le muestra un resumen de su compra.</p>" +
                "</div>" +
                "<div>" +
                "<ul>" +
                "<li>Folio: <b>" +folio.Id+"</b></li>"+
                "<li>Atendido por: <b>" + Info.Nombre + "</b></li>"+
                "<li>Fecha: <b>" + Info.Fecha + "</b></li>"+
                "<li>Sucursal: <b>" + Info.Sucursal + "</b></li>"+
                "<li>Tipo de Entrega: <b>" + Info.Entrega + "</b></li>"+
                "</ul>"+
                "</div>" +
            "<table>" +
            "<thead>" +
            "<tr>" +
            "<th>Producto</th>" +
            "<th>Cantidad</th>" +
            "<th>Precio</th>" +
            "<th>Total</th>" +
            "</tr>" +
            "</thead>" +
            "<tbody>";

            decimal total = 0;

            foreach (var P in LisProductos)
            {
                Producto Dproducto = Producto_Seleccionar_Id(P.IdProducto);

                HTML += "<tr>" +
                     "<td>"+ Dproducto.Nombre + "</td>" +
                     "<td>" + P.Cantidad + "</td>" +
                     "<td>" + P.Precio + "</td>" +
                      "<td>" + (P.Precio * P.Cantidad) + "</td>" +
                 "</tr>";

                total += (P.Precio * P.Cantidad);
            }

            HTML +=
            "<tr>" +
            "<td colspan='3' class='total'>Total:</td>" +
            "<td>$"+ total +"</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "<div class='footer'>" +
            "<p>Gracias por su compra</p>" +
            //"<a href ='"+url+ "/Encuestas/Index/?id="+IdVentaNew+"'>LinkPrueba</a>" +
            "<a style='text-decoration:none;font-size:15px;font-weight:600;color:#ffffff;padding-top:5px;padding-bottom:5px;padding-left:25px;padding-right:25px;border-radius: 3px;background-color:#cf000d;'href='http://" + host + "/Encuestas/FormatoEntrega/?id=" + IdVentaNew + "'><span>Reporte</span></a>" +
            "</div>" +
            "</div>" +
            "</body>" +
            "</html>";
            return HTML;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////Estructura CorreoTaller//////////////////////////////////////////////
        public bool EnvioCorreoTaller(TallerUser data)
        {
            bool validacion = false;

            if (correoSoap.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_",
                data.Correo, //A quién se va a enviar el correo
                "Encuesta Satisfación",              //Titulo de quién lo envia
                "CRM RETAIL", HtmlCorreoTaller(data)          //Asunto del correo
                ) == "Correo Enviado")

            {
                validacion = true;


            }
            return validacion;
        }

        public string HtmlCorreoTaller(TallerUser data)
        {
            string host = HttpContext.Current.Request.Url.Authority;
            string HTML = "" +
            "<!DOCTYPE html>" +
            "<html> " +
            "<head>" +
            "<title></title>" +
            "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +
            "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
            "<meta http-equiv='X-UA-Compatible' content='IE=edge' />" +
            "<style type='text/css'>" +
            "@media screen {" +
            "@font-face {" +
            "font-family: 'Lato';" +
            "font-style: normal;" +
            "font-weight: 400;" +
            "src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');" +
            "}" +
            "@font-face {" +
            "font-family: 'Lato';" +
            "font-style: normal;" +
            "font-weight: 700;" +
            "src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');" +
            "}" +
            "@font -face {" +
            "font-family: 'Lato';" +
            "font-style: italic;" +
            "font-weight: 400;" +
            "src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');" +
            "}" +
            "@font-face {" +
            "font-family: 'Lato';" +
            "font-style: italic;" +
            "font-weight: 700;" +
            "src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');" +
            "}" +
            "}" +
            "</style>" +
            "</head>" +
            "<body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;font-family: 'Roboto', sans-serif;'>" +
            "<div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'>" +
            "</div>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
            "<tr>" +
            "<td bgcolor='#448ecd' align='center'>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
            "<tr>" +
            "<td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> </td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "<tr>" +
            "<td bgcolor='#448ecd' align='center' style='padding: 0px 10px 0px 10px;'>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
            "<tr>" +
            "<td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Roboto', sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 3px; line-height: 48px;'>" +
            "<img src='https://i.ibb.co/2dHVrLM/cb589adc50376fda1ebc6e9404b08852-w2500-h1006.png' width='125' height='120' style='display: block; border: 0px;' />" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
            "<tr>" +
            "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Roboto', sans-serif; font-size: 18px; font-weight: 40; line-height: 25px;'>" +
            "<p style='font-size: 17px;font-family: 'Roboto', sans-serif; font-weight: 10;'>Estimado/a usuario/a: " + data.Usuario + "</p>" +
            "<p>Esperamos que estés disfrutando de tus habilidades recién adquiridas en el taller de asado que ofrecimos recientemente. Queremos agradecerte por tu participación y nos gustaría conocer tu opinión para mejorar aún más nuestras futuras actividades.</p>" +
            "<p>Te invitamos a responder una breve encuesta que nos ayudará a evaluar tu experiencia y asegurarnos de que cumplimos tus expectativas. Tu opinión es valiosa para nosotros y nos ayudará a brindar un mejor servicio en el futuro.</p>" +
            "<p>Por favor, toma unos minutos para completar la encuesta en el siguiente enlace:</p>" +
            "<a style='text-decoration:none;font-size:15px;font-weight:600;color:#ffffff;padding-top:5px;padding-bottom:5px;padding-left:25px;padding-right:25px;border-radius: 3px;background-color:#cf000d;'href='http://" + host + "/Encuestas/Index/?id=" + data.Id + "'><span>Encuesta</span></a>" +
            "</td>" +
            "</tr>" +
            "<p>Agradecemos de antemano tu colaboración y te recordamos que tu opinión es crucial para nosotros. Si tienes alguna pregunta o comentario adicional, no dudes en ponerte en contacto con nosotros.</p>" +
            "<tr>" +
            "<td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 25px;'>" +
            "</br>" +
            //"<a style='text-decoration: none; font-size: 20px; font-weight: 600; color: #ffffff; padding-top: 20px; padding-bottom: 20px; padding-left: 40px; padding-right: 40px; background-color: #005BBB;' href='https://" + host + "'><span>Más Información</span></a>" +
            "<p>¡Esperamos con ansias recibir tus comentarios!</p>" +
            "<p>Atentamente.</p>" +
            "<p>WEBER.</p>" +
            "</td>" +
            "</tr>" +
            "</tr>" +
            "</tr>" +
            "</br>" +
            "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
            "<tr>" +
            "<td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 100; line-height: 18px;'> <br>" +
            "<p style='margin: 0; font-size: 15px;'>Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
            "<tr>" +
            "<td bgcolor='#D1E9FF' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;'>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "<tr>" +
            "<td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'>" +
            "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>" +
            "<tr>" +
            "<td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;'> <br>" +
            "<p style='margin: 0;'>Queda prohibida cualquier revisión, retransmisión, distribución o cualquier otro uso o acción relacionada con esta información, hecha por personas o entidades distintas a los destinatarios a los que ha sido dirigida.</p>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</body>" +
            "</html>";
            return HTML;
        }
    }
}
