using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http;
using Laboratorio19.Models.WS;
using Laboratorio19.Models;

namespace Laboratorio19.Controllers
{
    public class AccessController : ApiController
    {

        [HttpGet]
        public Reply HelloworldId()
        {
            return new Reply
            {
                result = 1,
                message = "API Activa - Cafeteria Dulce Aroma",
                data = null
            };
        }

        // ==========================
        // MENU
        // ==========================

        [HttpGet]
        public Reply GetMenu()
        {
            Reply r = new Reply();
            r.result = 1;
            r.data = new List<object>();

            string conn = ConfigurationManager
                .ConnectionStrings["CafeteriaDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT MenuID, Nombre, Precio, Categoria FROM Menu", con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    r.data.Add(new
                    {
                        MenuID = dr["MenuID"],
                        Nombre = dr["Nombre"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        Categoria = dr["Categoria"].ToString()
                    });
                }
            }

            return r;
        }

        // ==========================
        // PEDIDOS
        // ==========================
        [HttpGet]
        public Reply GetPedidos()
        {
            Reply r = new Reply();
            List<object> lista = new List<object>();

            string conn = ConfigurationManager
                .ConnectionStrings["CafeteriaDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"
        SELECT P.PedidoID, M.Nombre, P.NombreCliente, 
               P.Cantidad, P.Total, P.FechaPedido
        FROM Pedidos P
        INNER JOIN Menu M ON P.MenuID = M.MenuID", con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new
                    {
                        PedidoID = dr["PedidoID"],
                        Producto = dr["Nombre"],
                        Cliente = dr["NombreCliente"],
                        Cantidad = dr["Cantidad"],
                        Total = dr["Total"],
                        Fecha = dr["FechaPedido"]
                    });
                }
            }

            r.result = 1;
            r.data = lista;
            return r;
        }

        [HttpPost]
        public Reply AddPedido(PedidoModel pedido)
        {
            Reply r = new Reply();

            try
            {
                string conn = ConfigurationManager
                    .ConnectionStrings["CafeteriaDB"].ConnectionString;

                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Pedidos (MenuID, NombreCliente, Cantidad, Total)
                VALUES (@MenuID, @NombreCliente, @Cantidad, @Total)
            ", con);

                    cmd.Parameters.AddWithValue("@MenuID", pedido.MenuID);
                    cmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                    cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                    cmd.Parameters.AddWithValue("@Total", pedido.Total);

                    cmd.ExecuteNonQuery();
                }

                r.result = 1;
                r.message = "Pedido guardado";
            }
            catch (Exception ex)
            {
                r.result = 0;
                r.message = ex.Message;
            }

            return r;
        }


    }
}

 




       