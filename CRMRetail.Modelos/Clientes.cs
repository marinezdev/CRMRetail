using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RFC { get; set; }
        public string DireccionFiscal {  get; set; }
        public string DireccionEntrega { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Tipo { get; set; }
        public int Origen { get; set; }
        public DateTime Alta { get; set; }
        public string Correo { get; set; }
        public int FisicaMoral { get; set; }
    }
}
