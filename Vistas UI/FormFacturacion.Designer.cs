namespace FacturacionApp.Vistas_UI
{
    partial class FormFacturacion
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
            txtNumero = new TextBox();
            txtClienteNombre = new TextBox();
            txtClienteDocumento = new TextBox();
            dtpFecha = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbProductos = new ComboBox();
            numCantidad = new NumericUpDown();
            btnAgregar = new Button();
            dgvDetalle = new DataGridView();
            lblTotal = new Label();
            btnGrabarFactura = new Button();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(163, 14);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(100, 23);
            txtNumero.TabIndex = 0;
            // 
            // txtClienteNombre
            // 
            txtClienteNombre.Location = new Point(163, 50);
            txtClienteNombre.Name = "txtClienteNombre";
            txtClienteNombre.Size = new Size(100, 23);
            txtClienteNombre.TabIndex = 1;
            // 
            // txtClienteDocumento
            // 
            txtClienteDocumento.Location = new Point(163, 92);
            txtClienteDocumento.Name = "txtClienteDocumento";
            txtClienteDocumento.Size = new Size(100, 23);
            txtClienteDocumento.TabIndex = 2;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(12, 139);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(251, 23);
            dtpFecha.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(145, 15);
            label1.TabIndex = 4;
            label1.Text = "Numero de comprobante:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 5;
            label2.Text = "Nombre del Cliente:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 95);
            label3.Name = "label3";
            label3.Size = new Size(125, 15);
            label3.TabIndex = 6;
            label3.Text = "DNI o CUIT del cliente:";
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(12, 179);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(121, 23);
            cmbProductos.TabIndex = 7;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(139, 180);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(120, 23);
            numCantidad.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(54, 350);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(164, 36);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar al Carrito";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(272, 0);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(528, 448);
            dgvDetalle.TabIndex = 10;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(12, 293);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(133, 30);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total: $ 0.00";
            // 
            // btnGrabarFactura
            // 
            btnGrabarFactura.Location = new Point(54, 402);
            btnGrabarFactura.Name = "btnGrabarFactura";
            btnGrabarFactura.Size = new Size(164, 36);
            btnGrabarFactura.TabIndex = 12;
            btnGrabarFactura.Text = "Confirmar y Emitir Factura";
            btnGrabarFactura.UseVisualStyleBackColor = true;
            btnGrabarFactura.Click += btnGrabarFactura_Click;
            // 
            // FormFacturacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGrabarFactura);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalle);
            Controls.Add(btnAgregar);
            Controls.Add(numCantidad);
            Controls.Add(cmbProductos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFecha);
            Controls.Add(txtClienteDocumento);
            Controls.Add(txtClienteNombre);
            Controls.Add(txtNumero);
            Name = "FormFacturacion";
            Text = "FormFacturacion";
            Load += FormFacturacion_Load;
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumero;
        private TextBox txtClienteNombre;
        private TextBox txtClienteDocumento;
        private DateTimePicker dtpFecha;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbProductos;
        private NumericUpDown numCantidad;
        private Button btnAgregar;
        private DataGridView dgvDetalle;
        private Label lblTotal;
        private Button btnGrabarFactura;
    }
}