namespace FacturacionApp
{
    partial class FormMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            btnProductos = new Button();
            btnFacturacion = new Button();
            btnConsultas = new Button();
            btnReportes = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Moccasin;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 451);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(260, 262);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(481, 203);
            button2.Name = "button2";
            button2.Size = new Size(53, 49);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(481, 114);
            button1.Name = "button1";
            button1.Size = new Size(53, 49);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(266, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(278, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.Maroon;
            btnProductos.FlatAppearance.BorderColor = Color.Black;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Location = new Point(266, 114);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(142, 30);
            btnProductos.TabIndex = 4;
            btnProductos.Text = "Gestion De Productos";
            btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnFacturacion
            // 
            btnFacturacion.BackColor = Color.Maroon;
            btnFacturacion.FlatAppearance.BorderColor = Color.Black;
            btnFacturacion.FlatStyle = FlatStyle.Flat;
            btnFacturacion.Location = new Point(266, 150);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(142, 30);
            btnFacturacion.TabIndex = 5;
            btnFacturacion.Text = "Emitir Factura";
            btnFacturacion.UseVisualStyleBackColor = false;
            btnFacturacion.Click += button4_Click;
            // 
            // btnConsultas
            // 
            btnConsultas.BackColor = Color.Maroon;
            btnConsultas.FlatAppearance.BorderColor = Color.Black;
            btnConsultas.FlatStyle = FlatStyle.Flat;
            btnConsultas.Location = new Point(266, 186);
            btnConsultas.Name = "btnConsultas";
            btnConsultas.Size = new Size(142, 30);
            btnConsultas.TabIndex = 6;
            btnConsultas.Text = "Consultar Facturas";
            btnConsultas.UseVisualStyleBackColor = false;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.Maroon;
            btnReportes.FlatAppearance.BorderColor = Color.Black;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Location = new Point(266, 222);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(142, 30);
            btnReportes.TabIndex = 7;
            btnReportes.Text = "Informe de Ventas";
            btnReportes.UseVisualStyleBackColor = false;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(535, 264);
            Controls.Add(button2);
            Controls.Add(btnReportes);
            Controls.Add(btnConsultas);
            Controls.Add(btnFacturacion);
            Controls.Add(btnProductos);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "FormMenu";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private Button button2;
        private Button btnProductos;
        private Button btnFacturacion;
        private Button btnConsultas;
        private Button btnReportes;
    }
}
