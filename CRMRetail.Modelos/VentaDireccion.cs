using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class VentaDireccion
    {
        public int IdVenta { get; set; }
        public int IdDireccion { get; set; }
        public int IdHorario { get; set; }
        public string FechaEntrega { get; set; }
    }
}
