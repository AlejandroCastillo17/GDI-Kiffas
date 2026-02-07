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

namespace GDI_kiffas.Interfaz
{
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            txtBarcode.Location = new Point(-200, -200);

            // 1) Cada vez que se muestre el form, enfocamos al txtBarcode
            this.Shown += (_, __) => txtBarcode.Focus();

            // 2) Capturamos el Enter del scanner
            txtBarcode.KeyDown += TxtBarcode_KeyDown;

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;

            btnAI.MouseEnter += btnAI_MouseEnter;
            btnAI.MouseLeave += btnAI_MouseLeave;

            btnLimpiar.MouseEnter += btnLimpiar_MouseEnter;
            btnLimpiar.MouseLeave += btnLimpiar_MouseLeave;

            btnGuardar.MouseEnter += btnGuardar_MouseEnter;
            btnGuardar.MouseLeave += btnGuardar_MouseLeave;

        }

        //***************************************************************************************

        // Logica

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodigoBarras.Text = txtBarcode.Text.Trim();
                txtBarcode.Clear();
                e.Handled = true;

                txtNombre.Focus();
            }
        }
        private void AgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                EnfocarTxtCodigo();
                return; // Si hay errores, detiene la ejecución
            }

            // Crear objeto producto
            Productos producto = new Productos
            {
                nombre = txtNombre.Text,
                codigobarras = txtCodigoBarras.Text.Trim(),
                preciouni = Convert.ToInt32(txtPU.Text),
                costo = Convert.ToInt32(txtCl.Text),
                cantidad_inicial = Convert.ToInt32(txtCantidad.Text),
                cantidad_actual = Convert.ToInt32(txtCantidad.Text),
                foto = ImagenABytes(PicFotoProducto.Image),
                fecha = DateTime.Now.Date
            };

            // Guardar en la BD
            if (ProductosBD.GuardarProducto(producto))
            {
                MessageBox.Show("Producto guardado con éxito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnfocarTxtCodigo();
            }
            else
            {
                MessageBox.Show("Error al guardar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnfocarTxtCodigo();
            }

            // Limpiar Campos
            txtNombre.Clear();
            txtCodigoBarras.Clear();
            txtPU.Clear();
            txtCl.Clear();
            txtCantidad.Clear();
            PicFotoProducto.Image = Properties.Resources.FondoKiffa2;
            EnfocarTxtCodigo();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPU.Text) ||
                string.IsNullOrWhiteSpace(txtCl.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Los campos del producto están vacíos, verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnfocarTxtCodigo();
                return false;
            }

            // Validar que el precio sea un número válido
            if (!int.TryParse(txtPU.Text, out _))
            {
                MessageBox.Show("El precio unitario debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnfocarTxtCodigo();
                return false;
            }

            // Validar que el costo sea un número válido
            if (!int.TryParse(txtCl.Text, out _))
            {
                MessageBox.Show("El costo por unidad debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnfocarTxtCodigo();
                return false;
            }

            // Validar que la cantidad sea un número válido
            if (!int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("La cantidad debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnfocarTxtCodigo();
                return false;
            }

            // Validar el codigo de barras
            if (string.IsNullOrWhiteSpace(txtCodigoBarras.Text))
            {
                MessageBox.Show("Escanee el codigo de barras para el nuevo producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnfocarTxtCodigo();
                return false;
            }

            EnfocarTxtCodigo();
            return true; // Retorna true si todo está correcto
        }

        private byte[] ImagenABytes(Image imagen)
        {
            if (imagen == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PicFotoProducto.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            EnfocarTxtCodigo();
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar Campos
            txtNombre.Clear();
            txtPU.Clear();
            txtCl.Clear();
            txtCantidad.Clear();
            PicFotoProducto.Image = Properties.Resources.FondoKiffa2;
            txtCodigoBarras.Clear();
            EnfocarTxtCodigo();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea caracteres que no sean letras o espacios
            }
        }


        private void txtPU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si no es un número
            }
        }

        private void txtCl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si no es un número
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla si no es un número
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            IrMenu();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        //***************************************************************************************

        // Enfoque de txt codigo

        private void EnfocarTxtCodigo()
        {
            if (string.IsNullOrWhiteSpace(txtCodigoBarras.Text))
            {
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
        }

        private void PicFotoProducto_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void AgregarProducto_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        private void txtCodigoBarras_Click(object sender, EventArgs e)
        {
            EnfocarTxtCodigo();
        }

        //***************************************************************************************

        // Diseño y animaciones

        // boton Clear
        private void btnAI_MouseEnter(object sender, EventArgs e)
        {
            btnAI.Size = new Size(151, 39);
            btnAI.BackColor = Color.Transparent;
            btnAI.FillColor = Color.Black;
            btnAI.ForeColor = Color.Cyan;
        }

        private void btnAI_MouseLeave(object sender, EventArgs e)
        {
            btnAI.Size = new Size(145, 37);
            btnAI.BackColor = Color.Transparent;
            btnAI.FillColor = Color.Cyan;
            btnAI.ForeColor = Color.Black;
        }

        // boton Clear
        private void btnLimpiar_MouseEnter(object sender, EventArgs e)
        {
            btnLimpiar.Size = new Size(156, 45);
            btnLimpiar.BackColor = Color.Transparent;
            btnLimpiar.FillColor = Color.Black;
            btnLimpiar.ForeColor = Color.Cyan;
        }

        private void btnLimpiar_MouseLeave(object sender, EventArgs e)
        {
            btnLimpiar.Size = new Size(152, 43);
            btnLimpiar.BackColor = Color.Transparent;
            btnLimpiar.FillColor = Color.Cyan;
            btnLimpiar.ForeColor = Color.Black;
        }

        // boton agregar
        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.Size = new Size(156, 45);
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.FillColor = Color.Black;
            btnGuardar.ForeColor = Color.Cyan;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.Size = new Size(152, 43);
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

            // Limpiar Campos
            txtNombre.Clear();
            txtPU.Clear();
            txtCl.Clear();
            txtCantidad.Clear();
            PicFotoProducto.Image = Properties.Resources.FondoKiffa2;
        }






        //***********************************************************************************************



        private void txtPU_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
