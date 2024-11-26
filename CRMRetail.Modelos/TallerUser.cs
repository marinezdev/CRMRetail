using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class TallerUser
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Fecha { get; set; }
        public string Taller { get; set; }
        public int Activo { get; set; }

    }
}
