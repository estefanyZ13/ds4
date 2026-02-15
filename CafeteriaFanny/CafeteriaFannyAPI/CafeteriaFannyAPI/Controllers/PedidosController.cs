using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using CafeteriaFannyAPI.Models;

namespace CafeteriaFannyAPI.Controllers
{
    public class PedidosController : ApiController
    {
        // Cadena de conexión
        private string conexion = ConfigurationManager.ConnectionStrings["CafeteriaFanny"].ConnectionString;

        // GET: api/Pedidos/Productos
        // Obtener lista de productos
        [HttpGet]
        [Route("api/Pedidos/Productos")]
        public IHttpActionResult GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = "SELECT ProductoID, Nombre, Precio FROM Productos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Bucle while - leer productos
                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        ProductoID = (int)reader["ProductoID"],
                        Nombre = reader["Nombre"].ToString(),
                        Precio = (decimal)reader["Precio"]
                    });
                }
            }

            return Ok(productos);
        }

        // POST: api/Pedidos
        // Crear nuevo pedido
        [HttpPost]
        [Route("api/Pedidos")]
        public IHttpActionResult CrearPedido([FromBody] Pedido pedido)
        {
            // Validación con if (estructura de control)
            if (pedido == null || string.IsNullOrEmpty(pedido.NombreCliente))
            {
                return BadRequest("Datos inválidos");
            }

            int pedidoID = 0;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = @"INSERT INTO Pedidos (NombreCliente, ProductoID, Cantidad, Total, FechaPedido) 
                               VALUES (@NombreCliente, @ProductoID, @Cantidad, @Total, GETDATE());
                               SELECT CAST(SCOPE_IDENTITY() AS INT)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                cmd.Parameters.AddWithValue("@ProductoID", pedido.ProductoID);
                cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);

                pedidoID = (int)cmd.ExecuteScalar();
            }

            return Ok(new { pedidoID = pedidoID, mensaje = "Pedido creado" });
        }

        // GET: api/Pedidos/5
        // Consultar pedido por ID
        [HttpGet]
        [Route("api/Pedidos/{id}")]
        public IHttpActionResult GetPedido(int id)
        {
            Pedido pedido = null;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = @"SELECT p.PedidoID, p.NombreCliente, p.Cantidad, p.Total, 
                                       p.FechaPedido, pr.Nombre AS NombreProducto
                               FROM Pedidos p
                               INNER JOIN Productos pr ON p.ProductoID = pr.ProductoID
                               WHERE p.PedidoID = @PedidoID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PedidoID", id);
                SqlDataReader reader = cmd.ExecuteReader();

                // Condición if - verificar si existe
                if (reader.Read())
                {
                    pedido = new Pedido
                    {
                        PedidoID = (int)reader["PedidoID"],
                        NombreCliente = reader["NombreCliente"].ToString(),
                        NombreProducto = reader["NombreProducto"].ToString(),
                        Cantidad = (int)reader["Cantidad"],
                        Total = (decimal)reader["Total"],
                        FechaPedido = (DateTime)reader["FechaPedido"]
                    };
                }
            }

            // Condición if - retornar resultado
            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }
    }
}
