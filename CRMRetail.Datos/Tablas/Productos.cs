using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Productos
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Productos> Seleccionar()
        {
            b.ExecuteCommandSP("Productos_Seleccionar");
            List<m.Productos> resultado = new List<m.Productos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Productos item = new m.Productos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    SKU = reader["sku"].ToString(),
                    Descripcion = reader["descripcion"].ToString(),
                    Categoria = int.Parse(reader["categoria"].ToString()),
                    PrecioPublico = decimal.Parse(reader["preciopublico"].ToString()),
                    PrecioDistribuidor = decimal.Parse(reader["preciodistribuidor"].ToString()),
                    Imagen = reader["imagen"].ToString(),
                    Fecha = reader["fecha"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fecha"].ToString()),
                    Activo = bool.Parse(reader["activo"].ToString())
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.VentasGeneral> SeleccionarCompradosPorCliente(int idcliente)
        {
            b.ExecuteCommandSP("Productos_Seleccionar_CompradosPorCliente");
            b.AddParameter("@idcliente", idcliente, SqlDbType.Int);
            List<m.VentasGeneral> resultado = new List<m.VentasGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasGeneral item = new m.VentasGeneral();
                {
                    item.Productos.Id = int.Parse(reader["id"].ToString());
                    item.Productos.Nombre = reader["nombre"].ToString();
                    item.Productos.SKU = reader["sku"].ToString();
                    item.Productos.PrecioPublico = decimal.Parse(reader["preciopublico"].ToString());
                    item.Ventas.Fecha = DateTime.Parse(reader["fecha"].ToString());
                    item.Ventas.Id = int.Parse(reader["idventa"].ToString());
                    item.Ventas.Tipo = int.Parse(reader["tipo"].ToString());
                    item.Ventas.TipoEntrega = int.Parse(reader["entrega"].ToString());
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.VentasGeneral> SeleccionarClientesPorProducto(int idproducto)
        {
            b.ExecuteCommandSP("Productos_Seleccionar_ClientesQueHanCompradoUnProduto");
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            List<m.VentasGeneral> resultado = new List<m.VentasGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasGeneral item = new m.VentasGeneral();
                {
                    item.Clientes.Id = int.Parse(reader["id"].ToString());
                    item.Clientes.Nombre = reader["cliente"].ToString();
                    item.Ventas.Id = int.Parse(reader["idventa"].ToString());
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public decimal SeleccionarPrecioProducto(int idproducto)
        {
            b.ExecuteCommandSP("Productos_Seleccionar_PrecioPorId");
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            return decimal.Parse(b.SelectString());
        }

        public m.Productos SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Productos_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Productos resultado = new m.Productos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
                resultado.SKU = reader["sku"].ToString();
                resultado.Descripcion = reader["descripcion"].ToString();
                resultado.Categoria = int.Parse(reader["categoria"].ToString());
                resultado.PrecioPublico = decimal.Parse(reader["preciopublico"].ToString());
                resultado.PrecioDistribuidor = decimal.Parse(reader["preciodistribuidor"].ToString());
                resultado.OtroPrecio1 = decimal.Parse(reader["otroprecio1"].ToString());
                resultado.OtroPrecio2 = decimal.Parse(reader["otroprecio2"].ToString());
                resultado.OtroPrecio3 = decimal.Parse(reader["otroprecio3"].ToString());
                resultado.Imagen = reader["imagen"].ToString();
                resultado.Fecha = reader["fecha"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fecha"].ToString());
                resultado.Activo = bool.Parse(reader["activo"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.Productos items)
        {
            b.ExecuteCommandSP("Productos_Agregar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@sku", items.SKU, SqlDbType.NVarChar, 50);
            b.AddParameter("@descripcion", items.Descripcion, SqlDbType.NVarChar, 150);
            b.AddParameter("@categoria", items.Categoria, SqlDbType.Int);
            b.AddParameter("@preciopublico", items.PrecioPublico, SqlDbType.Decimal);
            b.AddParameter("@preciodistribuidor", items.PrecioDistribuidor, SqlDbType.Decimal);
            b.AddParameter("@imagen", items.Imagen, SqlDbType.NVarChar, 150);
            b.AddParameter("@otroprecio1", items.OtroPrecio1, SqlDbType.Decimal);
            b.AddParameter("@otroprecio2", items.OtroPrecio2, SqlDbType.Decimal);
            b.AddParameter("@otroprecio3", items.OtroPrecio3, SqlDbType.Decimal);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameterWithReturnValue("@respuesta");
            return b.InserUpdateDeletetWithReturnValue();
        }

        public int Modificar(m.Productos items)
        {
            b.ExecuteCommandSP("Productos_Modificar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@sku", items.SKU, SqlDbType.NVarChar, 50);
            b.AddParameter("@descripcion", items.Descripcion, SqlDbType.NVarChar, 150);
            b.AddParameter("@categoria", items.Categoria, SqlDbType.Int);
            b.AddParameter("@preciopublico", items.PrecioPublico, SqlDbType.Decimal);
            b.AddParameter("@preciodistribuidor", items.PrecioDistribuidor, SqlDbType.Decimal);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@otroprecio1", items.OtroPrecio1, SqlDbType.Decimal);
            b.AddParameter("@otroprecio2", items.OtroPrecio2, SqlDbType.Decimal);
            b.AddParameter("@otroprecio3", items.OtroPrecio3, SqlDbType.Decimal);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int ModificarImagen(string imagen, int id)
        {
            b.ExecuteCommandSP("Productos_Modificar_Imagen");
            b.AddParameter("@imagen", imagen, SqlDbType.NVarChar, 150);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
