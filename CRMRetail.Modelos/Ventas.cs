using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Ventas
    {
        public int Id { get; set; }
        public Clientes Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int Tipo { get; set; }
        public int Vendedor { get; set; }
        public int TipoEntrega { get; set; }
        public int TarjetaCredito {get; set; }
        public DateTime FechaEntrega { get; set; }
        public string HoraEntrega { get; set; }
        public decimal Monto { get; set; }
        public Usuarios Usuarios { get; set; }
        public int BackOrder { get; set; }
        public int Estado { get; set; }
        public Ventas()
        {
            Clientes = new Clientes();
            Usuarios = new Usuarios();
        }
    }
}
