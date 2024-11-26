using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioDistribuidor { get; set; }
        public decimal PrecioPublico { get; set; }
        public decimal PrecioDemo { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public bool Activo { get; set; }

        //  PROMOCION 
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal Precio { get; set; }


        ///TALLERES
        public string Fecha { get; set; }
        public int IdVenta { get; set; }

    }
}
