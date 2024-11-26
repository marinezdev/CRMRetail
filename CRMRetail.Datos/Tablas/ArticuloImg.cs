using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class ArticuloImg
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public m.Mensaje ProductoImg_Agregar(m.ArticuloImg articuloImg)
        {
            b.ExecuteCommandSP("ProductoImg_Agregar");
            b.AddParameter("@IdProducto", articuloImg.IdProducto, SqlDbType.Int);
            b.AddParameter("@IdArchivo", articuloImg.IdArchivo, SqlDbType.Int);
            b.AddParameter("@NmArchivo", articuloImg.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", articuloImg.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", articuloImg.Descripcion, SqlDbType.NVarChar);
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

        public m.ArticuloImg ProductoImg_Seleccionar_IdProducto(m.Producto producto)
        {
            b.ExecuteCommandSP("ProductoImg_Seleccionar_IdProducto");
            b.AddParameter("@IdProducto", producto.Id, SqlDbType.Int);
            m.ArticuloImg resultado = new m.ArticuloImg();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Descripcion = reader["Descripcion"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }


        public m.Mensaje Productos_Modificar_Imagen(m.ArticuloImg articuloImg)
        {
            b.ExecuteCommandSP("Productos_Modificar_Imagen");
            b.AddParameter("@IdProducto", articuloImg.IdProducto, SqlDbType.Int);
            b.AddParameter("@IdArchivo", articuloImg.IdArchivo, SqlDbType.Int);
            b.AddParameter("@NmArchivo", articuloImg.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", articuloImg.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", articuloImg.Descripcion, SqlDbType.NVarChar);
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
