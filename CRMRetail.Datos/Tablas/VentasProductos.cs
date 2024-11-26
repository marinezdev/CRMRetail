using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class VentasProductos
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.VentasProductos> SeleccionarPorIdVenta(int idventa) 
        {
            b.ExecuteCommandSP("VentasProductos_Seleccionar_PorIdVenta");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            List<m.VentasProductos> resultado = new List<m.VentasProductos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasProductos item = new m.VentasProductos();
                item.IdVenta = int.Parse(reader["idventa"].ToString());
                item.Productos.Id = int.Parse(reader["id"].ToString());
                item.Productos.Nombre = reader["nombre"].ToString();
                item.Productos.SKU = reader["sku"].ToString();
                item.Productos.PrecioPublico = decimal.Parse(reader["preciopublico"].ToString());
                item.Precio = decimal.Parse(reader["precio"].ToString());
                item.Cantidad = int.Parse(reader["cantidad"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.VentasProductos> SeleccionarPorCategoria(int idcategoria)
        {
            b.ExecuteCommandSP("VentasProductos_Seleccionar_PorCategoria");
            b.AddParameter("@idcategoria", idcategoria, SqlDbType.Int);
            List<m.VentasProductos> resultado = new List<m.VentasProductos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasProductos item = new m.VentasProductos();
                item.IdVenta = int.Parse(reader["idventa"].ToString());
                item.Productos.Id = int.Parse(reader["idproducto"].ToString());
                item.Productos.Nombre = reader["nombre"].ToString();
                item.Productos.SKU = reader["sku"].ToString();
                item.Productos.PrecioPublico = decimal.Parse(reader["preciopublico"].ToString());
                item.Precio = decimal.Parse(reader["precio"].ToString());
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.NombreCategoria = reader["categoria"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(int idventa, int idproducto, int cantidad, decimal precio)
        {
            b.ExecuteCommandSP("VentasProductos_Agregar");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            b.AddParameter("@cantidad", cantidad, SqlDbType.Int);
            b.AddParameter("@precio", precio, SqlDbType.Decimal);
            return b.InsertUpdateDelete();
        }

        public int Modificar_Cantidad(int idventa, int idproducto, int cantidad)
        {
            b.ExecuteCommandSP("VentasProductos_Modificar_Cantidad");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            b.AddParameter("@cantidad", cantidad, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int Modificar_Precio(int idventa, int idproducto, decimal precio)
        {
            b.ExecuteCommandSP("VentasProductos_Modificar_Precio");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            b.AddParameter("@precio", precio, SqlDbType.Decimal);
            return b.InsertUpdateDelete();
        }

        public int EliminarRegistro(int idventa, int idproducto)
        {
            b.ExecuteCommandSP("VentasProductos_Eliminar_Registro");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
