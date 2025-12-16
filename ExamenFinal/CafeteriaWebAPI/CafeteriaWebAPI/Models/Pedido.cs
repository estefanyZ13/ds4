using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CafeteriaWebAPI.Models
{
    /// <summary>
    /// Clase que representa un pedido completo (POO - Composición)
    /// </summary>
    public class Pedido
    {
        // Propiedades (Encapsulamiento)
        public int PedidoID { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }

        // Relación: Un pedido tiene muchos detalles (Composición)
        public List<DetallePedido> Detalles { get; set; }

        // Constructor por defecto
        public Pedido()
        {
            Detalles = new List<DetallePedido>();
            FechaPedido = DateTime.Now;
            Estado = "Pendiente";
        }

        // Constructor con parámetros
        public Pedido(string nombreCliente)
        {
            NombreCliente = nombreCliente;
            Detalles = new List<DetallePedido>();
            FechaPedido = DateTime.Now;
            Estado = "Pendiente";
        }

        // Método para agregar un detalle al pedido
        public void AgregarDetalle(DetallePedido detalle)
        {
            if (detalle != null && detalle.EsValido())
            {
                Detalles.Add(detalle);
            }
        }

        // Método para calcular el total del pedido (Bucle)
        public void CalcularTotal()
        {
            Total = 0;
            foreach (var detalle in Detalles)
            {
                Total += detalle.Subtotal;
            }
        }

        // Alternativa usando LINQ
        public void CalcularTotalLinq()
        {
            Total = Detalles.Sum(d => d.Subtotal);
        }

        // Validación del pedido (Estructuras de control)
        public bool EsValido()
        {
            // Condiciones
            if (string.IsNullOrEmpty(NombreCliente))
                return false;

            if (Detalles == null || Detalles.Count == 0)
                return false;

            // Validar cada detalle (Bucle)
            foreach (var detalle in Detalles)
            {
                if (!detalle.EsValido())
                    return false;
            }

            return true;
        }

        // Método para cambiar el estado
        public void CambiarEstado(string nuevoEstado)
        {
            // Estructura de control - switch
            switch (nuevoEstado)
            {
                case "Pendiente":
                case "En Preparación":
                case "Completado":
                case "Cancelado":
                    Estado = nuevoEstado;
                    break;
                default:
                    throw new ArgumentException("Estado no válido");
            }
        }
    }
}