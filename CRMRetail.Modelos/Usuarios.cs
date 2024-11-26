using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public int Empresa { get; set; }
        public DateTime Alta { get; set; }
    }
}
