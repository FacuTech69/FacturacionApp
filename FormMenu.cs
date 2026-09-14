using FacturacionApp.Vistas_UI;
using System;
using System.Windows.Forms;

namespace FacturacionApp
{

    // Clase parcial heredada de Form (parcial porque la otra mitad la maneja el diseñador visual)
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            // Centramos el menú principal en la pantalla al iniciar
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Proyecto Realizado por Facundo Yrisarri", "Facturacion App", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Instanciamos el formulario 
            FormFacturacion formFacturacion = new FormFacturacion();
            // Lo abrimos 
            formFacturacion.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Instanciamos el formulario de productos
            FormProductos formProductos = new FormProductos();
            // Lo abrimos 
            formProductos.ShowDialog();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            // Instanciamos el formulario de historial
            FormConsultas formConsultas = new FormConsultas();
            // Lo abrimos 
            formConsultas.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // Instanciamos el formulario del informe simple
            FormReporte formReporte = new FormReporte();
            // Lo abrimos 
            formReporte.ShowDialog();
        }
    }
}
