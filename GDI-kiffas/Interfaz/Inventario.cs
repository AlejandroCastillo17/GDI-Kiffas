using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDI_kiffas.Logica;
using GDI_kiffas.BD;
using Guna.UI2.WinForms;

namespace GDI_kiffas.Interfaz
{
    public partial class Inventario : Form
    {
        public Inventario()
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

        private void Inventario_Load(object sender, EventArgs e)
        {

            cmb.Items.Add("⭢ Gestión Productos"); // título solo visual, deshabilitado
            cmb.Items.Add("Agregar producto");
            cmb.Items.Add("Editar producto");
            cmb.SelectedIndex = 0;


            // 👉 Estilos generales del DataGridView
            DGVproductos.ReadOnly = true;
            DGVproductos.RowHeadersVisible = false;
            DGVproductos.EnableHeadersVisualStyles = false;
            DGVproductos.ScrollBars = ScrollBars.Vertical;
            DGVproductos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DGVproductos.CurrentCell = null;
            DGVproductos.MultiSelect = false;
            DGVproductos.ColumnHeadersVisible = true;
            DGVproductos.ColumnHeadersHeight = 40;
            DGVproductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // 👉 Deshabilitar edición de celdas/filas/columnas
            DGVproductos.AllowUserToAddRows = false;
            DGVproductos.AllowUserToDeleteRows = false;
            DGVproductos.AllowUserToResizeColumns = false;
            DGVproductos.AllowUserToResizeRows = false;
            DGVproductos.AlternatingRowsDefaultCellStyle.BackColor = DGVproductos.RowsDefaultCellStyle.BackColor;

            // 👉 Estilo de bordes
            DGVproductos.GridColor = Color.Black;
            DGVproductos.BorderStyle = BorderStyle.FixedSingle;
            DGVproductos.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // 👉 Estilos visuales de celdas
            DGVproductos.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 15, FontStyle.Bold),
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // 👉 Estilo de los encabezados
            DGVproductos.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 16, FontStyle.Bold),
                BackColor = Color.Purple, // Puedes usar Color.FromArgb(0, 0, 192) para un azul más suave
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // 👉 Altura de filas
            DGVproductos.RowTemplate.Height = 100;

            // 👉 Crear columnas manualmente
            DGVproductos.ColumnCount = 5;
            DGVproductos.Columns[0].Name = "ID"; // Oculta el ID
            DGVproductos.Columns[0].Visible = false;

            DGVproductos.Columns[1].Name = "Nombre";
            DGVproductos.Columns[1].Width = 160;

            DGVproductos.Columns[2].Name = "Cantidad";
            DGVproductos.Columns[2].Width = 130;

            DGVproductos.Columns[3].Name = "Precio";
            DGVproductos.Columns[3].Width = 150;
            DGVproductos.Columns[3].DefaultCellStyle.Format = "C2";
            DGVproductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DGVproductos.Columns[4].Name = "Fecha";
            DGVproductos.Columns[4].Width = 220;

            // 👉 Agregar columna de imagen
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "Foto",
                HeaderText = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Stretch,
                Width = 180
            };
            DGVproductos.Columns.Insert(0, imgCol); // Insertarla al principio

            // 👉 Agregar botón de eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Text = "❌",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Popup,
                Width = 30
            };
            btnEliminar.DefaultCellStyle.BackColor = Color.Firebrick;
            btnEliminar.DefaultCellStyle.ForeColor = Color.White;
            DGVproductos.Columns.Add(btnEliminar);

            // 👉 Evento para mantener color del botón eliminar
            DGVproductos.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == DGVproductos.Columns["Eliminar"].Index && e.RowIndex >= 0)
                {
                    e.CellStyle.BackColor = Color.Firebrick;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.Firebrick;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            };

            // 👉 Evento click para eliminar
            DGVproductos.CellClick += (s, e) =>
            {
                if (!ValidarCodigoAcceso()) return;
                if (e.ColumnIndex == DGVproductos.Columns["Eliminar"].Index && e.RowIndex >= 0)
                {
                    int idmp = Convert.ToInt32(DGVproductos.Rows[e.RowIndex].Cells["ID"].Value);
                    DialogResult confirm = MessageBox.Show("¿Seguro que deseas eliminar este producto del inventario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        ProductosBD.EliminarProducto(idmp);
                        DGVproductos.Rows.RemoveAt(e.RowIndex);
                    }
                }
            };

            // 👉 Finalmente, cargar los datos
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
                DGVproductos.Rows.Add(imagen, p.id, p.nombre, p.cantidad_actual, p.preciouni, p.fecha);
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

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            IrMenu();
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb.SelectedIndex)
            {
                case 1: // Agregar producto
                    IrAP();
                    break;

                case 2: // Editar producto
                    IrAC();
                    break;
            }

            // Vuelve a dejar la selección en el título
            cmb.SelectedIndex = 0;
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

        private void IrAP()
        {
            if (!ValidarCodigoAcceso()) return;
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            AgregarProducto AG = new AgregarProducto();
            AG.Show();

            transicion.ShowSync(AG);
        }

        private void IrAC()
        {
            if (!ValidarCodigoAcceso()) return;
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            ActualizarCantidades a = new ActualizarCantidades();
            a.Show();

            transicion.ShowSync(a);
        }

        private void cmb_Click(object sender, EventArgs e)
        {

        }
    }
}
