using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos.Tablas
{
    public class Control_Archivos
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();
        public m.Control_Archivos NuevoArchivo()
        {
            b.ExecuteCommandSP("Control_Archivos_Id");

            m.Control_Archivos resultado = new m.Control_Archivos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
