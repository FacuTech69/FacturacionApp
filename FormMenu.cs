using FacturacionApp.Vistas_UI;

namespace FacturacionApp
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
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
            // Instanciamos el formulario de maestro-detalle
            FormFacturacion formFacturacion = new FormFacturacion();
            // Lo abrimos de forma modal
            formFacturacion.ShowDialog();
        }
    }
}
