using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos.Consultas
{
    public class Venta_PorMes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ayer { get; set; }
        public decimal hoy { get; set; }

        public string Dia { get; set; }
        public decimal TotalC { get; set; }
        public decimal TotalE { get; set; }
        public decimal TotalS { get; set; }
    }
}
