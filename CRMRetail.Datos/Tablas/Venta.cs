using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Venta
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();
      
        public List<m.Consultas.Venta_PorMes> Venta_PorMes()
        {
            b.ExecuteCommandSP("Venta_PorMes");
            List<m.Consultas.Venta_PorMes> resultado = new List<m.Consultas.Venta_PorMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_PorMes item = new m.Consultas.Venta_PorMes()
                {
                    Dia = reader["Dia"].ToString().Substring(0,10),
                    TotalC = Convert.ToDecimal(reader["TotalC"].ToString()),
                    TotalE = Convert.ToDecimal(reader["TotalE"].ToString()),
                    TotalS = Convert.ToDecimal(reader["TotalS"].ToString())
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Venta_PorMes> Venta_Dia()
        {
            b.ExecuteCommandSP("Venta_Dia");
            List<m.Consultas.Venta_PorMes> resultado = new List<m.Consultas.Venta_PorMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_PorMes item = new m.Consultas.Venta_PorMes()
                {
                    Dia = reader["Dia"].ToString().Substring(0, 10),
                    TotalC = Convert.ToDecimal(reader["TotalC"].ToString()),
                    TotalE = Convert.ToDecimal(reader["TotalE"].ToString()),
                    TotalS = Convert.ToDecimal(reader["TotalS"].ToString())
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Venta_PorMes> Venta_DiaR()
        {
            b.ExecuteCommandSP("Venta_DiaR");
            List<m.Consultas.Venta_PorMes> resultado = new List<m.Consultas.Venta_PorMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_PorMes item = new m.Consultas.Venta_PorMes()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    hoy = Convert.ToDecimal(reader["VentasHoy"].ToString()),
                    ayer = Convert.ToDecimal(reader["VentasAyer"].ToString()),
                    
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Venta_PorMes> R_Anual_2023()
        {
            b.ExecuteCommandSP("R_Anual_2023");
            List<m.Consultas.Venta_PorMes> resultado = new List<m.Consultas.Venta_PorMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_PorMes item = new m.Consultas.Venta_PorMes()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    TotalS = Convert.ToDecimal(reader["Cantidad"].ToString())

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Venta_PorMes> R_Anual_2024()
        {
            b.ExecuteCommandSP("R_Anual_2024");
            List<m.Consultas.Venta_PorMes> resultado = new List<m.Consultas.Venta_PorMes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_PorMes item = new m.Consultas.Venta_PorMes()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    TotalS = Convert.ToDecimal(reader["Cantidad"].ToString())

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        public List<m.Consultas.Venta_TOP> Venta_TOP()
        {
            b.ExecuteCommandSP("Venta_TOP");
            List<m.Consultas.Venta_TOP> resultado = new List<m.Consultas.Venta_TOP>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_TOP item = new m.Consultas.Venta_TOP()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Monto = Convert.ToDecimal(reader["Monto"].ToString()),
                    Sucursal = reader["Sucursal"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Venta_TOP> Venta_BackOrder()
        {
            b.ExecuteCommandSP("Venta_BackOrder");
            List<m.Consultas.Venta_TOP> resultado = new List<m.Consultas.Venta_TOP>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_TOP item = new m.Consultas.Venta_TOP()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Monto = Convert.ToDecimal(reader["Monto"].ToString()),
                    Sucursal = reader["Sucursal"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Venta_TOP> Venta_Selecionar()
        {
            b.ExecuteCommandSP("Venta_Selecionar");
            List<m.Consultas.Venta_TOP> resultado = new List<m.Consultas.Venta_TOP>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Venta_TOP item = new m.Consultas.Venta_TOP()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Monto = Convert.ToDecimal(reader["Monto"].ToString()),
                    Sucursal = reader["Sucursal"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Consultas.Venta_ResumenMes Venta_ResumenMes()
        {
            b.ExecuteCommandSP("Venta_ResumenMes");
            m.Consultas.Venta_ResumenMes resultado = new m.Consultas.Venta_ResumenMes();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Ventas = Convert.ToInt32(reader["Ventas"].ToString());
                resultado.Total = Convert.ToDecimal(reader["Total"].ToString());
                resultado.Coyoacan = Convert.ToDecimal(reader["Coyoacan"].ToString());
                resultado.Esmeralda = Convert.ToDecimal(reader["Esmeralda"].ToString());
                resultado.SubDistribuidores = Convert.ToDecimal(reader["SubDistribuidores"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.ReporteVentas> Venta_ResumenMesR()
        {
            b.ExecuteCommandSP("Venta_ResumenMesR");
            List<m.Consultas.ReporteVentas> resultado = new List<m.Consultas.ReporteVentas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.ReporteVentas item = new m.Consultas.ReporteVentas()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    VentasXMes = Convert.ToDecimal(reader["VentasXMes"].ToString()),

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Modelos SeleccionarDetalleCliente(int idventa)
        {
            
                b.ExecuteCommandSP("Venta_Seleccionar_DetalleCliente");
                b.AddParameter("@idventa", idventa, SqlDbType.Int);
                m.Modelos resultado = new m.Modelos();
                var reader = b.ExecuteReader();
                while (reader.Read())
                {
                    resultado.Venta.Id = int.Parse(reader["id"].ToString());
                    resultado.Venta.IdCliente = int.Parse(reader["idcliente"].ToString());
                    resultado.Venta.IdUsuario = int.Parse(reader["idusuario"].ToString());
                    resultado.Venta.IdSucursal = int.Parse(reader["idsucursal"].ToString());
                    resultado.Venta.IdFormaPago = int.Parse(reader["idformapago"].ToString());
                    resultado.Venta.IdTarjeta = reader.IsDBNull(reader.GetOrdinal("idtarjeta")) ? 0 : int.Parse(reader["idtarjeta"].ToString());
                    resultado.Venta.IdTipoEntrega = int.Parse(reader["idtipoentrega"].ToString());
                    resultado.Venta.IdEstatus = int.Parse(reader["idestatus"].ToString());
                    resultado.Venta.Monto = decimal.Parse(reader["monto"].ToString());
                    resultado.Venta.FechaRegistro = DateTime.Parse(reader["fecharegistro"].ToString());
                    resultado.Venta.Activo = bool.Parse(reader["activo"].ToString());
                    resultado.Cliente.Calle = reader["calle"].ToString();
                    resultado.Cliente.Nombre = reader["cliente"].ToString();
                    resultado.Cliente.RFC = reader["RFC"].ToString();
                }
                b.CloseConnection();
                return resultado;
        
        }
        
        public m.Mensajes Venta_Agregar(m.Venta venta)
        {
            b.ExecuteCommandSP("Venta_Agregar");
            b.AddParameter("@IdCliente", venta.IdCliente, SqlDbType.Int);
            b.AddParameter("@IdUsuario", venta.IdUsuario, SqlDbType.Int);
            b.AddParameter("@IdSucursal", venta.IdSucursal, SqlDbType.Int);
            b.AddParameter("@IdFormaPago", venta.IdFormaPago, SqlDbType.Int);
            b.AddParameter("@IdTarjeta", venta.IdTarjeta, SqlDbType.Int);
            b.AddParameter("@IdTipoEntrega", venta.IdTipoEntrega, SqlDbType.Int);
            b.AddParameter("@IdEstatus", venta.IdEstatus, SqlDbType.Int);
            b.AddParameter("@Monto", venta.Monto, SqlDbType.Decimal);
            m.Mensajes resultado = new m.Mensajes();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Respuesta"].ToString());
                resultado.Texto = reader["RespuestaText"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public int Modificar_Activo(int idventa, int activo)
        {
            b.ExecuteCommandSP("Venta_Modificar_Activo");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            b.AddParameter("@activo", activo, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }


        public List<m.Consultas.ReporteVentas> Socursales_ventasXmes()
        {
            b.ExecuteCommandSP("Socursales_ventasXmes");
            List<m.Consultas.ReporteVentas> resultado = new List<m.Consultas.ReporteVentas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
            
                m.Consultas.ReporteVentas item = new m.Consultas.ReporteVentas()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre =reader["Nombre"].ToString(),
                    VentasXMes = Decimal.Parse(reader["VentasXMes"].ToString())
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Venta InformacionVenta(m.Venta idventa)
        {

            b.ExecuteCommandSP("Venta_Seleccionar_DetalleCliente");
            b.AddParameter("@idventa", idventa, SqlDbType.Int);
            m.Venta resultado = new m.Venta();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
             
            }
            b.CloseConnection();
            return resultado;

        }
        ///LISTADO DE CORREO TALLER
        public List<m.TallerUser> Listar_CorreoTaller()
        {
            b.ExecuteCommandSP("Listar_CorreoTaller");

            List<m.TallerUser> resultado = new List<m.TallerUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.TallerUser item = new m.TallerUser()
                {
                    Usuario = reader["Usuario"].ToString(),
                    Fecha = reader["Fecha"].ToString(),
                    Taller = reader["Taller"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        ///CAMBIAR ESTADO DE CORREO
        public m.TallerUser ActualizarCorreoTaller()
        {
            b.ExecuteCommandSP("ActualizarCorreoTaller");
            m.TallerUser resultado = new m.TallerUser();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
