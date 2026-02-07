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
using GDI_kiffas.Logica;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Globalization;


namespace GDI_kiffas.Interfaz
{
    public partial class ActualizarCantidades : Form
    {
        public ActualizarCantidades()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;

            btnGuardar.MouseEnter += btnGuardar_MouseEnter;
            btnGuardar.MouseLeave += btnGuardar_MouseLeave;

            btnEditar.MouseEnter += btnLimpiar_MouseEnter;
            btnEditar.MouseLeave += btnLimpiar_MouseLeave;
        }

        //****************************************************************************************

        // Logica

        private void ActualizarCantidades_Load(object sender, EventArgs e)
        {
            // 👉 Estilo general
            DGVproductos.ReadOnly = true;
            DGVproductos.RowHeadersVisible = false;
            DGVproductos.EnableHeadersVisualStyles = false;
            DGVproductos.ScrollBars = ScrollBars.Vertical;
            DGVproductos.MultiSelect = false;
            DGVproductos.ColumnHeadersVisible = true;
            DGVproductos.ColumnHeadersHeight = 40;
            DGVproductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DGVproductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // ⬅️ Selección de fila completa

            // 👉 Deshabilitar acciones del usuario
            DGVproductos.AllowUserToAddRows = false;
            DGVproductos.AllowUserToDeleteRows = false;
            DGVproductos.AllowUserToResizeColumns = false;
            DGVproductos.AllowUserToResizeRows = false;

            // 👉 Estilo de celdas
            DGVproductos.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 15, FontStyle.Bold),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                SelectionBackColor = Color.Fuchsia,  // Cambio para que se distinga bien
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // 👉 Estilo de encabezados
            DGVproductos.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 16, FontStyle.Bold),
                BackColor = Color.Purple,
                ForeColor = Color.White,
                SelectionBackColor = Color.Purple,
                SelectionForeColor =Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // 👉 Estilo de bordes
            DGVproductos.GridColor = Color.Black;
            DGVproductos.BorderStyle = BorderStyle.FixedSingle;
            DGVproductos.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // 👉 Altura de las filas
            DGVproductos.RowTemplate.Height = 100;

            // 👉 Alternancia de color
            DGVproductos.AlternatingRowsDefaultCellStyle.BackColor = DGVproductos.RowsDefaultCellStyle.BackColor;

            // 👉 Crear columnas manualmente
            DGVproductos.ColumnCount = 5;
            DGVproductos.Columns[0].Name = "ID"; // Oculta el ID
            DGVproductos.Columns[0].Visible = false;

            DGVproductos.Columns[1].Name = "Nombre";
            DGVproductos.Columns[1].Width = 100;

            DGVproductos.Columns[2].Name = "Cantidad";
            DGVproductos.Columns[2].Width = 100;

            DGVproductos.Columns[3].Name = "Precio";
            DGVproductos.Columns[3].Width = 150;
            DGVproductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGVproductos.Columns[4].Name = "Costo Unitario";
            DGVproductos.Columns[4].Width = 220;
            DGVproductos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // 👉 Agregar columna de imagen
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "Foto",
                HeaderText = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Stretch,
                Width = 180
            };
            DGVproductos.Columns.Insert(0, imgCol); // Insertarla al principio

            CargarProductos();
        }

        List<Productos> listaOriginal = new List<Productos>();
        private void CargarProductos()
        {
            listaOriginal = Conexion.ObtenerProductos();
            MostrarProductos(listaOriginal);
        }

        private void MostrarProductos(List<Productos> producto)
        {
            DGVproductos.Rows.Clear();

            foreach (var p in producto)
            {
                Image imagen = p.foto != null ? ByteArrayToImage(p.foto) : null;
                DGVproductos.Rows.Add(imagen, p.id, p.nombre, p.cantidad_actual, p.preciouni, p.costo);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrados = listaOriginal
                .Where(P => !string.IsNullOrEmpty(P.nombre) && P.nombre.ToLower().Contains(filtro))
                .ToList();

            MostrarProductos(filtrados);
        }


        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (DGVproductos.SelectedRows.Count > 0)
            {
                int fila = DGVproductos.SelectedRows[0].Index;

                DGVproductos.ReadOnly = false;

                foreach (DataGridViewRow row in DGVproductos.Rows)
                {
                    if (row.Index != fila)
                        row.ReadOnly = true;
                }

                DGVproductos.Rows[fila].Cells["Nombre"].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Selecciona un producto para editar.");
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DGVproductos.SelectedRows.Count > 0)
            {
                int fila = DGVproductos.SelectedRows[0].Index;

                int id = Convert.ToInt32(DGVproductos.Rows[fila].Cells["ID"].Value);
                string nombre = DGVproductos.Rows[fila].Cells["Nombre"].Value.ToString();
                string cantidadStr = DGVproductos.Rows[fila].Cells["Cantidad"].Value.ToString();
                string precioStr = DGVproductos.Rows[fila].Cells["Precio"].Value.ToString();
                string costouni = DGVproductos.Rows[fila].Cells["Costo Unitario"].Value.ToString();

                // Validación directa del precio y cantidad
                if (!decimal.TryParse(precioStr, out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Precio inválido.");
                    return;
                }

                if (!decimal.TryParse(costouni, out decimal costo) || costo < 0)
                {
                    MessageBox.Show("Costo unitario inválido.");
                    return;
                }

                if (!int.TryParse(cantidadStr, out int cantidad) || cantidad < 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                string query = "UPDATE productos SET precio_unitario = @precio, Costo_lote = @costo, cantidad_actual = @cantidadNueva WHERE id = @id";

                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@cantidadNueva", cantidad);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@costo", costo);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Producto actualizado correctamente.");
                            DGVproductos.ReadOnly = true;
                            CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto a actualizar.");
                        }
                    }
                }

                CargarProductos();
            }
            else
            {
                MessageBox.Show("Selecciona una fila para guardar.");
            }
        }


        private void btnV_Click(object sender, EventArgs e)
        {
            IrMenu();
        }


        //***************************************************************************************

        // Diseño y animaciones

        // boton Clear
        private void btnLimpiar_MouseEnter(object sender, EventArgs e)
        {
            btnEditar.Size = new Size(142, 39);
            btnEditar.BackColor = Color.Transparent;
            btnEditar.FillColor = Color.Black;
            btnEditar.ForeColor = Color.White;
        }

        private void btnLimpiar_MouseLeave(object sender, EventArgs e)
        {
            btnEditar.Size = new Size(136, 37);
            btnEditar.BackColor = Color.Transparent;
            btnEditar.FillColor = Color.Cyan;
            btnEditar.ForeColor = Color.Black;
        }

        // boton agregar
        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.Size = new Size(158, 43);
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.FillColor = Color.Black;
            btnGuardar.ForeColor = Color.Cyan;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.Size = new Size(152, 41);
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.FillColor = Color.Cyan;
            btnGuardar.ForeColor = Color.Black;
        }

        // btnV
        private void btnV_MouseEnter(object sender, EventArgs e)
        {
            btnV.Size = new Size(66, 66);
        }

        private void btnV_MouseLeave(object sender, EventArgs e)
        {
            btnV.Size = new Size(60, 60);
        }


        //********************************************************************************************

        // Transiciones 

        private void IrMenu()
        {
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            Inventario i = new Inventario();
            i.Show();


            transicion.ShowSync(i);
        }

    }
}
