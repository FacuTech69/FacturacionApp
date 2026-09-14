using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FacturacionApp.Datos
{
    // Clase encargada de administrar y entregar las conexiones a SQL Server
    public class ConexionDb
    {
        // Cadena de conexion pc de casa que indica el servidor local, la base de datos y la seguridad integrada
        private readonly string _cadenaConexion = "Server=.\\SQLEXPRESS;Database=FacturacionDb;Integrated Security=True;TrustServerCertificate=True;";


        // Cadena para la PC de la facultad
        // private readonly string _cadenaConexion = "Server=.;Database=FacturacionDb;Integrated Security=True;TrustServerCertificate=True;";


        // Método público que crea y retorna un objeto SqlConnection configurado
        public SqlConnection ObtenerConexion()
        {
            // Instancia un nuevo objeto SqlConnection pasándole la cadena definida arriba
            return new SqlConnection(_cadenaConexion);
        }



    }
}
