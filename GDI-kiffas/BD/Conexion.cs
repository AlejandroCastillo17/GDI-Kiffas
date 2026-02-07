using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using GDI_kiffas.Logica;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace GDI_kiffas.BD
{
    public class Conexion
    {

        private static string cadenaConexion = "server=localhost; database=Kiffas; user=root; password=Alejo123-;";
        //private static string cadenaConexion = "server=192.168.1.8; database=Dorichips; user=tomas; password=1234;";
        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }


        public static List<Productos> ObtenerProductos()
        {
            List<Productos> listaProductos = new List<Productos>();

            using (MySqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT id, nombre, codigo_barras, precio_unitario, Costo_lote, cantidad_actual, foto, fecha FROM productos";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Productos producto = new Productos
                            {
                                id = reader.GetInt32("id"),
                                nombre = reader.GetString("nombre"),
                                codigobarras = reader.GetString("codigo_barras"),
                                preciouni = reader.GetDecimal("precio_unitario"),
                                costo = reader.GetDecimal("Costo_lote"),
                                cantidad_actual = reader.GetDecimal("cantidad_actual"),
                                foto = reader["foto"] != DBNull.Value ? (byte[])reader["foto"] : null,
                                fecha = reader.GetDateTime("fecha")
                            };
                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            return listaProductos;
        }

        public static Productos ObtenerPorCodigoBarras(long codigo)
        {
            using var conn = ObtenerConexion();
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
              SELECT id, nombre, precio_unitario, cantidad_actual, foto
              FROM productos
              WHERE codigo_barras = @cb
              LIMIT 1;
            ";
            cmd.Parameters.AddWithValue("@cb", codigo);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new Productos
            {
                id = r.GetInt32("id"),
                nombre = r.GetString("nombre"),
                preciouni = r.GetDecimal("precio_unitario"),
                cantidad_actual = r.GetDecimal("cantidad_actual"),
                foto = r["foto"] is DBNull ? null : (byte[])r["foto"]
            };
        }


        public static bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    Console.WriteLine("Conexión exitosa.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
                return false;
            }
        }

    }
}
