using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class CatColonias
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Catalogos> Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_Colonias_Seleccionar");
            b.AddParameter("@IdPolacion", Id, SqlDbType.Int);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos()
                {
                    Id = int.Parse(reader["IdCP"].ToString()),
                    Nombre = reader["Colonia"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
