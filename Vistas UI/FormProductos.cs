using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionApp.Datos;
using FacturacionApp.Entidades;

namespace FacturacionApp.Vistas_UI
{
    public partial class FormProductos : Form
    {

        // Instanciamos el DAO a nivel de clase para usarlo en todos los botones
        private readonly ProductoDao _productoDao = new ProductoDao();

        // Variable para rastrear si estamos editando un producto existente (guarda su Id) o creando uno nuevo (valdrá 0)
        private int _idProductoSeleccionado = 0;

        public FormProductos()
        {
            InitializeComponent();
            // Centramos la ventana en pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            // Deshabilitamos la generación automática de columnas para que la grilla quede más limpia
            dgvProductos.AutoGenerateColumns = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            // Llamamos al método que consulta la base y llena la grilla
            CargarGrilla();
            LimpiarCampos();
        }

        // Método auxiliar para refrescar los datos de la grilla desde SQL
        private void CargarGrilla(string filtro = "")
        {
            // Pedimos la lista al DAO (con o sin filtro) y la asignamos como origen de datos de la grilla
            dgvProductos.DataSource = _productoDao.ObtenerTodos(filtro);
        }

        // Método auxiliar para vaciar las cajas de texto y preparar un ingreso nuevo
        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            chkActivo.Checked = true;
            _idProductoSeleccionado = 0; // Reseteamos el ID a 0 para indicar que es un registro nuevo
        }

        // Evento del botón Limpiar / Nuevo
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Recargamos la grilla pasando el texto que el usuario escribió en el buscador
            CargarGrilla(txtBuscar.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validación de interfaz (UI): Nombre y Código no pueden estar vacíos
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El código y el nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Cortamos la ejecución acá, no vamos a la base de datos
            }

            // 2. Validación de interfaz (UI): El precio debe ser un número válido y mayor o igual a cero
            if (!decimal.TryParse(txtPrecio.Text, out decimal precioParseado) || precioParseado < 0)
            {
                MessageBox.Show("Ingrese un precio válido (mayor o igual a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Armamos el objeto Entidad con los datos de las cajas de texto
            Producto producto = new Producto
            {
                Id = _idProductoSeleccionado, // Si es 0 es nuevo, si tiene número es edición
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Precio = precioParseado,
                Activo = chkActivo.Checked
            };

            // Bloque try-catch para capturar errores que vengan de SQL Server (ej: código duplicado)[cite: 2]
            try
            {
                // Si el ID es 0, significa que no seleccionamos nada de la grilla, entonces es un ALTA
                if (_idProductoSeleccionado == 0)
                {
                    _productoDao.Insertar(producto);
                    MessageBox.Show("Producto guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Si el ID tiene un número, estamos MODIFICANDO un registro existente
                    _productoDao.Actualizar(producto);
                    MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refrescamos la lista para ver los cambios y vaciamos las cajas de texto
                CargarGrilla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Si SQL falla (por la restricción UNIQUE del código u otro error de conexión), avisamos al usuario[cite: 2]
                MessageBox.Show("Error al guardar: " + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Evento que detecta cuando el usuario hace clic en un renglón de la grilla
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el clic haya sido en una fila válida (no en los títulos de las columnas)
            if (e.RowIndex >= 0)
            {
                // Obtenemos la fila entera que el usuario seleccionó
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                // Extraemos los valores de las celdas y los pasamos a las cajas de texto correspondientes
                _idProductoSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
                txtCodigo.Text = fila.Cells["Codigo"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validamos que haya un producto seleccionado previamente en la grilla
            if (_idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pedimos confirmación al usuario antes de ejecutar una operación destructiva[cite: 2]
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario dice que sí, procedemos
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Llamamos al DAO que internamente decidirá si hace baja lógica (Activo=0) o física (DELETE)[cite: 2]
                    _productoDao.EliminarOFisicaOLogica(_idProductoSeleccionado);
                    MessageBox.Show("Producto eliminado o dado de baja.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizamos la pantalla
                    CargarGrilla();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    // Capturamos cualquier error inesperado
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}

