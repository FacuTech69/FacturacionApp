using FacturacionApp.Datos;
using FacturacionApp.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionApp.Vistas_UI
{
    public partial class FormConsultas : Form
    {
        private readonly FacturaDao _facturaDao;
        public FormConsultas()
        {
            InitializeComponent();
            _facturaDao = new FacturaDao();
        }

        private void FormConsultas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
            // Bloquea la edición manual de celdas
            dgvFacturas.ReadOnly = true;
            dgvDetalle.ReadOnly = true;

            // Evita que aparezca la fila vacía al final para agregar filas manualmente
            dgvFacturas.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToAddRows = false;
        }

        private void CargarFacturas(string busqueda = "")
        {
            try
            {
                // Rango seguro por defecto para evitar el desbordamiento de fecha
                DateTime desde = new DateTime(2000, 1, 1);
                DateTime hasta = DateTime.Today;

                List<Factura> facturas = _facturaDao.ObtenerFacturas(desde, hasta, busqueda);

                dgvFacturas.DataSource = null;
                dgvFacturas.DataSource = facturas;

                dgvDetalle.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarFacturas(txtBuscar.Text.Trim());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarFacturas();
        }

        // Al hacer clic en una fila de la grilla de facturas, se cargan automáticamente sus productos abajo
        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                try
                {
                    int idFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["Id"].Value);

                    // Método coincidente con la clase FacturaDao
                    List<FacturaDetalle> detalle = _facturaDao.ObtenerDetalleFactura(idFactura);

                    dgvDetalle.DataSource = null;
                    dgvDetalle.DataSource = detalle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el detalle de la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
