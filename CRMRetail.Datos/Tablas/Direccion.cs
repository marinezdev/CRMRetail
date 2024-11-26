using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMRetail.Modelos;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Direccion
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();
        public m.Mensajes RegistrarDireccionCliente(m.Direccion direccion)
        {
            b.ExecuteCommandSP("DireccionCliente_Agregar");
            b.AddParameter("@IdCliente", direccion.IdCliente, SqlDbType.Int);
            b.AddParameter("@IdEstado", direccion.IdEstado, SqlDbType.NVarChar);
            b.AddParameter("@IdPoblacion", direccion.IdPoblacion, SqlDbType.NVarChar);
            b.AddParameter("@Colonia", direccion.Colonia, SqlDbType.NVarChar);
            b.AddParameter("@IdCP", direccion.IdCP, SqlDbType.NVarChar);
            b.AddParameter("@NumExterior", direccion.NumExterior, SqlDbType.NVarChar);
            b.AddParameter("@NumInterior", direccion.NumInterior, SqlDbType.NVarChar);
            b.AddParameter("@Calle", direccion.Calle, SqlDbType.NVarChar);
            b.AddParameter("@EntreCalles", direccion.EntreCalles, SqlDbType.NVarChar);
            b.AddParameter("@Referencias", direccion.Referencias, SqlDbType.NVarChar);
            b.AddParameter("@FiscalEntrega", direccion.FiscalEntrega, SqlDbType.NVarChar);
            b.AddParameter("@Flag", direccion.Flag, SqlDbType.NVarChar);
            m.Mensajes resultado = new m.Mensajes();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = int.Parse(reader["Resultado"].ToString());
                resultado.Texto = reader["Texto"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }


        public m.Direccion RegistroDireccionFlash(m.Direccion direccion)
        {
            b.ExecuteCommandSP("DireccionCliente_Agregar_R");
            b.AddParameter("@IdCliente", direccion.IdCliente, SqlDbType.Int);
            b.AddParameter("@IdEstado", direccion.IdEstado, SqlDbType.Int);
            b.AddParameter("@IdMunicipio", direccion.IdPoblacion, SqlDbType.Int);
            b.AddParameter("@IdColonia", direccion.IdColonia, SqlDbType.Int);
            b.AddParameter("@IdCP", direccion.IdCP, SqlDbType.Int);
            b.AddParameter("@NumExterior", direccion.NumExterior, SqlDbType.NVarChar);
            b.AddParameter("@NumInterior", direccion.NumInterior, SqlDbType.NVarChar);
            b.AddParameter("@Calle", direccion.Calle, SqlDbType.NVarChar);
            b.AddParameter("@EntreCalles", direccion.EntreCalles, SqlDbType.NVarChar);
            b.AddParameter("@Referencias", direccion.Referencias, SqlDbType.NVarChar);

            m.Direccion r = new m.Direccion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                r.IdDireccion = int.Parse(reader["Id"].ToString());
            }
            b.CloseConnection();
            return r;
        }

        public List<m.Direccion> Direcciones_Seleccionar_IdCliente(m.Cliente cliente)
        {
            b.ExecuteCommandSP("Direcciones_Seleccionar_IdCliente");
            b.AddParameter("@IdCliente", cliente.Id, SqlDbType.Int);
            List<m.Direccion> resultado = new List<m.Direccion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Estado"].ToString().Length > 0)
                {
                    m.Direccion item = new m.Direccion()
                    {
                        IdDireccion = int.Parse(reader["IdDireccion"].ToString()),
                        IdEstado = int.Parse(reader["IdEstado"].ToString()),
                        Estado = reader["Estado"].ToString(),
                        IdPoblacion = int.Parse(reader["idpoblacion"].ToString()),
                        Poblacion = reader["Poblacion"].ToString(),
                        IdColonia = int.Parse(reader["IdColonia"].ToString()),
                        Colonia = reader["Colonia"].ToString(),
                        IdCP = int.Parse(reader["IdCP"].ToString()),
                        CP = reader["CP"].ToString(),
                        NumExterior = reader["NumExterior"].ToString(),
                        NumInterior = reader["NumInterior"].ToString(),
                        Calle = reader["Calle"].ToString(),
                        EntreCalles = reader["EntreCalles"].ToString(),
                        Referencias = reader["Referencias"].ToString(),
                        FiscalEntrega = int.Parse(reader["FiscalEntrega"].ToString()),
                        Flag = int.Parse(reader["Flag"].ToString())
                    };
                    resultado.Add(item);
                }
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Direccion> Direcciones_Seleccionar_List_IdCliente(m.Cliente cliente)
        {
            b.ExecuteCommandSP("Direcciones_Seleccionar_List_IdCliente");
            b.AddParameter("@IdCliente", cliente.Id, SqlDbType.Int);
            List<m.Direccion> resultado = new List<m.Direccion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Estado"].ToString().Length > 0)
                {
                    m.Direccion item = new m.Direccion()
                    {
                        IdDireccion = Convert.ToInt32(reader["Id"].ToString()),
                        IdEstado = int.Parse(reader["IdEstado"].ToString()),
                        Estado = reader["Estado"].ToString(),
                        Poblacion = reader["Poblacion"].ToString(),
                        Colonia = reader["Colonia"].ToString(),
                        IdCP = int.Parse(reader["IdCP"].ToString()),
                        CP = reader["CP"].ToString(),
                        NumExterior = reader["NumExterior"].ToString(),
                        NumInterior = reader["NumInterior"].ToString(),
                        Calle = reader["Calle"].ToString(),
                        EntreCalles = reader["EntreCalles"].ToString(),
                        Referencias = reader["Referencias"].ToString(),
                        FiscalEntrega = int.Parse(reader["FiscalEntrega"].ToString()),
                        Flag = int.Parse(reader["Flag"].ToString()),
                    };
                    resultado.Add(item);
                }
            }
            b.CloseConnection();
            return resultado;
        }

    }
}
