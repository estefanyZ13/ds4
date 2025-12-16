using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3
{
    public partial class Default : Page
    {
        private ArticuloDAL articuloDAL;

        public Default()
        {
            articuloDAL = new ArticuloDAL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
                ActualizarEstadisticas();
            }
        }

        private void CargarArticulos()
        {
            {
                try
                {
                    gvArticulos.DataSource = articuloDAL.ObtenerTodos();
                    gvArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    MostrarMensaje("Error al cargar artículos: " + ex.Message, false);
                }
            }
        }

        private void ActualizarEstadisticas()
        {
            try
            {
                lblTotalArticulos.Text = articuloDAL.ObtenerTotal().ToString();
            }
            catch (Exception)
            {
                lblTotalArticulos.Text = "0";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            try
            {
                Articulo articulo = new Articulo();
                articulo.Id = Convert.ToInt32(hfArticuloId.Value);
                articulo.Titulo = txtTitulo.Text.Trim();
                articulo.Autor = txtAutor.Text.Trim();
                articulo.AnioPublicacion = Convert.ToInt32(txtAnio.Text.Trim());
                articulo.RevistaCientifica = txtRevista.Text.Trim();
                articulo.DOI = txtDOI.Text.Trim();
                articulo.Resumen = txtResumen.Text.Trim();
                articulo.PalabrasClave = txtPalabrasClave.Text.Trim();
                articulo.UbicacionFisica = txtUbicacion.Text.Trim();

                bool resultado;
                string mensaje;

                if (articulo.Id == 0)
                {
                    resultado = articuloDAL.Insertar(articulo);
                    mensaje = resultado ? "Artículo registrado exitosamente" : "Error al registrar el artículo";
                }
                else
                {
                    resultado = articuloDAL.Actualizar(articulo);
                    mensaje = resultado ? "Artículo actualizado exitosamente" : "Error al actualizar el artículo";
                }

                MostrarMensaje(mensaje, resultado);

                if (resultado)
                {
                    LimpiarFormulario();
                    CargarArticulos();
                    ActualizarEstadisticas();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, false);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void gvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                CargarArticuloParaEditar(id);
            }
            else if (e.CommandName == "Eliminar")
            {
                EliminarArticulo(id);
            }
        }

        private void CargarArticuloParaEditar(int id)
        {
            try
            {
                Articulo articulo = articuloDAL.ObtenerPorId(id);

                if (articulo != null)
                {
                    hfArticuloId.Value = articulo.Id.ToString();
                    txtTitulo.Text = articulo.Titulo;
                    txtAutor.Text = articulo.Autor;
                    txtAnio.Text = articulo.AnioPublicacion.ToString();
                    txtRevista.Text = articulo.RevistaCientifica;
                    txtDOI.Text = articulo.DOI;
                    txtResumen.Text = articulo.Resumen;
                    txtPalabrasClave.Text = articulo.PalabrasClave;
                    txtUbicacion.Text = articulo.UbicacionFisica;

                    btnGuardar.Text = "💾 Actualizar Artículo";
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar artículo: " + ex.Message, false);
            }
        }

        private void EliminarArticulo(int id)
        {
            try
            {
                bool resultado = articuloDAL.Eliminar(id);
                string mensaje = resultado ? "Artículo eliminado exitosamente" : "Error al eliminar el artículo";

                MostrarMensaje(mensaje, resultado);

                if (resultado)
                {
                    CargarArticulos();
                    ActualizarEstadisticas();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar: " + ex.Message, false);
            }
        }

        private void LimpiarFormulario()
        {
            hfArticuloId.Value = "0";
            txtTitulo.Text = string.Empty;
            txtAutor.Text = string.Empty;
            txtAnio.Text = string.Empty;
            txtRevista.Text = string.Empty;
            txtDOI.Text = string.Empty;
            txtResumen.Text = string.Empty;
            txtPalabrasClave.Text = string.Empty;
            txtUbicacion.Text = string.Empty;
            btnGuardar.Text = "💾 Guardar Artículo";
            lblMensaje.Visible = false;
        }

        private void MostrarMensaje(string mensaje, bool esExito)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = esExito ? "alert alert-success" : "alert alert-danger";
            lblMensaje.Visible = true;
        }
    }
}