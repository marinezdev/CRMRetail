using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Producto
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();
        public m.Producto Producto_Seleccionar_SKU(string SKU)
        {
            b.ExecuteCommandSP("Producto_Seleccionar_SKU");
            b.AddParameter("@SKU", SKU, SqlDbType.NVarChar);
            m.Producto resultado = new m.Producto();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.SKU = reader["sku"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Producto> Producto_Seleccionar()
        {
            b.ExecuteCommandSP("Producto_Seleccionar");
            List<m.Producto> resultado = new List<m.Producto>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Producto item = new m.Producto()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    SKU = reader["SKU"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        public m.Producto Producto_Seleccionar_Id(m.Producto producto)
        {
            b.ExecuteCommandSP("Producto_Seleccionar_Id");
            b.AddParameter("@Id", producto.Id, SqlDbType.Int);
            m.Producto resultado = new m.Producto();
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
        public List<m.Catalogos> Producto_Precios_Listar_Nombres(int IdProducto)
        {
            b.ExecuteCommandSP("Producto_Precios_Listar_Nombres");
            b.AddParameter("@IdProducto", IdProducto, SqlDbType.Int);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        public m.Producto Producto_Selecionar_Precio(int IdCatPrecios, int IdProducto)
        {
            b.ExecuteCommandSP("Producto_Selecionar_Precio");
            b.AddParameter("@IdCatPrecios", IdCatPrecios, SqlDbType.Int);
            b.AddParameter("@IdProducto", IdProducto, SqlDbType.Int);
            m.Producto resultado = new m.Producto();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Precio = Convert.ToDecimal(reader["Precio"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }        
        
        public m.Mensaje Producto_Agregar(m.Producto producto)
        {
            b.ExecuteCommandSP("Producto_Agregar");
            b.AddParameter("@Nombre", producto.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@SKU", producto.SKU, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", producto.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@PrecioDistribuidor", producto.PrecioDistribuidor, SqlDbType.Decimal);
            b.AddParameter("@PrecioPublico", producto.PrecioPublico, SqlDbType.Decimal);
            b.AddParameter("@PrecioDemo", producto.PrecioDemo, SqlDbType.Decimal);
            b.AddParameter("@IdCategoria", producto.IdCategoria, SqlDbType.Int);
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

        public m.Mensaje Modificar(m.Producto producto)
        {
            b.ExecuteCommandSP("Producto_Modificar");
            b.AddParameter("@Id", producto.Id, SqlDbType.Int);
            b.AddParameter("@nombre", producto.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@sku", producto.SKU, SqlDbType.NVarChar);
            b.AddParameter("@descripcion", producto.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@preciodistribuidor", producto.PrecioDistribuidor, SqlDbType.Decimal);
            b.AddParameter("@preciopublico", producto.PrecioPublico, SqlDbType.Decimal);
            b.AddParameter("@preciodemo", producto.PrecioDemo, SqlDbType.Decimal);
            b.AddParameter("@idcategoria", producto.IdCategoria, SqlDbType.Int);
            b.AddParameter("@activo", producto.Activo, SqlDbType.Bit);
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


        public List<m.Producto> List_Porcentaje()
        {
            b.ExecuteCommandSP("List_Porcentaje");
            List<m.Producto> resultado = new List<m.Producto>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Producto item = new m.Producto()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Precio = Convert.ToDecimal(reader["Valor"].ToString())

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }


        public m.PromocionProducto AgregarPromocion(m.PromocionProducto promocionProducto)
        {
            b.ExecuteCommandSP("AgregarPromocion");
            b.AddParameter("@IdProducto", promocionProducto.Id, SqlDbType.Int);
            b.AddParameter("@FechaInicio", promocionProducto.FechaInicio, SqlDbType.NVarChar);
            b.AddParameter("@FechaFin", promocionProducto.FechaFin, SqlDbType.NVarChar);
            b.AddParameter("@Precio", promocionProducto.Precio, SqlDbType.Decimal);
            m.PromocionProducto resultado = new m.PromocionProducto();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            b.CloseConnection();
            return resultado;
        }

    }
}
