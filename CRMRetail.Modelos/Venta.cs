using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public int IdFormaPago { get; set; }
        public int IdTarjeta { get; set; }
        public int IdTipoEntrega { get; set; }
        public int IdEstatus { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        //Procesar info de venta
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }

        public string Fecha { get; set; }
        public string Sucursal { get; set; }
        public string Entrega { get; set; }

    }
}
