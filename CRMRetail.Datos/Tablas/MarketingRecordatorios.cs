using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class MarketingRecordatorios
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.MarketingRecordatorios> SeleccionarPorIdCampaña(string idcampaña)
        {
            b.ExecuteCommandSP("MarketingRecordatorios_Seleccionar_PorIdCampaña");
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            List<m.MarketingRecordatorios> resultado = new List<m.MarketingRecordatorios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.MarketingRecordatorios item = new m.MarketingRecordatorios();
                item.Id = int.Parse(reader["id"].ToString());
                item.IdCampaña = int.Parse(reader["idcampaña"].ToString());
                item.Asunto = reader["asunto"].ToString();
                item.Cuerpo = reader["cuerpo"].ToString();
                item.Envio = DateTime.Parse(reader["fechaenvio"].ToString());
                item.EnviarA = int.Parse(reader["enviara"].ToString());
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.MarketingRecordatorios SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("MarketingRecordatorios_Seleccionar_PorId");
            b.AddParameter("@id", id, SqlDbType.Int);
            m.MarketingRecordatorios resultado = new m.MarketingRecordatorios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.IdCampaña = int.Parse(reader["idcampaña"].ToString());
                resultado.Asunto = reader["asunto"].ToString();
                resultado.Cuerpo = reader["cuerpo"].ToString();
                resultado.Envio = DateTime.Parse(reader["fechaenvio"].ToString());
                resultado.EnviarA = int.Parse(reader["enviara"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public int Agregar(m.MarketingRecordatorios items)
        {
            b.ExecuteCommandSP("MarketingRecordatorios_Agregar");            
            b.AddParameter("@idcampaña", items.IdCampaña, SqlDbType.Int);
            b.AddParameter("@asunto", items.Asunto, SqlDbType.NVarChar, 150);
            b.AddParameter("@cuerpo", items.Cuerpo, SqlDbType.NVarChar, 4000);
            b.AddParameter("@fechaenvio", items.Envio, SqlDbType.DateTime);
            b.AddParameter("@enviara", items.EnviarA, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        public int Modificar(m.MarketingRecordatorios items)
        {
            b.ExecuteCommandSP("MarketingRecordatorios_Modificar");
            b.AddParameter("@asunto", items.Asunto, SqlDbType.NVarChar, 150);
            b.AddParameter("@cuerpo", items.Cuerpo, SqlDbType.NVarChar);
            b.AddParameter("@fechaenvio", items.Envio, SqlDbType.DateTime);
            b.AddParameter("@enviara", items.EnviarA, SqlDbType.Int);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
