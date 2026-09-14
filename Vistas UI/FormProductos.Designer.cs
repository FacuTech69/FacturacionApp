namespace FacturacionApp.Vistas_UI
{
    partial class FormProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductos));
            dgvProductos = new DataGridView();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtBuscar = new TextBox();
            chkActivo = new CheckBox();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            btnBuscar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(2, 1);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(368, 357);
            dgvProductos.TabIndex = 0;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(132, 11);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(132, 114);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(132, 56);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 3;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(132, 157);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 23);
            txtBuscar.TabIndex = 4;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(6, 205);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(128, 19);
            chkActivo.TabIndex = 5;
            chkActivo.Text = "Producto a la Venta";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(6, 306);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(109, 31);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(123, 306);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(109, 31);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(123, 257);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(109, 31);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(6, 257);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(109, 31);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 13);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 10;
            label1.Text = "Codigo del Producto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 64);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 11;
            label2.Text = "Nombre:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 114);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 12;
            label3.Text = "Valor Numerico:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 160);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 13;
            label4.Text = "Buscar:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Moccasin;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtCodigo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(chkActivo);
            panel1.Controls.Add(txtPrecio);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(txtNombre);
            panel1.Location = new Point(367, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 357);
            panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(257, 257);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 360);
            Controls.Add(panel1);
            Controls.Add(dgvProductos);
            Name = "FormProductos";
            Text = "FormProductos";
            Load += FormProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductos;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtBuscar;
        private CheckBox chkActivo;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Button btnBuscar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
        private PictureBox pictureBox1;
    }
}