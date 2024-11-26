using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Menu
    {
        public int Id { get; set; }
        public string IdJQuery { get; set; }
        public string Ruta { get; set; }
        public string Icono { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

    }
}
