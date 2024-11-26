using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos.Consultas
{
    public class Venta_TOP
    {
        public int Id { get; set; }
        public string FechaRegistro { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
        public string Sucursal { get; set; }
        public string Estatus { get; set; }
    }
}
