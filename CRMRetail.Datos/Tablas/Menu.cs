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
    /// Métodos para menú y menuroles
    /// </summary>
    public class Menu
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Menu> Seleccionar()
        {
            b.ExecuteCommandSP("Menu_Seleccionar");
            List<m.Menu> resultado = new List<m.Menu>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Menu item = new m.Menu();
                item.Id = int.Parse(reader["id"].ToString());
                item.IdJQuery = reader["idjquery"].ToString();
                item.Ruta = reader["ruta"].ToString();
                item.Icono = reader["icono"].ToString();
                item.Nombre = reader["nombre"].ToString();
                item.Activo = bool.Parse(reader["activo"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.MenuMenuRoles> SeleccionarMenuRol()
        {
            b.ExecuteCommandSP("MenuRoles_Seleccionar_MenuRol");
            List<m.MenuMenuRoles> resultado = new List<m.MenuMenuRoles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.MenuMenuRoles item = new m.MenuMenuRoles();
                item.Menu.Id = int.Parse(reader["id"].ToString());
                item.Menu.Nombre = reader["opcionmenu"].ToString();
                item.Menu.IdJQuery = reader["rol"].ToString();
                item.Menu.Activo = bool.Parse(reader["activo"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.MenuMenuRoles> SeleccionarMenuPorIdRol(int idrol)
        {
            b.ExecuteCommandSP("Menu_Seleccionar_PorIdRol");
            b.AddParameter("@idrol", idrol, SqlDbType.Int);
            List<m.MenuMenuRoles> resultado = new List<m.MenuMenuRoles>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.MenuMenuRoles item = new m.MenuMenuRoles();
                item.Menu.IdJQuery = reader["idjquery"].ToString();
                item.Menu.Ruta = reader["ruta"].ToString();
                item.Menu.Icono = reader["icono"].ToString();
                item.Menu.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.MenuRoles SeleccionarMenuRolPorId(int id)
        {
            b.ExecuteCommandSP("MenuRoles_Seleccionar_MenuRolPorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.MenuRoles resultado = new m.MenuRoles();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.IdMenu = int.Parse(reader["idmenu"].ToString());
                resultado.IdRol = int.Parse(reader["idrol"].ToString());
                resultado.Activo = bool.Parse(reader["activo"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Menu SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Menu_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Menu resultado = new m.Menu();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.IdJQuery = reader["idjquery"].ToString();
                resultado.Ruta = reader["ruta"].ToString();
                resultado.Icono = reader["icono"].ToString();
                resultado.Nombre = reader["nombre"].ToString();
                resultado.Activo = bool.Parse(reader["activo"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.Menu items)
        {
            b.ExecuteCommandSP("Menu_Agregar");
            b.AddParameter("@idjquery", items.IdJQuery, SqlDbType.NVarChar);
            b.AddParameter("@ruta", items.Ruta, SqlDbType.NVarChar);
            b.AddParameter("@icono", items.Icono, SqlDbType.NVarChar);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@activo", items.Activo == true ? 1 : 0, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        public int Modificar(m.Menu items)
        {
            b.ExecuteCommandSP("Menu_Modificar");
            b.AddParameter("@idjquery", items.IdJQuery, SqlDbType.NVarChar);
            b.AddParameter("@ruta", items.Ruta, SqlDbType.NVarChar);
            b.AddParameter("@icono", items.Icono, SqlDbType.NVarChar);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int AgregarMenuRol(m.MenuRoles items)
        {
            b.ExecuteCommandSP("MenuRoles_Agregar_MenuRol");
            b.AddParameter("@idmenu", items.IdMenu, SqlDbType.Int);
            b.AddParameter("@idrol", items.IdRol, SqlDbType.Int);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameterWithReturnValue("@resultado");
            return b.InserUpdateDeletetWithReturnValue();
        }

        public int ModificarMenuRol(m.MenuRoles items)
        {
            b.ExecuteCommandSP("MenuRoles_Modificar");
            b.AddParameter("@idmenu", items.IdMenu, SqlDbType.Int);
            b.AddParameter("@idrol", items.IdRol, SqlDbType.Int);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }


    }
}
