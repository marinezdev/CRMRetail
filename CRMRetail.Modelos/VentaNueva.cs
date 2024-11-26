using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class VentaNueva
    {
        // METODO DE PAGO.
        public string FechaVenta { get; set; }
        public int IdVendedor { get; set; }
        public int IdSucursal { get; set; }
        public int IdFormaPago { get; set; }
        public int IdFormaPagoTarjeta { get; set; }

        // REGISTRO DE UN NUEVO CLIENTE
        public int NuevoCliente { get; set; }
        public int IdCliente { get; set; }
        public string Correo { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoLocal { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdOrigenCliente { get; set; }

        public int TipoPersona { get; set; }

        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaConstitucion { get; set; }
        public string RFC { get; set; }


        // METODO DE ENVIO.
        public int IdTipoEntrega { get; set; }
        public string FechaEntrega { get; set; }
        public int IdHorario { get; set; }


        public int DireccionFiscal { get; set; }
        public int IdEstado { get; set; }
        public int IdPoblacion { get; set; }
        public string Colonia { get; set; }
        public int IdCP { get; set; }
        public string NumExterior { get; set; }
        public string NumInterior { get; set; }
        public string Calle { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }


        public int DireccionEntrega { get; set; }
        public int IdEstado2 { get; set; }
        public int IdPoblacion2 { get; set; }
        public string Colonia2 { get; set; }
        public int IdCP2 { get; set; }
        public string NumExterior2 { get; set; }
        public string NumInterior2 { get; set; }
        public string Calle2 { get; set; }
        public string EntreCalles2 { get; set; }
        public string Referencias2 { get; set; }
    }
}
