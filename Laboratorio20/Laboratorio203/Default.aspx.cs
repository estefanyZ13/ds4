using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Laboratorio203
{
    public partial class Laboratorio203 : System.Web.UI.Page
    {
        // Cadena de conexión desde Web.config
        string connectionString = ConfigurationManager.ConnectionStrings["ProductosDB"].ConnectionString;
        bool nuevo = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Al cargar la página por primera vez
                EstadoInicial();
            }
        }

        // Configura el estado inicial del formulario
        private void EstadoInicial()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtBuscarId.Text = "";

            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;

            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;

            lblMensaje.Text = "";
            lblMensaje.CssClass = "message";

            nuevo = false;
        }

        // Botón NUEVO - Habilita los campos para ingresar un nuevo registro
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
            btnBuscar.Enabled = false;

            lblMensaje.Text = "📝 Modo: Nuevo registro";
            lblMensaje.CssClass = "message message-info";

            txtNombre.Focus();
        }

        // Botón GUARDAR - Inserta o actualiza un registro
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MostrarMensaje("⚠️ El nombre es obligatorio", "error");
                    return;
                }

                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
                {
                    MostrarMensaje("⚠️ Ingrese un precio válido", "error");
                    return;
                }

                float stock;
                if (!float.TryParse(txtStock.Text, out stock) || stock < 0)
                {
                    MostrarMensaje("⚠️ Ingrese un stock válido", "error");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (nuevo)
                    {
                        // INSERTAR nuevo registro
                        string query = "INSERT INTO Laptops (nombre, precio, stock) VALUES (@nombre, @precio, @stock)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@stock", stock);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MostrarMensaje("✅ Registro guardado exitosamente", "success");
                                EstadoInicial();
                            }
                        }
                    }
                    else
                    {
                        // ACTUALIZAR registro existente
                        if (string.IsNullOrEmpty(txtId.Text))
                        {
                            MostrarMensaje("⚠️ Debe buscar un registro antes de actualizar", "error");
                            return;
                        }

                        string query = "UPDATE Laptops SET nombre=@nombre, precio=@precio, stock=@stock WHERE id=@id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@stock", stock);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MostrarMensaje("✅ Registro actualizado exitosamente", "success");
                                EstadoInicial();
                            }
                            else
                            {
                                MostrarMensaje("⚠️ No se pudo actualizar el registro", "error");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("❌ Error: " + ex.Message, "error");
            }
        }

        // Botón CANCELAR - Vuelve al estado inicial
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            MostrarMensaje("ℹ️ Operación cancelada", "info");
        }

        // Botón ELIMINAR - Elimina el registro actual
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MostrarMensaje("⚠️ Debe buscar un registro antes de eliminar", "error");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Laptops WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MostrarMensaje("✅ Registro eliminado exitosamente", "success");
                            EstadoInicial();
                        }
                        else
                        {
                            MostrarMensaje("⚠️ No se encontró el registro", "error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("❌ Error al eliminar: " + ex.Message, "error");
            }
        }

        // Botón BUSCAR - Busca un registro por ID
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscarId.Text))
                {
                    MostrarMensaje("⚠️ Ingrese un ID para buscar", "error");
                    return;
                }

                int id;
                if (!int.TryParse(txtBuscarId.Text, out id))
                {
                    MostrarMensaje("⚠️ El ID debe ser un número válido", "error");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, nombre, precio, stock FROM Laptops WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Se encontró el registro
                                txtId.Text = reader["id"].ToString();
                                txtNombre.Text = reader["nombre"].ToString();
                                txtPrecio.Text = reader["precio"].ToString();
                                txtStock.Text = reader["stock"].ToString();

                                // Habilitar edición
                                txtNombre.Enabled = true;
                                txtPrecio.Enabled = true;
                                txtStock.Enabled = true;

                                btnGuardar.Enabled = true;
                                btnCancelar.Enabled = true;
                                btnEliminar.Enabled = true;
                                btnNuevo.Enabled = false;
                                btnBuscar.Enabled = false;

                                nuevo = false;

                                MostrarMensaje("✅ Registro encontrado - Puede editar o eliminar", "success");
                            }
                            else
                            {
                                MostrarMensaje("❌ No se encontró ningún registro con ID: " + id, "error");
                                EstadoInicial();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("❌ Error al buscar: " + ex.Message, "error");
            }
        }

        // Botón SALIR - Redirige a la página principal
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        // Método auxiliar para mostrar mensajes
        private void MostrarMensaje(string mensaje, string tipo)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "message message-" + tipo;
            lblMensaje.Visible = true;
        }
    }
}