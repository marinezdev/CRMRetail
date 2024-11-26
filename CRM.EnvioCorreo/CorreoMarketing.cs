using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CRMRetail.Utilerias;
using CRMRetail.Modelos;
using System.ServiceModel.Channels;

namespace CRM.EnvioCorreo
{
    public class CorreoMarketing
    {
        ReferenciaDeServicioDeCorreoDeASAE.CorreoSoapClient correoSoap = new ReferenciaDeServicioDeCorreoDeASAE.CorreoSoapClient();
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public void EnvioMarketing()
        {
            //Procesa los correos que deberán enviarse a los contactos dentro de una campaña de mercadeo

            //Seleccionar campaña para ejecutarla (una por una)
            if (SeleccionarCampañas().Count() > 0)
            {
                foreach (var items in SeleccionarCampañas())
                {
                    var correodetalle = CorreoCampaña(items.Id.ToString());

                    //Seleccionar cada contacto para la campaña para enviarle el correo
                    foreach (var itms in ClientesDeCampaña(items.Id.ToString()))
                    {
                        //Seleccionar el correo y enviarlo
                        if (correodetalle.Cuerpo.Contains("[nombre]"))
                        {
                            string nombre = itms.Nombre;
                            correodetalle.Cuerpo = correodetalle.Cuerpo.Replace("[nombre]", nombre);
                            if (correodetalle.Cuerpo.Contains("[campa]"))
                                correodetalle.Cuerpo = correodetalle.Cuerpo.Replace("[campa]", CRMRetail.Utilerias.Cifrado.Encriptar(items.Id.ToString()));
                            if (correodetalle.Cuerpo.Contains("[conta]"))
                                correodetalle.Cuerpo = correodetalle.Cuerpo.Replace("[conta]", CRMRetail.Utilerias.Cifrado.Encriptar(itms.Id.ToString()));
                            EnviarCorreo(itms.Correo, "", correodetalle.Asunto, correodetalle.Cuerpo);
                        }
                        else
                        {
                            EnviarCorreo(itms.Correo, "", correodetalle.Asunto, correodetalle.Cuerpo);
                        }
                    }
                }
            }
            ActualizarCampañasProcesadas();
        }

        public void EnvioRecordatorios()
        {
            for (int i = 1; i < 7; i++)
            {
                if (SeleccionarCampañasConRecordatorios(i.ToString()).Count() > 0)
                {
                    foreach (var items in SeleccionarCampañasConRecordatorios(i.ToString()))
                    {
                        if (i.ToString() == "1")
                        {
                            var correodetalle = SeleccionarCorreoCampañasConRecordatorios(items.IdCampaña.ToString(), i.ToString());

                            //Seleccionar cada cliente para la campaña para enviarle el correo sin importar qué estado se encuentre 
                            foreach (var itms in ClientesDeCampaña(items.IdCampaña.ToString()))
                            {
                                //Seleccionar el correo y enviarlo
                                if (correodetalle.Cuerpo.Contains("[nombre]"))
                                {
                                    string nombre = itms.Nombre;
                                    correodetalle.Cuerpo = correodetalle.Cuerpo.Replace("[nombre]", nombre);
                                    EnviarCorreo(itms.Correo, "", correodetalle.Asunto, correodetalle.Cuerpo);
                                }
                                else
                                {
                                    EnviarCorreo(itms.Correo, "", correodetalle.Asunto, correodetalle.Cuerpo);
                                }
                            }
                        }
                        else if (i.ToString() == "2" || i.ToString() == "3" || i.ToString() == "4" || i.ToString() == "5")
                        {
                            var correodetalle = SeleccionarCorreoCampañasConRecordatorios(items.IdCampaña.ToString(), i.ToString());

                            //Seleccionar cada cliente para la campaña para enviarle el correo dependiendo del estado en el esté 
                            foreach (var itms in ClientesDeCampaña(items.IdCampaña.ToString(), i.ToString()))
                            {
                                //Seleccionar el correo y enviarlo
                                if (correodetalle.Cuerpo.Contains("[nombre]"))
                                {
                                    string nombre = itms.Nombre;
                                    correodetalle.Cuerpo = correodetalle.Cuerpo.Replace("[nombre]", nombre);
                                    EnviarCorreo(itms.Correo, "", correodetalle.Asunto, correodetalle.Cuerpo);
                                }
                                else
                                {
                                    EnviarCorreo(itms.Correo, "", correodetalle.Asunto, correodetalle.Cuerpo);
                                }
                            }
                        }
                    }
                }
            }

        }

        public bool EnviarCorreo(string correoaqueinseenvia, string titulo, string asunto, string mensaje)
        {
            bool ok = false;

            try
            {
                if (correoSoap.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_",
                    correoaqueinseenvia, //A quién se va a enviar el correo
                    titulo,              //Titulo de quién lo envia
                    asunto,              //Asunto del correo
                    mensaje) == "Correo Enviado")
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                //Inidicar si ha habido una falla con el webservice
                EscribirLogWebService(DateTime.Now.ToString() + " " + ex.Message);
                ok =  false;
            }
            return ok;
        }

        //**************** Procedimientos para marketing ************************************

        //Contar cuantas campañas se llevaran a cabo este día
        public int ContarCampañas()
        {
            string consulta = "SELECT COUNT(id) FROM marketing WHERE CONVERT(VARCHAR, inicio, 23)=CONVERT(VARCHAR, GETDATE(), 23) AND estado=1;";
            b.ExecuteCommandQuery(consulta);
            return int.Parse(b.SelectString());
        }

        //Seleccionar campaña para ejecutarla (una por una)
        public List<CRMRetail.Modelos.Marketing> SeleccionarCampañas()
        {
            string consulta = "SELECT id FROM marketing WHERE CONVERT(VARCHAR, envios, 23)=CONVERT(VARCHAR, GETDATE(), 23) AND estado=1";
            b.ExecuteCommandQuery(consulta);
            List<CRMRetail.Modelos.Marketing> resultado = new List<CRMRetail.Modelos.Marketing>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                CRMRetail.Modelos.Marketing item = new CRMRetail.Modelos.Marketing();
                item.Id = int.Parse(reader["Id"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //Seleccionar los nombres de los contactos y su correo para enviárselos todos

        public List<CRMRetail.Modelos.Clientes> ClientesDeCampaña(string idcampaña)
        {
            string consulta = "SELECT cli.id, cli.nombre, cli.apellidopaterno, cli.apellidomaterno, cli.correo " +
            "FROM marketingclientes mkc " +
            "INNER JOIN clientes cli ON cli.id = mkc.IdCliente " +
            "WHERE mkc.IdCampaña = @idcampaña";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            List<CRMRetail.Modelos.Clientes> resultado = new List<CRMRetail.Modelos.Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                CRMRetail.Modelos.Clientes item = new CRMRetail.Modelos.Clientes();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString() + " " + reader["apellidopaterno"].ToString() + " " + reader["apellidomaterno"].ToString();
                item.Correo = reader["correo"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //Seleccionar los nombres de los contactos y su correo para enviárselos filtrado
        public List<CRMRetail.Modelos.Clientes> ClientesDeCampaña(string idcampaña, string enviara)
        {
            string consulta = "SELECT cli.id, cli.nombre, cli.apellidopaterno, cli.apellidomaterno, cli.correo " +
            "FROM marketingclientes mkc " +
            "INNER JOIN clientes cli ON cli.id = mkc.IdCliente " +
            "WHERE mkc.IdCampaña = @idcampaña ";
            if (enviara == "2") //Confirmados
                consulta += "AND mkc.confirmacion=1";
            else if (enviara == "3") //Sin confirmar
                consulta += "AND ISNULL(mkc.confirmacion, 0)";
            else if (enviara == "4") //Asistió
                consulta += "AND mkc.asistencia=1";
            else if (enviara == "5") //No Asistió
                consulta += "AND ISNULL(mkc.asistencia,0)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            List<CRMRetail.Modelos.Clientes> resultado = new List<CRMRetail.Modelos.Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                CRMRetail.Modelos.Clientes item = new CRMRetail.Modelos.Clientes();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString() + " " + reader["apellidopaterno"].ToString() + " " + reader["apellidomaterno"].ToString();
                item.Correo = reader["correo"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //Armar el correo de la campaña y asignar el cliente si lo llevase el correo
        public CRMRetail.Modelos.MarketingCorreo CorreoCampaña(string idcampaña)
        {
            string consulta = "SELECT asunto,cuerpo FROM MarketingCorreo WHERE idcampaña=@idcampaña";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            CRMRetail.Modelos.MarketingCorreo resultado = new CRMRetail.Modelos.MarketingCorreo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Asunto = reader["asunto"].ToString();
                resultado.Cuerpo = reader["cuerpo"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        //Actualizador del estado de las campañas ya ejecutado su envío de correo
        public int ActualizarCampañasProcesadas()
        {
            string consulta = "UPDATE marketing SET estado = 2 WHERE CONVERT(VARCHAR, envios, 23)= CONVERT(VARCHAR, GETDATE(), 23) AND CONVERT(VARCHAR, DAY(envios), 23)= DAY(GETDATE()) AND estado = 1";
            b.ExecuteCommandQuery(consulta);
            return b.InsertUpdateDelete();
        }

        //Seleccionar las campañas con recordatorios 
        public List<CRMRetail.Modelos.MarketingRecordatorios> SeleccionarCampañasConRecordatorios(string enviara)
        {
            string consulta = "SELECT idcampaña FROM marketingrecordatorios WHERE CONVERT(VARCHAR, fechaenvio, 23)=CONVERT(VARCHAR, GETDATE(), 23) AND enviara=@enviara";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@enviara", enviara, SqlDbType.Int);
            List<CRMRetail.Modelos.MarketingRecordatorios> resultado = new List<CRMRetail.Modelos.MarketingRecordatorios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                CRMRetail.Modelos.MarketingRecordatorios item = new CRMRetail.Modelos.MarketingRecordatorios();
                item.IdCampaña = int.Parse(reader["idcampaña"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //Seleccionar el correo de la campañas con recordatorios
        public CRMRetail.Modelos.MarketingRecordatorios SeleccionarCorreoCampañasConRecordatorios(string idcampaña, string enviara)
        {
            string consulta = "SELECT asunto, cuerpo FROM marketingrecordatorios WHERE CONVERT(VARCHAR, fechaenvio, 23)=CONVERT(VARCHAR, GETDATE(), 23) AND idcampaña=@idcampaña AND enviara=@enviara ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            b.AddParameter("@enviara", enviara, SqlDbType.Int);
            CRMRetail.Modelos.MarketingRecordatorios resultado = new CRMRetail.Modelos.MarketingRecordatorios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Asunto = reader["asunto"].ToString();
                resultado.Cuerpo = reader["cuerpo"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        //Selecciona los correos que se enviarán a los clientes como recordatorios de una campaña
        public List<CRMRetail.Modelos.MarketingRecordatorios> SeleccionarCorreosDeRecordatorios()
        {
            string consulta = "SELECT id, idcampaña, asunto, cuerpo, fechaenvio FROM marketingrecordatorios WHERE CONVERT(VARCHAR, fechaenvio, 23)=CONVERT(VARCHAR, GETDATE(), 23) ";
            b.ExecuteCommandQuery(consulta);
            List<CRMRetail.Modelos.MarketingRecordatorios> resultado = new List<CRMRetail.Modelos.MarketingRecordatorios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                CRMRetail.Modelos.MarketingRecordatorios item = new CRMRetail.Modelos.MarketingRecordatorios();
                item.Id = int.Parse(reader["id"].ToString());
                item.IdCampaña = int.Parse(reader["idcampaña"].ToString());
                item.Asunto = reader["asunto"].ToString();
                item.Cuerpo = reader["cuerpo"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public CRMRetail.Modelos.MarketingRecordatorios SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT id, idcampaña, asunto, cuerpo, fechaenvio, fecharegistro, enviara FROM marketingrecordatorios WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            CRMRetail.Modelos.MarketingRecordatorios resultado = new CRMRetail.Modelos.MarketingRecordatorios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.IdCampaña = int.Parse(reader["idcampaña"].ToString());
                resultado.Asunto = reader["asunto"].ToString();
                resultado.Cuerpo = reader["cuerpo"].ToString();
                resultado.Envio = DateTime.Parse(reader["fechaenvio"].ToString());
                resultado.EnviarA = int.Parse(reader["enviara"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        //Adicionales privados
        public static bool EscribirLogWebService(string strMessage)
        {
            string path = "C:/Correos/CRMRetail/";
            string archivo = "_LogWebService.txt";
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + archivo, true);
                file.WriteLine(strMessage);
                file.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
