using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class MarketingClientes
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.MarketingClientes> SeleccionarPorIdCampaña(int idcampaña)
        {
            b.ExecuteCommandSP("MarketingClientes_Seleccionar_PorIdCampaña");
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            List<m.MarketingClientes> resultado = new List<m.MarketingClientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.MarketingClientes item = new m.MarketingClientes();
                item.Clientes.Id = int.Parse(reader["id"].ToString());
                item.Clientes.Nombre = reader["nombre"].ToString();
                item.Clientes.Correo = reader["correo"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        
        public int Agregar(int idcliente, int idcampaña)
        {
            b.ExecuteCommandSP("MarketingClientes_Agregar");
            b.AddParameter("@idcliente", idcliente, SqlDbType.Int);
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int Modificar(m.MarketingClientes items)
        {
            b.ExecuteCommandSP("MarketingClientes_Modificar");
            b.AddParameter("@idcliente", items.IdCliente, SqlDbType.Int);
            b.AddParameter("@idcampaña", items.IdCampaña, SqlDbType.Int);
            b.AddParameter("@seguimiento", items.Seguimiento, SqlDbType.NVarChar, 500);
            b.AddParameter("@ingreso", items.Ingreso, SqlDbType.Int);
            b.AddParameter("@asistencia", items.Asistencia, SqlDbType.Bit);
            b.AddParameter("@confirmacion", items.Confirmacion, SqlDbType.Bit);
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int Eliminar(int idcampaña, string idcliente)
        {
            b.ExecuteCommandSP("MarketingClientes_Eliminar");
            b.AddParameter("@idcampaña", idcampaña, SqlDbType.Int);
            b.AddParameter("@idcliente", idcliente, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
