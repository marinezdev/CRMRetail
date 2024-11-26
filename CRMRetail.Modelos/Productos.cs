using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public decimal PrecioPublico { get; set; }
        public decimal PrecioDistribuidor { get; set; }
        public string Imagen { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public decimal OtroPrecio1 { get; set; }
        public decimal OtroPrecio2 { get; set; }
        public decimal OtroPrecio3 { get; set; }

        //Campos extras para agregado de información
        public int TarjetaCredito { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string HoraEntrega { get; set; }

    }
}
