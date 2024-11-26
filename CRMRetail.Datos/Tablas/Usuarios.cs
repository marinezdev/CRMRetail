using System;
using System.Collections.Generic;
using System.Data;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Usuarios
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.UsuariosRoles> Seleccionar()
        {
            b.ExecuteCommandSP("Usuarios_Seleccionar");
            List<m.UsuariosRoles> resultado = new List<m.UsuariosRoles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.UsuariosRoles item = new m.UsuariosRoles();
                item.Usuarios.Id = int.Parse(reader["id"].ToString());
                item.Usuarios.Nombre = reader["nombre"].ToString();
                item.Usuarios.Clave = reader["clave"].ToString();
                item.Usuarios.Contraseña = reader["contraseña"].ToString();
                item.Usuarios.Correo = reader["correo"].ToString();
                item.Usuarios.Activo = bool.Parse(reader["activo"].ToString());
                item.Usuarios.Alta = DateTime.Parse(reader["alta"].ToString());
                item.Usuarios.Empresa = int.Parse(reader["empresa"].ToString());
                item.Roles.Nombre = reader["rol"].ToString();                
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.UsuariosRoles SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Usuarios_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.UsuariosRoles resultado = new m.UsuariosRoles();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Usuarios.Id = int.Parse(reader["id"].ToString());
                resultado.Usuarios.Nombre = reader["nombre"].ToString();
                resultado.Usuarios.Clave = reader["clave"].ToString();
                //resultado.Usuarios.Contraseña = Utilerias.Cifrado.Desencriptar(reader["contraseña"].ToString());
                resultado.Usuarios.Correo = reader["correo"].ToString();
                resultado.Usuarios.Activo = bool.Parse(reader["activo"].ToString());
                resultado.Usuarios.Alta = DateTime.Parse(reader["alta"].ToString());
                resultado.Usuarios.Empresa = int.Parse(reader["empresa"].ToString());
                resultado.Roles.Id = int.Parse(reader["idrol"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public int Valida(string clave, string contraseña)
        {
            b.ExecuteCommandSP("Usuarios_Validar_Acceso");
            b.AddParameter("@clave", clave, SqlDbType.NVarChar, 50);
            b.AddParameter("@contraseña", Utilerias.Cifrado.Encriptar(contraseña), SqlDbType.NVarChar, 50);
            return int.Parse(b.SelectString());
        }        

        public m.UsuariosRoles SeleccionarDetalle(int id)
        {
            b.ExecuteCommandSP("UsuariosRoles_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.UsuariosRoles resultado = new m.UsuariosRoles();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Usuarios.Id = int.Parse(reader["idusuario"].ToString());
                resultado.Usuarios.Nombre = reader["usuario"].ToString();
                resultado.Usuarios.Clave = reader["clave"].ToString();
                //resultado.Usuarios.Contraseña = Utilerias.Cifrado.Desencriptar(reader["Contrasena"].ToString());
                resultado.Usuarios.Correo = reader["correo"].ToString();
                resultado.Usuarios.Empresa = int.Parse(reader["empresa"].ToString());
                resultado.Roles.Id = int.Parse(reader["idrol"].ToString());
                resultado.Roles.Nombre = reader["rol"].ToString();
                resultado.Roles.Pagina = reader["pagina"].ToString();
                resultado.Roles.Controlador = reader["controlador"].ToString();

            }
            b.CloseConnection();
            return resultado;

        }

        public int Agregar(m.Usuarios items, int idrol)
        {
            b.ExecuteCommandSP("Usuarios_Agregar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@clave", items.Clave, SqlDbType.NVarChar, 50);
            b.AddParameter("@contraseña", Utilerias.Cifrado.Encriptar(items.Contraseña), SqlDbType.NVarChar, 50);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar, 150);
            b.AddParameter("@empresa", items.Empresa, SqlDbType.Int);
            b.AddParameter("@idrol", idrol, SqlDbType.Int);
            b.AddParameterWithReturnValue("@respuesta");
            return b.InserUpdateDeletetWithReturnValue();            
        }

        public int Modificar(m.Usuarios items, int idrol)
        {
            b.ExecuteCommandSP("Usuarios_Modificar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 150);
            b.AddParameter("@clave", items.Clave, SqlDbType.NVarChar, 50);
            //b.AddParameter("@contraseña", Utilerias.Cifrado.Encriptar(items.Contraseña), SqlDbType.NVarChar, 50);
            b.AddParameter("@correo", items.Correo, SqlDbType.NVarChar, 150);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            b.AddParameter("@idrol", idrol, SqlDbType.Int);
            b.AddParameter("@empresa", items.Empresa, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica la contraseña actual por una diferente
        /// </summary>
        /// <param name="claveactual">Contraseña actual</param>
        /// <param name="clavenueva">Contraseña nueva</param>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        public int ModificarContraseña(string claveactual, string clavenueva, int id)
        {
            b.ExecuteCommandSP("Usuarios_Modificar_Contraseña");
            b.AddParameter("@claveanterior", claveactual, SqlDbType.NVarChar, 50); // b.AddParameter("@claveactual", Utilerias.Cifrado.Encriptar(Anterior), SqlDbType.NVarChar);            
            b.AddParameter("@clavenueva", Utilerias.Cifrado.Encriptar(clavenueva), SqlDbType.NVarChar, 50); //b.AddParameter("@clavenueva", Utilerias.Cifrado.Encriptar(Nueva), SqlDbType.NVarChar);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

    }
}
