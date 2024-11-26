using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRetail.Datos.Tablas
{
    public abstract class ImplementacionInicial
    {
        public abstract string Implementacion1();
    }

    /// <summary>
    /// Accesible pero no sus métodos, éstos sólo por herencia
    /// </summary>
    public class ClaseAnidada : ImplementacionInicial
    {
        /// <summary>
        /// Se heredó de una clase abstracta, se exige su implementación
        /// </summary>
        /// <returns></returns>
        public override string Implementacion1()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método 1 protected de la Clase Anidada
        /// </summary>
        /// <returns></returns>
        protected string Metodo1()
        {
            return "Soy el método 1";
        }

        /// <summary>
        /// Método 2 protected de la clase ClaseAnidada
        /// </summary>
        /// <returns></returns>
        protected string Metodo2()
        {
            return "Soy el método 2";
        }

        /// <summary>
        /// Accesible por instanciación, sus métodos son públicos
        /// y accesan una clase pública con métodos protected
        /// sólo accesables por herencia
        /// </summary>
        public class Anidada1 : ClaseAnidada
        {
            /// <summary>
            /// Metodo 1 de la clase Anidada1
            /// </summary>
            /// <returns></returns>
            public string AccesoMetodo1()
            {
                return Metodo1();
            }

            /// <summary>
            /// Metodo 2 de la clase Anidada1
            /// </summary>
            /// <returns></returns>
            public string AccesoMetodo2()
            {
                return Metodo2();
            }

            /// <summary>
            /// Método 3 desde la clase Anidada2
            /// </summary>
            /// <returns></returns>
            public string AccesoMetodo3()
            {
                Anidada2 a2 = new Anidada2();
                return a2.Metodo3();
            }

            /// <summary>
            /// Método 5 desde la clase Anidada3
            /// </summary>
            /// <returns></returns>
            public string AccesoMetodo5()
            {
                Anidada3 a3 = new Anidada3();
                return a3.Metodo5() + " " + a3.Metodo7();
            }
        }

        /// <summary>
        /// No accesible, sólo por instancia
        /// </summary>
        internal sealed class Anidada2
        {
            internal string Metodo3()
            {
                return "Soy el método 3 de la clase Anidada2 ";
            }

            internal string Metodo4()
            {
                return "Soy el método 4 de la clase Anidada2";
            }
        }

        //Clase privada dentro de ClaseAnidada
        class Anidada3
        {
            public string Metodo5()
            {
                return "Soy el metodo 5 de la clase Anidada 3";
            }

            string Metodo6()
            {
                return "Soy el metodo 6 de la clase Anidada 3";
            }

            public string Metodo7()
            {
                return Metodo6();
            }
        }
    }

    public class ClaseAnidada4
    {
        protected string Metodo8()
        {
            return "Soy el método 8 de la ClaseAnidada4";
        }

        public class ClaseAnidada5 : ClaseAnidada4
        {
            /// <summary>
            /// De la ClaseAnidada4 se hereda el método protectd 8
            /// </summary>
            /// <returns></returns>
            public string Metodo_8()
            {
                return Metodo8();
            }
        }
    }

    /// <summary>
    /// Contenedor para accesar las clases publicas vía herencia o instancia hacia otro proyecto
    /// </summary>
    public class ClaseAnidada5
    {
        public ClaseAnidada.Anidada1 ca1;
        public ClaseAnidada4.ClaseAnidada5 ca4ca5;

        public ClaseAnidada5()
        {
            ca1 = new ClaseAnidada.Anidada1();
            ca4ca5 = new ClaseAnidada4.ClaseAnidada5();
        }
    }
}
