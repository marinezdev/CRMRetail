using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m = CRMRetail.Modelos;

namespace CRMRetail.Datos
{
    public static class Catalogos
    {
        /// <summary>
        /// Genera una consulta para llenar una lista proporcionando el nombre de la tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static List<m.Catalogos> Seleccionar(string tabla)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT id,nombre FROM {0} WHERE Activo=1 ORDER BY nombre", tabla);
            b.ExecuteCommandQuery(consulta);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public static List<m.Catalogos> SeleccionarEstado(string tabla)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT id,estado FROM {0} ORDER BY estado", tabla);
            b.ExecuteCommandQuery(consulta);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Estado = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Obtiene un listado de una tabla especificando una configuración
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="idconfiguracion"></param>
        /// <returns></returns>
        public static List<m.Catalogos> Seleccionar(string tabla, string idconfiguracion)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT id,nombre FROM {0} WHERE idconfiguracion={1} ORDER BY nombre", tabla, idconfiguracion);
            b.ExecuteCommandQuery(consulta);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Obtiene los datos de una tabla para llenar una lista
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="nombre">Nombre del campo nombre</param>
        /// <param name="id">Nombre del campo id</param>
        /// <returns></returns>
        public static List<m.Catalogos> Seleccionar(string tabla, string nombre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT {1}, {2} FROM {0} ORDER BY nombre", tabla, nombre, id);
            b.ExecuteCommandQuery(consulta);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos
                {
                    Id = int.Parse(reader[1].ToString()),
                    Nombre = reader[0].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Obtiene un registro de una fila de la consulta obtenida
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="idNombre">Nombre del campo Id</param>
        /// <param name="id">Valor numérico del campo id</param>
        /// <returns>Propiedad con los valores obtenidos</returns>
        public static m.Catalogos SeleccionarPorId(string tabla, string idNombre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE {1}=@id", tabla, idNombre);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            m.Catalogos resultado = new m.Catalogos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader[0].ToString());
                resultado.Nombre = reader[1].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        /// <summary>
        /// Obtiene registros de una tabla de sub si encuentra datos de la tabla padre
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<m.Catalogos> SeleccionarSubConsulta(string tabla, string campopadre, string id)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT * FROM {0} WHERE {1} = {2} ORDER BY nombre", tabla, campopadre, id);
            b.ExecuteCommandQuery(consulta);
            List<m.Catalogos> resultado = new List<m.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Catalogos item = new m.Catalogos
                {
                    Id = int.Parse(reader[0].ToString()),
                    Nombre = reader[1].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public static string SeleccionarNombrePorId(string id, string tabla)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("SELECT nombre FROM {0} WHERE id=@id", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.SelectString();
        }

        ///// <summary>
        ///// Guarda dos valores dos columnas sin especificación de identidad
        ///// </summary>
        ///// <param name="tabla">Nombre de la tabla</param>
        ///// <param name="columna1">Nombre de la columna 1</param>
        ///// <param name="columna2">Nombre de la columna 2</param>
        //public static void Guardar(string tabla, string valor1, string valor2)
        //{
        //    AccesoDatos b = new AccesoDatos();

        //    string consulta = string.Format("INSERT INTO {0} VALUES(@valor1, @valor2)", tabla);
        //    b.ExecuteCommandQuery(consulta);
        //    b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
        //    b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
        //    b.InsertUpdateDelete();
        //}

        /// <summary>
        /// Guarda un valor una columna con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="valor1">Valor para el campo 1</param>
        public static int Guardar(string tabla, string columna1, string valor1)
        {
            AccesoDatos b = new AccesoDatos();
            int valor2 = 1;
            string columna2 = "Activo";


            string consulta = string.Format("INSERT INTO {0} ({1}, {2}) VALUES(@valor1, @valor2)", tabla, columna1, columna2);
            b.ExecuteCommandQuery(consulta);

            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.Int);

            return b.InsertUpdateDelete();
        }


        public static int Eliminar(string tabla, int id)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("SP_EliminarArchivo");
            b.AddParameter("@id", id, SqlDbType.Int);
            b.AddParameter("@tabla", tabla, SqlDbType.NVarChar);

            // Ejecutar la operación de eliminación y obtener el resultado
            int resultado = b.InsertUpdateDelete();

            // Cerrar la conexión
            b.ConnectionCloseToTransaction();

            // Retornar el resultado
            return resultado;
        }


        public static void Guardar(string tabla, string columna1, string columna2, string valor1, string valor2)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("INSERT INTO {0} ({1}, {2}) VALUES(@valor1, @valor2)", tabla, columna1, columna2);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Guarda tres valores tres columnas con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="columna2">Nombre de la columna 2</param>
        /// <param name="columna3">Nombre de la columna 3</param>
        /// <param name="valor1">Valor para el campo 1</param>
        /// <param name="valor2">Valor para el campo 2</param>
        /// <param name="valor3">Valor para el campo 3</param>
        public static void Guardar(string tabla, string columna1, string columna2, string columna3, string valor1, string valor2, string valor3)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("INSERT INTO {0} ({1}, {2}, {3}) VALUES(@valor1, @valor2, @valor3)", tabla, columna1, columna2, columna3);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.AddParameter("@valor3", valor3, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        public static void ModificarNombre(string tabla, string valor1, string valor2)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET Nombre=@valor2 WHERE id=@valor1", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con dos valores, uno para un valor, otro para un id
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="columnaid"></param>
        /// <param name="valorcolumnaid"></param>
        /// <param name="columnanombre"></param>
        public static void Modificar(string tabla, string columna1, string valor1, string valor2)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET Nombre=@valor2 WHERE {1}=@valor1", tabla, columna1);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con tres valores, dos para dos campos, uno para Id
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre del campo Id</param>
        /// <param name="valor1">Valor del campo Id</param>
        /// <param name="columna2">Nombre de la columna2</param>
        /// <param name="valor2">Valor de la columma2</param>
        /// <param name="columna3">Nombre de la columna3</param>
        /// <param name="valor3">Valor de la columna 3</param>
        public static void Modificar(string tabla, string columna1, string valor1, string columna2, string valor2, string columna3, string valor3)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET {2}=@valor2, {3}=@valor3 WHERE {1}=@valor1", tabla, columna1, columna2, columna3);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.AddParameter("@valor3", valor3, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con tres valores, dos para campos, uno para Id
        /// </summary>
        /// <param name="prms">Todos los parámetros (cuidar el orden): nombre de la tabla, nombre del campo id, valor del campo id, nombre columna 2, valor columna 2
        /// nombre columna 3, valor columna 3</param>
        public static void Modificar(params string[] prms)
        {
            AccesoDatos b = new AccesoDatos();

            string consulta = string.Format("UPDATE {0} SET {2}=@valor2, {3}=@valor3 WHERE {1}=@valor1", prms[0], prms[1], prms[3], prms[5]);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", prms[2], SqlDbType.NVarChar);
            b.AddParameter("@valor2", prms[4], SqlDbType.NVarChar);
            b.AddParameter("@valor3", prms[6], SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        //Obtener los clientes por nombre
        public static List<m.Clientes> SeleccionarClientesPorNombre()
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("Clientes_Seleccionar_PorNombre_Compuesto");
            List<m.Clientes> resultado = new List<m.Clientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Clientes item = new m.Clientes()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //Obtener los productos por nombre
        public static List<m.Productos> SeleccionarProductosPorNombre()
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("Productos_Seleccionar_PorNombre_Compuesto");
            List<m.Productos> resultado = new List<m.Productos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Productos item = new m.Productos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        //Obtener los vendedores
        public static List<m.Usuarios> SeleccionarVendedores()
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("Usuarios_Seleccionar_Vendedores");
            List<m.Usuarios> resultado = new List<m.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Usuarios item = new m.Usuarios()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
