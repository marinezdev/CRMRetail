using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos.Consultas
{
    public class ReporteVentas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal VentasXMes { get; set; }
    }
}
