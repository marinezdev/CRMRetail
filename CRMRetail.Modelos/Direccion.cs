using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Direccion
    {
        public int Id { get; set; }
        public int IdDireccion { get; set; } //Para no confundir con el id del cliente
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdPoblacion { get; set; }
        public string Poblacion { get; set; }
        public int IdColonia { get; set; }
        public string Colonia { get; set; }
        public int IdCP { get; set; }
        public string CP { get; set; }

        public string NumExterior { get; set; }
        public string NumInterior { get; set; }
        public string Calle { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }
        public int FiscalEntrega { get; set; }
        public int Flag { get; set; }

        public int IdCliente { get; set; }
        public int Select { get; set; }

        //******* DIRECCION 2
        public int Id2 { get; set; }
        public int IdDireccion2 { get; set; } //Para no confundir con el id del cliente
        public int IdEstado2 { get; set; }
        public string Estado2 { get; set; }
        public int IdPoblacion2 { get; set; }
        public string Poblacion2 { get; set; }
        public int IdColonia2 { get; set; }
        public string Colonia2 { get; set; }
        public int IdCP2 { get; set; }
        public string CP2 { get; set; }

        public string NumExterior2 { get; set; }
        public string NumInterior2 { get; set; }
        public string Calle2 { get; set; }
        public string EntreCalles2 { get; set; }
        public string Referencias2 { get; set; }
        public int FiscalEntrega2 { get; set; }
        public int Flag2 { get; set; }

        public int IdCliente2 { get; set; }


    }
}
