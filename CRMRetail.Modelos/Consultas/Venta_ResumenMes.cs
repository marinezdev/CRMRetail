using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos.Consultas
{
    public class Venta_ResumenMes
    {
        public int Ventas { get; set; }
        public decimal Total { get; set; }
        public decimal Coyoacan { get; set; }
        public decimal Esmeralda { get; set; }
        public decimal SubDistribuidores { get; set; }
    }
}
