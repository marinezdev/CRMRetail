using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Marketing
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Marketing> Seleccionar()
        {
            b.ExecuteCommandSP("Marketing_Seleccionar");
            List<m.Marketing> resultado = new List<m.Marketing>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Marketing item = new m.Marketing()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Clave = reader["clave"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Inicio = DateTime.Parse(reader["inicio"].ToString()),
                    Fin = DateTime.Parse(reader["fin"].ToString()),
                    Registro = DateTime.Parse(reader["registro"].ToString()),
                    Objetivo = reader["objetivo"].ToString(),
                    Estado = int.Parse(reader["estado"].ToString()),
                    Usuario = int.Parse(reader["usuario"].ToString()),
                    Correo = int.Parse(reader["correo"].ToString()),
                    Facebook = int.Parse(reader["facebook"].ToString()),
                    Linkedin = int.Parse(reader["linkedin"].ToString()),
                    Llamada = int.Parse(reader["llamada"].ToString()),
                    PaginaASAE = int.Parse(reader["paginaasae"].ToString()),
                    Envios = DateTime.Parse(reader["envios"].ToString()),
                    InicioEvento = DateTime.Parse(reader["inicioevento"].ToString()),
                    FinEvento = DateTime.Parse(reader["finevento"].ToString()),
                    HoraInicio = reader["horainicio"].ToString(),
                    HoraFin = reader["horafin"].ToString(),
                    Ubicacion = reader["ubicacion"].ToString(),
                    Descripcion = reader["descripcion"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Marketing SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Marketing_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Marketing resultado = new m.Marketing();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Clave = reader["clave"].ToString();
                resultado.Nombre = reader["nombre"].ToString();
                resultado.Inicio = DateTime.Parse(reader["inicio"].ToString());
                resultado.Fin = DateTime.Parse(reader["fin"].ToString());
                resultado.Registro = DateTime.Parse(reader["registro"].ToString());
                resultado.Objetivo = reader["objetivo"].ToString();
                resultado.Estado = int.Parse(reader["estado"].ToString());
                resultado.Usuario = int.Parse(reader["usuario"].ToString());
                resultado.Correo = int.Parse(reader["correo"].ToString());
                resultado.Facebook = int.Parse(reader["facebook"].ToString());
                resultado.Linkedin = int.Parse(reader["linkedin"].ToString());
                resultado.Llamada = int.Parse(reader["llamada"].ToString());
                resultado.PaginaASAE = int.Parse(reader["paginaasae"].ToString());
                resultado.Envios = DateTime.Parse(reader["envios"].ToString());
                resultado.InicioEvento = DateTime.Parse(reader["inicioevento"].ToString());
                resultado.FinEvento = DateTime.Parse(reader["finevento"].ToString());
                resultado.HoraInicio = reader["horainicio"].ToString();
                resultado.HoraFin = reader["horafin"].ToString();
                resultado.Ubicacion = reader["ubicacion"].ToString();
                resultado.Descripcion = reader["descripcion"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.Marketing items)
        {
            b.ExecuteCommandSP("Marketing_Agregar");
            b.AddParameter("@clave", items.Clave, SqlDbType.NVarChar, 50);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@inicio", items.Inicio, SqlDbType.Date);
            b.AddParameter("@fin", items.Fin, SqlDbType.DateTime);
            b.AddParameter("@objetivo", items.Objetivo, SqlDbType.NVarChar);
            b.AddParameter("@estado", items.Estado, SqlDbType.Int);
            b.AddParameter("@usuario", items.Usuario, SqlDbType.Int);
            b.AddParameter("@correo", items.Correo, SqlDbType.Int);
            b.AddParameter("@facebook", items.Facebook, SqlDbType.Int);
            b.AddParameter("@linkedin", items.Linkedin, SqlDbType.Int);
            b.AddParameter("@llamada", items.Llamada, SqlDbType.Int);
            b.AddParameter("@paginaasae", items.PaginaASAE, SqlDbType.Int);
            b.AddParameter("@envios", items.Envios, SqlDbType.DateTime);
            b.AddParameter("@inicioevento", items.InicioEvento, SqlDbType.DateTime);
            b.AddParameter("@finevento", items.FinEvento, SqlDbType.DateTime);
            b.AddParameter("@horainicio", items.HoraInicio, SqlDbType.NVarChar, 8);
            b.AddParameter("@horafin", items.HoraFin, SqlDbType.NVarChar, 8);
            b.AddParameter("@ubicacion", items.Ubicacion, SqlDbType.NVarChar, 50);
            b.AddParameter("@descripcion", items.Descripcion, SqlDbType.NVarChar, 150);
            b.AddParameterWithReturnValue("@respuesta");
            return b.InserUpdateDeletetWithReturnValue();
        }

        public int Modificar(m.Marketing items)
        {
            b.ExecuteCommandSP("Marketing_Modificar");
            b.AddParameter("@clave", items.Clave, SqlDbType.NVarChar, 50);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@inicio", items.Inicio, SqlDbType.Date);
            b.AddParameter("@fin", items.Fin, SqlDbType.DateTime);
            b.AddParameter("@objetivo", items.Objetivo, SqlDbType.NVarChar);
            b.AddParameter("@correo", items.Correo, SqlDbType.Int);
            b.AddParameter("@facebook", items.Facebook, SqlDbType.Int);
            b.AddParameter("@linkedin", items.Linkedin, SqlDbType.Int);
            b.AddParameter("@llamada", items.Llamada, SqlDbType.Int);
            b.AddParameter("@paginaasae", items.PaginaASAE, SqlDbType.Int);
            b.AddParameter("@envios", items.Envios, SqlDbType.Date);
            b.AddParameter("@inicioevento", items.InicioEvento, SqlDbType.Date);
            b.AddParameter("@finevento", items.FinEvento, SqlDbType.Date);
            b.AddParameter("@horainicio", items.HoraInicio, SqlDbType.NVarChar, 8);
            b.AddParameter("@horafin", items.HoraFin, SqlDbType.NVarChar, 8);
            b.AddParameter("@ubicacion", items.Ubicacion, SqlDbType.NVarChar, 50);
            b.AddParameter("@descripcion", items.Descripcion, SqlDbType.NVarChar, 150);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
