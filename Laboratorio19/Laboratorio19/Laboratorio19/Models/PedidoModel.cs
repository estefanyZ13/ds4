using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio19.Models
{
    public class PedidoModel
    {
        public int MenuID { get; set; }
        public string NombreCliente { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
