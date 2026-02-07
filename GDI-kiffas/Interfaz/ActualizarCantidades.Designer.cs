using Guna.UI2.WinForms;

namespace GDI_kiffas.Interfaz
{
    partial class ActualizarCantidades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarCantidades));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEditar = new Guna2Button();
            btnGuardar = new Guna2Button();
            btnV = new Guna2Button();
            guna2Panel2 = new Guna2Panel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            guna2Panel3 = new Guna2Panel();
            DGVproductos = new Guna2DataGridView();
            txtBuscar = new Guna2TextBox();
            guna2Panel2.SuspendLayout();
            guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVproductos).BeginInit();
            SuspendLayout();
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Transparent;
            btnEditar.BorderRadius = 5;
            btnEditar.BorderThickness = 2;
            btnEditar.CustomizableEdges = customizableEdges1;
            btnEditar.DisabledState.BorderColor = Color.DarkGray;
            btnEditar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEditar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEditar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEditar.FillColor = Color.Cyan;
            btnEditar.Font = new Font("Arial Rounded MT Bold", 15.75F);
            btnEditar.ForeColor = Color.Black;
            btnEditar.Location = new Point(665, 13);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEditar.Size = new Size(136, 37);
            btnEditar.TabIndex = 28;
            btnEditar.Text = "Editar";
            btnEditar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.BorderRadius = 5;
            btnGuardar.BorderThickness = 2;
            btnGuardar.CustomizableEdges = customizableEdges3;
            btnGuardar.DisabledState.BorderColor = Color.DarkGray;
            btnGuardar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGuardar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGuardar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGuardar.FillColor = Color.Cyan;
            btnGuardar.Font = new Font("Arial Rounded MT Bold", 15.75F);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(348, 319);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnGuardar.Size = new Size(152, 41);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnV
            // 
            btnV.BackColor = Color.Transparent;
            btnV.BorderRadius = 30;
            btnV.CustomizableEdges = customizableEdges5;
            btnV.DisabledState.BorderColor = Color.DarkGray;
            btnV.DisabledState.CustomBorderColor = Color.DarkGray;
            btnV.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnV.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnV.FillColor = Color.Thistle;
            btnV.Font = new Font("Arial Rounded MT Bold", 15.75F);
            btnV.ForeColor = Color.White;
            btnV.Image = (Image)resources.GetObject("btnV.Image");
            btnV.ImageSize = new Size(60, 60);
            btnV.Location = new Point(12, 12);
            btnV.Name = "btnV";
            btnV.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnV.Size = new Size(60, 60);
            btnV.TabIndex = 24;
            btnV.Click += btnV_Click;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.Transparent;
            guna2Panel2.BorderColor = Color.Cyan;
            guna2Panel2.BorderRadius = 25;
            guna2Panel2.BorderThickness = 2;
            guna2Panel2.Controls.Add(guna2HtmlLabel7);
            guna2Panel2.CustomBorderColor = Color.Cyan;
            guna2Panel2.CustomizableEdges = customizableEdges7;
            guna2Panel2.FillColor = Color.Fuchsia;
            guna2Panel2.Location = new Point(163, 12);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel2.Size = new Size(584, 91);
            guna2Panel2.TabIndex = 29;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(104, 15);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Padding = new Padding(6, 2, 6, 2);
            guna2HtmlLabel7.Size = new Size(385, 61);
            guna2HtmlLabel7.TabIndex = 10;
            guna2HtmlLabel7.Text = "Editar Producto";
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.Transparent;
            guna2Panel3.BorderColor = Color.Cyan;
            guna2Panel3.BorderRadius = 25;
            guna2Panel3.BorderThickness = 2;
            guna2Panel3.Controls.Add(DGVproductos);
            guna2Panel3.Controls.Add(txtBuscar);
            guna2Panel3.Controls.Add(btnEditar);
            guna2Panel3.Controls.Add(btnGuardar);
            guna2Panel3.CustomBorderColor = Color.Cyan;
            guna2Panel3.CustomizableEdges = customizableEdges11;
            guna2Panel3.FillColor = Color.FromArgb(64, 64, 64);
            guna2Panel3.Location = new Point(33, 127);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel3.Size = new Size(824, 372);
            guna2Panel3.TabIndex = 30;
            // 
            // DGVproductos
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 237, 183);
            DGVproductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DGVproductos.BackgroundColor = Color.Gray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(241, 196, 15);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVproductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVproductos.ColumnHeadersHeight = 4;
            DGVproductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(251, 243, 207);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(245, 215, 95);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DGVproductos.DefaultCellStyle = dataGridViewCellStyle3;
            DGVproductos.GridColor = Color.FromArgb(249, 233, 170);
            DGVproductos.Location = new Point(16, 66);
            DGVproductos.Name = "DGVproductos";
            DGVproductos.RowHeadersVisible = false;
            DGVproductos.Size = new Size(792, 247);
            DGVproductos.TabIndex = 29;
            DGVproductos.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.SunFlower;
            DGVproductos.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(250, 237, 183);
            DGVproductos.ThemeStyle.AlternatingRowsStyle.Font = null;
            DGVproductos.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DGVproductos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DGVproductos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DGVproductos.ThemeStyle.BackColor = Color.Gray;
            DGVproductos.ThemeStyle.GridColor = Color.FromArgb(249, 233, 170);
            DGVproductos.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(241, 196, 15);
            DGVproductos.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DGVproductos.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            DGVproductos.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DGVproductos.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DGVproductos.ThemeStyle.HeaderStyle.Height = 4;
            DGVproductos.ThemeStyle.ReadOnly = false;
            DGVproductos.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(251, 243, 207);
            DGVproductos.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVproductos.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            DGVproductos.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            DGVproductos.ThemeStyle.RowsStyle.Height = 25;
            DGVproductos.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(245, 215, 95);
            DGVproductos.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderColor = Color.Gray;
            txtBuscar.BorderRadius = 5;
            txtBuscar.BorderThickness = 2;
            txtBuscar.CustomizableEdges = customizableEdges9;
            txtBuscar.DefaultText = "";
            txtBuscar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBuscar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBuscar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.ForeColor = Color.Black;
            txtBuscar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Location = new Point(294, 14);
            txtBuscar.Margin = new Padding(4, 3, 4, 3);
            txtBuscar.MaxLength = 20;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderForeColor = Color.Gray;
            txtBuscar.PlaceholderText = "Buscar por nombre o codigo...";
            txtBuscar.SelectedText = "";
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtBuscar.Size = new Size(252, 36);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // ActualizarCantidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FondoKiffa2;
            ClientSize = new Size(884, 511);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel2);
            Controls.Add(btnV);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ActualizarCantidades";
            Text = "KIFFA BAR";
            Load += ActualizarCantidades_Load;
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVproductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnEditar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2TextBox txtCodigoBarras;
        private Guna.UI2.WinForms.Guna2TextBox txtNombre;
        private Guna.UI2.WinForms.Guna2TextBox txtPU;
        private Guna.UI2.WinForms.Guna2TextBox txtCl;
        private Guna.UI2.WinForms.Guna2Button btnV;
        private Guna2Panel guna2Panel2;
        private Guna2HtmlLabel guna2HtmlLabel7;
        private Guna2Panel guna2Panel3;
        private Guna2TextBox txtBuscar;
        private Guna2DataGridView DGVproductos;
    }
}