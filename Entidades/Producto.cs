using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FacturacionApp.Entidades
{
    //Clase publica que representa la entidad Producto 
    public class Producto
    {
        //Clave primaria que va incrementandose
        public int Id { get; set; }

        // Codigo comercial Ingresado por el usuario para identificar el producto
        public string Codigo { get; set; } = string.Empty;


        //Nombre o descripcion del producto

        public string Nombre { get; set; } = string.Empty;

        //Precio de venta actual del producto en el catalogo

        public decimal Precio { get; set; } 

        //Indica si el producto esta disponible para ser vendible 
        public bool Activo { get; set; } = true; // Default en true


        //Sobrescribimos ToString para que al mostrar el producto en combos visuales se lea el Nombre y Precio

        public override string ToString()
        {
            return  Codigo + " - " + Nombre  + " ($" + Precio + ")";

        }
    }
}
