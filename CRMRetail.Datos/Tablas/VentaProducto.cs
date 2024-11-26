using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class VentaProducto
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Modelos> SeleccionarDetalleProducto(int idventa)
        {
            b.ExecuteCommandSP("VentaProducto_Seleccionar");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            List<m.Modelos> resultado = new List<m.Modelos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Modelos items = new m.Modelos();

                items.VentaProducto.Id = int.Parse(reader["id"].ToString());
                items.VentaProducto.IdVenta = int.Parse(reader["idventa"].ToString());
                items.VentaProducto.IdProducto = int.Parse(reader["idproducto"].ToString());
                items.VentaProducto.IdPrecio = int.Parse(reader["idprecio"].ToString());
                items.VentaProducto.Precio = decimal.Parse(reader["precio"].ToString());
                items.VentaProducto.Cantidad = int.Parse(reader["cantidad"].ToString());
                items.VentaProducto.BackOrder = int.Parse(reader["backorder"].ToString());
                items.VentaProducto.FechaRegistro = DateTime.Parse(reader["fecharegistro"].ToString());
                items.VentaProducto.Activo = bool.Parse(reader["Activo"].ToString());
                items.Producto.Nombre = reader["producto"].ToString();

                resultado.Add(items);
            }
            b.CloseConnection();
            return resultado;
        }


        public m.Mensaje VentaProducto_Agregar(m.VentaProducto ventaProducto)
        {
            b.ExecuteCommandSP("VentaProducto_Agregar");
            b.AddParameter("@IdVenta", ventaProducto.IdVenta, SqlDbType.Int);
            b.AddParameter("@IdProducto", ventaProducto.IdProducto, SqlDbType.Int);
            b.AddParameter("@IdPrecio", ventaProducto.IdPrecio, SqlDbType.Int);
            b.AddParameter("@Precio", ventaProducto.Precio, SqlDbType.Decimal);
            b.AddParameter("@Cantidad", ventaProducto.Cantidad, SqlDbType.Int);
            b.AddParameter("@BackOrder", ventaProducto.BackOrder, SqlDbType.Int);
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
