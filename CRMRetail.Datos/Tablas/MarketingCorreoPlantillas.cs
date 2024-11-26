using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class MarketingCorreoPlantillas
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.MarketingCorreoPlantillas> Seleccionar()
        {
            b.ExecuteCommandSP("MarketingCorreoPlantillas_Seleccionar");
            List<m.MarketingCorreoPlantillas> resultado = new List<m.MarketingCorreoPlantillas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.MarketingCorreoPlantillas item = new m.MarketingCorreoPlantillas();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.Codigo = reader["codigo"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.MarketingCorreoPlantillas SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("MarketingCorreoPlantillas_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.MarketingCorreoPlantillas resultado = new m.MarketingCorreoPlantillas();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Codigo = reader["codigo"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
