namespace FacturacionApp.Vistas_UI
{
    partial class FormReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporte));
            pictureBox1 = new PictureBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnGenerarReporte = new Button();
            lblTotalRecaudado = new Label();
            lblCantidadFacturas = new Label();
            dgvReporte = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(63, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDesde.Location = new Point(5, 180);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(61, 21);
            lblDesde.TabIndex = 1;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(72, 180);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(200, 23);
            dtpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHasta.Location = new Point(5, 228);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(57, 21);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(72, 227);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(200, 23);
            dtpHasta.TabIndex = 4;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.Maroon;
            btnGenerarReporte.FlatAppearance.BorderColor = Color.Black;
            btnGenerarReporte.FlatStyle = FlatStyle.Flat;
            btnGenerarReporte.ForeColor = SystemColors.ButtonHighlight;
            btnGenerarReporte.Location = new Point(72, 267);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(200, 36);
            btnGenerarReporte.TabIndex = 5;
            btnGenerarReporte.Text = "Generar Informe";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // lblTotalRecaudado
            // 
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRecaudado.Location = new Point(5, 324);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new Size(241, 30);
            lblTotalRecaudado.TabIndex = 6;
            lblTotalRecaudado.Text = "Total Recaudado: $0.00";
            // 
            // lblCantidadFacturas
            // 
            lblCantidadFacturas.AutoSize = true;
            lblCantidadFacturas.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidadFacturas.Location = new Point(5, 369);
            lblCantidadFacturas.Name = "lblCantidadFacturas";
            lblCantidadFacturas.Size = new Size(209, 30);
            lblCantidadFacturas.TabIndex = 7;
            lblCantidadFacturas.Text = "Ventas Realizadas: 0";
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(364, -1);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(435, 451);
            dgvReporte.TabIndex = 8;
            // 
            // FormReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvReporte);
            Controls.Add(lblCantidadFacturas);
            Controls.Add(lblTotalRecaudado);
            Controls.Add(btnGenerarReporte);
            Controls.Add(dtpHasta);
            Controls.Add(lblHasta);
            Controls.Add(dtpDesde);
            Controls.Add(lblDesde);
            Controls.Add(pictureBox1);
            Name = "FormReporte";
            Text = "FormReporte";
            Load += FormReporte_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnGenerarReporte;
        private Label lblTotalRecaudado;
        private Label lblCantidadFacturas;
        private DataGridView dgvReporte;
    }
}