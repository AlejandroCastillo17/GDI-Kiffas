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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GDI_kiffas.Interfaz
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            btn1.MouseEnter += Btn1_MouseEnter;
            btn1.MouseLeave += Btn1_MouseLeave;

            btn2.MouseEnter += Btn2_MouseEnter;
            btn2.MouseLeave += Btn2_MouseLeave;

            btnDV.MouseEnter += BtnDV_MouseEnter;
            btnDV.MouseLeave += BtnDV_MouseLeave;

            btnTA.MouseEnter += BtnTA_MouseEnter;
            btnTA.MouseLeave += BtnTA_MouseLeave;

            btnHT.MouseEnter += BtnHT_MouseEnter;
            btnHT.MouseLeave += BtnHT_MouseLeave;

            btnCerrarTurno.MouseEnter += BtnCturno_MouseEnter;
            btnCerrarTurno.MouseLeave += BtnCturno_MouseLeave;

            btn3.MouseEnter += Btn3_MouseEnter;
            btn3.MouseLeave += Btn3_MouseLeave;

            btn4.MouseEnter += Btn4_MouseEnter;
            btn4.MouseLeave += Btn4_MouseLeave;
        }

        // Gestion de Mesas
        private void Btn1_MouseEnter(object sender, EventArgs e)
        {
            btn1.Size = new Size(180, 57);
            btn1.FillColor = Color.Black;
            btn1.ForeColor = Color.Cyan;
        }

        private void Btn1_MouseLeave(object sender, EventArgs e)
        {
            btn1.Size = new Size(175, 55);
            btn1.FillColor = Color.Cyan;
            btn1.ForeColor = Color.Black;
        }

        // Registro de Ventas
        private void Btn2_MouseEnter(object sender, EventArgs e)
        {
            btn2.Size = new Size(180, 57);
            btn2.FillColor = Color.Black;
            btn2.ForeColor = Color.Cyan;
        }

        private void Btn2_MouseLeave(object sender, EventArgs e)
        {
            btn2.Size = new Size(175, 55);
            btn2.FillColor = Color.Cyan;
            btn2.ForeColor = Color.Black;
        }

        // Gestion de inventario
        private void Btn3_MouseEnter(object sender, EventArgs e)
        {
            btn3.Size = new Size(180, 57);
            btn3.FillColor = Color.Black;
            btn3.ForeColor = Color.Cyan;
        }

        private void Btn3_MouseLeave(object sender, EventArgs e)
        {
            btn3.Size = new Size(175, 55);
            btn3.FillColor = Color.Cyan;
            btn3.ForeColor = Color.Black;
        }

        // Informes
        private void Btn4_MouseEnter(object sender, EventArgs e)
        {
            btn4.Size = new Size(180, 57);
            btn4.FillColor = Color.Black;
            btn4.ForeColor = Color.Cyan;
        }

        private void Btn4_MouseLeave(object sender, EventArgs e)
        {
            btn4.Size = new Size(175, 55);
            btn4.FillColor = Color.Cyan;
            btn4.ForeColor = Color.Black;
        }


        // Devolucion
        private void BtnDV_MouseEnter(object sender, EventArgs e)
        {
            btnDV.Size = new Size(180, 57);
            btnDV.FillColor = Color.Black;
            btnDV.ForeColor = Color.Cyan;
        }

        private void BtnDV_MouseLeave(object sender, EventArgs e)
        {
            btnDV.Size = new Size(175, 55);
            btnDV.FillColor = Color.Cyan;
            btnDV.ForeColor = Color.Black;
        }

        // Turno
        private void BtnTA_MouseEnter(object sender, EventArgs e)
        {
            btnTA.Size = new Size(180, 57);
            btnTA.FillColor = Color.Black;
            btnTA.ForeColor = Color.Cyan;
        }

        private void BtnTA_MouseLeave(object sender, EventArgs e)
        {
            btnTA.Size = new Size(175, 55);
            btnTA.FillColor = Color.Cyan;
            btnTA.ForeColor = Color.Black;
        }

        // Historial turno
        private void BtnHT_MouseEnter(object sender, EventArgs e)
        {
            btnHT.Size = new Size(180, 57);
            btnHT.FillColor = Color.Black;
            btnHT.ForeColor = Color.Cyan;
        }

        private void BtnHT_MouseLeave(object sender, EventArgs e)
        {
            btnHT.Size = new Size(175, 55);
            btnHT.FillColor = Color.Cyan;
            btnHT.ForeColor = Color.Black;
        }

        // Cerrar Turno
        private void BtnCturno_MouseEnter(object sender, EventArgs e)
        {
            btnCerrarTurno.Size = new Size(120, 60);
            btnCerrarTurno.FillColor = Color.Cyan;
            btnCerrarTurno.ForeColor = Color.Black;
        }

        private void BtnCturno_MouseLeave(object sender, EventArgs e)
        {
            btnCerrarTurno.Size = new Size(114, 58);
            btnCerrarTurno.FillColor = Color.Black;
            btnCerrarTurno.ForeColor = Color.Cyan;
        }

        //*******************************************************************************************

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            IrMesas();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            IrVentas();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            IrInventario();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            IrInformes();
        }

        private void btnDV_Click(object sender, EventArgs e)
        {
            IrDV();
        }

        private void btnTA_Click(object sender, EventArgs e)
        {
            IrTurno();
        }

        private void btnHT_Click(object sender, EventArgs e)
        {
            IrHT();
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

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar el turno?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var turno = Turno.TurnoActual;

                using (var conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    var cmd = new MySqlCommand("UPDATE turnos SET fecha_cierre = NOW(), total_ventas = (SELECT SUM(ingreso) FROM ventas_turno WHERE id_turno = @id) WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", turno.Id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Turno cerrado correctamente.");
                Turno.TurnoActual = null;

                Application.Restart(); // o volver al formulario de bienvenida
            }
        }

        //********************************************************************************************

        private void IrVentas()
        {
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);

            this.Hide();

            RegistrarVentas venta = new RegistrarVentas();
            venta.Show();

            transicion.ShowSync(venta);
        }

        private void IrMesas()
        {

            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();

            MesasActivas mesa = new MesasActivas();
            mesa.Show();

            transicion.ShowSync(mesa);
        }

        private void IrInventario()
        {
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);

            this.Hide();

            Inventario invent = new Inventario();
            invent.Show();

            transicion.ShowSync(invent);
        }

        private void IrDV()
        {
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);

            this.Hide();

            Devoluciones d = new Devoluciones();
            d.Show();

            transicion.ShowSync(d);
        }

        private void IrInformes()
        {
            if (!ValidarCodigoAcceso()) return;
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            Informes infor = new Informes();
            infor.Show();

            transicion.ShowSync(infor);
        }

        private void IrTurno()
        {

            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            TurnoActual tur = new TurnoActual();
            tur.Show();

            transicion.ShowSync(tur);
        }

        private void IrHT()
        {

            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            HistorialTurnos tur = new HistorialTurnos();
            tur.Show();

            transicion.ShowSync(tur);
        }


    }


}
