using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace CafeteriaWebForms
{
    public partial class Consultar : System.Web.UI.Page
    {
        // Clases internas para deserializar el JSON del API
        public class PedidoConsulta
        {
            public int PedidoID { get; set; }
            public string NombreCliente { get; set; }
            public DateTime FechaPedido { get; set; }
            public string Estado { get; set; }
            public decimal Total { get; set; }
            public List<DetallePedidoConsulta> Detalles { get; set; }
        }

        public class DetallePedidoConsulta
        {
            public int DetalleID { get; set; }
            public int ProductoID { get; set; }
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicialización de la página
        }

        /// <summary>
        /// Evento cuando se hace clic en "Consultar Pedido"
        /// Llama al Web API GET usando HttpClient
        /// </summary>
        protected async void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Ocultar paneles anteriores
                pnlResultado.Visible = false;
                pnlError.Visible = false;

                // Validar el ID del pedido (Estructura de control - if)
                int pedidoID;
                if (!int.TryParse(txtPedidoID.Text, out pedidoID) || pedidoID <= 0)
                {
                    MostrarError("Por favor ingresa un ID de pedido válido");
                    return;
                }

                // Obtener la URL del API desde Web.config
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

                // Llamar al Web API usando HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la petición GET al API
                    string url = $"{apiUrl}Pedidos/{pedidoID}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verificar si fue exitoso (Estructura de control - if/else)
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer y deserializar la respuesta JSON
                        string jsonRespuesta = await response.Content.ReadAsStringAsync();
                        PedidoConsulta pedido = JsonConvert.DeserializeObject<PedidoConsulta>(jsonRespuesta);

                        // Mostrar la información del pedido
                        MostrarPedido(pedido);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MostrarError($"No se encontró el pedido con ID: {pedidoID}");
                    }
                    else
                    {
                        MostrarError($"Error al consultar el pedido. Código: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al consultar el pedido: " + ex.Message);
            }
        }

        /// <summary>
        /// Método para mostrar la información del pedido
        /// </summary>
        private void MostrarPedido(PedidoConsulta pedido)
        {
            // Mostrar el panel de resultados
            pnlResultado.Visible = true;

            // Llenar la información básica del pedido
            lblPedidoID.Text = pedido.PedidoID.ToString();
            lblNombreCliente.Text = pedido.NombreCliente;
            lblFecha.Text = pedido.FechaPedido.ToString("dd/MM/yyyy HH:mm");

            // Configurar el estado con color (Estructura de control - switch)
            lblEstado.Text = pedido.Estado;
            switch (pedido.Estado)
            {
                case "Pendiente":
                    lblEstado.CssClass = "estado estado-pendiente";
                    break;
                case "En Preparación":
                    lblEstado.CssClass = "estado estado-preparacion";
                    break;
                case "Completado":
                    lblEstado.CssClass = "estado estado-completado";
                    break;
                case "Cancelado":
                    lblEstado.CssClass = "estado estado-cancelado";
                    break;
                default:
                    lblEstado.CssClass = "estado";
                    break;
            }

            // Llenar el GridView con los detalles
            GridViewDetalles.DataSource = pedido.Detalles;
            GridViewDetalles.DataBind();

            // Agregar el total en el footer
            if (GridViewDetalles.FooterRow != null)
            {
                GridViewDetalles.FooterRow.Cells[0].Text = "TOTAL";
                GridViewDetalles.FooterRow.Cells[0].ColumnSpan = 3;
                GridViewDetalles.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                GridViewDetalles.FooterRow.Cells[1].Visible = false;
                GridViewDetalles.FooterRow.Cells[2].Visible = false;
                GridViewDetalles.FooterRow.Cells[3].Text = $"${pedido.Total:F2}";
                GridViewDetalles.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            }
        }

        /// <summary>
        /// Evento que se ejecuta al enlazar cada fila del GridView
        /// </summary>
        protected void GridViewDetalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Aplicar formato a las celdas (Estructura de control - if)
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Opcional: aplicar estilos adicionales a las filas
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#f5f5f5'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'");
            }
        }

        /// <summary>
        /// Método para mostrar mensajes de error
        /// </summary>
        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            pnlError.Visible = true;
            pnlResultado.Visible = false;
        }
    }
}