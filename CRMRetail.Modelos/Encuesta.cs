using System;
namespace CRMRetail.Modelos
{
	public class Encuesta
	{
        public int Id { get; set; }
        public string Nombre { get; set; }

        //////////DATA Question/////////////////////////
         public int IdVenta { get; set; }
        public int Q1 { get; set; }
        public int Q2 { get; set; }
        public int Q3 { get; set; }
        public int Q4 { get; set; }
        public int Q5 { get; set; }
        public int Q6 { get; set; }
        public string Q4t { get; set; }
        public string Q5t { get; set; }
    }
}

