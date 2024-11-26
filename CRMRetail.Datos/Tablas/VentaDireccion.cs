using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class VentaDireccion
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public m.Mensaje VentaDireccion_Agregar(m.VentaDireccion ventaDireccion)
        {
            b.ExecuteCommandSP("VentaDireccion_Agregar");
            b.AddParameter("@IdVenta", ventaDireccion.IdVenta, SqlDbType.Int);
            b.AddParameter("@IdDireccion", ventaDireccion.IdDireccion, SqlDbType.Int);
            b.AddParameter("@IdHorario", ventaDireccion.IdHorario, SqlDbType.Int);
            b.AddParameter("@FechaEntrega", ventaDireccion.FechaEntrega, SqlDbType.NVarChar);
            m.Mensaje resultado = new m.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Respuesta = Convert.ToBoolean(Convert.ToInt32(reader["Respuesta"].ToString()));
                resultado.RespuestaText = reader["RespuestaText"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
