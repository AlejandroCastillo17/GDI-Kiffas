using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GDI_kiffas.BD;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using GDI_kiffas.Logica;

namespace GDI_kiffas.Interfaz
{
    public partial class Informes : Form
    {
        public Informes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;

            btnD.MouseEnter += btnD_MouseEnter;
            btnD.MouseLeave += btnD_MouseLeave;

            btnI.MouseEnter += btnI_MouseEnter;
            btnI.MouseLeave += btnI_MouseLeave;
        }

        //****************************************************************************************

        // Logica

        private void Informes_Load(object sender, EventArgs e)
        {
            // Establecer rango predeterminado (últimos 7 días)
            DTPinicio.Value = DateTime.Now.AddDays(-7);
            DTPfin.Value = DateTime.Now;

            // Cargar el informe con la fecha predeterminada
            CargarInforme();
            CalcularUtilidad();
            CalcularVentaTotal();
            diseñoDG();
        }

        private void CargarInforme()
        {
            try
            {
                if (DGinforme == null)
                {
                    MessageBox.Show("El DataGridView no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime fechaInicio = DTPinicio.Value.Date;
                DateTime fechaFin = DTPfin.Value.Date;

                string query = @"
                    SELECT
                        v.producto AS 'Producto',
                        SUM(v.cantidad) AS 'Cantidad',
                        v.fecha AS 'Fecha',
                        SUM(v.precio) AS 'Ingreso Total',
                        SUM(v.cantidad * p.Costo_lote) AS 'Costo',
                        SUM(v.precio) - SUM(v.cantidad * p.Costo_lote) AS 'Ganancia Neta'
                    FROM ventas v
                    INNER JOIN productos p ON v.producto = p.nombre
                    WHERE v.fecha BETWEEN @fechaInicio AND @fechaFin
                    GROUP BY v.fecha, v.producto
                    ORDER BY v.fecha, v.producto;
                ";

                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        DGinforme.DataSource = dt;
                    }
                }

                if (DGinforme.Columns.Count == 0)
                {
                    MessageBox.Show("No se encontraron columnas en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el informe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularUtilidad()
        {
            try
            {
                if (DGinforme.Rows.Count == 0) return; // Evita error si no hay datos

                decimal totalVentas = 0;
                decimal totalCostoMateriaPrima = 0;

                foreach (DataGridViewRow row in DGinforme.Rows)
                {
                    if (row.Cells["Ingreso Total"].Value != DBNull.Value && row.Cells["Costo"].Value != DBNull.Value)
                    {
                        decimal precio = Convert.ToDecimal(row.Cells["Ingreso Total"].Value);
                        decimal costoMateriaPrima = Convert.ToDecimal(row.Cells["Costo"].Value);

                        totalVentas += precio;
                        totalCostoMateriaPrima += costoMateriaPrima;
                    }
                }

                decimal utilidadGeneral = totalVentas - totalCostoMateriaPrima;
                lblutilidad.Text = "Utilidad general: $" + utilidadGeneral.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la utilidad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularVentaTotal()
        {
            try
            {
                if (DGinforme.Rows.Count == 0) return; // Evita error si no hay datos

                decimal totalVentas = 0;

                foreach (DataGridViewRow row in DGinforme.Rows)
                {
                    if (row.Cells["Ingreso Total"].Value != DBNull.Value)
                    {
                        decimal precio = Convert.ToDecimal(row.Cells["Ingreso Total"].Value);

                        totalVentas += precio;
                    }
                }

                lblventa.Text = "Venta Total: $" + totalVentas.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la venta total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void diseñoDG()
        {
            // ===== CONFIGURACIÓN GENERAL =====
            DGinforme.EnableHeadersVisualStyles = false;
            DGinforme.ReadOnly = true;
            DGinforme.AllowUserToAddRows = false;
            DGinforme.AllowUserToDeleteRows = false;
            DGinforme.AllowUserToResizeColumns = false;
            DGinforme.AllowUserToResizeRows = false;
            DGinforme.RowHeadersVisible = false;
            DGinforme.MultiSelect = false;
            DGinforme.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DGinforme.CurrentCell = null;
            DGinforme.ColumnHeadersVisible = true;
            DGinforme.ColumnHeadersHeight = 40;
            DGinforme.AlternatingRowsDefaultCellStyle.BackColor = DGinforme.RowsDefaultCellStyle.BackColor;
            DGinforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // ===== ESTILO DE ENCABEZADOS =====
            DGinforme.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Purple,
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.Purple
            };

            // ===== ESTILO DE CELDAS =====
            DGinforme.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.Silver,
                SelectionForeColor = Color.Black
            };

            // ===== BORDES Y REJILLA =====
            DGinforme.GridColor = Color.Black;
            DGinforme.BorderStyle = BorderStyle.FixedSingle;
            DGinforme.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // ===== CONFIGURAR ANCHOS Y FORMATOS DE COLUMNAS =====
            // 0: Producto
            DGinforme.Columns[0].Width = 120;

            // 1: Cantidad
            DGinforme.Columns[1].Width = 100;

            // 2: Fecha
            DGinforme.Columns[2].Width = 115;
            DGinforme.Columns[2].DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy",
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // 3: Ingreso total
            DGinforme.Columns[3].Width = 110;
            DGinforme.Columns[3].DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C2",
                Alignment = DataGridViewContentAlignment.MiddleRight
            };

            // 4: Costo total de materia prima
            DGinforme.Columns[4].Width = 100;
            DGinforme.Columns[4].DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C2",
                Alignment = DataGridViewContentAlignment.MiddleRight
            };

            // 5: Ganancia neta
            DGinforme.Columns[5].Width = 155;
            DGinforme.Columns[5].DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C2",
                Alignment = DataGridViewContentAlignment.MiddleRight
            };
        }


        private void DTPinicio_ValueChanged(object sender, EventArgs e)
        {
            CargarInforme();
            CalcularUtilidad();
            CalcularVentaTotal();
        }

        private void DTPfin_ValueChanged(object sender, EventArgs e)
        {
            CargarInforme();
            CalcularUtilidad();
            CalcularVentaTotal();
        }

        private string textoFactura = "";

        private void btnI_Click(object sender, EventArgs e)
        {
            if (DGinforme.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("       *** INFORME DE VENTAS KIFFA BAR ***");
            sb.AppendLine($"Del: {DTPinicio.Value:dd/MM/yyyy}  Al: {DTPfin.Value:dd/MM/yyyy}");
            sb.AppendLine("----------------------------------------");

            foreach (DataGridViewRow fila in DGinforme.Rows)
            {
                string producto = fila.Cells["Producto"].Value?.ToString();
                string cantidad = fila.Cells["Cantidad"].Value?.ToString();
                string fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value).ToString("dd/MM");
                string ingreso = Convert.ToDecimal(fila.Cells["Ingreso Total"].Value).ToString("C2");
                string ganancia = Convert.ToDecimal(fila.Cells["Ganancia Neta"].Value).ToString("C2");

                sb.AppendLine($"{fecha} - {producto}");
                sb.AppendLine($"Cant: {cantidad} | Ingreso: {ingreso} | Ganancia: {ganancia}");
                sb.AppendLine("----------------------------------------");
            }

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

        private void ExportarAPDF(DataGridView dgv, string titulo, string balance)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Guardar reporte"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Document documento = new iTextSharp.text.Document(PageSize.A4);
                PdfWriter.GetInstance(documento, new FileStream(saveFileDialog.FileName, FileMode.Create));
                documento.Open();

                // ❗ Especificar el namespace correcto para evitar conflicto
                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                iTextSharp.text.Font fuenteFecha = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                iTextSharp.text.Font fuenteTabla = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                iTextSharp.text.Font fuenteBalance = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.RED);

                // Título centrado
                Paragraph tituloParrafo = new Paragraph(titulo, fuenteTitulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                documento.Add(new Paragraph("\n"));
                documento.Add(new Paragraph("\n"));
                documento.Add(new Paragraph("\n"));
                documento.Add(new Paragraph("\n"));
                documento.Add(new Paragraph("\n"));
                documento.Add(tituloParrafo);

                // Fecha alineada a la derecha
                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Paragraph fechaParrafo = new Paragraph("Fecha: " + fechaActual, fuenteFecha)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                documento.Add(fechaParrafo);

                // Espacio antes de la tabla
                documento.Add(new Paragraph("\n"));

                // Crear la tabla con el número de columnas del DataGridView
                PdfPTable tabla = new PdfPTable(dgv.Columns.Count);
                tabla.WidthPercentage = 100;

                // Agregar encabezados con color de fondo
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText, fuenteTabla))
                    {
                        BackgroundColor = BaseColor.ORANGE,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celda);
                }

                // Agregar filas con datos
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        tabla.AddCell(new Phrase(celda.Value?.ToString() ?? "", fuenteTabla));
                    }
                }

                documento.Add(tabla);

                // Espacio antes del balance
                documento.Add(new Paragraph("\n"));

                // Balance de utilidad centrado y en negrita
                Paragraph balanceParrafo = new Paragraph(balance, fuenteBalance)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                documento.Add(balanceParrafo);

                documento.Close();

                MessageBox.Show("Exportado con éxito.", "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnD_Click(object sender, EventArgs e)
        {
            ExportarAPDF(DGinforme, "Informe de utilidades", lblutilidad.Text);
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
        }

        private void btnV_MouseLeave(object sender, EventArgs e)
        {
            btnV.Size = new Size(60, 60);
        }

        //btnD
        private void btnD_MouseEnter(object sender, EventArgs e)
        {
            btnD.Size = new Size(158, 63);
            btnD.BackColor = Color.Transparent;
            btnD.FillColor = Color.Black;
            btnD.ForeColor = Color.Cyan;
        }

        private void btnD_MouseLeave(object sender, EventArgs e)
        {
            btnD.Size = new Size(152, 61);
            btnD.BackColor = Color.Transparent;
            btnD.FillColor = Color.Cyan;
            btnD.ForeColor = Color.Black;
        }

        //btnI
        private void btnI_MouseEnter(object sender, EventArgs e)
        {
            btnI.Size = new Size(158, 63);
            btnI.BackColor = Color.Transparent;
            btnI.FillColor = Color.Black;
            btnI.ForeColor = Color.Cyan;
        }

        private void btnI_MouseLeave(object sender, EventArgs e)
        {
            btnI.Size = new Size(152, 61);
            btnI.BackColor = Color.Transparent;
            btnI.FillColor = Color.Cyan;
            btnI.ForeColor = Color.Black;
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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
