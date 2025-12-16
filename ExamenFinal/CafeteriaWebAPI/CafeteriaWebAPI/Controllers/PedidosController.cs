using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CafeteriaWebAPI.Models;

namespace CafeteriaWebAPI.Controllers
{
    /// <summary>
    /// Controlador Web API para gestionar pedidos
    /// </summary>
    [RoutePrefix("api/Pedidos")]
    public class PedidosController : ApiController
    {
        // Obtener la cadena de conexión del Web.config
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ConexionCafeteria"].ConnectionString;

        /// <summary>
        /// POST: api/Pedidos
        /// Crear un nuevo pedido (ADO.NET)
        /// </summary>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CrearPedido([FromBody] Pedido pedido)
        {
            try
            {
                // Validación del pedido (Estructura de control - if)
                if (pedido == null)
                {
                    return BadRequest("El pedido no puede ser nulo");
                }

                if (!pedido.EsValido())
                {
                    return BadRequest("El pedido no es válido. Verifica los datos.");
                }

                // Calcular el total antes de guardar
                pedido.CalcularTotal();

                // Usar ADO.NET para guardar en la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Iniciar una transacción (para integridad de datos)
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Insertar el pedido principal
                        string queryPedido = @"
                            INSERT INTO Pedidos (NombreCliente, FechaPedido, Estado, Total)
                            VALUES (@NombreCliente, @FechaPedido, @Estado, @Total);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int pedidoID;
                        using (SqlCommand cmd = new SqlCommand(queryPedido, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                            cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                            cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                            cmd.Parameters.AddWithValue("@Total", pedido.Total);

                            pedidoID = (int)cmd.ExecuteScalar();
                        }

                        // 2. Insertar los detalles del pedido (Bucle foreach)
                        string queryDetalle = @"
                            INSERT INTO DetallePedido (PedidoID, ProductoID, Cantidad, PrecioUnitario, Subtotal)
                            VALUES (@PedidoID, @ProductoID, @Cantidad, @PrecioUnitario, @Subtotal)";

                        foreach (var detalle in pedido.Detalles)
                        {
                            using (SqlCommand cmd = new SqlCommand(queryDetalle, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@PedidoID", pedidoID);
                                cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                                cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                cmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                                cmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Confirmar la transacción
                        transaction.Commit();

                        // Retornar el ID del pedido creado
                        return Ok(new
                        {
                            success = true,
                            pedidoID = pedidoID,
                            mensaje = "Pedido creado exitosamente"
                        });
                    }
                    catch (Exception ex)
                    {
                        // Revertir la transacción en caso de error
                        transaction.Rollback();
                        return InternalServerError(new Exception("Error al guardar el pedido: " + ex.Message));
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error en el servidor: " + ex.Message));
            }
        }

        /// <summary>
        /// GET: api/Pedidos/{id}
        /// Consultar el estado de un pedido por ID (ADO.NET)
        /// </summary>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult ObtenerPedido(int id)
        {
            try
            {
                // Validación (Estructura de control)
                if (id <= 0)
                {
                    return BadRequest("El ID del pedido debe ser mayor a 0");
                }

                Pedido pedido = null;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Consultar el pedido principal
                    string queryPedido = @"
                        SELECT PedidoID, NombreCliente, FechaPedido, Estado, Total
                        FROM Pedidos
                        WHERE PedidoID = @PedidoID";

                    using (SqlCommand cmd = new SqlCommand(queryPedido, conn))
                    {
                        cmd.Parameters.AddWithValue("@PedidoID", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pedido = new Pedido
                                {
                                    PedidoID = (int)reader["PedidoID"],
                                    NombreCliente = reader["NombreCliente"].ToString(),
                                    FechaPedido = (DateTime)reader["FechaPedido"],
                                    Estado = reader["Estado"].ToString(),
                                    Total = (decimal)reader["Total"]
                                };
                            }
                        }
                    }

                    // Si no se encontró el pedido
                    if (pedido == null)
                    {
                        return NotFound();
                    }

                    // 2. Consultar los detalles del pedido (Bucle while con DataReader)
                    string queryDetalle = @"
                        SELECT d.DetalleID, d.ProductoID, p.Nombre AS NombreProducto, 
                               d.Cantidad, d.PrecioUnitario, d.Subtotal
                        FROM DetallePedido d
                        INNER JOIN Productos p ON d.ProductoID = p.ProductoID
                        WHERE d.PedidoID = @PedidoID";

                    using (SqlCommand cmd = new SqlCommand(queryDetalle, conn))
                    {
                        cmd.Parameters.AddWithValue("@PedidoID", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DetallePedido detalle = new DetallePedido
                                {
                                    DetalleID = (int)reader["DetalleID"],
                                    ProductoID = (int)reader["ProductoID"],
                                    NombreProducto = reader["NombreProducto"].ToString(),
                                    Cantidad = (int)reader["Cantidad"],
                                    PrecioUnitario = (decimal)reader["PrecioUnitario"],
                                    Subtotal = (decimal)reader["Subtotal"]
                                };

                                pedido.Detalles.Add(detalle);
                            }
                        }
                    }
                }

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al consultar el pedido: " + ex.Message));
            }
        }

        /// <summary>
        /// GET: api/Pedidos/productos
        /// Obtener lista de productos disponibles
        /// </summary>
        [HttpGet]
        [Route("productos")]
        public IHttpActionResult ObtenerProductos()
        {
            try
            {
                List<Producto> productos = new List<Producto>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT ProductoID, Nombre, Descripcion, Precio, Disponible
                        FROM Productos
                        WHERE Disponible = 1
                        ORDER BY Nombre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Bucle while para leer todos los productos
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    ProductoID = (int)reader["ProductoID"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    Precio = (decimal)reader["Precio"],
                                    Disponible = (bool)reader["Disponible"]
                                };

                                productos.Add(producto);
                            }
                        }
                    }
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al obtener productos: " + ex.Message));
            }
        }
    }
}
