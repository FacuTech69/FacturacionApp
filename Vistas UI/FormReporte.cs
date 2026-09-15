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
using static FacturacionApp.Datos.FacturaDao;

namespace FacturacionApp.Vistas_UI
{
    public partial class FormReporte : Form
    {
        // Instancia del objeto DAO para comunicación con la base de datos
        private readonly FacturaDao _facturaDao;
        public FormReporte()
        {
            InitializeComponent();
            _facturaDao = new FacturaDao();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            // Configurar rango de fecha por defecto: del primer día del mes actual a la fecha de hoy
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Today;

            // Configuración de seguridad para el DataGridView (modo solo lectura)
            dgvReporte.ReadOnly = true;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Generar la primera consulta con las fechas por defecto
            GenerarReporte();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
        // Método principal para calcular métricas y cargar las grillas
        private void GenerarReporte()
        {
            try
            {
                DateTime desde = dtpDesde.Value;
                DateTime hasta = dtpHasta.Value;

                // Validación de coherencia de rango de fechas
                if (desde.Date > hasta.Date)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Obtener de la BD los productos vendidos agrupados en el rango de fechas
                List<ReporteProductoDto> reporteProductos = _facturaDao.ObtenerVentasPorProducto(desde, hasta);

                // Asignar el origen de datos a la grilla de productos
                dgvReporte.DataSource = null;
                dgvReporte.DataSource = reporteProductos;

                // Aplicar formato de moneda a la columna de Total Recaudado en la grilla
                if (dgvReporte.Columns["TotalRecaudado"] != null)
                {
                    dgvReporte.Columns["TotalRecaudado"].DefaultCellStyle.Format = "C2";
                    dgvReporte.Columns["TotalRecaudado"].HeaderText = "Total Recaudado ($)";
                }

                if (dgvReporte.Columns["CantidadVendida"] != null)
                {
                    dgvReporte.Columns["CantidadVendida"].HeaderText = "Unidades Vendidas";
                }

                // 2. Obtener facturas individuales para calcular métricas de totales y cantidades
                List<Factura> facturasDelPeriodo = _facturaDao.ObtenerFacturas(desde, hasta, "")
                                                    .Where(f => !f.Anulada) // Solo facturas activas
                                                    .ToList();

                // 3. Cálculos dinámicos utilizando LINQ
                decimal totalGeneral = facturasDelPeriodo.Sum(f => f.Total);
                int cantidadVentas = facturasDelPeriodo.Count;

                // 4. Mostrar métricas consolidadas en los Labels de pantalla
                lblTotalRecaudado.Text = $"Total Recaudado: {totalGeneral:C2}";
                lblCantidadFacturas.Text = $"Ventas Realizadas: {cantidadVentas}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el informe de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}