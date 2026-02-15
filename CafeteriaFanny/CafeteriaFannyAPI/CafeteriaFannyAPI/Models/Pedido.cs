using System;

namespace CafeteriaFannyAPI.Models
{
    // Clase POO básica - Pedido
    public class Pedido
    {
        public int PedidoID { get; set; }
        public string NombreCliente { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}