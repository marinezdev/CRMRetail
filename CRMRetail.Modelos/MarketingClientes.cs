using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class MarketingClientes
    {
   		public int Id { get; set; }
		public int IdCliente { get; set; }
		public int IdCampaña { get; set; }
		public string Seguimiento { get; set; }
		public int Ingreso { get; set; }
		public bool Asistencia { get; set; }
		public bool Confirmacion { get; set; }

		public Clientes Clientes { get; set; }

		public MarketingClientes()
        {
			Clientes = new Clientes();
        }

	}
}
