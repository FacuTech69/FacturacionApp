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
    public partial class FormFacturacion : Form
    {
        // DAOs para interactuar con productos y facturas
        private readonly ProductoDao _productoDao = new ProductoDao();
        private readonly FacturaDao _facturaDao = new FacturaDao();

        // Objeto Factura en memoria que actuara como cabecera y contendrá la lista de detalles
        private Factura _facturaActual = new Factura();

        public FormFacturacion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            CargarProductosCombo();
            ConfigurarGrillaDetalle();
            LimpiarFormulario();
        }

        // Carga los productos activos de la base de datos dentro del ComboBox
        private void CargarProductosCombo()
        {
            List<Producto> productos = _productoDao.ObtenerActivos();

            cmbProductos.DataSource = productos;
            cmbProductos.DisplayMember = "Nombre"; // Lo que el usuario ve en el desplegable
            cmbProductos.ValueMember = "Id";       // El valor oculto asociado a la seleccion
        }

        // Configura manualmente las columnas de la grilla del carrito
        private void ConfigurarGrillaDetalle()
        {
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.Columns.Clear();

            // Columna Producto
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductoNombre",
                HeaderText = "Producto",
                Width = 200
            });

            // Columna Precio Unitario
            var colPrecio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unit."
            };
            colPrecio.DefaultCellStyle.Format = "C2";
            dgvDetalle.Columns.Add(colPrecio);

            // Columna Cantidad
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cant."
            });

            // Columna Subtotal
            var colSubtotal = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal"
            };
            colSubtotal.DefaultCellStyle.Format = "C2";
            dgvDetalle.Columns.Add(colSubtotal);
        }
        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos que haya un producto seleccionado en el combo
            if (cmbProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos el producto seleccionado castceando el ítem del combo
            Producto prodSeleccionado = (Producto)cmbProductos.SelectedItem;
            int cantidad = (int)numCantidad.Value;

            // Verificamos si el producto ya esta agregado en el carrito para sumar la cantidad
            FacturaDetalle existente = _facturaActual.Detalles.Find(d => d.ProductoId == prodSeleccionado.Id);

            if (existente != null)
            {
                // Si ya existe, incrementamos su cantidad
                existente.Cantidad += cantidad;
            }
            else
            {
                // Si es un producto nuevo en el carrito, creamos un nuevo renglon de detalle
                FacturaDetalle nuevoDetalle = new FacturaDetalle
                {
                    ProductoId = prodSeleccionado.Id,
                    ProductoNombre = prodSeleccionado.Nombre,
                    PrecioUnitario = prodSeleccionado.Precio,
                    Cantidad = cantidad
                };

                _facturaActual.Detalles.Add(nuevoDetalle);
            }

            // Refrescamos la interfaz del carrito y recalculamos el total acumulado
            ActualizarCarrito();

        }

        // Actualiza el origen de datos de la grilla y calcula la suma total
        private void ActualizarCarrito()
        {
            // Reasignamos la lista para forzar la actualizacion del DataGridView
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = _facturaActual.Detalles;

            // Recalculamos el total acumulado de la cabecera
            _facturaActual.CalcularTotal();
            lblTotal.Text = $"Total: {_facturaActual.Total:C2}";
        }

        private void btnGrabarFactura_Click(object sender, EventArgs e)
        {
            // Validaciones de UI antes de ir a la base de datos
            if (string.IsNullOrWhiteSpace(txtClienteNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_facturaActual.Detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al carrito.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNumero.Text, out int numeroFactura) || numeroFactura <= 0)
            {
                MessageBox.Show("Ingrese un número de factura válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Poblamos los datos restantes de la cabecera
            _facturaActual.Numero = numeroFactura;
            _facturaActual.Fecha = dtpFecha.Value;
            _facturaActual.ClienteNombre = txtClienteNombre.Text.Trim();
            _facturaActual.ClienteDocumento = txtClienteDocumento.Text.Trim();

            try
            {
                // Llamamos al DAO que ejecutara la transaccion de forma atómica
                _facturaDao.InsertarFactura(_facturaActual);

                MessageBox.Show("¡Factura emitida e insertada en la base de datos con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Si la transaccion falla (Rollback), mostramos el mensaje retornado por el DAO
                MessageBox.Show(ex.Message, "Error al Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            // Vacia los campos para emitir un nuevo comprobante
        private void LimpiarFormulario()
        {
            _facturaActual = new Factura();
            txtNumero.Clear();
            txtClienteNombre.Clear();
            txtClienteDocumento.Clear();
            numCantidad.Value = 1;
            dtpFecha.Value = DateTime.Now;
            ActualizarCarrito();
        }
    }

}      
    

