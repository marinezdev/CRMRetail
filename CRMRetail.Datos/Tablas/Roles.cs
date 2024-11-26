using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Roles
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Roles> Seleccionar()
        {
            b.ExecuteCommandSP("Roles_Seleccionar");
            List<m.Roles> resultado = new List<m.Roles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Roles item = new m.Roles()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),
                    Pagina = reader["pagina"].ToString(),
                    Controlador = reader["controlador"].ToString(),
                    Activo = bool.Parse(reader["activo"].ToString()),

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Roles SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Roles_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Roles resultado = new m.Roles();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
                resultado.Pagina = reader["pagina"].ToString();
                resultado.Controlador = reader["controlador"].ToString();
                resultado.Activo = bool.Parse(reader["activo"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.Roles items)
        {
            b.ExecuteCommandSP("Roles_Agregar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 50);
            b.AddParameter("@pagina", items.Pagina, SqlDbType.NVarChar, 50);
            b.AddParameter("@controlador", items.Controlador, SqlDbType.NVarChar, 50);
            return b.InsertUpdateDelete();
        }

        public int Modificar(m.Roles items)
        {
            b.ExecuteCommandSP("Roles_Modificar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 50);
            b.AddParameter("@pagina", items.Pagina, SqlDbType.NVarChar, 50);
            b.AddParameter("@controlador", items.Controlador, SqlDbType.NVarChar, 50);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }



    }
}
