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
using GDI_kiffas.Logica;
using GDI_kiffas.BD;
using MySql.Data.MySqlClient;

namespace GDI_kiffas.Interfaz
{
    public partial class MesasActivas : Form
    {
        private List<Mesas> mesasActivas = new List<Mesas>();

        public MesasActivas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(200, 100);
            this.MaximizeBox = false;
            this.Load += MesasActivas_Load;
        }

        private void MesasActivas_Load(object sender, EventArgs e)
        {
            CargarYRenderizarMesas();

            btnV.MouseEnter += btnV_MouseEnter;
            btnV.MouseLeave += btnV_MouseLeave;
        }

        private void CargarYRenderizarMesas()
        {
            mesasActivas = ObtenerMesasActivas();
            RenderizarMesas();
        }

        private List<Mesas> ObtenerMesasActivas()
        {
            var listaMesas = new List<Mesas>();

            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();

                var pedidosActivos = new List<int>();
                string sqlPedidos = "SELECT DISTINCT id_pedido FROM ventas WHERE mesa = TRUE;";

                using (var cmd = new MySqlCommand(sqlPedidos, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pedidosActivos.Add(reader.GetInt32("id_pedido"));
                    }
                }

                foreach (int pedidoId in pedidosActivos)
                {
                    var mesa = new Mesas
                    {
                        NombreMesa = "Mesa " + pedidoId
                    };

                    string sqlLineas = @"
                        SELECT producto, cantidad, precio
                        FROM ventas
                        WHERE mesa = TRUE AND id_pedido = @pid;
                    ";

                    using (var cmd2 = new MySqlCommand(sqlLineas, conn))
                    {
                        cmd2.Parameters.AddWithValue("@pid", pedidoId);

                        using (var reader2 = cmd2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                // Creamos un objeto Ventas para cada fila
                                var v = new Ventas
                                {
                                    producto = reader2.GetString("producto"),
                                    cantidad = reader2.GetInt32("cantidad"),
                                    precio = reader2.GetDecimal("precio"),
                                    // fecha no es estrictamente necesaria aquí
                                };
                                mesa.Ventas.Add(v);
                            }
                        }
                    }

                    listaMesas.Add(mesa);
                }
            }

            return listaMesas;
        }


        // 4) Renderiza la lista de mesas en el FlowLayoutPanel
        private void RenderizarMesas()
        {
            flpMesas.Controls.Clear();

            if (mesasActivas.Count == 0)
            {
                flpMesas.Controls.Add(new Label
                {
                    Text = "No hay mesas activas",
                    Font = new Font("Arial", 14, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true
                });
                return;
            }

            foreach (var mesa in mesasActivas)
            {
                var panelMesa = new Panel
                {
                    Width = 200,
                    Height = 200,
                    BorderStyle = BorderStyle.Fixed3D,
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    BackColor = Color.White
                };

                var lblNombre = new Label
                {
                    Text = mesa.NombreMesa,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.TopCenter

                };

                var lstProductos = new ListBox
                {
                    Height = 100,
                    Dock = DockStyle.Top,
                    BackColor = Color.Silver,
                    Font = new Font("Arial",9,FontStyle.Regular)
                };
                foreach (var v in mesa.Ventas)
                    lstProductos.Items.Add($"{v.producto} x{v.cantidad} = $ {v.precio:C2}");

                var lblTotal = new Label
                {
                    Text = $"Total: {mesa.CalcularTotal():C2}",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.BottomCenter
                };

                var btnPagar = new Button
                {
                    Text = "Pagado",
                    Height = 30,
                    Dock = DockStyle.Bottom,
                    BackColor = Color.Green,
                    ForeColor = Color.White
                };
                btnPagar.Click += (s, e) =>
                {
                    MarcarMesaPagada(mesa);
                    CargarYRenderizarMesas();
                };

                panelMesa.Controls.Add(btnPagar);
                panelMesa.Controls.Add(lblTotal);
                panelMesa.Controls.Add(lstProductos);
                panelMesa.Controls.Add(lblNombre);

                flpMesas.Controls.Add(panelMesa);
            }
        }
        private void MarcarMesaPagada(Mesas mesa)
        {
            if (!int.TryParse(mesa.NombreMesa.Replace("Mesa ", ""), out int pedidoId))
                return;

            using (var conn = Conexion.ObtenerConexion())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"UPDATE ventas SET mesa = FALSE WHERE mesa = TRUE AND id_pedido = @pid;";
                cmd.Parameters.AddWithValue("@pid", pedidoId);
                cmd.ExecuteNonQuery();
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


            Menu menu = new Menu();
            menu.Show();

            transicion.ShowSync(menu);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        /*private void btnAM_Click(object sender, EventArgs e)
        {
            Mesas nuevaMesa = new Mesas
            {
                NombreMesa = $"Mesa {mesasActivas.Count + 1}",
                Ventas = new List<Ventas>
                {
                    new Ventas { producto = "Hamburguesa", precio = 12000 },
                    new Ventas { producto = "Bebida", precio = 3000 }
                }
            };

            mesasActivas.Add(nuevaMesa);
            RenderizarMesas();

        }*/
    }
}
