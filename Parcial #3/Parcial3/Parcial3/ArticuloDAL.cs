using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Parcial3
{
    public class ArticuloDAL
    {
        private string connectionString;

        public ArticuloDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Articulo> ObtenerTodos()
        {
            List<Articulo> articulos = new List<Articulo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                    ArticuloID, 
                    Titulo, 
                    COALESCE(Resumen, '') AS Resumen,
                    YEAR(FechaPublicacion) AS AnioPublicacion, 
                    COALESCE(DOI, '') AS DOI,
                    COALESCE(PalabrasClave, '') AS PalabrasClave,
                    FechaRegistro
                FROM EZ_Articulos 
                ORDER BY FechaRegistro DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = Convert.ToInt32(reader["ArticuloID"]);
                    art.Titulo = reader["Titulo"].ToString();
                    art.Autor = ""; // Se llenará desde otra tabla
                    art.AnioPublicacion = reader["AnioPublicacion"] != DBNull.Value ? Convert.ToInt32(reader["AnioPublicacion"]) : DateTime.Now.Year;
                    art.RevistaCientifica = ""; // Se llenará desde otra tabla
                    art.DOI = reader["DOI"].ToString();
                    art.Resumen = reader["Resumen"].ToString();
                    art.PalabrasClave = reader["PalabrasClave"].ToString();
                    art.UbicacionFisica = ""; // No existe en EZ_Articulos
                    art.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);

                    articulos.Add(art);
                }
            }

            return articulos;
        }

        public Articulo ObtenerPorId(int id)
        {
            Articulo articulo = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                    ArticuloID, 
                    Titulo, 
                    COALESCE(Resumen, '') AS Resumen,
                    YEAR(FechaPublicacion) AS AnioPublicacion, 
                    COALESCE(DOI, '') AS DOI,
                    COALESCE(PalabrasClave, '') AS PalabrasClave,
                    FechaRegistro
                FROM EZ_Articulos 
                WHERE ArticuloID = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = Convert.ToInt32(reader["ArticuloID"]);
                    articulo.Titulo = reader["Titulo"].ToString();
                    articulo.Autor = "";
                    articulo.AnioPublicacion = reader["AnioPublicacion"] != DBNull.Value ? Convert.ToInt32(reader["AnioPublicacion"]) : DateTime.Now.Year;
                    articulo.RevistaCientifica = "";
                    articulo.DOI = reader["DOI"].ToString();
                    articulo.Resumen = reader["Resumen"].ToString();
                    articulo.PalabrasClave = reader["PalabrasClave"].ToString();
                    articulo.UbicacionFisica = "";
                    articulo.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                }
            }

            return articulo;
        }

        public bool Insertar(Articulo articulo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO EZ_Articulos 
                                (Titulo, Resumen, FechaPublicacion, DOI, PalabrasClave, TipoDocumento, Estado, FechaRegistro)
                                VALUES 
                                (@Titulo, @Resumen, @FechaPublicacion, @DOI, @PalabrasClave, 'Artículo', 'Activo', @FechaRegistro)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Titulo", articulo.Titulo ?? "");
                cmd.Parameters.AddWithValue("@Resumen", articulo.Resumen ?? "");
                cmd.Parameters.AddWithValue("@FechaPublicacion", new DateTime(articulo.AnioPublicacion, 1, 1));
                cmd.Parameters.AddWithValue("@DOI", articulo.DOI ?? "");
                cmd.Parameters.AddWithValue("@PalabrasClave", articulo.PalabrasClave ?? "");
                cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        public bool Actualizar(Articulo articulo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE EZ_Articulos SET 
                                Titulo = @Titulo,
                                Resumen = @Resumen,
                                FechaPublicacion = @FechaPublicacion,
                                DOI = @DOI,
                                PalabrasClave = @PalabrasClave
                                WHERE ArticuloID = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Titulo", articulo.Titulo ?? "");
                cmd.Parameters.AddWithValue("@Resumen", articulo.Resumen ?? "");
                cmd.Parameters.AddWithValue("@FechaPublicacion", new DateTime(articulo.AnioPublicacion, 1, 1));
                cmd.Parameters.AddWithValue("@DOI", articulo.DOI ?? "");
                cmd.Parameters.AddWithValue("@PalabrasClave", articulo.PalabrasClave ?? "");
                cmd.Parameters.AddWithValue("@Id", articulo.Id);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM EZ_Articulos WHERE ArticuloID = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }

        public int ObtenerTotal()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM EZ_Articulos";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}