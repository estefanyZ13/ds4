using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeteriaWebAPI.Models
{
    /// <summary>
    /// Clase que representa un producto de la cafetería (POO)
    /// </summary>
    /// 
    [Serializable]

    public class Producto
    {
        // Propiedades (Encapsulamiento)
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }

        // Constructor por defecto
        public Producto()
        {
            Disponible = true;
        }

        // Constructor con parámetros
        public Producto(int productoID, string nombre, string descripcion, decimal precio, bool disponible)
        {
            ProductoID = productoID;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Disponible = disponible;
        }

        // Método para obtener información del producto
        public string ObtenerInformacion()
        {
            return $"{Nombre} - ${Precio:F2}";
        }

        // Método para validar el producto
        public bool EsValido()
        {
            return !string.IsNullOrEmpty(Nombre) && Precio > 0;
        }
    }
}