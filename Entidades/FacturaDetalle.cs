using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Entidades
{
    // Clase publica que representa un renglon individual de la venta
    public class FacturaDetalle
    {

        // Clave primaria unica de la linea de detalle
        public int Id { get; set; }

        // Clave foranea que relaciona esta linea con la cabecera de la Factura
        public int FacturaId { get; set; }

        // Clave foranea que indica el producto vendido en este renglon
        public int ProductoId { get; set; }

        // Propiedad auxiliar que guarda el objeto Producto para mostrar su Nombre en las grillas de la UI
        public string ProductoNombre { get; set; } = string.Empty;

        // Cantidad de unidades compradas de este producto (debe ser mayor a cero)
        public int Cantidad { get; set; }

        // Precio unitario congelado en el instante exacto de emitir la factura
        public decimal PrecioUnitario { get; set; }

        // Subtotal calculado para la linea (Cantidad multiplicada por PrecioUnitario)
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
