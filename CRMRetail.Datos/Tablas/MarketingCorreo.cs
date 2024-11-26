using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class MarketingCorreo
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public m.MarketingCorreo SeleccionarPorIdCampaña(string idcampaña)
        {
            b.ExecuteCommandSP("MarketingCorreo_Seleccionar_PorIdCampaña");
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            m.MarketingCorreo resultado = new m.MarketingCorreo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.IdCampaña = int.Parse(reader["idcampaña"].ToString());
                resultado.Asunto = reader["asunto"].ToString();
                resultado.Cuerpo = reader["cuerpo"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(string idcampaña, string asunto, string cuerpo)
        {
            b.ExecuteCommandSP("MarketingCorreo_Agregar");
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            b.AddParameter("@asunto", asunto, SqlDbType.NVarChar, 200);
            b.AddParameter("@cuerpo", cuerpo, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        public int Modificar(string idcampaña, string asunto, string cuerpo)
        {
            b.ExecuteCommandSP("MarketingCorreo_Modificar ");
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            b.AddParameter("@asunto", asunto, SqlDbType.NVarChar, 200);
            b.AddParameter("@cuerpo", cuerpo, SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }
    }
}
