using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Ventas
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Ventas> SeleccionarPorIdUsuario(int idusuario)
        {
            b.ExecuteCommandSP("Ventas_Seleccionar_PorIdUsuario");
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<m.Ventas> resultado = new List<m.Ventas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Ventas item = new m.Ventas();

                item.Id = int.Parse(reader["id"].ToString());
                item.Clientes.Id = int.Parse(reader["idcliente"].ToString());
                item.Clientes.Nombre = reader["nombre"].ToString();
                item.Clientes.ApellidoPaterno = reader["apellidopaterno"].ToString();
                item.Clientes.ApellidoMaterno = reader["apellidomaterno"].ToString();
                item.Clientes.RFC = reader["rfc"].ToString();
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.Tipo = int.Parse(reader["tipo"].ToString());
                item.TipoEntrega = int.Parse(reader["entrega"].ToString());
                item.Usuarios.Id = int.Parse(reader["vendedor"].ToString());
                item.Monto = decimal.Parse(reader["monto"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Ventas SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Ventas_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Ventas resultado = new m.Ventas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Clientes.Id = int.Parse(reader["idcliente"].ToString());
                resultado.Clientes.Nombre = reader["nombre"].ToString();
                resultado.Clientes.ApellidoPaterno = reader["apellidopaterno"].ToString();
                resultado.Clientes.ApellidoMaterno = reader["apellidomaterno"].ToString();
                resultado.Clientes.RFC = reader["rfc"].ToString();
                resultado.Clientes.DireccionFiscal = reader["direccionfiscal"].ToString();
                resultado.Clientes.DireccionEntrega = reader["direccionentrega"].ToString();
                resultado.Fecha = DateTime.Parse(reader["fecha"].ToString());
                resultado.Tipo = int.Parse(reader["tipo"].ToString());
                resultado.Vendedor = int.Parse(reader["vendedor"].ToString());
                resultado.TipoEntrega = int.Parse(reader["entrega"].ToString());
                resultado.TarjetaCredito = reader["tarjetacredito"].ToString() == ""? 0 : int.Parse(reader["tarjetacredito"].ToString());
                resultado.FechaEntrega = reader["fechaentrega"].ToString() == ""? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fechaentrega"].ToString());
                resultado.HoraEntrega = reader["horaentrega"].ToString();
                resultado.BackOrder = int.Parse(reader["backorder"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public int SeleccionarCuantasVentasBackOrderPendiente()
        {
            b.ExecuteCommandSP("Ventas_Seleccionar_BackOrderActivo");
            return int.Parse(b.SelectString());
        }

        public List<m.Ventas> SeleccionarVentasBakcOrderPendientes()
        {
            b.ExecuteCommandSP("Ventas_Seleccionar_ConBackOrderActivo");
            List<m.Ventas> resultado = new List<m.Ventas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Ventas item = new m.Ventas();

                item.Id = int.Parse(reader["id"].ToString());
                item.Clientes.Id = int.Parse(reader["idcliente"].ToString());
                item.Clientes.Nombre = reader["nombre"].ToString();
                item.Clientes.ApellidoPaterno = reader["apellidopaterno"].ToString();
                item.Clientes.ApellidoMaterno = reader["apellidomaterno"].ToString();
                item.Clientes.RFC = reader["rfc"].ToString();
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.Tipo = int.Parse(reader["tipo"].ToString());
                item.TipoEntrega = int.Parse(reader["entrega"].ToString());
                item.Usuarios.Id = int.Parse(reader["vendedor"].ToString());
                item.Monto = decimal.Parse(reader["monto"].ToString());
                item.BackOrder = int.Parse(reader["backorder"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;

        }

        public int Agregar(int idcliente, DateTime fecha, int tipo, int vendedor, int tipoentrega, int? tarjetacredito, DateTime fechaentrega, string horaentrega)
        {
            b.ExecuteCommandSP("Ventas_Agregar");
            b.AddParameter("@idcliente", idcliente, SqlDbType.Int);
            b.AddParameter("@fecha", fecha, SqlDbType.DateTime);
            b.AddParameter("@tipo", tipo, SqlDbType.Int);
            b.AddParameter("@vendedor", vendedor, SqlDbType.Int);
            b.AddParameter("@entrega", tipoentrega, SqlDbType.Int);
            if (tarjetacredito > 0)
                b.AddParameter("@tarjetacredito", tarjetacredito, SqlDbType.Int);
            else
                b.AddParameter("@tarjetacredito");
            if (fechaentrega > DateTime.Parse("1900/01/01"))
            {
                b.AddParameter("@fechaentrega", fechaentrega, SqlDbType.DateTime);
                b.AddParameter("@horaentrega", horaentrega, SqlDbType.NVarChar);
            }
            else
            {
                b.AddParameter("@fechaentrega");
                b.AddParameter("@horaentrega");
            }
            return b.SelectWithReturnValue();
        }

        public int Modificar(m.Ventas items)
        {
            b.ExecuteCommandSP("Ventas_Modificar");
            b.AddParameter("@idcliente", items.Clientes.Id, SqlDbType.Int);
            b.AddParameter("@tipo", items.Tipo, SqlDbType.Int);
            b.AddParameter("@vendedor", items.Vendedor, SqlDbType.Int);
            b.AddParameter("@entrega", items.TipoEntrega, SqlDbType.Int);
            if (items.TarjetaCredito > 0)
                b.AddParameter("@tarjetacredito", items.TarjetaCredito, SqlDbType.Int);
            else
                b.AddParameter("@tarjetacredito");
            if (items.FechaEntrega > DateTime.Parse("1900/01/01"))
            {
                b.AddParameter("@fechaentrega", items.FechaEntrega, SqlDbType.DateTime);
                b.AddParameter("@horaentrega", items.HoraEntrega, SqlDbType.NVarChar);
            }
            else
            {
                b.AddParameter("@fechaentrega");
                b.AddParameter("@horaentrega");
            }
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int Modificar_BackOrder(int idventa, int backorder)
        {
            b.ExecuteCommandSP("Ventas_Modificar_BackOrder");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            b.AddParameter("@backorder", backorder, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int Modificar_Cancelar_Venta(int idventa)
        {
            b.ExecuteCommandSP("Ventas_Modificar_Cancelar");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
