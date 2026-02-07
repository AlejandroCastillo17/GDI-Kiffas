using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDI_kiffas.Logica;
using GDI_kiffas.BD;
using MySql.Data.MySqlClient;

namespace GDI_kiffas.BD
{
    internal class ProductosBD
    {
        public static bool GuardarProducto(Productos producto)
        {
            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "INSERT INTO productos (nombre, codigo_barras, precio_unitario, Costo_lote, cantidad_inicial, cantidad_actual, foto, fecha) VALUES (@nombre, @codigo_barras, @precio_unitario, @Costo_lote, @cantidad_inicial, @cantidad_actual, @foto, @fecha)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                        cmd.Parameters.AddWithValue("@codigo_barras", producto.codigobarras);
                        cmd.Parameters.AddWithValue("@precio_unitario", producto.preciouni);
                        cmd.Parameters.AddWithValue("@Costo_lote", producto.costo);
                        cmd.Parameters.AddWithValue("@cantidad_inicial", producto.cantidad_inicial);
                        cmd.Parameters.AddWithValue("@cantidad_actual", producto.cantidad_actual);

                        // Convertir la imagen a bytes
                        cmd.Parameters.AddWithValue("@foto", (object)producto.foto ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@fecha", producto.fecha);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el producto: " + ex.Message);
                return false;
            }
        }

        public static void EliminarProducto(int idProducto)
        {

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "DELETE FROM productos WHERE id = @id";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idProducto);
                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
