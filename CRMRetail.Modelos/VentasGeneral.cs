using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class VentasGeneral
    {
        public Clientes Clientes { get; set; }
        public Productos Productos { get; set; }
        public Ventas Ventas { get; set; }
        public VentasProductos VentasProductos { get; set; }

        public Usuarios Usuarios { get; set; }
        public VentasGeneral()
        {
            Clientes = new Clientes();
            Productos = new Productos();
            Ventas = new Ventas();
            VentasProductos = new VentasProductos();
            Usuarios = new Usuarios();
        }
    }
}
