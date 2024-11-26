using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class NuevoArticuloImg
    {
        public ArticuloImg ArticuloImg { get; set; }
    }
    public class ArticuloImg
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdArchivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Activo { get; set; }
    }
}
