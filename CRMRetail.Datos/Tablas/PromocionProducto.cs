using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class PromocionProducto
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public m.Mensaje PromocionProducto_Agregar(m.PromocionProducto promocionProducto)
        {
            b.ExecuteCommandSP("PromocionProducto_Agregar");
            b.AddParameter("@IdProducto", promocionProducto.IdProducto, SqlDbType.Int);
            b.AddParameter("@FechaInicio", promocionProducto.FechaInicio, SqlDbType.NVarChar);
            b.AddParameter("@FechaFin", promocionProducto.FechaFin, SqlDbType.NVarChar);
            b.AddParameter("@Precio", promocionProducto.Precio, SqlDbType.Decimal);
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

        public m.PromocionProducto PromocionProducto_Seleccionar_IdProducto(m.Producto producto)
        {
            b.ExecuteCommandSP("PromocionProducto_Seleccionar_IdProducto");
            b.AddParameter("@IdProducto", producto.Id, SqlDbType.Int);
            m.PromocionProducto resultado = new m.PromocionProducto();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.FechaInicio = reader["FechaInicio"].ToString();
                resultado.FechaFin = reader["FechaFin"].ToString();
                resultado.Precio = Convert.ToDecimal(reader["Precio"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
