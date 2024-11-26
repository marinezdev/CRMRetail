using System;
using System.Collections.Generic;
using m=CRMRetail.Modelos;
namespace CRMRetail.Modelos
{
    public class NuevoProductoVenta
    {
      
        public int IdProducto { get; set; }
        public object Producto { get; set; }
        public int Cantidad { get; set; }
        public List<m.Catalogos> CatPrecios { get; set; }
        public int IdCatPrecios { get; set; }
        public decimal Precio { get; set; }
        public int BackOrder { get; set; }
	}
}

