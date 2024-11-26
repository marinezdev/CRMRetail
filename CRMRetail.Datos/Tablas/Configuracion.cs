using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Configuracion
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Configuracion> Seleccionar()
        {
            b.ExecuteCommandSP("Configuracion_Seleccionar");
            List<m.Configuracion> resultado = new List<m.Configuracion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Configuracion item = new m.Configuracion()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString(),

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Configuracion SeleccionarPorId(string id)
        {
            b.ExecuteCommandSP("Configuracion_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Configuracion resultado = new m.Configuracion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.Configuracion items)
        {
            b.ExecuteCommandSP("Socursal_Insertar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        public int Modificar(m.Configuracion items)
        {
            b.ExecuteCommandSP("Configuracion_Modificar");
            b.AddParameter("@nombre", items.Nombre, SqlDbType.Int);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }



    }
        
}
