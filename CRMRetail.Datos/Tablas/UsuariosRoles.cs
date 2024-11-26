using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class UsuariosRoles
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public m.UsuariosRoles SeleccionarPorId(string id)
        {
            b.ExecuteCommandSP("UsuariosRoles_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.UsuariosRoles resultado = new m.UsuariosRoles();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Usuarios.Id = int.Parse(reader["id"].ToString());
                resultado.Usuarios.Nombre = reader["usuario"].ToString();
                resultado.Usuarios.Clave = reader["clave"].ToString();
                resultado.Roles.Id = int.Parse(reader["idrol"].ToString());
                resultado.Roles.Nombre = reader["rol"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        





    }
}
