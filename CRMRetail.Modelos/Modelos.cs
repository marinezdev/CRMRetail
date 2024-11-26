using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Modelos
    {
        public Cliente Cliente { get; set; }
        public Direccion Direccion { get; set; }

        public Venta Venta { get; set; }

        public Producto Producto { get; set; }

        public VentaProducto VentaProducto { get; set; }

        public Modelos()
        {
            Cliente = new Cliente();
            Direccion = new Direccion();

            Venta = new Venta();
            Producto = new Producto();
            VentaProducto = new VentaProducto();
        }
    }
}
