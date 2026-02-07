using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GDI_kiffas.Logica;

namespace GDI_kiffas.BD
{
    internal class VentasBD
    {
        public static bool GuardarVenta(List<Ventas> ventas)
        {
            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    foreach (var item in ventas)
                    {
                        string query = "INSERT INTO ventas (id_pedido, producto, cantidad, precio, fecha, mesa) VALUES (@id_pedido, @producto, @cantidad, @precio, @fecha, @mesa)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id_pedido", item.id_pedido);
                            cmd.Parameters.AddWithValue("@producto", item.producto);
                            cmd.Parameters.AddWithValue("@cantidad", item.cantidad);
                            cmd.Parameters.AddWithValue("@precio", item.precio);
                            cmd.Parameters.AddWithValue("@fecha", item.fecha);
                            cmd.Parameters.AddWithValue("@mesa", item.mesa);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la venta: " + ex.Message);
                return false;
            }
        }

        public static void RegistrarVentaTurno(int idTurno, string producto, int cantidad, decimal ingreso, int id_pedido)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO ventas_turno (id_turno, producto, cantidad, ingreso, hora, id_pedido) VALUES (@id_turno, @producto, @cantidad, @ingreso, NOW(), @id_pedido)", conn);
                cmd.Parameters.AddWithValue("@id_turno", idTurno);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@ingreso", ingreso);
                cmd.Parameters.AddWithValue("@id_pedido", id_pedido);
                cmd.ExecuteNonQuery();
            }

        }

    }
}
