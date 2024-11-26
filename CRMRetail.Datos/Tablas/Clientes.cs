using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Clientes
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Clientes> Seleccionar()
        {
            b.ExecuteCommandSP("Clientes_Seleccionar");
            List<m.Clientes> resultado = new List<m.Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Clientes item = new m.Clientes() 
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    ApellidoPaterno = reader["apellidopaterno"].ToString(),
                    ApellidoMaterno = reader["apellidomaterno"].ToString(),
                    RFC = reader["rfc"].ToString(),
                    DireccionFiscal = reader["direccionfiscal"].ToString(),
                    DireccionEntrega = reader["direccionentrega"].ToString(),
                    TelefonoFijo = reader["telefonofijo"].ToString(),
                    TelefonoCelular = reader["telefonocelular"].ToString(),
                    Sexo = reader["sexo"].ToString(),
                    FechaNacimiento = reader["fechanacimiento"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fechanacimiento"].ToString()),
                    Tipo = int.Parse(reader["tipo"].ToString()),
                    Origen = int.Parse(reader["origen"].ToString()),
                    Alta = DateTime.Parse(reader["alta"].ToString()),
                    Correo = reader["correo"].ToString(),
                    FisicaMoral = int.Parse(reader["fisicamoral"].ToString())
            };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Clientes SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Clientes_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Clientes resultado = new m.Clientes();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
                resultado.ApellidoPaterno = reader["apellidopaterno"].ToString();
                resultado.ApellidoMaterno = reader["apellidomaterno"].ToString(); 
                resultado.RFC = reader["rfc"].ToString();
                resultado.DireccionFiscal = reader["direccionfiscal"].ToString();
                resultado.DireccionEntrega = reader["direccionentrega"].ToString();
                resultado.TelefonoFijo = reader["telefonofijo"].ToString();
                resultado.TelefonoCelular = reader["telefonocelular"].ToString();
                resultado.Sexo = reader["sexo"].ToString();
                resultado.FechaNacimiento = reader["fechanacimiento"].ToString() == "" ? DateTime.Parse("1900/01/01") : DateTime.Parse(reader["fechanacimiento"].ToString());
                resultado.Tipo = int.Parse(reader["tipo"].ToString());
                resultado.Origen = int.Parse(reader["origen"].ToString());
                resultado.Correo = reader["correo"].ToString();
                resultado.FisicaMoral = int.Parse(reader["fisicamoral"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Clientes> SeleccionarNombresCompletos()
        {
            b.ExecuteCommandSP("Clientes_Seleccionar_PorNombre_Compuesto");
            List<m.Clientes> resultado = new List<m.Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Clientes item = new m.Clientes()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Clientes> SeleccionarPorIdProducto(int idproducto)
        {
            b.ExecuteCommandSP("Clientes_Seleccionar_PorIdProducto");
            b.AddParameter("@idproducto", idproducto, SqlDbType.Int);
            List<m.Clientes> resultado = new List<m.Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Clientes item = new m.Clientes()
                {
                    Id = int.Parse(reader["idcliente"].ToString()),
                    Nombre = reader["cliente"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.Clientes items)
        {
            b.ExecuteCommandSP("Clientes_Agregar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 50);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno, SqlDbType.NVarChar, 50);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno, SqlDbType.NVarChar, 50);
            b.AddParameter("@rfc", items.RFC, SqlDbType.NVarChar, 50);
            b.AddParameter("@direccionfiscal", items.DireccionFiscal, SqlDbType.NVarChar, 150);
            b.AddParameter("@direccionentrega", items.DireccionEntrega, SqlDbType.NVarChar, 150);
            b.AddParameter("@telefonofijo", items.TelefonoFijo, SqlDbType.NVarChar, 10);
            b.AddParameter("@telefonocelular", items.TelefonoCelular, SqlDbType.NVarChar, 10);
            b.AddParameter("@sexo", items.Sexo, SqlDbType.NChar, 1);
            if (items.FechaNacimiento > DateTime.Parse("1900/01/01"))
                b.AddParameter("@fechanacimiento", items.FechaNacimiento, SqlDbType.Date);
            else
                b.AddParameter("@fechanacimiento");
            b.AddParameter("@tipo", items.Tipo, SqlDbType.Int);
            b.AddParameter("@origen", items.Origen, SqlDbType.Int);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar, 150);
            b.AddParameter("@fisicamoral", items.FisicaMoral, SqlDbType.Int);
            b.AddParameterWithReturnValue("@respuesta");
            return b.InserUpdateDeletetWithReturnValue();
        }

        public int Modificar(m.Clientes items)
        {
            b.ExecuteCommandSP("Clientes_Modificar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 50);
            b.AddParameter("@apellidopaterno", items.ApellidoPaterno, SqlDbType.NVarChar, 50);
            b.AddParameter("@apellidomaterno", items.ApellidoMaterno, SqlDbType.NVarChar, 50);
            b.AddParameter("@rfc", items.RFC, SqlDbType.NVarChar, 50);
            b.AddParameter("@direccionfiscal", items.DireccionFiscal, SqlDbType.NVarChar, 150);
            b.AddParameter("@direccionentrega", items.DireccionEntrega, SqlDbType.NVarChar, 150);
            b.AddParameter("@telefonofijo", items.TelefonoFijo, SqlDbType.NVarChar, 10);
            b.AddParameter("@telefonocelular", items.TelefonoCelular, SqlDbType.NVarChar, 10);
            b.AddParameter("@sexo", items.Sexo, SqlDbType.NChar, 1);
            b.AddParameter("@fechanacimiento", items.FechaNacimiento, SqlDbType.Date);
            b.AddParameter("@tipo", items.Tipo, SqlDbType.Int);
            b.AddParameter("@origen", items.Origen, SqlDbType.Int);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar, 150);
            b.AddParameter("@fisicamoral", items.FisicaMoral, SqlDbType.Int);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
