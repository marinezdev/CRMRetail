using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class MarketingCorreo
    {
		public int Id { get; set; }
		public int IdCampaña { get; set; }
		public string Asunto { get; set; }
		public string Cuerpo { get; set; }

	}
}
