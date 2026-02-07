using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
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

namespace GDI_kiffas.Interfaz
{
    public partial class RegistrarVentas : Form
    {
        public RegistrarVentas()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            txtCodigoBarra.Location = new Point(-200, -200);

            // Suscribimos el evento Shown para poner el foco en el TextBox
            this.Shown += (_, __) => txtCodigoBarra.Focus();
            this.Click += RegistrarVentas_Click;


            // También aquí puedes suscribir el KeyDown de txtCodigoBarra
            txtCodigoBarra.KeyDown += txtCodigoBarra_KeyDown;

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;

            Descorche.MouseEnter += Descorche_MouseEnter;
            Descorche.MouseLeave += Descorche_MouseLeave;

            btnAgregar.MouseEnter += btnAgregar_MouseEnter;
            btnAgregar.MouseLeave += btnAgregar_MouseLeave;

            btnAceptar.MouseEnter += btnAceptar_MouseEnter;
            btnAceptar.MouseLeave += btnAceptar_MouseLeave;

            btnEliminar.MouseEnter += btnEliminar_MouseEnter;
            btnEliminar.MouseLeave += btnEliminar_MouseLeave;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //****************************************************************************************

        // Logica

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (long.TryParse(txtCodigoBarra.Text.Trim(), out long codigo))
                {
                    bool agregado = AgregarProductoPorCodigo(codigo);
                    if (!agregado)
                    {
                        MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtCodigoBarra.Clear();
                }
                else
                {
                    MessageBox.Show("Código inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoBarra.Clear();
                }


                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void EnfocarTxtCodigo()
        {
            txtCodigoBarra.Focus();
            txtCodigoBarra.SelectAll();
        }


        private List<Productos> listaProductosOriginal = new List<Productos>();

        private void RegistrarVentas_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
            this.ActiveControl = txtCodigoBarra;
        }
        private void CBM_CheckedChanged(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void DGproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void DGpedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }
        private void guna2Panel2_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void guna2Panel5_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void guna2Panel4_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void guna2Panel6_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void RegistrarVentas_Load(object sender, EventArgs e)
        {
            // ========== CONFIGURACIÓN GENERAL ==========
            DGproductos.AutoGenerateColumns = false;
            DGproductos.Columns.Clear();
            DGproductos.ReadOnly = true;
            DGproductos.RowHeadersVisible = false;
            DGproductos.CurrentCell = null;
            DGproductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGproductos.ColumnHeadersVisible = true;
            DGproductos.ColumnHeadersHeight = 30;


            // ========== ESTILOS DE CELDAS ==========
            DGproductos.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            DGproductos.DefaultCellStyle.BackColor = Color.Gray;
            DGproductos.DefaultCellStyle.ForeColor = Color.White;
            DGproductos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGproductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 0, 192);
            DGproductos.DefaultCellStyle.SelectionForeColor = Color.White;
            DGproductos.AlternatingRowsDefaultCellStyle.BackColor = DGproductos.RowsDefaultCellStyle.BackColor;

            // ========== ESTILOS DE ENCABEZADOS ==========
            DGproductos.EnableHeadersVisualStyles = false;
            DGproductos.ColumnHeadersDefaultCellStyle.BackColor = Color.Purple;
            DGproductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGproductos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            DGproductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGproductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Purple;
            DGproductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ========== CONFIGURACIÓN DE BORDES ==========
            DGproductos.GridColor = Color.Black;
            DGproductos.BorderStyle = BorderStyle.FixedSingle;
            DGproductos.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // ========== PROPIEDADES DE COMPORTAMIENTO ==========
            DGproductos.AllowUserToAddRows = false;
            DGproductos.AllowUserToDeleteRows = false;
            DGproductos.AllowUserToResizeColumns = false;
            DGproductos.AllowUserToResizeRows = false;
            DGproductos.RowTemplate.Height = 80;

            // ========== DEFINICIÓN DE COLUMNAS ==========
            // Columna Imagen
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Stretch,
                Width = 150
            };
            DGproductos.Columns.Add(imgCol);

            // Columnas de texto
            DGproductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                Visible = false
            });

            DGproductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Producto",
                HeaderText = "Producto",
                Width = 100
            });

            DGproductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio",
                Visible = false
            });

            // ========== LLENADO DE DATOS ==========
            CargarProductos();
            ConfigurarPedido();
        }


        private void CargarProductos()
        {
            listaProductosOriginal = Conexion.ObtenerProductos();
            MostrarProductos(listaProductosOriginal);
        }

        private void MostrarProductos(List<Productos> productos)
        {
            DGproductos.Rows.Clear();

            foreach (var producto in productos)
            {
                Image imagen = producto.foto != null ? ByteArrayToImage(producto.foto) : null;
                DGproductos.Rows.Add(imagen, producto.id, producto.nombre, producto.preciouni);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            string filtro = txtBuscar.Text.Trim().ToLower();

            var filtrados = listaProductosOriginal
                .Where(p =>
                    (!string.IsNullOrEmpty(p.nombre) && p.nombre.ToLower().Contains(filtro)) ||
                    (!string.IsNullOrEmpty(p.codigobarras) && p.codigobarras.ToLower().Contains(filtro))
                )
                .ToList();

            MostrarProductos(filtrados);

            EnfocarTxtCodigo();
        }




        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void ConfigurarPedido()
        {
            // Configuración general del DataGridView
            DGpedido.AutoGenerateColumns = false;
            DGpedido.Columns.Clear();
            DGpedido.ReadOnly = true;
            DGpedido.RowHeadersVisible = false;
            DGpedido.AllowUserToAddRows = false;
            DGpedido.AllowUserToResizeColumns = false;
            DGpedido.AllowUserToResizeRows = false;
            DGpedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGpedido.ColumnHeadersVisible = true;
            DGpedido.ColumnHeadersHeight = 40;

            // Estilo de bordes
            DGpedido.GridColor = Color.Black;
            DGpedido.BorderStyle = BorderStyle.FixedSingle;
            DGpedido.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Estilo de encabezados
            DGpedido.EnableHeadersVisualStyles = false;
            DGpedido.ColumnHeadersDefaultCellStyle.BackColor = Color.Fuchsia;
            DGpedido.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGpedido.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            DGpedido.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGpedido.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Fuchsia; // Mantiene color al seleccionar encabezado
            DGpedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // Estilo de celdas
            DGpedido.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            DGpedido.DefaultCellStyle.BackColor = Color.Gray;
            DGpedido.DefaultCellStyle.ForeColor = Color.White;
            DGpedido.DefaultCellStyle.SelectionBackColor = Color.HotPink;
            DGpedido.DefaultCellStyle.SelectionForeColor = Color.White;
            DGpedido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGpedido.AlternatingRowsDefaultCellStyle.BackColor = DGpedido.RowsDefaultCellStyle.BackColor;


            // Agregar columnas al DataGridView
            DGpedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "id",
                Width = 0,
                Visible = false
            });

            DGpedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Producto",
                Width = 100
            });

            DGpedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "cantidad",
                HeaderText = "Cantidad",
                Width = 81
            });

            DGpedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "preciouni",
                HeaderText = "Precio Unitario",
                Width = 82,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            DGpedido.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                Width = 85,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    ForeColor = Color.Black
                }
            });

            // Enlazar datos
            DGpedido.DataSource = new BindingList<Productos>(pedido);

            // Eventos y actualizaciones
            DGpedido.CellFormatting += DGpedido_CellFormatting;
            actualizarsuma();
        }


        private void DGpedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGpedido.Columns[e.ColumnIndex].HeaderText == "Total" && e.RowIndex >= 0)
            {
                var producto = pedido[e.RowIndex];
                e.Value = (producto.cantidad * producto.preciouni).ToString("C2"); // Formato de moneda

            }
        }

        private List<Productos> pedido = new List<Productos>();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (DGproductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto antes de agregarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnfocarTxtCodigo();
                return;
            }

            // Obtener valores directamente desde las celdas
            int id = Convert.ToInt32(DGproductos.SelectedRows[0].Cells[1].Value);
            string nombre = DGproductos.SelectedRows[0].Cells[2].Value.ToString();
            int precio = Convert.ToInt32(DGproductos.SelectedRows[0].Cells[3].Value);
            int cantidad = 1;

            // Buscar si el producto ya existe en la lista
            var productoExistente = pedido.FirstOrDefault(p => p.id == id);

            if (productoExistente != null)
            {
                productoExistente.cantidad++;
            }
            else
            {
                pedido.Add(new Productos { id = id, nombre = nombre, preciouni = precio, cantidad = cantidad });
            }

            actualizarpedido();
            actualizarsuma();

            EnfocarTxtCodigo();
            this.ActiveControl = txtCodigoBarra;
        }

        private bool AgregarProductoPorCodigo(long codigo)
        {
            var prod = Conexion.ObtenerPorCodigoBarras(codigo);
            if (prod == null) return false;

            var existente = pedido.FirstOrDefault(p => p.id == prod.id);
            if (existente != null)
            {
                existente.cantidad++;
            }
            else
            {
                pedido.Add(new Productos
                {
                    id = prod.id,
                    nombre = prod.nombre,
                    preciouni = prod.preciouni,
                    cantidad = 1
                });
            }

            actualizarpedido();
            actualizarsuma();
            return true;
        }


        private void actualizarpedido()
        {
            DGpedido.DataSource = null;
            DGpedido.DataSource = pedido;
            actualizarsuma();
        }

        private void actualizarsuma()
        {
            decimal total = pedido.Sum(p => p.cantidad * p.preciouni);
            lblTotal.Text = $"Total: {total:C2}";
        }

        private void RegistrarVentas_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            pedido.Clear();
            DGpedido.DataSource = null;
            DGpedido.Rows.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (DGpedido.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnfocarTxtCodigo();
                return;
            }

            int id = Convert.ToInt32(DGpedido.SelectedRows[0].Cells[0].Value); // ID del producto

            var productoExistente = pedido.FirstOrDefault(p => p.id == id);

            if (productoExistente != null)
            {
                if (productoExistente.cantidad > 1)
                {
                    productoExistente.cantidad--; // Resta la cantidad si es mayor a 1
                }
                else
                {
                    pedido.Remove(productoExistente); // Elimina el producto si la cantidad es 1
                }
            }

            actualizarpedido();
            actualizarsuma();

            EnfocarTxtCodigo();
            this.ActiveControl = txtCodigoBarra;
        }

        private int ObtenerNuevoIdPedido()
        {
            int nuevoId = 1;
            string query = "SELECT MAX(id_pedido) FROM ventas";

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    object resultado = comando.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        nuevoId = Convert.ToInt32(resultado) + 1;
                    }
                }
            }

            return nuevoId;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<Ventas> listaVentas = new List<Ventas>();

            if (pedido.Count > 0)
            {
                int idPedido = ObtenerNuevoIdPedido(); // Generar un solo id para todo el pedido

                foreach (DataGridViewRow row in DGpedido.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null) // Verificar que las celdas no sean nulas
                    {
                        string producto = row.Cells[1].Value.ToString();
                        int cantidad = Convert.ToInt32(row.Cells[2].Value); // Obtener cantidad
                        decimal precio = Convert.ToDecimal(row.Cells[3].Value);
                        int idProducto = Convert.ToInt32(row.Cells[0].Value);

                        Ventas venta = new Ventas
                        {
                            id_pedido = idPedido,
                            producto = producto,
                            cantidad = cantidad,
                            precio = precio * cantidad,
                            fecha = DateTime.Now.Date,
                            mesa = CBM.Checked
                        };

                        VentasBD.RegistrarVentaTurno(Turno.TurnoActual.Id, producto, cantidad, venta.precio, idPedido);

                        listaVentas.Add(venta);
                        ActualizarInventario(idProducto, cantidad);
                    }
                }



                // Guardar en la base de datos solo si hay productos en la lista
                if (listaVentas.Count > 0)
                {
                    if (VentasBD.GuardarVenta(listaVentas))
                    {
                        MessageBox.Show("Pedido registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    pedido.Clear();
                    actualizarsuma();
                    actualizarpedido();
                }
                else
                {
                    MessageBox.Show("No hay productos válidos en el pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (CBM.Checked)
                {
                    var nuevaMesa = new Mesas
                    {
                        NombreMesa = "Mesa ",
                        Ventas = listaVentas
                    };

                }
            }
            else
            {
                MessageBox.Show("No hay productos en el pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtBuscar.Clear();
            CBM.Checked = false;
            EnfocarTxtCodigo();
            this.ActiveControl = txtCodigoBarra;
        }

        private void ActualizarInventario(int idproducto, int cantidadRestar)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"UPDATE productos 
                         SET cantidad_actual = cantidad_actual - @cantidadRestar 
                         WHERE id = @idproducto";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@cantidadRestar", cantidadRestar);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Descorche_Click(object sender, EventArgs e)
        {
            int idPedido = ObtenerNuevoIdPedido();
            string descorche = Microsoft.VisualBasic.Interaction.InputBox("Ingrese valor del descorche:", "Registrar descorche");

            if (decimal.TryParse(descorche, out decimal desc))
            {
                Ventas venta = new Ventas
                {
                    id_pedido = idPedido,
                    producto = "Descorche",
                    cantidad = 1,
                    precio = desc,
                    fecha = DateTime.Now.Date,
                    mesa = CBM.Checked
                };

                VentasBD.RegistrarVentaTurno(Turno.TurnoActual.Id, "Descorche", 1, venta.precio, idPedido);
            }
            else
            {
                MessageBox.Show("Valor invalido, verifique por favor.");
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

        //btnAgregarP
        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.Size = new Size(226, 47);
            btnAgregar.BackColor = Color.Transparent;
            btnAgregar.FillColor = Color.Black;
            btnAgregar.ForeColor = Color.Cyan;
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.Size = new Size(222, 45);
            btnAgregar.BackColor = Color.Transparent;
            btnAgregar.FillColor = Color.Cyan;
            btnAgregar.ForeColor = Color.Black;
        }

        // btnAceptarPe
        private void btnAceptar_MouseEnter(object sender, EventArgs e)
        {
            btnAceptar.Size = new Size(114, 58);
            btnAceptar.BackColor = Color.Transparent;
            btnAceptar.FillColor = Color.Black;
            btnAceptar.ForeColor = Color.Cyan;
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.Size = new Size(108, 56);
            btnAceptar.BackColor = Color.Transparent;
            btnAceptar.FillColor = Color.Cyan;
            btnAceptar.ForeColor = Color.Black;
        }

        // btnEliminarP 
        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            btnEliminar.Size = new Size(114, 58);
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.FillColor = Color.Black;
            btnEliminar.ForeColor = Color.Cyan;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.Size = new Size(108, 56);
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.FillColor = Color.Cyan;
            btnEliminar.ForeColor = Color.Black;
        }

        // descorche 
        private void Descorche_MouseEnter(object sender, EventArgs e)
        {
            Descorche.Size = new Size(50, 42);
            Descorche.BackColor = Color.Transparent;
            Descorche.FillColor = Color.Black;
            Descorche.ForeColor = Color.Gold;
        }

        private void Descorche_MouseLeave(object sender, EventArgs e)
        {
            Descorche.Size = new Size(47, 40);
            Descorche.BackColor = Color.Transparent;
            Descorche.FillColor = Color.Gold;
            Descorche.ForeColor = Color.Black;
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

            txtBuscar.Clear();
            CBM.Checked = false;
        }

        //******************************************************************************************

        // Generado por error
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
