using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class UsuariosRoles
    {
        public Roles Roles { get; set; }
        public Usuarios Usuarios { get; set; }

        public UsuariosRoles()
        {
            Roles = new Roles();
            Usuarios = new Usuarios();
        }
    }
}
