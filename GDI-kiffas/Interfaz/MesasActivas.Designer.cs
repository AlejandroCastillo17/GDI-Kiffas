namespace GDI_kiffas.Interfaz
{
    partial class MesasActivas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MesasActivas));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flpMesas = new FlowLayoutPanel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnV = new Guna.UI2.WinForms.Guna2Button();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel3.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flpMesas
            // 
            flpMesas.BackColor = Color.Black;
            flpMesas.BorderStyle = BorderStyle.Fixed3D;
            flpMesas.ForeColor = Color.Black;
            flpMesas.Location = new Point(21, 24);
            flpMesas.Name = "flpMesas";
            flpMesas.Size = new Size(780, 298);
            flpMesas.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.Black;
            guna2HtmlLabel1.Location = new Point(15, 14);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Padding = new Padding(6, 2, 6, 2);
            guna2HtmlLabel1.Size = new Size(352, 61);
            guna2HtmlLabel1.TabIndex = 10;
            guna2HtmlLabel1.Text = "Mesas Activas";
            guna2HtmlLabel1.Click += guna2HtmlLabel1_Click;
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
            btnV.TabIndex = 9;
            btnV.Click += btnV_Click;
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.Transparent;
            guna2Panel3.BorderColor = Color.Cyan;
            guna2Panel3.BorderRadius = 25;
            guna2Panel3.BorderThickness = 2;
            guna2Panel3.Controls.Add(flpMesas);
            guna2Panel3.CustomBorderColor = Color.Cyan;
            guna2Panel3.CustomizableEdges = customizableEdges3;
            guna2Panel3.FillColor = Color.FromArgb(64, 64, 64);
            guna2Panel3.Location = new Point(31, 137);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel3.Size = new Size(828, 346);
            guna2Panel3.TabIndex = 11;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.Cyan;
            guna2Panel1.BorderRadius = 25;
            guna2Panel1.BorderThickness = 2;
            guna2Panel1.Controls.Add(guna2HtmlLabel1);
            guna2Panel1.CustomBorderColor = Color.Cyan;
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.FillColor = Color.Fuchsia;
            guna2Panel1.Location = new Point(267, 21);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(383, 91);
            guna2Panel1.TabIndex = 12;
            // 
            // MesasActivas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FondoKiffa2;
            ClientSize = new Size(884, 511);
            Controls.Add(guna2Panel1);
            Controls.Add(guna2Panel3);
            Controls.Add(btnV);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MesasActivas";
            Text = "KIFFA BAR";
            guna2Panel3.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpMesas;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnV;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}