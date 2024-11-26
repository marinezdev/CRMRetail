using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Modelos
{
    public class Marketing
    {
		public int Id { get; set; }
		public string Clave { get; set; }
		public string Nombre { get; set; }
		public DateTime Inicio { get; set; }
		public DateTime Fin { get; set; }
		public DateTime Registro { get; set; }
		public string Objetivo { get; set; }
		public int Estado { get; set; }
		public int Usuario { get; set; }
		public int Correo { get; set; }
		public int Facebook { get; set; }
		public int Linkedin { get; set; }
		public int Llamada { get; set; }
		public int PaginaASAE { get; set; }
		public DateTime Envios { get; set; }
		public DateTime InicioEvento { get; set; }
		public DateTime FinEvento { get; set; }
		public string HoraInicio { get; set; }
		public string HoraFin { get; set; }
		public string Ubicacion { get; set; }
		public string Descripcion { get; set; }
	}
}
