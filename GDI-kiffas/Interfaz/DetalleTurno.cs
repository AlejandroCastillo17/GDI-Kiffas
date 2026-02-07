using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
    public partial class DetalleTurno : Form
    {
        private int _idTurno;
        private string _encargado;
        private decimal _base;

        public DetalleTurno(int id, string encargado, decimal bas)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;

            btnI.MouseEnter += btnI_MouseEnter;
            btnI.MouseLeave += btnI_MouseLeave;

            _idTurno = id;
            _encargado = encargado;
            _base = bas;
        }

        //****************************************************************************************

        // Logica

        private void DetalleTurno_Load(object sender, EventArgs e)
        {
            // ===== CONFIGURACIÓN GENERAL =====
            DG.EnableHeadersVisualStyles = false;
            DG.ReadOnly = true;
            DG.AllowUserToAddRows = false;
            DG.AllowUserToDeleteRows = false;
            DG.AllowUserToResizeColumns = false;
            DG.AllowUserToResizeRows = false;
            DG.RowHeadersVisible = false;
            DG.MultiSelect = false;
            DG.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DG.CurrentCell = null;
            DG.ColumnHeadersVisible = true;
            DG.ColumnHeadersHeight = 40;
            DG.AlternatingRowsDefaultCellStyle.BackColor = DG.RowsDefaultCellStyle.BackColor;
            DG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ===== ESTILO DE ENCABEZADOS =====
            DG.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.Purple
            };

            // ===== ESTILO DE CELDAS =====
            DG.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black
            };

            // ===== BORDES Y REJILLA =====
            DG.GridColor = Color.Black;
            DG.BorderStyle = BorderStyle.FixedSingle;
            DG.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // ===== CARGA DE DATOS Y CONFIGURACIÓN DE COLUMNAS =====
            lblEncargado.Text = $"Encargado: {_encargado}";
            lblBase.Text = $"Base: {_base:C}";

            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT producto, cantidad, ingreso, hora FROM ventas_turno WHERE id_turno = @id", conn);
                cmd.Parameters.AddWithValue("@id", _idTurno);

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                DG.DataSource = dt;

                // Configurar columnas solo si el DataTable tiene datos
                if (DG.Columns.Count >= 4)
                {
                    // Producto
                    DG.Columns["producto"].HeaderText = "Producto";
                    DG.Columns["producto"].Width = 150;

                    // Cantidad
                    DG.Columns["cantidad"].HeaderText = "Cantidad";
                    DG.Columns["cantidad"].Width = 90;

                    // Ingreso
                    DG.Columns["ingreso"].HeaderText = "Ingreso";
                    DG.Columns["ingreso"].Width = 110;
                    DG.Columns["ingreso"].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    };

                    // Hora
                    DG.Columns["hora"].HeaderText = "Hora";
                    DG.Columns["hora"].Width = 150;
                    DG.Columns["hora"].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd/MM/yyyy HH:mm",
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    };
                }

                // ===== CÁLCULO DE TOTALES =====
                decimal total = dt.AsEnumerable().Sum(r => r.Field<decimal>("ingreso"));
                lblTotal.Text = $"Total ventas: {total:C}";
                lblEnCaja.Text = $"Caja: {(_base + total):C}";
            }
        }

        private string textoFactura = "";
        private void btnI_Click(object sender, EventArgs e)
        {
            if (DG.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("       *** INFORME DE VENTAS DE TURNO KIFFA BAR ***");
            sb.AppendLine($"Encargado: {_encargado} - Base: {_base}");
            sb.AppendLine("----------------------------------------");

            foreach (DataGridViewRow fila in DG.Rows)
            {
                string producto = fila.Cells["producto"].Value?.ToString();
                string cantidad = fila.Cells["cantidad"].Value?.ToString();
                string fecha = Convert.ToDateTime(fila.Cells["hora"].Value).ToString("dd/MM");
                string ingreso = Convert.ToDecimal(fila.Cells["ingreso"].Value).ToString("C2");

                sb.AppendLine($"{fecha} - {producto}");
                sb.AppendLine($"Cant: {cantidad} | Ingreso: {ingreso}");
                sb.AppendLine("----------------------------------------");
            }

            sb.AppendLine($"{lblTotal.Text}");
            sb.AppendLine($"{lblEnCaja.Text}");
            sb.AppendLine("----------------------------------------");

            sb.AppendLine("        FIN DEL INFORME");
            textoFactura = sb.ToString();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirFactura);

            try
            {
                pd.Print(); // Enviar a impresora predeterminada
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }
        private void ImprimirFactura(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Font fuente = new System.Drawing.Font("Consolas", 9, FontStyle.Regular);
            e.Graphics.DrawString(textoFactura, fuente, Brushes.Black, new RectangleF(0, 0, 280, 10000));
        }
        private void btnV_Click(object sender, EventArgs e)
        {
            IrHT();
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

        // btnI
        private void btnI_MouseEnter(object sender, EventArgs e)
        {
            btnI.Size = new Size(116, 54);
            btnI.BackColor = Color.Transparent;
            btnI.FillColor = Color.Black;
            btnI.ForeColor = Color.Cyan;
        }

        private void btnI_MouseLeave(object sender, EventArgs e)
        {
            btnI.Size = new Size(113, 52);
            btnI.BackColor = Color.Transparent;
            btnI.FillColor = Color.Cyan;
            btnI.ForeColor = Color.Black;
        }

        //********************************************************************************************

        // Transiciones 

        private void IrHT()
        {
            var transicion = new Guna2Transition();
            transicion.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            transicion.ShowSync(this);


            this.Hide();


            HistorialTurnos HT = new HistorialTurnos();
            HT.Show();

            transicion.ShowSync(HT);
        }
    }
}
