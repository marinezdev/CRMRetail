using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class CatHorarios
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Catalogos> Seleccionar()
        {
            b.ExecuteCommandSP("cat_horarios_seleccionar");
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Horario"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
