using System;
using System.Collections.Generic;
using System.Data;
using m = CRMRetail.Modelos;


namespace CRMRetail.Datos.Tablas
{
    public class Encuesta
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        public List<m.Encuesta> List_Cat_q1_t1()
        {
            b.ExecuteCommandSP("List_Cat_q1_t1");
            List<m.Encuesta> resultado = new List<m.Encuesta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Encuesta item = new m.Encuesta()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Encuesta> List_Cat_q3_t1()
        {
            b.ExecuteCommandSP("List_Cat_q3_t1");
            List<m.Encuesta> resultado = new List<m.Encuesta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Encuesta item = new m.Encuesta()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        public List<m.Encuesta> List_Cat_q2_t1()
        {
            b.ExecuteCommandSP("List_Cat_q2_t1");
            List<m.Encuesta> resultado = new List<m.Encuesta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Encuesta item = new m.Encuesta()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
        public List<m.Encuesta> List_Cat_q1_t2()
        {
            b.ExecuteCommandSP("List_Cat_q1_t2");
            List<m.Encuesta> resultado = new List<m.Encuesta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Encuesta item = new m.Encuesta()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<m.Venta> List_venta(m.Venta venta)
        {
            b.ExecuteCommandSP("InfoCompraProductos");
            b.AddParameter("@Id ", venta.Id, SqlDbType.Int);

            List<m.Venta> resultado = new List<m.Venta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                m.Venta item = new m.Venta()
                {
                    Cantidad = int.Parse(reader["Cantidad"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    SKU = reader["SKU"].ToString(),
                    Descripcion = reader["Descripcion"].ToString()

                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public m.Cliente InfoUsuario(m.Cliente cliente)
        {
            b.ExecuteCommandSP("InfoUsuario");
            b.AddParameter("@Id ", cliente.Id, SqlDbType.Int);

            m.Cliente resultado = new m.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.TelefonoMovil = reader["TelefonoMovil"].ToString();
                resultado.Calle = reader["Direccion"].ToString();
                resultado.Correo = reader["Correo"].ToString();
                resultado.CP = reader["CP"].ToString();
                resultado.FechaNacimiento = reader["Fecha"].ToString();
            }
            reader = null;

            b.CloseConnection();
            return resultado;
        }

        public m.Encuesta InsertFormatoEntrega(m.Encuesta encuesta)
        {
            b.ExecuteCommandSP("InsertFormatoEntrega");
            b.AddParameter("@IdVenta", encuesta.IdVenta, SqlDbType.Int);
            b.AddParameter("@Q1", encuesta.Q1, SqlDbType.Int);
            b.AddParameter("@Q2", encuesta.Q2, SqlDbType.Int);
            b.AddParameter("@Q3", encuesta.Q3, SqlDbType.Int);
            b.AddParameter("@Q4", encuesta.Q4, SqlDbType.Int);
            b.AddParameter("@Q5", encuesta.Q5, SqlDbType.Int);
            m.Encuesta resultado = new m.Encuesta();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;

            b.CloseConnection();
            return resultado;
        }


        public m.Encuesta InsertEncuestaWeber(m.Encuesta encuesta)
        {
            b.ExecuteCommandSP("InsertEncuestaWeber");
            b.AddParameter("@IdVenta", encuesta.IdVenta, SqlDbType.Int);
            b.AddParameter("@Q1", encuesta.Q1, SqlDbType.Int);
            b.AddParameter("@Q2", encuesta.Q2, SqlDbType.Int);
            b.AddParameter("@Q3", encuesta.Q3, SqlDbType.Int);

            b.AddParameter("@Q4", encuesta.Q4t, SqlDbType.NVarChar);
            b.AddParameter("@Q5", encuesta.Q5t, SqlDbType.NVarChar);

            b.AddParameter("@Q6", encuesta.Q6, SqlDbType.Int);

            m.Encuesta resultado = new m.Encuesta();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;

            b.CloseConnection();
            return resultado;
        }
    }
}

