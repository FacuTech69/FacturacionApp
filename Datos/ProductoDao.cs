using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionApp.Entidades;
using Microsoft.Data.SqlClient;

namespace FacturacionApp.Datos
{
    // Clase DAO responsable de todas las operaciones SQL sobre la tabla Productos
    public class ProductoDao
    {
        // Instancia privada de nuestra clase de conexion a la base de datos
        private readonly ConexionDb _conexionDb = new ConexionDb();

        // Método para listar todos los productos permitiendo filtrar por codigo o nombre
        public List<Producto> ObtenerTodos(string filtro = "")
        {
            // Instanciamos la lista donde guardaremos los productos recuperados de la base
            List<Producto> lista = new List<Producto>();

            // Sentencia SQL parametrizada para evitar inyeccion de código y filtrar por busqueda
            string query = "SELECT Id, Codigo, Nombre, Precio, Activo FROM Productos " +
                           "WHERE Codigo LIKE @Filtro OR Nombre LIKE @Filtro ORDER BY Nombre ASC";

            // Bloque using para asegurar que la conexion a SQL se cierre al terminar de usarla
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Creamos el comando de SQL pasándole la consulta y la conexion
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Asignamos el valor del filtro usando comodines % para busquedas parciales
                    comando.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    // Abrimos explícitamente la conexion con la base de datos
                    conexion.Open();

                    // Ejecutamos la consulta y obtenemos un cursor SqlDataReader para leer conectados
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        // Iteramos fila por fila mientras existan datos por leer
                        while (reader.Read())
                        {
                            // Mapeamos cada columna del reader hacia un objeto Producto de C#
                            Producto prod = new Producto
                            {
                                // Leemos el Id entero de la columna Id
                                Id = reader.GetInt32(0),
                                // Leemos la cadena de texto de la columna Codigo
                                Codigo = reader.GetString(1),
                                // Leemos la cadena de texto de la columna Nombre
                                Nombre = reader.GetString(2),
                                // Leemos el monto decimal de la columna Precio
                                Precio = reader.GetDecimal(3),
                                // Leemos el valor booleano (bit) de la columna Activo
                                Activo = reader.GetBoolean(4)
                            };

                            // Agregamos el producto mapeado a la lista de resultados
                            lista.Add(prod);
                        }
                    }
                }
            }

            // Retornamos la lista completa cargada en memoria
            return lista;
        }

        // Método que devuelve únicamente los productos activos para el combo de facturacion
        public List<Producto> ObtenerActivos()
        {
            // Instanciamos la lista receptora
            List<Producto> lista = new List<Producto>();

            // Sentencia SQL que recupera solo los registros con Activo = 1
            string query = "SELECT Id, Codigo, Nombre, Precio, Activo FROM Productos WHERE Activo = 1 ORDER BY Nombre ASC";

            // Apertura y gestion de recursos conectados con using
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Preparamos el comando SQL
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Abrimos la conexion a la base
                    conexion.Open();

                    // Ejecutamos la lectura conectada
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        // Leemos fila por fila
                        while (reader.Read())
                        {
                            // Agregamos el producto activo a la lista
                            lista.Add(new Producto
                            {
                                Id = reader.GetInt32(0),
                                Codigo = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                Activo = reader.GetBoolean(4)
                            });
                        }
                    }
                }
            }

            // Devolvemos la lista de productos filtrados
            return lista;
        }

        // Método para insertar un nuevo producto en la base de datos
        public void Insertar(Producto producto)
        {
            // Consulta de insercion parametrizada
            string query = "INSERT INTO Productos (Codigo, Nombre, Precio, Activo) VALUES (@Codigo, @Nombre, @Precio, @Activo)";

            // Gestion segura de conexion
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Configuramos el comando de insercion
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Agregamos el parámetro @Codigo sanitizado
                    comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                    // Agregamos el parámetro @Nombre sanitizado
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    // Agregamos el parámetro @Precio sanitizado
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    // Agregamos el parámetro @Activo sanitizado
                    comando.Parameters.AddWithValue("@Activo", producto.Activo);

                    // Abrimos la conexion
                    conexion.Open();

                    // Ejecutamos la instruccion de insercion que no retorna filas
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar los datos de un producto existente
        public void Actualizar(Producto producto)
        {
            // Consulta SQL de modificacion de datos por Id
            string query = "UPDATE Productos SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, Activo = @Activo WHERE Id = @Id";

            // Gestion con bloques using
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Preparamos el comando
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Seteamos los valores de los parámetros con los datos del objeto
                    comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Activo", producto.Activo);
                    comando.Parameters.AddWithValue("@Id", producto.Id);

                    // Abrimos la conexion
                    conexion.Open();

                    // Ejecutamos la actualizacion en SQL Server
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Método para verificar si un producto ya fue utilizado en alguna factura de venta
        public bool EstaReferenciadoEnFacturas(int productoId)
        {
            // Consulta de conteo para saber si existen renglones de detalle con este producto
            string query = "SELECT COUNT(1) FROM FacturaDetalle WHERE ProductoId = @ProductoId";

            // Bloque using para garantizar el cierre
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Preparamos el comando
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Asignamos el id a verificar
                    comando.Parameters.AddWithValue("@ProductoId", productoId);

                    // Abrimos la conexion
                    conexion.Open();

                    // ExecuteScalar ejecuta la consulta y devuelve el primer valor de la primera fila (el COUNT)
                    int cantidad = (int)comando.ExecuteScalar();

                    // Retorna true si la cantidad es mayor a 0 (está referenciado)
                    return cantidad > 0;
                }
            }
        }

        // Método para eliminar fisicamente o dar de baja logica a un producto segun las reglas del TP
        public void EliminarOFisicaOLogica(int productoId)
        {
            // Verificamos primero si el producto tiene historial de ventas
            bool referenciado = EstaReferenciadoEnFacturas(productoId);

            // Cadena donde guardaremos la consulta SQL correspondiente
            string query;

            // Si está referenciado aplicamos baja lógica, si no, aplicamos borrado físico
            if (referenciado)
            {
                // Baja lógica: no lo borramos de la tabla, solo cambiamos Activo a 0
                query = "UPDATE Productos SET Activo = 0 WHERE Id = @Id";
            }
            else
            {
                // Baja física: eliminamos el registro definitivamente de la base de datos
                query = "DELETE FROM Productos WHERE Id = @Id";
            }

            // Ejecutamos la consulta correspondiente
            using (SqlConnection conexion = _conexionDb.ObtenerConexion())
            {
                // Configuramos el comando SQL
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Asignamos el ID
                    comando.Parameters.AddWithValue("@Id", productoId);

                    // Abrimos la conexion
                    conexion.Open();

                    // Ejecutamos la eliminacion o baja logica
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
