using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDI_kiffas.BD;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace GDI_kiffas.Interfaz
{
    public partial class Devoluciones : Form
    {
        public Devoluciones()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;
        }

        //****************************************************************************************

        // Logica

        private void Devoluciones_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarVentas();
        }

        private void ConfigurarGrid()
        {
            dgvVentas.Columns.Clear();
            dgvVentas.AutoGenerateColumns = false;

            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.EnableHeadersVisualStyles = false;
            dgvVentas.ScrollBars = ScrollBars.Vertical;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvVentas.CurrentCell = null;
            dgvVentas.MultiSelect = false;
            dgvVentas.ColumnHeadersVisible = true;
            dgvVentas.ColumnHeadersHeight = 40;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AllowUserToResizeColumns = false;
            dgvVentas.AllowUserToResizeRows = false;

            dgvVentas.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvVentas.GridColor = Color.Black;
            dgvVentas.BorderStyle = BorderStyle.FixedSingle;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            dgvVentas.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgvVentas.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 16, FontStyle.Bold),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgvVentas.RowTemplate.Height = 100;

            // ======== Agregar columnas manualmente =========

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Productos",
                DataPropertyName = "Productos",
                HeaderText = "Productos",
                Width = 320
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CostoTotal",
                DataPropertyName = "Costo Total",
                HeaderText = "Costo",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaHora",
                DataPropertyName = "Fecha y Hora",
                HeaderText = "Fecha y Hora",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // ===== Botón Revertir =====

            DataGridViewButtonColumn btnRevertir = new DataGridViewButtonColumn
            {
                Name = "Revertir",
                HeaderText = "",
                Text = "↩ Revertir",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                Width = 120
            };
            btnRevertir.DefaultCellStyle.BackColor = Color.OrangeRed;
            btnRevertir.DefaultCellStyle.ForeColor = Color.White;

            dgvVentas.Columns.Add(btnRevertir);

            dgvVentas.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == dgvVentas.Columns["Revertir"].Index && e.RowIndex >= 0)
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.OrangeRed;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            };

            dgvVentas.CellClick += dgvVentas_CellClick;

            // Cambiar tamaño de fuente de la columna "Productos"
            dgvVentas.Columns["Productos"].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Ajustar contenido de texto automáticamente al tamaño de la celda
            dgvVentas.Columns["Productos"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void CargarVentas()
        {
            dgvVentas.DataSource = ObtenerResumenVentas();
        }

        public DataTable ObtenerResumenVentas()
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        id_pedido,
                        GROUP_CONCAT(CONCAT(cantidad, ' x ', producto) SEPARATOR ', ') AS Productos,
                        SUM(precio) AS 'Costo Total',
                        MAX(CONCAT(fecha, ' ', LPAD(HOUR(NOW()), 2, '0'), ':', LPAD(MINUTE(NOW()), 2, '0'))) AS 'Fecha y Hora'
                    FROM ventas
                    GROUP BY id_pedido
                    ORDER BY id_pedido DESC;
                ";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ValidarCodigoAcceso()) return;
            if (e.RowIndex >= 0 && dgvVentas.Columns[e.ColumnIndex].Name == "Revertir")
            {
                // Obtener el DataRowView vinculado a la fila
                var row = (DataRowView)dgvVentas.Rows[e.RowIndex].DataBoundItem;

                // Extraer id_pedido
                int idPedido = Convert.ToInt32(row["id_pedido"]);

                var confirmar = MessageBox.Show(
                    $"¿Estás seguro de revertir el pedido #{idPedido}?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    DevolverPedido(idPedido); // Aquí va tu lógica para revertir el pedido
                    CargarVentas(); // Recargar lista tras revertir
                }
            }
        }

        private bool ValidarCodigoAcceso()
        {
            string codigoCorrecto = "giovani2025";
            string input = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el código de acceso:", "Validación de adminitrador", "");

            if (input == codigoCorrecto)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Código incorrecto. Acceso denegado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DevolverPedido(int idPedido)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                // Obtener productos del pedido
                string selectQuery = "SELECT producto, cantidad FROM ventas WHERE id_pedido = @idPedido";
                var productos = new List<(string nombre, int cantidad)>();

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conexion))
                {
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add((reader.GetString("producto"), reader.GetInt32("cantidad")));
                        }
                    }
                }

                // Sumar cantidades al inventario
                foreach (var (nombre, cantidad) in productos)
                {
                    string update = @"UPDATE productos SET cantidad_actual = cantidad_actual + @cantidad 
                              WHERE nombre = @nombre";
                    using (var cmdUpdate = new MySqlCommand(update, conexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@cantidad", cantidad);
                        cmdUpdate.Parameters.AddWithValue("@nombre", nombre);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                // Eliminar la venta
                string deleteQuery = "DELETE FROM ventas WHERE id_pedido = @idPedido";
                using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conexion))
                {
                    cmdDelete.Parameters.AddWithValue("@idPedido", idPedido);
                    int eliminadas = cmdDelete.ExecuteNonQuery();

                    if (eliminadas > 0)
                    {
                        MessageBox.Show("Venta devuelta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el pedido o ya fue devuelto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Eliminar la venta del turno actual
                string Query = "DELETE FROM ventas_turno WHERE id_pedido = @idPedido";
                using (MySqlCommand cmdDeleteV = new MySqlCommand(Query, conexion))
                {
                    cmdDeleteV.Parameters.AddWithValue("@idPedido", idPedido);
                    cmdDeleteV.ExecuteNonQuery();
                }
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            IrMenu();
        }

        //***************************************************************************************

        // Diseño y animaciones

        // btnV
        private void btnV_MouseEnter(object sender, EventArgs e)
        {
            btnV.Size = new Size(66, 66);
            btnV.ForeColor = Color.White;
        }

        private void btnV_MouseLeave(object sender, EventArgs e)
        {
            btnV.Size = new Size(60, 60);
            btnV.ForeColor = Color.Black;
        }


        //********************************************************************************************

        // Transiciones 

        private void IrMenu()
        {
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            Menu menu = new Menu();
            menu.Show();

            transicion.ShowSync(menu);
        }
    }
}
