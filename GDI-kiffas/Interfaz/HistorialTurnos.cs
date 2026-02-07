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

namespace GDI_kiffas.Interfaz
{
    public partial class HistorialTurnos : Form
    {
        public HistorialTurnos()
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

        private void HistorialTurnos_Load(object sender, EventArgs e)
        {
            // ===== CONFIGURACIÓN GENERAL =====
            DGHistorial.EnableHeadersVisualStyles = false;
            DGHistorial.ReadOnly = true;
            DGHistorial.AllowUserToAddRows = false;
            DGHistorial.AllowUserToDeleteRows = false;
            DGHistorial.AllowUserToResizeColumns = false;
            DGHistorial.AllowUserToResizeRows = false;
            DGHistorial.RowHeadersVisible = false;
            DGHistorial.MultiSelect = false;
            DGHistorial.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DGHistorial.CurrentCell = null;
            DGHistorial.ColumnHeadersVisible = true;
            DGHistorial.ColumnHeadersHeight = 40;
            DGHistorial.RowTemplate.Height = 50;
            DGHistorial.AlternatingRowsDefaultCellStyle.BackColor = DGHistorial.RowsDefaultCellStyle.BackColor;
            DGHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ===== ESTILO DE ENCABEZADOS =====
            DGHistorial.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.Purple
            };

            // ===== ESTILO DE CELDAS =====
            DGHistorial.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black
            };

            // ===== BORDES Y REJILLA =====
            DGHistorial.GridColor = Color.Black;
            DGHistorial.BorderStyle = BorderStyle.FixedSingle;
            DGHistorial.CellBorderStyle = DataGridViewCellBorderStyle.Single;


            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT id, encargado, base, fecha_inicio, fecha_cierre, total_ventas FROM turnos WHERE fecha_cierre IS NOT NULL ORDER BY fecha_inicio DESC", conn);
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                DGHistorial.DataSource = dt;

                // Configurar columnas solo si el DataTable tiene datos
                if (DGHistorial.Columns.Count >= 4)
                {

                    DGHistorial.Columns[0].HeaderText = "ID";
                    DGHistorial.Columns[0].Visible = false;

                    DGHistorial.Columns[1].HeaderText = "Encargado";
                    DGHistorial.Columns[1].Width = 120;

                    DGHistorial.Columns[2].HeaderText = "Base";
                    DGHistorial.Columns[2].Width = 120;
                    DGHistorial.Columns[2].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    };

                    DGHistorial.Columns[3].HeaderText = "Fecha Inicio";
                    DGHistorial.Columns[3].Width = 150;
                    DGHistorial.Columns[3].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    };

                    DGHistorial.Columns[4].HeaderText = "Fecha Cierre";
                    DGHistorial.Columns[4].Width = 150;
                    DGHistorial.Columns[4].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    };

                    DGHistorial.Columns[5].HeaderText = "Ventas Totales";
                    DGHistorial.Columns[5].Width = 150;
                    DGHistorial.Columns[5].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    };

                }
            }

            // 👉 Agregar botón de detalles
            if (!DGHistorial.Columns.Contains("Detalles"))
            {
                var btnDetalles = new DataGridViewButtonColumn
                {
                    Name = "Detalles",
                    HeaderText = "",
                    Text = "Ver Detalles",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Popup,
                    Width = 90,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = Color.Fuchsia,
                        ForeColor = Color.White,
                        SelectionBackColor = Color.Fuchsia,
                        SelectionForeColor = Color.White
                    }
                };

                DGHistorial.Columns.Add(btnDetalles);
            }

            // 👉 Evento para mantener color del botón detalles
            DGHistorial.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == DGHistorial.Columns["Detalles"].Index && e.RowIndex >= 0)
                {
                    e.CellStyle.BackColor = Color.Fuchsia;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.Fuchsia;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            };

            // 👉 Evento click para detalles
            DGHistorial.CellClick += (s, e) =>
            {
                if (e.ColumnIndex == DGHistorial.Columns["Detalles"].Index && e.RowIndex >= 0)
                {
                    if (DGHistorial.CurrentRow != null)
                    {
                        int idTurno = Convert.ToInt32(DGHistorial.CurrentRow.Cells[0].Value);
                        string encargado = DGHistorial.CurrentRow.Cells[1].Value.ToString();
                        decimal bas = Convert.ToDecimal(DGHistorial.CurrentRow.Cells[2].Value);


                        var transicion = new Guna2Transition();
                        transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
                        transicion.ShowSync(this);
                        this.Hide();
                        DetalleTurno DT = new DetalleTurno(idTurno, encargado, bas);
                        DT.Show();
                        transicion.ShowSync(DT);
                    }
                }
            };

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
