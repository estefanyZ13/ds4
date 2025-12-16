using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeteriaWebAPI.Models
{
    /// <summary>
    /// Clase que representa el detalle de un pedido (POO)
    /// </summary>
    public class DetallePedido
    {
        // Propiedades (Encapsulamiento)
        public int DetalleID { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; } // Para mostrar en consultas
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Constructor por defecto
        public DetallePedido()
        {
        }

        // Constructor con parámetros
        public DetallePedido(int productoID, int cantidad, decimal precioUnitario)
        {
            ProductoID = productoID;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            CalcularSubtotal();
        }

        // Método para calcular el subtotal (Lógica de negocio)
        public void CalcularSubtotal()
        {
            Subtotal = Cantidad * PrecioUnitario;
        }

        // Validación
        public bool EsValido()
        {
            return ProductoID > 0 && Cantidad > 0 && PrecioUnitario > 0;
        }
    }
}