using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class PromocionProducto
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string FechaRegistro { get; set; }
        public decimal Precio { get; set; }
    }
}
