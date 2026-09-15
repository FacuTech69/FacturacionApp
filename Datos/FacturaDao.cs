using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionApp.Entidades;
using Microsoft.Data.SqlClient;

namespace FacturacionApp.Datos
{
    // Clase DAO responsable de administrar las facturas, detalles y reportes
    public class FacturaDao
    {

        // Instancia privada para obtener conexiones a la base de datos
        private readonly ConexionDb _conexionDb = new ConexionDb();

        // Método transaccional para guardar cabecera y detalle en bloque
        public void InsertarFactura(Factura factura)
        {
            // Bloque using para asegurar el cierre de la conexion
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Abrimos la conexion antes de iniciar la transaccion
                conexion.Open();

                // Iniciamos una transaccion local en esta conexion
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    // Bloque try para capturar cualquier error durante los inserts
                    try
                    {
                        // Consulta para insertar la cabecera usando OUTPUT INSERTED.Id para recuperar el ID generado
                        string queryCabecera = "INSERT INTO Facturas (Numero, Fecha, ClienteNombre, ClienteDocumento, Total) " +
                                               "OUTPUT INSERTED.Id " +
                                               "VALUES (@Numero, @Fecha, @ClienteNombre, @ClienteDocumento, @Total)";

                        // Creamos el comando asociandolo a la conexion y a la transaccion actual[cite: 1, 2]
                        using (SqlCommand cmdCabecera = new SqlCommand(queryCabecera, conexion, transaccion))
                        {
                            // Asignamos el parametro Numero[cite: 1, 2]
                            cmdCabecera.Parameters.AddWithValue("@Numero", factura.Numero);
                            // Asignamos el parametro Fecha
                            cmdCabecera.Parameters.AddWithValue("@Fecha", factura.Fecha);
                            // Asignamos el parametro ClienteNombre
                            cmdCabecera.Parameters.AddWithValue("@ClienteNombre", factura.ClienteNombre);
                            // Asignamos el parametro ClienteDocumento
                            cmdCabecera.Parameters.AddWithValue("@ClienteDocumento", factura.ClienteDocumento);
                            // Asignamos el parametro Total
                            cmdCabecera.Parameters.AddWithValue("@Total", factura.Total);

                            // Ejecutamos y capturamos el ID autoincremental que SQL le asigno a la factura
                            factura.Id = (int)cmdCabecera.ExecuteScalar();
                        }

                        // Consulta para insertar cada renglon del detalle
                        string queryDetalle = "INSERT INTO FacturaDetalle (FacturaId, ProductoId, Cantidad, PrecioUnitario, Subtotal) " +
                                              "VALUES (@FacturaId, @ProductoId, @Cantidad, @PrecioUnitario, @Subtotal)";

                        // Iteramos sobre cada renglon de la lista de detalles en memoria
                        foreach (var detalle in factura.Detalles)
                        {
                            // Creamos un nuevo comando para insertar este renglon particular, dentro de la misma transaccion[cite: 1, 2]
                            using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion))
                            {
                                // Asignamos el ID de la cabecera recien creada
                                cmdDetalle.Parameters.AddWithValue("@FacturaId", factura.Id);
                                // Asignamos el ID del producto
                                cmdDetalle.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                // Asignamos la cantidad comprada
                                cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                // Asignamos el precio congelado
                                cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                                // Asignamos el subtotal del renglon
                                cmdDetalle.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                                // Ejecutamos la insercion de este renglon sin esperar retorno de datos
                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // Si el ciclo termina sin errores, confirmamos permanentemente todos los cambios en la base de datos[cite: 1, 2]
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si cualquier INSERT falla, deshacemos absolutamente todos los cambios (rollback completo)[cite: 1, 2]
                        transaccion.Rollback();
                        // Relanzamos la excepcion para que la capa visual (formulario) le avise al usuario[cite: 1, 2]
                        throw new Exception("Error al emitir la factura. Transacción cancelada: " + ex.Message);


                    }
                }
            }

        }


        // Método para listar facturas con filtros de fecha y cliente
        public List<Factura> ObtenerFacturas(DateTime desde, DateTime hasta, string clienteFiltro = "")
        {
            // Lista para almacenar los resultados
            List<Factura> lista = new List<Factura>();

            // Query base filtrando por rango de fechas inclusivo
            string query = "SELECT Id, Numero, Fecha, ClienteNombre, ClienteDocumento, Total FROM Facturas " +
                           "WHERE Fecha >= @Desde AND Fecha <= @Hasta ";

            // Si el usuario escribio algo en el filtro de cliente, agregamos la condicion LIKE
            if (!string.IsNullOrEmpty(clienteFiltro))
            {
                // Anexamos la condicion de busqueda por nombre de cliente
                query += "AND ClienteNombre LIKE @Cliente ";
            }

            // Ordenamos los resultados desde la factura mas reciente a la mas antigua
            query += "ORDER BY Fecha DESC";

            // Aseguramos el cierre de conexion
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Preparamos el comando
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Configuramos rango inicial (inicio del dia)
                    comando.Parameters.AddWithValue("@Desde", desde.Date);
                    // Configuramos rango final (fin del dia, 23:59:59)
                    comando.Parameters.AddWithValue("@Hasta", hasta.Date.AddDays(1).AddTicks(-1));

                    // Si hay filtro de cliente, lo parametrizamos
                    if (!string.IsNullOrEmpty(clienteFiltro))
                    {
                        // Usamos % para que busque coincidencias parciales de texto
                        comando.Parameters.AddWithValue("@Cliente", "%" + clienteFiltro + "%");
                    }

                    // Abrimos conexion
                    conexion.Open();

                    // Ejecutamos la lectura conectada[cite: 1, 2]
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        // Leemos las filas
                        while (reader.Read())
                        {
                            // Agregamos el objeto Factura a la lista
                            lista.Add(new Factura
                            {
                                Id = reader.GetInt32(0),
                                Numero = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                ClienteNombre = reader.GetString(3),
                                ClienteDocumento = reader.GetString(4),
                                Total = reader.GetDecimal(5)
                            });
                        }
                    }
                }
            }
            // Retornamos los comprobantes filtrados
            return lista;
        }

        // Método para cargar los renglones (detalle) de una factura seleccionada
        public List<FacturaDetalle> ObtenerDetalleFactura(int facturaId)
        {
            // Lista para los renglones
            List<FacturaDetalle> lista = new List<FacturaDetalle>();

            // Consulta con INNER JOIN para traer tambien el nombre del producto[cite: 1, 2]
            string query = "SELECT fd.Id, fd.FacturaId, fd.ProductoId, p.Nombre, fd.Cantidad, fd.PrecioUnitario, fd.Subtotal " +
                           "FROM FacturaDetalle fd " +
                           "INNER JOIN Productos p ON fd.ProductoId = p.Id " +
                           "WHERE fd.FacturaId = @FacturaId";

            // Uso de bloque using
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Preparamos comando
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Asignamos ID de cabecera
                    comando.Parameters.AddWithValue("@FacturaId", facturaId);
                    // Abrimos conexion
                    conexion.Open();

                    // Lectura conectada[cite: 1, 2]
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        // Ciclo de lectura
                        while (reader.Read())
                        {
                            // Mapeamos los datos de la fila a la clase FacturaDetalle
                            lista.Add(new FacturaDetalle
                            {
                                Id = reader.GetInt32(0),
                                FacturaId = reader.GetInt32(1),
                                ProductoId = reader.GetInt32(2),
                                ProductoNombre = reader.GetString(3), // Viene del JOIN con Productos
                                Cantidad = reader.GetInt32(4),
                                PrecioUnitario = reader.GetDecimal(5)
                                // Subtotal no hace falta asignarlo porque la propiedad en C# lo calcula solo
                            });
                        }
                    }
                }
            }
            // Devolvemos las lineas
            return lista;
        }

        // Método para cumplir con el punto 4.4: Informe simple de totales por producto[cite: 1, 2]
        public List<ProductoReporteDto> ObtenerReporteProductos(DateTime desde, DateTime hasta)
        {
            // Lista del DTO de reporte
            List<ProductoReporteDto> lista = new List<ProductoReporteDto>();

            // Consulta agregada (SUM, GROUP BY) para calcular volumen de ventas[cite: 1, 2]
            string query = "SELECT p.Codigo, p.Nombre, SUM(fd.Cantidad) AS CantidadTotal, SUM(fd.Subtotal) AS MontoTotal " +
                           "FROM FacturaDetalle fd " +
                           "INNER JOIN Productos p ON fd.ProductoId = p.Id " +
                           "INNER JOIN Facturas f ON fd.FacturaId = f.Id " +
                           "WHERE f.Fecha >= @Desde AND f.Fecha <= @Hasta " +
                           "GROUP BY p.Codigo, p.Nombre " +
                           "ORDER BY MontoTotal DESC";

            // Gestion de conexion
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Comando SQL
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Parametros de rango de fechas
                    comando.Parameters.AddWithValue("@Desde", desde.Date);
                    comando.Parameters.AddWithValue("@Hasta", hasta.Date.AddDays(1).AddTicks(-1));

                    // Apertura de conexion
                    conexion.Open();

                    // Lectura de los datos agrupados
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        // Recorrido de filas
                        while (reader.Read())
                        {
                            // Mapeamos directo al DTO del informe[cite: 1, 2]
                            lista.Add(new ProductoReporteDto
                            {
                                Codigo = reader.GetString(0),
                                Nombre = reader.GetString(1),
                                CantidadTotalVendida = reader.GetInt32(2),
                                MontoTotalRecaudado = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            // Devolvemos el reporte terminado
            return lista;
        }
        // DTO (Data Transfer Object) para estructurar la grilla de ventas por producto
        public class ReporteProductoDto
        {
            public string Producto { get; set; }
            public int CantidadVendida { get; set; }
            public decimal TotalRecaudado { get; set; }
        }

        // Agregar este método dentro de la clase FacturaDao:
        public List<ReporteProductoDto> ObtenerVentasPorProducto(DateTime desde, DateTime hasta)
        {
            List<ReporteProductoDto> lista = new List<ReporteProductoDto>();

            string query = @"
        SELECT 
            p.Nombre AS Producto,
            SUM(fd.Cantidad) AS CantidadVendida,
            SUM(fd.Cantidad * fd.PrecioUnitario) AS TotalRecaudado
        FROM Facturas f
        INNER JOIN FacturaDetalle fd ON f.Id = fd.FacturaId
        INNER JOIN Productos p ON fd.ProductoId = p.Id
        WHERE f.Fecha >= @Desde AND f.Fecha <= @Hasta
        GROUP BY p.Nombre
        ORDER BY TotalRecaudado DESC";

            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Desde", desde.Date);
                cmd.Parameters.AddWithValue("@Hasta", hasta.Date.AddDays(1).AddTicks(-1));

                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ReporteProductoDto
                        {
                            Producto = reader["Producto"].ToString(),
                            CantidadVendida = Convert.ToInt32(reader["CantidadVendida"]),
                            TotalRecaudado = Convert.ToDecimal(reader["TotalRecaudado"])
                        });
                    }
                }
            }

            return lista;

        }
    }
}
    
