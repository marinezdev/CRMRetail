using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class VentasProductos
    {
        public int IdVenta { get; set; }
        public Productos Productos { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public VentasProductos()
        {
            Productos = new Productos();
        }
    }
}
