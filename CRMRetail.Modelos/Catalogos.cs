using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Catalogos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Estado { get; set; }
    }

    public class CoinsultaCatalogos
    {
        public Catalogos Catalogos { get; set; }
    }
}
