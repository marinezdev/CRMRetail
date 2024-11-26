using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Cliente
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public m.Cliente RegistrarCliente(m.Cliente cliente)
        {
            b.ExecuteCommandSP("RegistrarCliente");
            b.AddParameter("@TipoPersona", cliente.TipoPersona, SqlDbType.Int);
            b.AddParameter("@Nombre", cliente.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", cliente.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", cliente.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@Sexo", cliente.Sexo, SqlDbType.NVarChar);
            b.AddParameter("@FechaNacimiento", cliente.FechaNacimiento, SqlDbType.NVarChar);
            b.AddParameter("@MesCumple", cliente.MesCumple, SqlDbType.NVarChar);
            b.AddParameter("@DiaCumple", cliente.DiaCumple, SqlDbType.NVarChar);
            b.AddParameter("@FechaConstitucion", cliente.FechaConstitucion, SqlDbType.NVarChar);
            b.AddParameter("@RFC", cliente.RFC, SqlDbType.NVarChar);
            b.AddParameter("@Correo", cliente.Correo, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoMovil", cliente.TelefonoMovil, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoLocal", cliente.TelefonoLocal, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoCliente", cliente.IdTipoCliente, SqlDbType.Int);
            b.AddParameter("@IdOrigenCliente", cliente.IdOrigenCliente, SqlDbType.Int);
            b.AddParameter("@IdSucursal", cliente.IdSucursal, SqlDbType.Int);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdCliente = int.Parse(reader["IdCliente"].ToString());
                resultado.Resultado = reader["Resultado"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente BuscarClienteRFC(m.Cliente cliente)
        {
            b.ExecuteCommandSP("Cliente_Seleccionar_RFC");
            b.AddParameter("@RFC", cliente.RFC, SqlDbType.NVarChar);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdCliente = int.Parse(reader["Id"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Cliente> Cliente_Seleccionar()
        {
            b.ExecuteCommandSP("Cliente_Seleccionar");
            List<m.Cliente> resultado = new List<m.Cliente>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Cliente item = new m.Cliente()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    TelefonoMovil = reader["TelefonoMovil"].ToString(),
                    Correo = reader["Correo"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente Cliente_Seleccionar_Id(m.Cliente cliente)
        {
            b.ExecuteCommandSP("Cliente_Seleccionar_Id");
            b.AddParameter("@Id", cliente.Id, SqlDbType.NVarChar);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdCliente = int.Parse(reader["Id"].ToString());
                resultado.TipoPersona = int.Parse(reader["TipoPersona"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Sexo = reader["Sexo"].ToString();
                resultado.FechaNacimiento = reader["FechaNacimiento"].ToString();
                resultado.FechaConstitucion = reader["FechaConstitucion"].ToString();
                resultado.RFC = reader["RFC"].ToString();
                resultado.Correo = reader["Correo"].ToString();
                resultado.TelefonoMovil = reader["TelefonoMovil"].ToString();
                resultado.TelefonoLocal = reader["TelefonoLocal"].ToString();
                resultado.TipoCliente = reader["TipoCliente"].ToString();
                resultado.OrigenCliente = reader["OrigenCliente"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente Cliente_Seleccionar_Id(int Id)
        {
            b.ExecuteCommandSP("Cliente_Seleccionar_Id");
            b.AddParameter("@Id", Id, SqlDbType.NVarChar);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdCliente = int.Parse(reader["Id"].ToString());
                resultado.TipoPersona = int.Parse(reader["TipoPersona"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Sexo = reader["Sexo"].ToString();
                resultado.FechaNacimiento = reader["FechaNacimiento"].ToString();
                resultado.FechaConstitucion = reader["FechaConstitucion"].ToString();
                resultado.RFC = reader["RFC"].ToString();
                resultado.Correo = reader["Correo"].ToString();
                resultado.TelefonoMovil = reader["TelefonoMovil"].ToString();
                resultado.TelefonoLocal = reader["TelefonoLocal"].ToString();
                resultado.TipoCliente = reader["TipoCliente"].ToString();
                resultado.OrigenCliente = reader["OrigenCliente"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente ClienteSeleccionarDetallePorId(int id)
        {
            b.ExecuteCommandSP("Cliente_Seleccionar_Detalle_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.TipoPersona = int.Parse(reader["TipoPersona"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                resultado.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.Sexo = reader["Sexo"].ToString();
                resultado.FechaNacimiento = reader["FechaNacimiento"].ToString();
                resultado.FechaConstitucion = reader["FechaConstitucion"].ToString();
                resultado.RFC = reader["RFC"].ToString();
                resultado.Correo = reader["Correo"].ToString();
                resultado.TelefonoMovil = reader["TelefonoMovil"].ToString();
                resultado.TelefonoLocal = reader["TelefonoLocal"].ToString();
                resultado.TipoCliente = reader["TipoCliente"].ToString();
                resultado.OrigenCliente = reader["OrigenCliente"].ToString();
                resultado.IdSucursal = int.Parse(reader["sucursal"].ToString());
                resultado.Activo = bool.Parse(reader["activo"].ToString());
                resultado.FechaRegistro = reader["FechaRegistro"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Consultas.Cliente_Ganados_TOP> Cliente_Ganados_TOP()
        {
            b.ExecuteCommandSP("Cliente_Ganados_TOP");
            List<m.Consultas.Cliente_Ganados_TOP> resultado = new List<m.Consultas.Cliente_Ganados_TOP>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Consultas.Cliente_Ganados_TOP item = new m.Consultas.Cliente_Ganados_TOP()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Total = Convert.ToDecimal(reader["Total"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public int Modificar(m.Modelos items)
        {
            b.ExecuteCommandSP("Cliente_Modificar");
            b.AddParameter("@id", items.Cliente.Id, SqlDbType.Int);
            b.AddParameter("@tipopersona", items.Cliente.TipoPersona, SqlDbType.Int);
            b.AddParameter("@nombre", items.Cliente.Nombre, SqlDbType.NVarChar, 250);
            if (items.Cliente.TipoPersona == 1)
            {
                b.AddParameter("@apaterno", items.Cliente.ApellidoPaterno, SqlDbType.NVarChar, 250);
                b.AddParameter("@amaterno", items.Cliente.ApellidoMaterno, SqlDbType.NVarChar, 250);
                b.AddParameter("@sexo", items.Cliente.Sexo, SqlDbType.NVarChar, 50);
                b.AddParameter("@fechanacimiento", items.Cliente.FechaNacimiento, SqlDbType.Date);
            }
            else
            {
                b.AddParameter("@apaterno");
                b.AddParameter("@amaterno");
                b.AddParameter("@sexo");
                b.AddParameter("@fechanacimiento");
            }

            if (items.Cliente.TipoPersona == 2)
            {
                b.AddParameter("@fechaconstitucion", items.Cliente.FechaConstitucion, SqlDbType.Date);
            }
            else
            {
                b.AddParameter("@fechaconstitucion");
            }
            b.AddParameter("@rfc", items.Cliente.RFC, SqlDbType.NVarChar, 250);
            b.AddParameter("@correo", items.Cliente.Correo, SqlDbType.NVarChar, 250);
            b.AddParameter("@telefonomovil", items.Cliente.TelefonoMovil, SqlDbType.VarChar, 10);
            
            if (string.IsNullOrEmpty(items.Cliente.TelefonoLocal))                
                b.AddParameter("@telefonolocal");
            else
                b.AddParameter("@telefonolocal", items.Cliente.TelefonoLocal, SqlDbType.VarChar, 10);

            b.AddParameter("@idtipocliente", items.Cliente.IdTipoCliente, SqlDbType.Int);
            b.AddParameter("@idorigencliente", items.Cliente.IdOrigenCliente, SqlDbType.Int);
            b.AddParameter("@idsucursal", items.Cliente.IdSucursal, SqlDbType.Int);
            b.AddParameter("@activo", items.Cliente.Activo, SqlDbType.Bit);

            //Parametros para direccion 1
            b.AddParameter("@iddireccion", items.Direccion.Id, SqlDbType.Int);
            b.AddParameter("@idcliente", items.Direccion.IdCliente, SqlDbType.Int);
            b.AddParameter("@idestado", items.Direccion.IdEstado, SqlDbType.Int);
            b.AddParameter("@idpoblacion", items.Direccion.IdPoblacion, SqlDbType.Int);
            b.AddParameter("@idcolonia", items.Direccion.IdColonia, SqlDbType.Int);
            b.AddParameter("@idcp", items.Direccion.IdCP, SqlDbType.Int);
            b.AddParameter("@calle", items.Direccion.Calle, SqlDbType.VarChar, 250);
            b.AddParameter("@numinterior", items.Direccion.NumInterior, SqlDbType.VarChar, 50);

            if (!string.IsNullOrEmpty(items.Direccion.NumExterior))
                b.AddParameter("@numexterior", items.Direccion.NumExterior, SqlDbType.VarChar, 50);
            else
                b.AddParameter("@numexterior");

            if (!string.IsNullOrEmpty(items.Direccion.EntreCalles))
                b.AddParameter("@entrecalles", items.Direccion.EntreCalles, SqlDbType.VarChar);
            else
                b.AddParameter("@entrecalles");

            if (!string.IsNullOrEmpty(items.Direccion.Referencias))
                b.AddParameter("@referencias", items.Direccion.Referencias, SqlDbType.VarChar);
            else
                b.AddParameter("@referencias");

            b.AddParameter("@fiscalentrega", items.Direccion.FiscalEntrega, SqlDbType.Bit);
            b.AddParameter("@flag", items.Direccion.Flag, SqlDbType.Bit);

            //Parametros para direccion 2
            if (items.Direccion.Id2 > 0)
            {
                b.AddParameter("@iddireccion2", items.Direccion.Id2, SqlDbType.Int);
                b.AddParameter("@idcliente2", items.Direccion.IdCliente2, SqlDbType.Int);
                b.AddParameter("@idestado2", items.Direccion.IdEstado2, SqlDbType.Int);
                b.AddParameter("@idpoblacion2", items.Direccion.IdPoblacion2, SqlDbType.Int);
                b.AddParameter("@idcolonia2", items.Direccion.IdColonia2, SqlDbType.Int);
                b.AddParameter("@idcp2", items.Direccion.IdCP2, SqlDbType.Int);
                b.AddParameter("@calle2", items.Direccion.Calle2, SqlDbType.VarChar, 250);
                b.AddParameter("@numinterior2", items.Direccion.NumInterior2, SqlDbType.VarChar, 50);

                if (!string.IsNullOrEmpty(items.Direccion.NumExterior2))
                    b.AddParameter("@numexterior2", items.Direccion.NumExterior2, SqlDbType.VarChar, 50);
                else
                    b.AddParameter("@numexterior2");

                if (!string.IsNullOrEmpty(items.Direccion.EntreCalles2))
                    b.AddParameter("@entrecalles2", items.Direccion.EntreCalles2, SqlDbType.VarChar);
                else
                    b.AddParameter("@entrecalles2");

                if (!string.IsNullOrEmpty(items.Direccion.Referencias2))
                    b.AddParameter("@referencias2", items.Direccion.Referencias2, SqlDbType.VarChar);
                else
                    b.AddParameter("@referencias2");
                
                //b.AddParameter("@fiscalentrega2", items.Direccion.FiscalEntrega2, SqlDbType.Bit);
                //b.AddParameter("@flag2", items.Direccion.Flag2, SqlDbType.Bit);
            }


            return b.InsertUpdateDelete();
        }

        public m.Cliente Consultar_tipoCliente(m.Cliente cliente)
        {
            b.ExecuteCommandSP("Consultar_tipoCliente");
            b.AddParameter("@Id", cliente.Id, SqlDbType.NVarChar);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdCliente = int.Parse(reader["IdCliente"].ToString());
               
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente Consultar_taller(m.Cliente cliente)
        {
            b.ExecuteCommandSP("Consultar_taller");
            b.AddParameter("@Id", cliente.Id, SqlDbType.NVarChar);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.IdCliente = int.Parse(reader["IdProducto"].ToString());

            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente Conteo_BackOrder()
        {
            b.ExecuteCommandSP("Conteo_BackOrder");
          
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente ConteoUser()
        {
            b.ExecuteCommandSP("ConteoUser");

            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }


        public m.Cliente ObtenerDuracionMembresia(m.Cliente cliente)
        {
            b.ExecuteCommandSP("ObtenerDuracionMembresia");
            b.AddParameter("@Id", cliente.Id, SqlDbType.NVarChar);
            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.FechaConstitucion = reader["FechaRegistro"].ToString();
                resultado.Resultado = reader["duracion_membresia"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }


        public List<m.Producto> InsertarTaller(List<m.Producto> Talleres,int idventa)
        {
            List<m.Producto> resultado = new List<m.Producto>();

            foreach (var taller in Talleres)
            {
                b.ExecuteCommandSP("InsertarTaller"); // Mover la ejecución de la consulta dentro del bucle

                b.AddParameter("@Idtaller", taller.Id, SqlDbType.Int);
                b.AddParameter("@Fecha", taller.Fecha, SqlDbType.VarChar);
                b.AddParameter("@Idventa", idventa, SqlDbType.Int);

                var reader = b.ExecuteReader();
                while (reader.Read())
                {
                    m.Producto documento = new m.Producto();
                    documento.Id = Convert.ToInt32(reader["Id"].ToString());
                    resultado.Add(documento);
                }
                reader.Close();

                b.ConnectionCloseToTransaction();
            }

            return resultado;
        }

    }
}
