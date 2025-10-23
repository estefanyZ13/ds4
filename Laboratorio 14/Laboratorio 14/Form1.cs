using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Laboratorio_14
{
    public partial class frmProductos : Form
    {
        string connectionString = @"Server=(local);Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";
        bool nuevo;
        public frmProductos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar el estado inicial de los controles
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            txtId.Enabled = false;
            txbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            // Limpiar los campos de texto
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void label_Buscar_Click(object sender, EventArgs e)
        {

        }

        private void tstId_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            // Deshabilitar botón Nuevo y habilitar Guardar y Cancelar
            tsbNuevo.Enabled = false;
            tsbGuardar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbEliminar.Enabled = false;
            // Deshabilitar búsqueda durante la creación
            txtId.Enabled = true;
            txbBuscar.Enabled = false;
            // Habilitar campos de texto para ingresar datos
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;

            txtNombre.Focus();
            nuevo = true;
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    if (nuevo) // Modo INSERT - Nuevo producto
                    {
                        cmd.CommandType = CommandType.Text;
                        // Agregar todas las columnas requeridas de la tabla Products
                        cmd.CommandText = "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                                          "VALUES (@nombre, @supplierID, @categoryID, @quantity, @precio, @stock, @unitsOrder, @reorder, @discontinued)";

                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@supplierID", DBNull.Value); // NULL si no tienes este dato
                        cmd.Parameters.AddWithValue("@categoryID", DBNull.Value); // NULL si no tienes este dato
                        cmd.Parameters.AddWithValue("@quantity", DBNull.Value); // NULL si no tienes este dato
                        cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt16(txtStock.Text));
                        cmd.Parameters.AddWithValue("@unitsOrder", 0); // Valor por defecto
                        cmd.Parameters.AddWithValue("@reorder", 0); // Valor por defecto
                        cmd.Parameters.AddWithValue("@discontinued", false); // Valor por defecto

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Registro guardado correctamente.", "Éxito",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // Modo UPDATE - Actualizar producto existente
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE Products SET ProductName = @nombre, " +
                                          "UnitPrice = @precio, UnitsInStock = @stock " +
                                          "WHERE ProductID = @id";

                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                        cmd.Parameters.AddWithValue("@stock", Convert.ToInt16(txtStock.Text));

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente.", "Éxito",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                // Restaurar estado inicial del formulario
                tsbNuevo.Enabled = true;
                tsbGuardar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbEliminar.Enabled = false;
                txtId.Enabled = false;
                tsbBuscar.Enabled = true;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                txtStock.Enabled = false;

                txtId.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
            }
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            // Restaurar el estado inicial del formulario
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;

            txtId.Enabled = false;
            txbBuscar.Enabled = true;

            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            // Limpiar todos los campos de texto
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            // Construir el mensaje de confirmación con el ID del producto
            string sql = "Delete from Products where ProductID = " + txtId.Text + ";";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    // Confirmar la eliminación antes de ejecutar
                    DialogResult resultado = MessageBox.Show(
                        "¿Está seguro de eliminar este producto?\n\nProducto: " + txtNombre.Text,
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.", "Éxito",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return; // Usuario canceló la eliminación
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar estado inicial del formulario
                tsbNuevo.Enabled = true;
                tsbGuardar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbEliminar.Enabled = false;

                txtId.Enabled = false;
                txbBuscar.Enabled = true;

                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                txtStock.Enabled = false;

                // Limpiar todos los campos
                txtId.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            // Validar que se haya ingresado un ID
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID de producto para buscar.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            string sql = "SELECT * FROM Products WHERE ProductID = " + txtId.Text;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Si se encontró el producto
                    {
                        // Cargar los datos en los campos de texto
                        txtNombre.Text = reader["ProductName"].ToString();
                        txtPrecio.Text = reader["UnitPrice"].ToString();
                        txtStock.Text = reader["UnitsInStock"].ToString();

                        // Configurar controles para permitir edición
                        tsbNuevo.Enabled = false;
                        tsbGuardar.Enabled = true;
                        tsbCancelar.Enabled = true;
                        tsbEliminar.Enabled = true;

                        txtId.Enabled = true;
                        tsbBuscar.Enabled = false;

                        txtNombre.Enabled = true;
                        txtPrecio.Enabled = true;
                        txtStock.Enabled = true;

                        txtNombre.Focus();

                        // Establecer bandera en false (modo edición)
                        nuevo = false;
                    }
                    else // No se encontró el producto
                    {
                        MessageBox.Show("Ningún registro encontrado con el ID ingresado.", "Sin resultados",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtId.Text = "";
                        txtId.Focus();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
