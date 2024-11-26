using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class CatCP
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Catalogos> Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_CP_Seleccionar");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["CP"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Direccion> Cat_CP_Busqueda(string  CP)
        {
            b.ExecuteCommandSP("Cat_CP_Busqueda");
            b.AddParameter("@CP", CP, SqlDbType.NVarChar);
            List<m.Direccion> resultado = new List<m.Direccion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Direccion item = new m.Direccion()
                {
                    IdEstado = int.Parse(reader["IdEstado"].ToString()),
                    Estado = reader["Estado"].ToString(),
                    IdPoblacion = int.Parse(reader["IdPoblacion"].ToString()),
                    Poblacion = reader["Poblacion"].ToString(),
                    IdColonia = int.Parse(reader["IdColonia"].ToString()),
                    Colonia = reader["Colonia"].ToString(),
                    IdCP = int.Parse(reader["IdCP"].ToString()),
                    CP = reader["CP"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
