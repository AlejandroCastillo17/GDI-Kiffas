using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using GDI_kiffas.BD;
using GDI_kiffas.Logica;
using MySql.Data.MySqlClient;


namespace GDI_kiffas.Interfaz
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();

            btnIR.MouseEnter += Button1_MouseEnter;
            btnIR.MouseLeave += Button1_MouseLeave;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            btnIR.Size = new Size(288, 56);
            btnIR.FillColor = Color.Black;
            btnIR.ForeColor = Color.Cyan;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            btnIR.Size = new Size(282, 54);
            btnIR.FillColor = Color.Cyan;
            btnIR.ForeColor = Color.Black;
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnIR_Click(object sender, EventArgs e)
        {
            string encargado = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del encargado:","Inicio de Turno");
            string baseStr = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la base del turno:", "Inicio de Turno");

            if (decimal.TryParse(baseStr, out decimal baseTurno))
            {
                int turnoId = InsertarTurnoNuevo(encargado, baseTurno);
                Turno.TurnoActual = new Turno
                {
                    Id = turnoId,
                    Encargado = encargado,
                    Base = baseTurno,
                    FechaInicio = DateTime.Now
                };

                Transicion();
            }
            else
            {
                MessageBox.Show("Base inválida, acceso denegado.");
            }
        }

        public int InsertarTurnoNuevo(string encargado, decimal baseTurno)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO turnos (encargado, base, fecha_inicio) VALUES (@encargado, @base, NOW()); SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@encargado", encargado);
                cmd.Parameters.AddWithValue("@base", baseTurno);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            /*if (Conexion.ProbarConexion() == true)
            {
                MessageBox.Show("Hay conexion", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void Transicion()
        {

            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            Menu menu = new Menu();
            menu.Show();

            transicion.ShowSync(menu);
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
