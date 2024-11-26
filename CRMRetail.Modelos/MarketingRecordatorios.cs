using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class MarketingRecordatorios
    {
        public int Id { get; set; }
        public int IdCampaña { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public DateTime Envio { get; set; }
        public int EnviarA { get; set; }
    }
}
