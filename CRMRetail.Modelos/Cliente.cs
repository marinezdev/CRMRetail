using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Cliente
    {
        
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdDireccion { get; set; } //Direcciones asociadas
        public int IdDireccion2 { get; set; } //Direcciones asociadas
        public int TipoPersona { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }


        //control cumpleaños
        public string MesCumple { get; set; }
        public string DiaCumple { get; set; }
        public string FechaRegistro { get; set; }


        public string FechaConstitucion { get; set; }
        public string RFC { get; set; }
        public string Correo { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoLocal { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdOrigenCliente { get; set; }
        public int IdSucursal { get; set; }

        public bool Activo { get; set; }

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


        public int FiscalEntrega { get; set; }

        public string Resultado { get; set; }


        public string TipoCliente { get; set; }
        public string OrigenCliente { get; set; }
        public int Flag { get; set; }

    }
}
