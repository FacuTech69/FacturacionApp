using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Entidades
{
    // Clase publica que representa la cabecera principal de un comprobante de venta
    public class Factura
    {
        // Clave primaria unica de la factura en la base de datos
        public int Id { get; set; }

        // Numero correlativo visible para el cliente y el comercio
        public int Numero { get; set; }

        // Fecha y hora exacta de emision de la factura (por defecto asigna la fecha actual)
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Nombre y apellido completo del cliente
        public string ClienteNombre { get; set; } = string.Empty;

        // Documento de identificacion fiscal o personal del cliente (DNI o CUIT)
        public string ClienteDocumento { get; set; } = string.Empty;

        // Monto total acumulado de la factura
        public decimal Total { get; set; }

        // Coleccion de renglones o lineas asociadas a esta cabecera
        public List<FacturaDetalle> Detalles { get; set; } = new List<FacturaDetalle>();

        //Propiedad opcional para manejar el estado de anulacion 

        public bool Anulada { get; set; }
    }
}
