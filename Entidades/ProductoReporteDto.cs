using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Entidades
{
    //Objeto DTO (Data Transfer Object) para mostrar los datos agregados del informe
    public class ProductoReporteDto
    {
        // Codigo comercial del producto reportado
        public string Codigo { get; set; } = string.Empty;

        // Nombre del producto reportado
        public string Nombre { get; set; } = string.Empty;

        // Total acumulado de unidades vendidas dentro del rango de fechas seleccionado
        public int CantidadTotalVendida { get; set; }

        // Monto total monetario acumulado vendido por este producto
        public decimal MontoTotalRecaudado { get; set; }
    }
}
