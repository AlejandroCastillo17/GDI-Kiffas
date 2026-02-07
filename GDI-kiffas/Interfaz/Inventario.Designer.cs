namespace GDI_kiffas.Interfaz
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnV = new Guna.UI2.WinForms.Guna2Button();
            DGVproductos = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            cmb = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVproductos).BeginInit();
            guna2Panel1.SuspendLayout();
            guna2Panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnV
            // 
            btnV.BackColor = Color.Transparent;
            btnV.BorderRadius = 30;
            btnV.CustomizableEdges = customizableEdges1;
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
            btnV.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnV.Size = new Size(60, 60);
            btnV.TabIndex = 4;
            btnV.Click += btnV_Click;
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
            DGVproductos.Location = new Point(47, 186);
            DGVproductos.Name = "DGVproductos";
            DGVproductos.RowHeadersVisible = false;
            DGVproductos.Size = new Size(792, 283);
            DGVproductos.TabIndex = 5;
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
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.Cyan;
            guna2Panel1.BorderRadius = 25;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.CustomBorderColor = Color.Cyan;
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.FillColor = Color.Fuchsia;
            guna2Panel1.Location = new Point(92, 12);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(500, 91);
            guna2Panel1.TabIndex = 13;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(15, 14);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Padding = new Padding(6, 2, 6, 2);
            guna2HtmlLabel1.Size = new Size(476, 61);
            guna2HtmlLabel1.TabIndex = 10;
            guna2HtmlLabel1.Text = "Productos Kiffa Bar";
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.Transparent;
            guna2Panel3.BorderColor = Color.Cyan;
            guna2Panel3.BorderRadius = 25;
            guna2Panel3.BorderThickness = 2;
            guna2Panel3.Controls.Add(txtBuscar);
            guna2Panel3.CustomBorderColor = Color.Cyan;
            guna2Panel3.CustomizableEdges = customizableEdges7;
            guna2Panel3.FillColor = Color.FromArgb(64, 64, 64);
            guna2Panel3.Location = new Point(31, 124);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel3.Size = new Size(824, 366);
            guna2Panel3.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderColor = Color.Gray;
            txtBuscar.BorderRadius = 5;
            txtBuscar.BorderThickness = 2;
            txtBuscar.CustomizableEdges = customizableEdges5;
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
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtBuscar.Size = new Size(252, 36);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // cmb
            // 
            cmb.BackColor = Color.Transparent;
            cmb.BorderColor = Color.Black;
            cmb.BorderRadius = 10;
            cmb.CustomizableEdges = customizableEdges9;
            cmb.DrawMode = DrawMode.OwnerDrawFixed;
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.FillColor = Color.Cyan;
            cmb.FocusedColor = Color.FromArgb(94, 148, 255);
            cmb.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb.ForeColor = Color.Black;
            cmb.ItemHeight = 30;
            cmb.Location = new Point(615, 36);
            cmb.Name = "cmb";
            cmb.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cmb.Size = new Size(257, 36);
            cmb.TabIndex = 15;
            cmb.SelectedIndexChanged += cmb_SelectedIndexChanged;
            cmb.Click += cmb_Click;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(884, 511);
            Controls.Add(cmb);
            Controls.Add(DGVproductos);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel1);
            Controls.Add(btnV);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inventario";
            Text = "KIFFA BAR";
            Load += Inventario_Load;
            ((System.ComponentModel.ISupportInitialize)DGVproductos).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnV;
        private Guna.UI2.WinForms.Guna2DataGridView DGVproductos;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private Guna.UI2.WinForms.Guna2ComboBox cmb;
    }
}