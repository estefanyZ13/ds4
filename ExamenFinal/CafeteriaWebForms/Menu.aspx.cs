using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace CafeteriaWebForms
{
    [Serializable]

    public partial class Menu : System.Web.UI.Page
    {
        // Clase interna para representar un producto en el carrito
        public class ProductoCarrito
        {
            public int ProductoID { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal { get; set; }
        }

        // Lista de productos en el carrito (ViewState para mantener entre postbacks)
        private List<ProductoCarrito> Carrito
        {
            get
            {
                if (ViewState["Carrito"] == null)
                    ViewState["Carrito"] = new List<ProductoCarrito>();
                return (List<ProductoCarrito>)ViewState["Carrito"];
            }
            set
            {
                ViewState["Carrito"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar productos desde la base de datos
                CargarProductos();
                ActualizarCarrito();
            }
        }

        /// <summary>
        /// Método para cargar productos desde SQL Server usando ADO.NET
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                // Obtener la cadena de conexión del Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["ConexionCafeteria"].ConnectionString;

                // Crear la conexión (Estructura de control - using)
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta SQL
                    string query = @"SELECT ProductoID, Nombre, Descripcion, Precio, Disponible 
                                   FROM Productos 
                                   WHERE Disponible = 1 
                                   ORDER BY Nombre";

                    // Crear comando
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Usar SqlDataAdapter para llenar un DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Verificar si hay datos (Estructura de control - if)
                        if (dt.Rows.Count > 0)
                        {
                            GridViewProductos.DataSource = dt;
                            GridViewProductos.DataBind();
                        }
                        else
                        {
                            MostrarMensaje("No hay productos disponibles en este momento.", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar productos: " + ex.Message, false);
            }
        }

        /// <summary>
        /// Evento cuando se hace clic en "Agregar al Pedido"
        /// </summary>
        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                // Obtener los datos del producto (separados por ";")
                string[] datos = e.CommandArgument.ToString().Split(';');
                int productoID = int.Parse(datos[0]);
                string nombre = datos[1];
                decimal precio = decimal.Parse(datos[2]);

                // Buscar si el producto ya está en el carrito (Bucle foreach)
                ProductoCarrito itemExistente = null;
                foreach (var item in Carrito)
                {
                    if (item.ProductoID == productoID)
                    {
                        itemExistente = item;
                        break;
                    }
                }

                // Si existe, incrementar cantidad; si no, agregarlo (Estructura de control - if/else)
                if (itemExistente != null)
                {
                    itemExistente.Cantidad++;
                    itemExistente.Subtotal = itemExistente.Cantidad * itemExistente.Precio;
                }
                else
                {
                    ProductoCarrito nuevoItem = new ProductoCarrito
                    {
                        ProductoID = productoID,
                        Nombre = nombre,
                        Precio = precio,
                        Cantidad = 1,
                        Subtotal = precio
                    };
                    Carrito.Add(nuevoItem);
                }

                // Actualizar la vista del carrito
                ActualizarCarrito();
                MostrarMensaje($"✓ {nombre} agregado al pedido", true);
            }
        }

        /// <summary>
        /// Actualizar la visualización del carrito
        /// </summary>
        private void ActualizarCarrito()
        {
            pnlCarrito.Controls.Clear();

            // Verificar si hay productos (Estructura de control - if)
            if (Carrito.Count == 0)
            {
                lblCarritoVacio.Visible = true;
                pnlCarrito.Controls.Add(lblCarritoVacio);
                lblTotal.Text = "$0.00";
                return;
            }

            lblCarritoVacio.Visible = false;
            decimal total = 0;

            // Mostrar cada producto del carrito (Bucle foreach)
            foreach (var item in Carrito)
            {
                // Crear un panel para cada item
                Panel itemPanel = new Panel
                {
                    CssClass = "carrito-item"
                };

                // Información del producto
                Label lblInfo = new Label
                {
                    Text = $"{item.Nombre} - ${item.Precio:F2} x {item.Cantidad} = ${item.Subtotal:F2}"
                };
                itemPanel.Controls.Add(lblInfo);

                // Botón para eliminar
                Button btnEliminar = new Button
                {
                    Text = "Eliminar",
                    CssClass = "btn-eliminar",
                    CommandArgument = item.ProductoID.ToString()
                };
                btnEliminar.Click += BtnEliminar_Click;
                itemPanel.Controls.Add(btnEliminar);

                pnlCarrito.Controls.Add(itemPanel);

                // Calcular total (acumulador)
                total += item.Subtotal;
            }

            lblTotal.Text = $"${total:F2}";
        }

        /// <summary>
        /// Evento para eliminar un producto del carrito
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productoID = int.Parse(btn.CommandArgument);

            // Buscar y eliminar el producto (Bucle for con índice)
            for (int i = 0; i < Carrito.Count; i++)
            {
                if (Carrito[i].ProductoID == productoID)
                {
                    Carrito.RemoveAt(i);
                    break;
                }
            }

            ActualizarCarrito();
            MostrarMensaje("Producto eliminado del pedido", true);
        }

        /// <summary>
        /// Evento cuando se hace clic en "Realizar Pedido"
        /// Llama al Web API usando HttpClient
        /// </summary>
        /// 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles")]

        protected async void btnRealizarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya productos en el carrito (Estructura de control)
                if (Carrito.Count == 0)
                {
                    MostrarMensaje("Debes agregar al menos un producto al pedido", false);
                    return;
                }

                // Validar nombre del cliente
                if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
                {
                    MostrarMensaje("Por favor ingresa tu nombre", false);
                    return;
                }

                // Crear el objeto del pedido (POO)
                var pedido = new
                {
                    NombreCliente = txtNombreCliente.Text.Trim(),
                    FechaPedido = DateTime.Now,
                    Estado = "Pendiente",
                    Detalles = Carrito.Select(item => new
                    {
                        item.ProductoID,        // Simplificado ✓
                        item.Cantidad,          // Simplificado ✓
                        PrecioUnitario = item.Precio,
                        item.Subtotal          // ✓ Simplificado también
                    }).ToList()
                };
                // Serializar el pedido a JSON
                string jsonPedido = JsonConvert.SerializeObject(pedido);

                // Obtener la URL del API desde Web.config
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

                // Llamar al Web API usando HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Configurar el contenido de la petición
                    StringContent content = new StringContent(jsonPedido, Encoding.UTF8, "application/json");

                    // Hacer la petición POST al API
                    HttpResponseMessage response = await client.PostAsync(apiUrl + "Pedidos", content);

                    // Verificar si fue exitoso (Estructura de control)
                    if (response.IsSuccessStatusCode)
                    {
                        string resultado = await response.Content.ReadAsStringAsync();
                        var respuesta = JsonConvert.DeserializeObject<Dictionary<string, object>>(resultado);

                        MostrarMensaje($"¡Pedido #{respuesta["pedidoID"]} creado exitosamente! " +
                                       $"Puedes consultar su estado con este ID.", true);

                        Carrito.Clear();
                        txtNombreCliente.Text = "";
                        ActualizarCarrito();

                    }
                    else
                    {
                        MostrarMensaje("Error al crear el pedido. Código: " + response.StatusCode, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al realizar el pedido: " + ex.Message, false);
            }
        }

        /// <summary>
        /// Método para mostrar mensajes al usuario
        /// </summary>
        private void MostrarMensaje(string mensaje, bool esExito)
        {
            lblMensaje.Text = mensaje;
            pnlMensaje.Visible = true;

            // Aplicar clase CSS según el tipo de mensaje (Estructura de control)
            if (esExito)
            {
                divMensaje.Attributes["class"] = "mensaje exito";
            }
            else
            {
                divMensaje.Attributes["class"] = "mensaje error";
            }
        }
    }
}