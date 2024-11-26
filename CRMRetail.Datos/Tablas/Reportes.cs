using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    /// <summary>
    /// Cualquier reporte generado se maneja en esta clase de la tabla que sea
    /// </summary>
    public class Reportes
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public int ReporteVentasPorDiaPorEmpresa(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_PorDia_PorEmpresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        public decimal ReporteMontosPorDiaPorEmpresa(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_PorDia_PorEmpresa_Montos");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return decimal.Parse(b.SelectString());
        }

        public int ReporteVentasPorMesPorEmpresa(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_PorMes_PorEmpresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        public decimal ReporteMontosPorMesPorEmpresa(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_PorMes_PorEmpresa_Montos");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return decimal.Parse(b.SelectString());
        }

        public int ReporteVentasAnualPorEmpresa(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_Anual_PorEmpresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        public decimal ReporteMontosAnualPorEmpresa(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_Anual_PorEmpresa_Montos");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            return decimal.Parse(b.SelectString());
        }

        public List<m.VentasGeneral> ProductosXCliente(int idproducto)
        {
            b.ExecuteCommandSP("Reporte_Ventas_Clientes_PorProducto");
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            List<m.VentasGeneral> resultado = new List<m.VentasGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasGeneral item = new m.VentasGeneral();
                item.Productos.Id = int.Parse(reader["id"].ToString());
                item.Productos.SKU = reader["sku"].ToString();
                item.Productos.Nombre = reader["nombre"].ToString();
                item.VentasProductos.IdVenta = int.Parse(reader["idventa"].ToString());
                item.Ventas.Fecha = DateTime.Parse(reader["fechaventa"].ToString());
                item.Clientes.Nombre = reader["cliente"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.VentasGeneral> TopTenProductosXTienda(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_TopTenProductosPorEmpresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            List<m.VentasGeneral> resultado = new List<m.VentasGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasGeneral item = new m.VentasGeneral();
                item.Productos.Nombre = reader["nombre"].ToString();
                item.Productos.SKU = reader["sku"].ToString();
                item.Productos.Id = int.Parse(reader["id"].ToString()); //Obtiene los contados
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.VentasGeneral> TopTenCategoriasXTienda(int idempresa)
        {
            b.ExecuteCommandSP("Reporte_Ventas_TopTenCategoriasPorEmpresa");
            b.AddParameter("@idempresa", idempresa, SqlDbType.Int);
            List<m.VentasGeneral> resultado = new List<m.VentasGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.VentasGeneral item = new m.VentasGeneral();
                item.Productos.Nombre = reader["categoria"].ToString(); //Se guarda la categoria
                item.Productos.Id = int.Parse(reader["id"].ToString()); //Obtiene los contados
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }


    }
}
