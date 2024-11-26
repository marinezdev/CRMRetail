using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;


namespace CRMRetail.Datos.Tablas
{
    public class CatEstados
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Catalogos> Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Estados_Seleccionar");
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["Estado"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
