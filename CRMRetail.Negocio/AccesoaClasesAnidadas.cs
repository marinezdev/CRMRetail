using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Negocio
{

    /// <summary>
    /// Acceso a métodos desde otros proyectos
    /// </summary>
    public class AccesoaClasesAnidadas 
    {       
        /// <summary>
        /// Acceso a las clases por instancia
        /// </summary>
        /// <returns></returns>
        public string Metodo1()
        {
            Datos.Tablas.ClaseAnidada ca = new Datos.Tablas.ClaseAnidada(); //Accesible pero sus metodos no por ser protected

            Datos.Tablas.ClaseAnidada.Anidada1 ca1 = new Datos.Tablas.ClaseAnidada.Anidada1();
            ca1.AccesoMetodo1(); //--+
                                 //  +--Ambos vienen de una clase publica, pero los métodos son protected, heredados
            ca1.AccesoMetodo2(); //--+

            ca1.AccesoMetodo3(); //Viene de una clase publica, pero su metodo esta instanciado dentro de éste método, la clase es internal y sus metodos tambien

            ca1.AccesoMetodo5(); //Se unen dos métodos de esta clase privada para unirse en uno, ambos públicos, pero uno es privado y no se puede accesar

            //La clase Anidada2 no es accesible al ser internal sealed
            //sólo accesible en el proyecto en el que se creó            

            //La clase Anidada3 ni siquiera es accesible de ninguna forma por ser privada, sólo en el proyecto
            //en el que se creó

            Datos.Tablas.ClaseAnidada4 ca4 = new Datos.Tablas.ClaseAnidada4();
            //ca4. //Sin acceso a métodos (sólo tiene uno protected)
            
            Datos.Tablas.ClaseAnidada4.ClaseAnidada5 ca4ca5 = new Datos.Tablas.ClaseAnidada4.ClaseAnidada5();
            ca4ca5.Metodo_8();

            

            return "";
        }
    } 
    
    /// <summary>
    /// Se pueden accesar métodos protected de una clase pública pero sólo por herencia de otro proyecto
    /// </summary>
    public class AccesoaClasesAnidadas2 : Datos.Tablas.ClaseAnidada
    {
        Datos.Tablas.ClaseAnidada ca = new Datos.Tablas.ClaseAnidada(); //Instancia a la clase para intentar accesar los métodos (de otro proyecto)

        public string aaa()
        {
            //ca. //Se intenta accesar algún método por instanciación, pero como son protected, no son accesibles
            return Metodo1(); //Aquí se pudo accesar directo porque se heredó desde la clase
        }
    }

    public class AccesoaClasesAnidadas3 : Datos.Tablas.ClaseAnidada5
    {
        //Acceso a las clases publicas que heredan metodos protected de otro proyecto
        Datos.Tablas.ClaseAnidada5 ca5 = new Datos.Tablas.ClaseAnidada5(); 
        public string Cualquiera()
        {
            ca1.AccesoMetodo1();        //Por herencia
            ca4ca5.Metodo_8();          //Por herencia
            ca5.ca1.AccesoMetodo1();    //Por instancia
            ca5.ca4ca5.Metodo_8();      //Por instancia

            return null;
        }
    }

    public class AccesoaClasesAnidadas4
    {
        //Se crea una instancia a la clase y se accesan metodos porque están en el mismo proyecto
        AccesoaClasesAnidadas3 aca3 = new AccesoaClasesAnidadas3();
        public void ProcesoLocal()
        {
            aca3.ca1.AccesoMetodo1();   //------+
            aca3.ca4ca5.Metodo_8();     //      + Accesados por instanciación
            aca3.Cualquiera();          //------+
        }

    }
}
